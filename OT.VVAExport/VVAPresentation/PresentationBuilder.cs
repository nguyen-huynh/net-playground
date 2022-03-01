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

    /// <summary>
    /// Follow the OpenXml Docs
    /// <para>Refs: 
    ///     <see href="https://docs.microsoft.com/en-us/office/open-xml/working-with-presentationml-documents">Working with PresentationML documents (Open XML SDK)</see>
    /// </para>
    /// </summary>
    public partial class PresentationBuilder
    {
        private PresentationDocument _presentationDocument = null;
        private PresentationPart _presentationPart = null;

        public void Create(string? filePath = null)
        {
            PresentationDocument presentationDocument = null;
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetTempPath(), $"Presentation_{DateTime.Now.ToString("HHmmss")}.pptx");

                if (!IO.Path.IsPathFullyQualified(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetFullPath(filePath));

                RelationshipIds.Clear();
                RelationshipIdHolders.Clear();

                _presentationDocument = presentationDocument = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation);
                PresentationPart presentationPart = _presentationPart = presentationDocument.AddPresentationPart();
                presentationPart.Presentation = new Presentation();

                CreatePresentationParts(presentationPart);

                // Close the presentation handle
                presentationDocument.Close();
            }
            finally
            {
                if ((presentationDocument != null))
                {
                    presentationDocument.Dispose();
                }

                _presentationDocument = null;
                _presentationPart = null;
            }
        }

        //private void CreatePresentationParts(PresentationPart presentationPart)
        //{
        //    var slideMasterId = GenerateRelationshipId<SlideMasterId>();

        //    var openingSlidePart = CreateOpeningVVASlide(presentationPart);
        //    var slideLayoutPart = CreateSlideLayoutPart(openingSlidePart, slideMasterId);
        //    var slideMasterPart = CreateSlideMasterPart(slideLayoutPart, slideMasterId);
        //    slideMasterPart.AddPart(slideLayoutPart, slideMasterId);
        //    presentationPart.AddPart(slideMasterPart, slideMasterId);

        //    var vvaSlidePart = CreateSlidePart(presentationPart);
        //    var slideLayoutPart2 = CreateSlideLayoutPart(vvaSlidePart, slideMasterId);

        //    //slideMasterPart.AddPart(slideLayoutPart2);
        //    //presentationPart.AddPart(slideMasterPart2, slideMasterId2);
        //    var themePart = CreateTheme(slideMasterPart);
        //    presentationPart.AddPart(themePart, this.LastRelationshipIdOf<Theme>());

        //    SlideSize slideSize = new SlideSize() { Cx = 7772400, Cy = 4572000 };
        //    NotesSize notesSize = new NotesSize() { Cx = 6858000, Cy = 9144000 };
        //    DefaultTextStyle defaultTextStyle = new DefaultTextStyle();

        //    presentationPart.Presentation.Append(this.GetIdList<SlideMasterId>(), this.GetIdList<SlideId>(), slideSize, notesSize, defaultTextStyle);
        //}

        private void CreatePresentationParts(PresentationPart presentationPart)
        {
            var slideMasterId = GenerateRelationshipId<SlideMasterId>();
            var openingSlidePart = presentationPart.AddNewPart<SlidePart>(this.GenerateRelationshipId<SlideId>());
            this.GenerateOpeningSlidePart(ref openingSlidePart);

            var openingSlideLayoutPart = openingSlidePart.AddNewPart<SlideLayoutPart>(slideMasterId);
            this.GenerateOpeningSlideLayoutPart(ref openingSlideLayoutPart);

            var slideMasterPart = openingSlideLayoutPart.AddNewPart<SlideMasterPart>(slideMasterId);
            this.GenerateSlideMasterPart(ref slideMasterPart);

            slideMasterPart.AddPart(openingSlideLayoutPart, slideMasterId);
            presentationPart.AddPart(slideMasterPart, slideMasterId);

            // Slide 2
            var vvaSlide = presentationPart.AddNewPart<SlidePart>(this.GenerateRelationshipId<SlideId>());
            this.GenerateVVASlidePart(ref vvaSlide);

            vvaSlide.AddPart<SlideLayoutPart>(openingSlideLayoutPart, slideMasterId);

            var themePart = CreateTheme(slideMasterPart);
            presentationPart.AddPart(themePart, this.LastRelationshipIdOf<Theme>());

            SlideSize slideSize = new SlideSize() { Cx = 7772400, Cy = 4572000 };
            NotesSize notesSize = new NotesSize() { Cx = 6858000, Cy = 9144000 };
            DefaultTextStyle defaultTextStyle = new DefaultTextStyle();

            presentationPart.Presentation.Append(this.GetIdList<SlideMasterId>(), this.GetIdList<SlideId>(), slideSize, notesSize, defaultTextStyle);
        }

        
    }
}