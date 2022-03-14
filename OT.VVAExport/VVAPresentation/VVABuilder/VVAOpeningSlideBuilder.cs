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

    public class VVAOpeningSlideBuilder : VVASlideBuilder, IVVASlideBuilder
    {
        public VVAOpeningSlideBuilder(PresentationBuilder presentationBuilder, PresentationPart presentationPart) : base(presentationBuilder, presentationPart)
        {
        }

        private protected override ShapeTree GetShapeTree()
        {
            var shapeTree = new ShapeTree();
            shapeTree.Append(new NonVisualGroupShapeProperties(
                                new NonVisualDrawingProperties() { Id = _presentationBuilder.NewId, Name = "" },
                                new NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()));

            shapeTree.Append(new GroupShapeProperties(new TransformGroup()));

            var topWhiteGroupShape = this.GenerateTopWhiteRectangle(ref shapeTree);
            shapeTree.Append(topWhiteGroupShape);

            var openingShape = new Shape();
            openingShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "OpeningText");
            openingShape.AppendDefaultShapeProperties(posX: (VVAConstants.SLIDE_WIDTH - VVAConstants.PixelToOpenXmlUnit(500)) / 2,
                                                      posY: (VVAConstants.SLIDE_HEIGHT - VVAConstants.PixelToOpenXmlUnit(100)) / 2,
                                                      width: VVAConstants.PixelToOpenXmlUnit(500),
                                                      height: VVAConstants.PixelToOpenXmlUnit(100));
            openingShape.AppendDefaultShapeStyle();
            openingShape.Append(GenerateOpeningTextBody());
            shapeTree.Append(openingShape);

            return shapeTree;
        }

        public TextBody GenerateOpeningTextBody()
        {
            var paragraph1 = new Paragraph();

            paragraph1.Append(new ParagraphProperties { Alignment = TextAlignmentTypeValues.Center });
            paragraph1.Append(new Run(
                    new RunProperties(
                        new SolidFill(new SchemeColor() { Val = SchemeColorValues.Background1 }),
                        new LatinFont { Typeface = "Klavika Medium Condensed", Panose = "020B0506040000020004", PitchFamily = 34, CharacterSet = 0 }
                        )
                    { Language = "en-US", FontSize = 3200, },
                    new D.Text("OPENING SLIDE")
                    ));
            paragraph1.Append(new EndParagraphRunProperties() { Language = "en-US" });

            var paragraph2 = new Paragraph();

            paragraph2.Append(new ParagraphProperties { Alignment = TextAlignmentTypeValues.Center });
            paragraph2.Append(new Run(
                    new RunProperties(
                        new SolidFill(new SchemeColor() { Val = SchemeColorValues.Background1 }),
                        new LatinFont { Typeface = "Klavika Condensed", Panose = "020B0506040000020004", PitchFamily = 34, CharacterSet = 0 }
                        )
                    { Language = "en-US", FontSize = 2400, },
                    new D.Text("Edited by Programmer post-export")
                    ));
            paragraph2.Append(new EndParagraphRunProperties() { Language = "en-US" });

            var result = new TextBody(
                    new BodyProperties(),
                    new ListStyle(),
                    paragraph1,
                    paragraph2
                    );
            return result;
        }
    }
}