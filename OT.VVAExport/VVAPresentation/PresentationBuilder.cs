namespace OT.VVAExport.VVAPresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using IO = System.IO;
    using System.IO;
    using OT.VVAExport.VVAPresentation.VVABuilder;

    /// <summary>
    /// Follow the OpenXml Docs
    /// <para>Refs: 
    ///     <see href="https://docs.microsoft.com/en-us/office/open-xml/working-with-presentationml-documents">Working with PresentationML documents (Open XML SDK)</see>
    /// </para>
    /// </summary>
    public partial class PresentationBuilder
    {
        public void Create(string filePath = null)
        {
            PresentationDocument presentationDocument = null;
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetTempPath(), $"Presentation_{DateTime.Now.ToString("HHmmss")}.pptx");

                if (!IO.Path.IsPathFullyQualified(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetFullPath(filePath));

                this.CleanRelationshipId();

                presentationDocument = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation);
                PresentationPart presentationPart = presentationDocument.AddPresentationPart();
                presentationPart.Presentation = new Presentation();

                CreatePresentationParts(presentationPart, presentationDocument);

                // Close the presentation handle
                presentationDocument.Close();
            }
            finally
            {
                if ((presentationDocument != null))
                {
                    presentationDocument.Dispose();
                }
            }
        }

        private void CreatePresentationParts(PresentationPart presentationPart, PresentationDocument presentationDocument)
        {
            MediaDataPart mediaDataPart1 = presentationDocument.CreateMediaDataPart("video/mp4", "mp4");
            using (var stream = File.OpenRead("./video.mp4"))
            {
                mediaDataPart1.FeedData(stream);
            }

            //var imagePartId = this.GeneratePartRelationshipId<ImagePart>();
            var slideMasterId = GenerateRelationshipId<SlideMasterId>();

            var vvaOpeningSlideBuilder = new VVAOpeningSlideBuilder(this, presentationPart);
            vvaOpeningSlideBuilder.SetOtfImagePart();
            vvaOpeningSlideBuilder.GenerateSlide();

            var openingSlideLayoutPart = vvaOpeningSlideBuilder.SlidePart.AddNewPart<SlideLayoutPart>(slideMasterId);
            this.GenerateSlideLayoutPart(ref openingSlideLayoutPart);

            var slideMasterPart = openingSlideLayoutPart.AddNewPart<SlideMasterPart>(slideMasterId);
            this.GenerateSlideMasterPart(ref slideMasterPart);

            slideMasterPart.AddPart(openingSlideLayoutPart, slideMasterId);
            presentationPart.AddPart(slideMasterPart, slideMasterId);

            // Slide 2
            var vvaExerciseSlideBuilder = new VVAExerciseSlideBuilder(this, presentationPart, presentationDocument)
            {
                BlockDuration = "00:00",
                BlockName = "Block name",
                Exercises = new List<Models.VVAExercise>
                {
                    new Models.VVAExercise{ ExerciseId = 1, Name = "Exercise Name", Prescription = "300m JUST ONCE", VideoUrl=""}
                },
                ExerciseMediaDataPart = mediaDataPart1
            };
            vvaExerciseSlideBuilder.SlidePart.AddVideoReferenceRelationship(mediaDataPart1, "rId2");
            vvaExerciseSlideBuilder.SlidePart.AddMediaReferenceRelationship(mediaDataPart1, "rId1");
            //vvaExerciseSlideBuilder.SetOtfImagePart();
            vvaExerciseSlideBuilder.OtfImagePart = vvaExerciseSlideBuilder.SlidePart.AddPart<ImagePart>(vvaOpeningSlideBuilder.OtfImagePart);
            vvaExerciseSlideBuilder.GenerateSlide();
            vvaExerciseSlideBuilder.SlidePart.AddPart<SlideLayoutPart>(openingSlideLayoutPart, slideMasterId);
            slideMasterPart.AddPart(vvaExerciseSlideBuilder.SlidePart);

            var themePart = CreateTheme(slideMasterPart);
            presentationPart.AddPart(themePart, this.LastRelationshipIdOf<Theme>());

            SlideSize slideSize = new SlideSize() { Cx = VVAConstants.SLIDE_WIDTH, Cy = VVAConstants.SLIDE_HEIGHT };
            NotesSize notesSize = new NotesSize() { Cx = VVAConstants.NOTE_WIDTH, Cy = VVAConstants.NOTE_HEIGHT };
            DefaultTextStyle defaultTextStyle = new DefaultTextStyle();

            presentationPart.Presentation.Append(this.GetIdList<SlideMasterId>(), this.GetIdList<SlideId>(), slideSize, notesSize, defaultTextStyle);
        }
    }
}