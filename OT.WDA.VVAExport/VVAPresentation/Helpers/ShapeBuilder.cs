namespace OT.WDA.VVAExport.VVAPresentation.Helpers
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Presentation;
    using System;

    using D = DocumentFormat.OpenXml.Drawing;

    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeDrawingProperties;
    using NonVisualShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeProperties;
    using Shape = DocumentFormat.OpenXml.Presentation.Shape;
    using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
    using ShapeStyle = DocumentFormat.OpenXml.Presentation.ShapeStyle;
    using TextBody = DocumentFormat.OpenXml.Presentation.TextBody;

    public static class ShapeBuilder
    {
        public enum TextBoxFit
        {
            None,
            ResizeShapeToFixText,
            ShrinkTextOnOverflow,
        }

        public enum TextVerticalAlignment
        {
            Top,
            Middle,
            Bottom,
            TopCentered,
            MiddleCentered,
            BottomCentered
        }

        public static NonVisualShapeProperties AppendDefaultNonVisualShapeProperties<T>(this T element, UInt32Value id = null, string name = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new NonVisualShapeProperties(
                    new NonVisualDrawingProperties() { Id = id, Name = name },
                    new NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }) { TextBox = true },
                    new ApplicationNonVisualDrawingProperties(new PlaceholderShape()));
            element.Append(result);
            return result;
        }

        public static ShapeProperties AppendDefaultShapeProperties<T>(this T element,
            long? posX = 0, long? posY = 0,
            long? width = 0, long? height = 0,
            HexBinaryValue backgroundColor = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new ShapeProperties();

            result.Append(new Transform2D(new Offset { X = posX, Y = posY }, new Extents { Cx = width, Cy = height }));
            result.Append(new PresetGeometry(new AdjustValueList()) { Preset = D.ShapeTypeValues.Rectangle });
            if (backgroundColor != null)
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

        public static ShapeStyle AppendDefaultShapeStyle<T>(this T element, string fontColor = null) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var fontRef = new FontReference() { Index = FontCollectionIndexValues.Minor };
            if (string.IsNullOrEmpty(fontColor))
                fontRef.Append(new SchemeColor { Val = SchemeColorValues.Dark1 });
            else
                fontRef.Append(new RgbColorModelHex { Val = fontColor });

            var result = new ShapeStyle(
                new LineReference(new SchemeColor(new Shade { Val = 50000 }) { Val = SchemeColorValues.Light1 }) { Index = 2u },
                new FillReference(new SchemeColor() { Val = SchemeColorValues.Light1 }) { Index = 1u },
                new EffectReference(new SchemeColor() { Val = SchemeColorValues.Light1 }) { Index = 0u },
                fontRef
                );
            element.Append(result);
            return result;
        }

        public static TextBody AppendDefaultTextBody<T>(this T element,
                                                        string text = null,
                                                        int fontSize = 2400,
                                                        bool italic = false,
                                                        bool bold = false,
                                                        bool ellipsis = false,
                                                        TextAlignmentTypeValues textAlignment = TextAlignmentTypeValues.Left,
                                                        TextVerticalAlignment textVerticalAlignment = TextVerticalAlignment.Middle,
                                                        string fontColor = null,
                                                        TextBoxFit textBoxFit = TextBoxFit.None) where T : Shape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var paragraph = new Paragraph();

            paragraph.Append(new ParagraphProperties { Alignment = textAlignment,  FontAlignment = TextFontAlignmentValues.Center});
            if (!string.IsNullOrEmpty(text))
            {
                //var solidFill = new SolidFill();
                //if (string.IsNullOrEmpty(fontColor))
                //    solidFill.Append(new SchemeColor { Val = SchemeColorValues.Dark1 });
                //else
                //    solidFill.Append(new RgbColorModelHex { Val = fontColor });

                paragraph.Append(new Run(
                    new RunProperties(
                        new EastAsianFont { Typeface = "+mn-lt" },
                        new ComplexScriptFont { Typeface = "+mn-lt" }
                        //solidFill,
                        //new LatinFont { Typeface = bold ? "Klavika Medium Condensed" : "Klavika Condensed" }
                        )
                    { Language = "en-US", FontSize = fontSize, Italic = italic },
                    new D.Text(text)
                    ));
            }
            paragraph.Append(new EndParagraphRunProperties() { Language = "en-US" });

            OpenXmlLeafElement textBoxFitElement = null;
            switch (textBoxFit)
            {
                case TextBoxFit.None:
                    break;

                case TextBoxFit.ResizeShapeToFixText:
                    textBoxFitElement = new ShapeAutoFit();
                    break;

                case TextBoxFit.ShrinkTextOnOverflow:
                    textBoxFitElement = new NormalAutoFit() { FontScale = 92500};
                    break;

                default:
                    break;
            }

            var result = new TextBody(
                    new BodyProperties(textBoxFitElement)
                    {
                        Rotation = 0,
                        UseParagraphSpacing = false,
                        ColumnCount = 1,
                        ColumnSpacing = 0,
                        VerticalOverflow = ellipsis ? TextVerticalOverflowValues.Ellipsis : TextVerticalOverflowValues.Overflow,
                        HorizontalOverflow = TextHorizontalOverflowValues.Overflow,
                        Vertical = TextVerticalValues.Horizontal,
                        Wrap = TextWrappingValues.Square,
                        AnchorCenter = textVerticalAlignment == TextVerticalAlignment.BottomCentered
                        || textVerticalAlignment == TextVerticalAlignment.MiddleCentered
                        || textVerticalAlignment == TextVerticalAlignment.TopCentered,
                        Anchor = (textVerticalAlignment == TextVerticalAlignment.Top || textVerticalAlignment == TextVerticalAlignment.TopCentered) ? TextAnchoringTypeValues.Top
                            : (textVerticalAlignment == TextVerticalAlignment.Middle || textVerticalAlignment == TextVerticalAlignment.MiddleCentered ? TextAnchoringTypeValues.Center
                                : TextAnchoringTypeValues.Bottom)
                    },
                    new ListStyle(),
                    paragraph
                    );
            element.Append(result);
            return result;
        }
    }
}