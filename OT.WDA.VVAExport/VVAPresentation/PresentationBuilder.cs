
namespace OT.WDA.VVAExport.VVAPresentation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using OT.WDA.VVAExport.Models;
    using Path = System.IO.Path;
    using OT.WDA.VVAExport.VVAPresentation.VVABuilder;

    //using OT.WDA.VVAExport.VVAPresentation.VVABuilder;

    public interface IPresentationBuilder
    {
        public PresentationDocument PresentationDocument { get; }
        public List<IVVASlideBuilder> VVASlideBuilders { get; }
        public UInt32Value NewId { get; }
        public Dictionary<int, MediaDataPart> MapExerciseIdMedia { get;}
        public Dictionary<int, double> MapExerciseVideoDuration { get; }
        public string CreatePackage(IEnumerable<VVASlide> slides, string filePath = null);
        public string GenerateRelationshipId<T>() where T : class;
        public string LastRelationshipIdOf<T>() where T : class;
    }

    /// <summary>
    /// Follow the OpenXml Docs
    /// <para>Refs:
    ///     <see href="https://docs.microsoft.com/en-us/office/open-xml/working-with-presentationml-documents">Working with PresentationML documents (Open XML SDK)</see>
    /// </para>
    /// </summary>
    public partial class PresentationBuilder : IPresentationBuilder
    {
        private PresentationDocument _presentationDocument = null;
        public PresentationDocument PresentationDocument { get => _presentationDocument; private set { _presentationDocument = value; } }
        public List<IVVASlideBuilder> VVASlideBuilders { get; private set; } = new List<IVVASlideBuilder>();
        public Dictionary<int, MediaDataPart> MapExerciseIdMedia { get; private set; } = new Dictionary<int, MediaDataPart>();
        public Dictionary<int, double> MapExerciseVideoDuration { get; private set; } = new Dictionary<int, double>();

        public string CreatePackage(IEnumerable<VVASlide> slides, string filePath = null)
        {
            try
            {
                filePath = filePath ?? Path.Combine(Path.GetTempPath(), "VVAExports", $"Presentation_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pptx");
                if (!Path.IsPathFullyQualified(filePath))
                    filePath = Path.Combine(Path.GetFullPath(filePath));

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                PresentationDocument = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation);
                PresentationDocument.AddPresentationPart();
                PresentationDocument.PresentationPart.Presentation = new Presentation();

                CreatePresentationParts(slides);

                // Close the presentation handle
                PresentationDocument.Close();
            }
            finally
            {
                if ((PresentationDocument != null))
                {
                    PresentationDocument.Dispose();
                }

                // Clear memory
                PresentationDocument = null;
                CleanRelationshipId();
                VVASlideBuilders = new List<IVVASlideBuilder>();
                MapExerciseIdMedia = new Dictionary<int, MediaDataPart>();
                MapExerciseVideoDuration = new Dictionary<int, double>();
            }
            return filePath;
        }

        private void CreatePresentationParts(IEnumerable<VVASlide> slides)
        {
            var slideMasterId = GenerateRelationshipId<SlideMasterId>();

            IVVASlideBuilder openingSlideBuilder = new VVAOpeningSlideBuilder(this, null);
            VVASlideBuilders.Add(openingSlideBuilder);
            var openingSlidePart = openingSlideBuilder.Build();

            var openingSlideLayoutPart = openingSlidePart.AddNewPart<SlideLayoutPart>(slideMasterId);
            this.GenerateSlideLayoutPart(ref openingSlideLayoutPart);

            var slideMasterPart = openingSlideLayoutPart.AddNewPart<SlideMasterPart>(slideMasterId);
            this.GenerateSlideMasterPart(ref slideMasterPart);

            slideMasterPart.AddPart(openingSlideLayoutPart, slideMasterId);
            this.PresentationDocument.PresentationPart.AddPart(slideMasterPart, slideMasterId);

            var exerciseSlideBuilder = slides.Select<VVASlide, IVVASlideBuilder>(x => new VVAExerciseSlideBuilder(this, x)).ToList();
            exerciseSlideBuilder.ForEach(builder =>
            {
                builder.Build();
                builder.SlidePart.AddPart<SlideLayoutPart>(openingSlideLayoutPart, slideMasterId);
                slideMasterPart.AddPart(builder.SlidePart);
                VVASlideBuilders.Add(builder);
            });

            var themePart = CreateTheme(slideMasterPart);
            this.PresentationDocument.PresentationPart.AddPart(themePart, this.LastRelationshipIdOf<Theme>());

            var slideMasterIds = this.PresentationDocument.PresentationPart.Parts.Where(x => x.OpenXmlPart is SlideMasterPart)
                .Select((x, idx) => new SlideMasterId { Id = (2147483648U + UInt32Value.FromUInt32((uint)idx)), RelationshipId = x.RelationshipId });
            var slideIds = this.PresentationDocument.PresentationPart.Parts.Where(x => x.OpenXmlPart is SlidePart)
                .Select((x, idx) => new SlideId { Id = (256U + UInt32Value.FromUInt32((uint)idx)), RelationshipId = x.RelationshipId });

            this.PresentationDocument.PresentationPart.Presentation.Append(new SlideMasterIdList(slideMasterIds),
                                                                           new SlideIdList(slideIds),
                                                                           new SlideSize() { Cx = VVAConstants.SLIDE_WIDTH, Cy = VVAConstants.SLIDE_HEIGHT },
                                                                            new NotesSize() { Cx = VVAConstants.NOTE_WIDTH, Cy = VVAConstants.NOTE_HEIGHT },
                                                                           new DefaultTextStyle());
        }
    }
}