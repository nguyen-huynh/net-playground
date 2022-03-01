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

    public partial class PresentationBuilder
    {
        private Background GetVVaBackground()
        {
            return new Background(new BackgroundProperties(
                new SolidFill(new RgbColorModelHex() { Val = "2A2835" }),
                new EffectList()));
        }

        private SlidePart CreateSlidePart(PresentationPart presentationPart, string slideId = null)
        {
            slideId = slideId ?? this.GenerateRelationshipId<SlideId>();
            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>(slideId);
            slidePart.Slide = new Slide(
                    new CommonSlideData(
                        GetVVaBackground(),
                        new ShapeTree(
                            new P.NonVisualGroupShapeProperties(
                                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" },
                                    new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                                new P.ShapeProperties(),
                                new P.TextBody(
                                    new BodyProperties(),
                                    new ListStyle(),
                                    new Paragraph(new EndParagraphRunProperties() { Language = "en-US" }))))),
                    new ColorMapOverride(new MasterColorMapping()));
            return slidePart;
        }
    
        private SlidePart CreateOpeningVVASlide(PresentationPart presentationPart, string slideId = null)
        {
            slideId = slideId ?? this.GenerateRelationshipId<SlideId>();
            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>(slideId);
            slidePart.Slide = new Slide(
                    new CommonSlideData(
                        GetVVaBackground(),
                        new ShapeTree(
                            new P.NonVisualGroupShapeProperties(
                                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" },
                                    new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                                new P.ShapeProperties(),
                                new P.TextBody(
                                    new BodyProperties(),
                                    new ListStyle(),
                                    new Paragraph(new EndParagraphRunProperties() { Language = "en-US" }))))),
                    new ColorMapOverride(new MasterColorMapping()));
            return slidePart;
        }

        private SlidePart InsertOpeningVVASlide (PresentationPart presentationPart, int position, string slideId = null)
        {
            var slide = new Slide(
                    new CommonSlideData(
                        GetVVaBackground(),
                        new ShapeTree(
                            new P.NonVisualGroupShapeProperties(
                                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" },
                                    new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                                new P.ShapeProperties(),
                                new P.TextBody(
                                    new BodyProperties(),
                                    new ListStyle(),
                                    new Paragraph(new Run(new D.Text() { Text = "slide TITLE" }), new EndParagraphRunProperties() { Language = "en-US" }))),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = 3U, Name = "Content Placeholder" },
                                    new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 })),
                                new P.TextBody(new BodyProperties(),new ListStyle(),new Paragraph())
                            )),
                    new ColorMapOverride(new MasterColorMapping())));

            slideId = slideId ?? this.GenerateRelationshipId<SlideId>();
            var slidePart = presentationPart.AddNewPart<SlidePart>(slideId);
            slide.Save(slidePart);
            return slidePart;
        }

        private void GenerateOpeningSlidePart(ref SlidePart openingSlidePart)
        {
            Slide slide = new Slide();

            slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slide.Append(new CommonSlideData(
                        GetVVaBackground(),
                        new ShapeTree(
                            new NonVisualGroupShapeProperties(
                                new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new Shape(
                                new NonVisualShapeProperties(
                                    new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" },
                                    new NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                                new ShapeProperties(),
                                new TextBody(
                                    new BodyProperties(),
                                    new ListStyle(),
                                    new Paragraph(new EndParagraphRunProperties() { Language = "en-US" })))),
                            GenerateTopWhiteRectangle(3U, name: "TopWhiteRectangle")
                        ),
                    new ColorMapOverride(new MasterColorMapping()));

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
                                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
                                new P.NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()),
                            new GroupShapeProperties(new TransformGroup()),
                            new P.Shape(
                                new P.NonVisualShapeProperties(
                                    new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" },
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

        private OpenXmlElement GenerateTopWhiteRectangle(UInt32Value id, string name = null)
        {
            var shape = new Shape();

            var nonVisualShapeProperties = new NonVisualShapeProperties(
                                    new NonVisualDrawingProperties() { Id = id, Name = name ?? "TopWhiteRectangle" },
                                    new NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape()));

            var shapeProperties = new P.ShapeProperties(
                new Transform2D(new Offset { X = 0, Y = 0 }, new Extents { Cx = SLIDE_WIDTH, Cy = 389088 }),
                new PresetGeometry(new AdjustValueList()) { Preset = D.ShapeTypeValues.Rectangle},
                new SolidFill(new RgbColorModelHex { Val = "FFFFFF"}),
                new Outline(new NoFill())
                );

            var shapeStyle = new P.ShapeStyle(
                    new LineReference( new SchemeColor (new Shade { Val = 50000}) { Val = SchemeColorValues.Accent1}) { Index = 2U},
                    new FillReference(new SchemeColor () { Val = SchemeColorValues.Accent1 } ) { Index = 1U }
                );

            var textBody = new P.TextBody(
                    new BodyProperties(),
                    new ListStyle(),
                    new Paragraph(new EndParagraphRunProperties() { Language = "en-US" }));

            shape.Append(nonVisualShapeProperties, shapeProperties, shapeStyle, textBody);

            return shape;
        }
    }
}