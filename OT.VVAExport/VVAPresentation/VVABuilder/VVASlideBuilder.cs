namespace OT.VVAExport.VVAPresentation.VVABuilder
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.Diagnostics;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
    using Shape = DocumentFormat.OpenXml.Presentation.Shape;
    using NonVisualShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeProperties;
    using NonVisualShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeDrawingProperties;
    using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
    using TextBody = DocumentFormat.OpenXml.Presentation.TextBody;
    using GroupShape = DocumentFormat.OpenXml.Presentation.GroupShape;
    using Picture = DocumentFormat.OpenXml.Presentation.Picture;
    using System.IO;

    public abstract class VVASlideBuilder
    {
        internal readonly PresentationBuilder _presentationBuilder;
        internal readonly PresentationPart _presentationPart;
        private SlidePart _slidePart;
        public SlidePart SlidePart { get => _slidePart; private set { _slidePart = value; } }

        public ImagePart OtfImagePart { get; set; }

        public VVASlideBuilder(PresentationBuilder presentationBuilder,
            PresentationPart presentationPart)
        {
            _presentationBuilder = presentationBuilder;
            _presentationPart = presentationPart;
            _slidePart = _presentationPart.AddNewPart<SlidePart>(_presentationBuilder.GenerateRelationshipId<SlideId>());
        }

        public virtual Background GetVVaBackground()
        {
            return new Background(new BackgroundProperties(
                new SolidFill(new RgbColorModelHex() { Val = "2A2835" }),
                new EffectList()));
        }

        public abstract ShapeTree GetShapeTree();

        public virtual void GenerateSlide()
        {
            if (SlidePart == null) return;

            if (SlidePart.Slide == null)
                SlidePart.Slide = new Slide();

            SlidePart.Slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            SlidePart.Slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            SlidePart.Slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData = new CommonSlideData();
            commonSlideData.Append(GetVVaBackground());

            var shapeTree = GetShapeTree();

            commonSlideData.Append(shapeTree);
            SlidePart.Slide.Append(commonSlideData);
            SlidePart.Slide.Append(new ColorMapOverride(new MasterColorMapping()));
        }

        public virtual GroupShape GenerateTopWhiteRectangle(ref ShapeTree shapeTree)
        {
            GroupShape groupShape = new GroupShape();
            groupShape.AppendDefaultNonVisualGroupShapeProperties(id: _presentationBuilder.NewId, name: "BlockInfo");
            groupShape.AppendDefaultGroupShapeProperties(width: VVAConstants.SLIDE_WIDTH, height: VVAConstants.TOP_WHITE_REC_HEIGHT);

            var whiteShape = new Shape();
            whiteShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "TopWhiteRec");
            whiteShape.AppendDefaultShapeProperties(width: VVAConstants.SLIDE_WIDTH, height: VVAConstants.TOP_WHITE_REC_HEIGHT, backgroundColor: "FFFFFF");
            whiteShape.AppendDefaultShapeStyle();
            whiteShape.AppendDefaultTextBody(" ");
            groupShape.Append(whiteShape);

            var blockNameShape = GetBlockName();
            if (blockNameShape != null)
                groupShape.Append(blockNameShape);

            var blockDurationShape = GetBlockDuration();
            if (blockDurationShape != null)
                groupShape.Append(blockDurationShape);

            if (OtfImagePart != null)
            {
                var otfLogoPicture = new Picture();
                otfLogoPicture.AppendNonVisualPictureProperties(id: _presentationBuilder.NewId, name: "OTFLogo", uri: $@"{{{Guid.NewGuid()}}}");
                otfLogoPicture.AppendBlipFill(imageRId: SlidePart.GetIdOfPart(OtfImagePart), isStrechShape: true);
                otfLogoPicture.AppendShapeProperties(posX: VVAConstants.OTF_IMAGE_LEFT,
                                                     posY: VVAConstants.OTF_IMAGE_TOP,
                                                     width: VVAConstants.OTF_IMAGE_WIDTH,
                                                     height: VVAConstants.OTF_IMAGE_HEIGHT);
                groupShape.Append(otfLogoPicture);
            }

            return groupShape;
        }

        public virtual Shape GetBlockName() => null;
        public virtual Shape GetBlockDuration() => null;

        public virtual ImagePart SetOtfImagePart(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            OtfImagePart = this.SlidePart.AddImagePart(ImagePartType.Png);
            OtfImagePart.FeedData(stream);
            return OtfImagePart;
        }

        public virtual ImagePart SetOtfImagePart(string filePath = "./otf-logo.png")
        {
            using (Stream stream = new MemoryStream(File.ReadAllBytes(System.IO.Path.GetFullPath(filePath))))
            {
                return this.SetOtfImagePart(stream);
            }
        }
    }
}