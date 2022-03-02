﻿namespace OT.VVAExport.VVAPresentation
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
    using ShapeStyle = DocumentFormat.OpenXml.Presentation.ShapeStyle;
    using Text = DocumentFormat.OpenXml.Presentation.Text;

    public static class ShapeBuilder
    {
        public static NonVisualShapeProperties AppendDefaultNonVisualShapeProperties<T>(this T element, UInt32Value id =  null, string name = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new NonVisualShapeProperties(
                    new NonVisualDrawingProperties() { Id = id, Name = name },
                    new NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }) { TextBox= true},
                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape()));
            element.Append(result);
            return result;
        }

        public static ShapeProperties AppendDefaultShapeProperties<T>(this T element,
            int? posX = 0, int? posY = 0,
            int? width = 0, int? height = 0,
            HexBinaryValue backgroundColor = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new ShapeProperties();

            result.Append(new Transform2D(new Offset { X = posX, Y = posY }, new Extents { Cx = width, Cy = height }));
            result.Append(new PresetGeometry(new AdjustValueList()) { Preset = D.ShapeTypeValues.Rectangle });
            if(backgroundColor != null)
            {
                result.Append(new SolidFill(new RgbColorModelHex { Val = backgroundColor }));
            }
            else
            {
                result.Append(new NoFill());
            }

            result.Append(new Outline(new NoFill()));
            element.Append(result);
            return result;
        }

        public static ShapeStyle AppendDefaultShapeStyle<T>(this T element, HexBinaryValue backgroundColor = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new ShapeStyle(
                new LineReference(new SchemeColor(new Shade { Val = 50000 }) { Val = SchemeColorValues.Light1 }) { Index = 2u },
                new FillReference(new SchemeColor() { Val = SchemeColorValues.Light1 }) { Index = 1u},
                new EffectReference(new SchemeColor() { Val = SchemeColorValues.Light1 }) { Index = 0u },
                new FontReference(new SchemeColor() { Val = SchemeColorValues.Dark1 }) { Index = FontCollectionIndexValues.Minor }
                );
            element.Append(result);
            return result;
        }

        public static TextBody AppendDefaultTextBody<T>(this T element,
                                                        string text = null,
                                                        int fontSize = 2400,
                                                        TextAlignmentTypeValues textAlignment = TextAlignmentTypeValues.Left) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var paragraph = new Paragraph();

            paragraph.Append(new ParagraphProperties { Alignment = textAlignment });
            if (!string.IsNullOrEmpty(text))
            {
                paragraph.Append(new Run(
                    new RunProperties(
                        new EastAsianFont { Typeface = "+mn-lt" },
                        new ComplexScriptFont { Typeface = "+mn-lt" }
                        )
                    { Language = "en-US" , FontSize  = fontSize, },
                    new D.Text(text)
                    ));
            }
            paragraph.Append(new EndParagraphRunProperties() { Language = "en-US" });

            var result = new TextBody(
                    new BodyProperties(),
                    new ListStyle(),
                    paragraph
                    );
            element.Append(result);
            return result;
        }

        public static TextBody AppendOpeningTextBox<T>(this T element) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var paragraph1 = new Paragraph();

            paragraph1.Append(new ParagraphProperties { Alignment = TextAlignmentTypeValues.Center });
            paragraph1.Append(new Run(
                    new RunProperties(
                        new SolidFill(new SchemeColor() { Val = SchemeColorValues.Background1}),
                        new LatinFont { Typeface = "Klavika Medium Condensed" , Panose = "020B0506040000020004" , PitchFamily = 34 , CharacterSet=0}
                        ){ Language = "en-US", FontSize = 3200, },
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
            element.Append(result);
            return result;
        }
    }
}