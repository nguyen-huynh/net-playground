namespace OT.WDA.VVAExport.VVAPresentation.VVABuilder
{
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using OT.WDA.VVAExport.Models;
    using OT.WDA.VVAExport.VVAPresentation.Helpers;
    using System;
    using System.IO;
    using GroupShape = DocumentFormat.OpenXml.Presentation.GroupShape;
    using Picture = DocumentFormat.OpenXml.Presentation.Picture;
    using Shape = DocumentFormat.OpenXml.Presentation.Shape;
    using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;

    public interface IVVASlideBuilder
    {
        public SlidePart SlidePart { get; }
        public ImagePart OtfImagePart { get; }

        /// <summary>
        /// Generate Slide Part and its contents
        /// </summary>
        /// <returns></returns>
        public SlidePart Build();

        /// <summary>
        /// Get SlidePartId
        /// </summary>
        /// <returns></returns>
        public string GetSlidePartRId();
    }

    public abstract class VVASlideBuilder : IVVASlideBuilder
    {
        private protected readonly IPresentationBuilder _presentationBuilder;
        private protected readonly VVASlide _slide;
        internal readonly PresentationPart _presentationPart;
        private SlidePart _slidePart;

        public SlidePart SlidePart
        { get => _slidePart; private set { _slidePart = value; } }

        public ImagePart OtfImagePart { get; private protected set; }

        public VVASlideBuilder(IPresentationBuilder presentationBuilder, VVASlide slide)
        {
            _presentationBuilder = presentationBuilder;
            _slide = slide;
            _presentationPart = presentationBuilder.PresentationDocument.PresentationPart;
        }

        /// <inheritdoc/>
        public virtual SlidePart Build()
        {
            SlidePart = _presentationPart.AddNewPart<SlidePart>();
            AddMultiMediaPart();
            GenerateSlide();
            return SlidePart;
        }

        /// <inheritdoc/>
        public string GetSlidePartRId()
            => _presentationPart.GetIdOfPart(SlidePart);

        #region Virtual Methods

        /// <summary>
        /// Add multiple media part in slide
        /// </summary>
        private protected virtual void AddMultiMediaPart()
        {
            OtfImagePart = AddImagePart(VVAConstants.OTF_IMAGE_PATH);
        }

        private protected virtual void GenerateSlide()
        {
            if (SlidePart == null) throw new ArgumentNullException(nameof(SlidePart));

            if (SlidePart.Slide == null)
                SlidePart.Slide = new Slide();

            SlidePart.Slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            SlidePart.Slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            SlidePart.Slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData = new CommonSlideData();
            commonSlideData.Append(GetVVaBackground());

            var shapeTree = GenerateShapeTree();

            commonSlideData.Append(shapeTree);
            SlidePart.Slide.Append(commonSlideData);
            SlidePart.Slide.Append(new ColorMapOverride(new MasterColorMapping()));
        }

        private protected virtual Background GetVVaBackground()
        {
            return new Background(new BackgroundProperties(
                new SolidFill(new RgbColorModelHex() { Val = "2A2835" }),
                new EffectList()));
        }

        private protected virtual ShapeTree GenerateShapeTree()
        {
            var shapeTree = new ShapeTree();
            shapeTree.Append(new NonVisualGroupShapeProperties(
                                new NonVisualDrawingProperties() { Id = _presentationBuilder.NewId, Name = "" },
                                new NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()));

            shapeTree.Append(new GroupShapeProperties(new TransformGroup()));

            var topWhiteGroupShape = this.GenerateTopWhiteRectangle(ref shapeTree);
            shapeTree.Append(topWhiteGroupShape);
            return shapeTree;
        }

        #endregion Virtual Methods

        #region Shape Builder

        private protected virtual GroupShape GenerateTopWhiteRectangle(ref ShapeTree shapeTree)
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

        private protected virtual Shape GetBlockDuration()
        {
            if (_slide == null || string.IsNullOrEmpty(_slide.Duration)) return null;

            var blockNameShape = new Shape();
            blockNameShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "BlockDuration");
            blockNameShape.AppendDefaultShapeProperties(posX: (VVAConstants.SLIDE_WIDTH + VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        width: (VVAConstants.SLIDE_WIDTH - VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        height: VVAConstants.TOP_WHITE_REC_HEIGHT);
            blockNameShape.AppendDefaultShapeStyle();
            blockNameShape.AppendDefaultTextBody(text: _slide.Duration, textAlignment: TextAlignmentTypeValues.Right);
            return blockNameShape;
        }

        private protected virtual Shape GetBlockName()
        {
            if (_slide == null || string.IsNullOrEmpty(_slide.Header)) return null;

            var blockNameShape = new Shape();
            blockNameShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "BlockName");
            blockNameShape.AppendDefaultShapeProperties(width: (VVAConstants.SLIDE_WIDTH - VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        height: VVAConstants.TOP_WHITE_REC_HEIGHT);
            blockNameShape.AppendDefaultShapeStyle();
            blockNameShape.AppendDefaultTextBody(text: _slide.Header);
            return blockNameShape;
        }

        #endregion Shape Builder

        #region MultiMediaPart

        private protected virtual ImagePart AddImagePart(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            var imagePart = this.SlidePart.AddImagePart(ImagePartType.Png);
            imagePart.FeedData(stream);
            return imagePart;
        }

        private protected virtual ImagePart AddImagePart(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                throw new ArgumentNullException(nameof(imagePath));

            using (Stream stream = new MemoryStream(File.ReadAllBytes(System.IO.Path.GetFullPath(imagePath))))
            {
                return AddImagePart(stream);
            }
        }

        #endregion MultiMediaPart
    }
}