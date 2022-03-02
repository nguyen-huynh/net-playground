namespace OT.VVAExport.VVAPresentation
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

    public partial class PresentationBuilder
    {
        private Background GetVVaBackground()
        {
            return new Background(new BackgroundProperties(
                new SolidFill(new RgbColorModelHex() { Val = "2A2835" }),
                new EffectList()));
        }

        private void GenerateOpeningSlidePart(ref SlidePart openingSlidePart, ImagePart otflogoImagePart)
        {
            Slide slide = new Slide();

            slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            var commonSlideData = new CommonSlideData();
            commonSlideData.Append(GetVVaBackground());

            var shapeTree = new ShapeTree();
            this.GenerateTopWhiteRectangle(ref shapeTree, openingSlidePart, otflogoImagePart);

            commonSlideData.Append(shapeTree);
            slide.Append(commonSlideData);
            slide.Append(new ColorMapOverride(new MasterColorMapping()));

            openingSlidePart.Slide = slide;
        }

        private void GenerateVVASlidePart(ref SlidePart slidePart)
        {
            Slide slide = new Slide();

            slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slide.Append(new CommonSlideData(
                        GetVVaBackground(),
                        new ShapeTree(
                            new P.NonVisualGroupShapeProperties(
                                new P.NonVisualDrawingProperties() { Id = this.NewId, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = this.NewId, Name = "Title 1" },
                                    new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                                new P.ShapeProperties(),
                                new P.TextBody(
                                    new BodyProperties(),
                                    new ListStyle(),
                                    new Paragraph(new EndParagraphRunProperties() { Language = "en-US" }))))),
                    new ColorMapOverride(new MasterColorMapping()));

            slidePart.Slide = slide;
        }

        private void GenerateTopWhiteRectangle(ref ShapeTree shapeTree, SlidePart openingSlidePart, ImagePart otflogoImagePart)
        {
            shapeTree.Append(new NonVisualGroupShapeProperties(
                                new NonVisualDrawingProperties() { Id = this.NewId, Name = "" },
                                new NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()));

            shapeTree.Append(new GroupShapeProperties(new TransformGroup()));

            GroupShape groupShape = new GroupShape();

            groupShape.AppendDefaultNonVisualGroupShapeProperties(id: this.NewId, name: "BlockInfo");
            groupShape.AppendDefaultGroupShapeProperties(width: SLIDE_WIDTH, height: 389088);

            var whiteShape = new Shape();
            whiteShape.AppendDefaultNonVisualShapeProperties(id: this.NewId, name: "TopWhiteRec");
            whiteShape.AppendDefaultShapeProperties(width: SLIDE_WIDTH, height: 389088, backgroundColor: "FFFFFF");
            whiteShape.AppendDefaultShapeStyle();
            whiteShape.AppendDefaultTextBody(" ");
            groupShape.Append(whiteShape);

            var blockNameShape = new Shape();
            blockNameShape.AppendDefaultNonVisualShapeProperties(id: this.NewId, name: "BlockName");
            blockNameShape.AppendDefaultShapeProperties(width: (SLIDE_WIDTH - 228745) / 2, height: 389088);
            blockNameShape.AppendDefaultShapeStyle();
            blockNameShape.AppendDefaultTextBody(text: "Block Name");
            groupShape.Append(blockNameShape);

            var blockDurationShape = new Shape();
            blockDurationShape.AppendDefaultNonVisualShapeProperties(id: this.NewId, name: "BlockDuration");
            blockDurationShape.AppendDefaultShapeProperties(posX: (SLIDE_WIDTH + 228745) / 2, width: (SLIDE_WIDTH - 228745) / 2, height: 389088);
            blockDurationShape.AppendDefaultShapeStyle();
            blockDurationShape.AppendDefaultTextBody(text: "00:00", textAlignment: TextAlignmentTypeValues.Right);
            groupShape.Append(blockDurationShape);

            var otfLogoPicture = new Picture();
            otfLogoPicture.AppendNonVisualPictureProperties(id: this.NewId, name: "OTFLogo", uri: $@"{{{Guid.NewGuid()}}}");
            otfLogoPicture.AppendBlipFill(imageRId: openingSlidePart.GetIdOfPart(otflogoImagePart), isStrechShape: true);
            otfLogoPicture.AppendShapeProperties(posX: (SLIDE_WIDTH - 228745) / 2, posY: 50259, width: 228745, height: 285750);
            //otfLogoPicture.AppendDefaultShapeStyle();
            groupShape.Append(otfLogoPicture);

            var openingShape = new Shape();
            openingShape.AppendDefaultNonVisualShapeProperties(id: this.NewId, name: "OpeningText");
            openingShape.AppendDefaultShapeProperties(posX: 2080706, posY: 1808947, width: 3610989, height: 954107);
            openingShape.AppendDefaultShapeStyle();
            openingShape.AppendOpeningTextBox();
            //openingShape.TextBody = ShapeBuilder.GenerateOpeningText();
            shapeTree.Append(openingShape);

            shapeTree.Append(groupShape);
        }
    }
}