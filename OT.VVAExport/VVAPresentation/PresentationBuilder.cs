namespace OT.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using A = DocumentFormat.OpenXml.Drawing;

    using System;
    using System.IO;
    using A16 = DocumentFormat.OpenXml.Office2016.Drawing;
    using AP = DocumentFormat.OpenXml.ExtendedProperties;
    using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
    using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
    using VT = DocumentFormat.OpenXml.VariantTypes;
    using IO = System.IO;

    public class PresentationBuilder
    {
        public void Create(string? filePath = null)
        {
            PresentationDocument presentationDocument = null;
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetTempPath(), $"Presentation_{DateTime.Now.ToString("HHmmss")}.pptx");

                if (!IO.Path.IsPathFullyQualified(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetFullPath(filePath));

                presentationDocument = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation);
                PresentationPart presentationPart = presentationDocument.AddPresentationPart();
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
            }
        }

        private void CreatePresentationParts(PresentationPart presentationPart)
        {
            SlideMasterIdList slideMasterIdList1 = new SlideMasterIdList(new SlideMasterId() { Id = (UInt32Value)2147483648U, RelationshipId = "rId1" });
            SlideIdList slideIdList1 = new SlideIdList(new SlideId() { Id = (UInt32Value)256U, RelationshipId = "rId2" });
            SlideSize slideSize1 = new SlideSize() { Cx = 7772400, Cy = 4572000, Type = SlideSizeValues.Custom };
            NotesSize notesSize1 = new NotesSize() { Cx = 6858000, Cy = 9144000 };
            DefaultTextStyle defaultTextStyle1 = new DefaultTextStyle();

            presentationPart.Presentation.Append(slideMasterIdList1, slideIdList1, slideSize1, notesSize1, defaultTextStyle1);

            SlidePart slidePart1;
            SlideLayoutPart slideLayoutPart1;
            SlideMasterPart slideMasterPart1;
            ThemePart themePart1;

            slidePart1 = CreateSlidePart(presentationPart);
            slideLayoutPart1 = CreateSlideLayoutPart(slidePart1);
            slideMasterPart1 = CreateSlideMasterPart(slideLayoutPart1);
            themePart1 = CreateTheme(slideMasterPart1);

            slideMasterPart1.AddPart(slideLayoutPart1, "rId1");
            presentationPart.AddPart(slideMasterPart1, "rId1");
            presentationPart.AddPart(themePart1, "rId5");
        }

        private static SlidePart CreateSlidePart(PresentationPart presentationPart)
        {
            SlidePart slidePart1 = presentationPart.AddNewPart<SlidePart>("rId2");
            Slide slide = new Slide();

            slide.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData = new CommonSlideData();

            Background background = new Background();

            BackgroundProperties backgroundProperties = new BackgroundProperties();

            A.SolidFill aSolidFill = new A.SolidFill();

            A.RgbColorModelHex aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "2A2835";

            aSolidFill.Append(aRgbColorModelHex);

            backgroundProperties.Append(aSolidFill);

            A.EffectList aEffectList = new A.EffectList();

            backgroundProperties.Append(aEffectList);

            background.Append(backgroundProperties);

            commonSlideData.Append(background);

            ShapeTree shapeTree = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties = new NonVisualGroupShapeProperties();

            NonVisualDrawingProperties nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 1u;
            nonVisualDrawingProperties.Name = "";

            nonVisualGroupShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

            nonVisualGroupShapeProperties.Append(nonVisualGroupShapeDrawingProperties);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties.Append(applicationNonVisualDrawingProperties);

            shapeTree.Append(nonVisualGroupShapeProperties);

            GroupShapeProperties groupShapeProperties = new GroupShapeProperties();

            A.TransformGroup aTransformGroup = new A.TransformGroup();

            A.Offset aOffset = new A.Offset();
            aOffset.X = 0;
            aOffset.Y = 0;

            aTransformGroup.Append(aOffset);

            A.Extents aExtents = new A.Extents();
            aExtents.Cx = 0;
            aExtents.Cy = 0;

            aTransformGroup.Append(aExtents);

            A.ChildOffset aChildOffset = new A.ChildOffset();
            aChildOffset.X = 0;
            aChildOffset.Y = 0;

            aTransformGroup.Append(aChildOffset);

            A.ChildExtents aChildExtents = new A.ChildExtents();
            aChildExtents.Cx = 0;
            aChildExtents.Cy = 0;

            aTransformGroup.Append(aChildExtents);

            groupShapeProperties.Append(aTransformGroup);

            shapeTree.Append(groupShapeProperties);

            Shape shape = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Rectangle 3";

            A.NonVisualDrawingPropertiesExtensionList aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            A.NonVisualDrawingPropertiesExtension aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            A16.CreationId a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{63C19952-6783-4C90-83E0-33389700A76E}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 0;
            aOffset.Y = 0;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 7772098;
            aExtents.Cy = 389088;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            A.PresetGeometry aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            A.AdjustValueList aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aSolidFill = new A.SolidFill();

            A.SchemeColor aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Background1;

            aSolidFill.Append(aSchemeColor);

            shapeProperties.Append(aSolidFill);

            A.Outline aOutline = new A.Outline();

            A.NoFill aNoFill = new A.NoFill();

            aOutline.Append(aNoFill);

            shapeProperties.Append(aOutline);

            shape.Append(shapeProperties);

            ShapeStyle shapeStyle = new ShapeStyle();

            A.LineReference aLineReference = new A.LineReference();
            aLineReference.Index = 2u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            A.Shade aShade = new A.Shade();
            aShade.Val = 50000;

            aSchemeColor.Append(aShade);

            aLineReference.Append(aSchemeColor);

            shapeStyle.Append(aLineReference);

            A.FillReference aFillReference = new A.FillReference();
            aFillReference.Index = 1u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            aFillReference.Append(aSchemeColor);

            shapeStyle.Append(aFillReference);

            A.EffectReference aEffectReference = new A.EffectReference();
            aEffectReference.Index = 0u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            aEffectReference.Append(aSchemeColor);

            shapeStyle.Append(aEffectReference);

            A.FontReference aFontReference = new A.FontReference();
            aFontReference.Index = A.FontCollectionIndexValues.Minor;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Light1;

            aFontReference.Append(aSchemeColor);

            shapeStyle.Append(aFontReference);

            shape.Append(shapeStyle);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Rotation = 0;
            aBodyProperties.UseParagraphSpacing = false;
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.ColumnCount = 1;
            aBodyProperties.ColumnSpacing = 0;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.FromWordArt = false;
            aBodyProperties.AnchorCenter = false;
            aBodyProperties.ForceAntiAlias = false;
            aBodyProperties.CompatibleLineSpacing = true;
            aBodyProperties.VerticalOverflow = A.TextVerticalOverflowValues.Overflow;
            aBodyProperties.HorizontalOverflow = A.TextHorizontalOverflowValues.Overflow;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Wrap = A.TextWrappingValues.Square;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            A.PresetTextWrap aPresetTextWrap = new A.PresetTextWrap();
            aPresetTextWrap.Preset = A.TextShapeValues.TextNoShape;

            aAdjustValueList = new A.AdjustValueList();

            aPresetTextWrap.Append(aAdjustValueList);

            aBodyProperties.Append(aPresetTextWrap);

            A.NoAutoFit aNoAutoFit = new A.NoAutoFit();

            aBodyProperties.Append(aNoAutoFit);

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aParagraph.Append(aParagraphProperties);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            Picture picture = new Picture();

            NonVisualPictureProperties nonVisualPictureProperties = new NonVisualPictureProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 8u;
            nonVisualDrawingProperties.Name = "Picture 8";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{BAF11E55-D15D-475E-ACCB-FC75DDC0F4D4}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualPictureProperties.Append(nonVisualDrawingProperties);

            NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties = new NonVisualPictureDrawingProperties();

            A.PictureLocks aPictureLocks = new A.PictureLocks();
            aPictureLocks.NoChangeAspect = true;

            nonVisualPictureDrawingProperties.Append(aPictureLocks);

            nonVisualPictureProperties.Append(nonVisualPictureDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualPictureProperties.Append(applicationNonVisualDrawingProperties);

            picture.Append(nonVisualPictureProperties);

            BlipFill blipFill = new BlipFill();

            A.Blip aBlip = new A.Blip();
            aBlip.Embed = "rId2";

            blipFill.Append(aBlip);

            A.Stretch aStretch = new A.Stretch();

            A.FillRectangle aFillRectangle = new A.FillRectangle();

            aStretch.Append(aFillRectangle);

            blipFill.Append(aStretch);

            picture.Append(blipFill);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3767260;
            aOffset.Y = 50259;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 228745;
            aExtents.Cy = 285750;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            picture.Append(shapeProperties);

            shapeTree.Append(picture);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 9u;
            nonVisualDrawingProperties.Name = "TextBox 8";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{36668F03-A98C-48F9-9B2E-CAAF2FF3AC6E}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();
            nonVisualShapeDrawingProperties.TextBox = true;

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 4392;
            aOffset.Y = 0;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 7760825;
            aExtents.Cy = 461665;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aNoFill = new A.NoFill();

            shapeProperties.Append(aNoFill);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Rotation = 0;
            aBodyProperties.UseParagraphSpacing = false;
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.ColumnCount = 1;
            aBodyProperties.ColumnSpacing = 0;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.FromWordArt = false;
            aBodyProperties.AnchorCenter = false;
            aBodyProperties.ForceAntiAlias = false;
            aBodyProperties.CompatibleLineSpacing = true;
            aBodyProperties.VerticalOverflow = A.TextVerticalOverflowValues.Overflow;
            aBodyProperties.HorizontalOverflow = A.TextHorizontalOverflowValues.Overflow;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Wrap = A.TextWrappingValues.Square;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            aPresetTextWrap = new A.PresetTextWrap();
            aPresetTextWrap.Preset = A.TextShapeValues.TextNoShape;

            aAdjustValueList = new A.AdjustValueList();

            aPresetTextWrap.Append(aAdjustValueList);

            aBodyProperties.Append(aPresetTextWrap);

            A.ShapeAutoFit aShapeAutoFit = new A.ShapeAutoFit();

            aBodyProperties.Append(aShapeAutoFit);

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.FontSize = 2400;
            aRunProperties.Dirty = false;

            A.EastAsianFont aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-lt";

            aRunProperties.Append(aEastAsianFont);

            A.ComplexScriptFont aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-lt";

            aRunProperties.Append(aComplexScriptFont);

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Block Name");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.FontSize = 2400;

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "Calibri";

            aEndParagraphRunProperties.Append(aComplexScriptFont);

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 10u;
            nonVisualDrawingProperties.Name = "TextBox 9";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{2B3F3B5C-4712-4F58-8B0F-22193766B863}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();
            nonVisualShapeDrawingProperties.TextBox = true;

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 7906;
            aOffset.Y = 0;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 7760825;
            aExtents.Cy = 461665;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aNoFill = new A.NoFill();

            shapeProperties.Append(aNoFill);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Rotation = 0;
            aBodyProperties.UseParagraphSpacing = false;
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.ColumnCount = 1;
            aBodyProperties.ColumnSpacing = 0;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.FromWordArt = false;
            aBodyProperties.AnchorCenter = false;
            aBodyProperties.ForceAntiAlias = false;
            aBodyProperties.CompatibleLineSpacing = true;
            aBodyProperties.VerticalOverflow = A.TextVerticalOverflowValues.Overflow;
            aBodyProperties.HorizontalOverflow = A.TextHorizontalOverflowValues.Overflow;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Wrap = A.TextWrappingValues.Square;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            aPresetTextWrap = new A.PresetTextWrap();
            aPresetTextWrap.Preset = A.TextShapeValues.TextNoShape;

            aAdjustValueList = new A.AdjustValueList();

            aPresetTextWrap.Append(aAdjustValueList);

            aBodyProperties.Append(aPresetTextWrap);

            aShapeAutoFit = new A.ShapeAutoFit();

            aBodyProperties.Append(aShapeAutoFit);

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Alignment = A.TextAlignmentTypeValues.Right;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.FontSize = 2400;
            aRunProperties.Dirty = false;

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-lt";

            aRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-lt";

            aRunProperties.Append(aComplexScriptFont);

            aRun.Append(aRunProperties);

            aText = new A.Text("00:00");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 14u;
            nonVisualDrawingProperties.Name = "Rectangle 13";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{E4849660-1ECB-4DF1-9020-621A1B593C2F}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 2959450;
            aOffset.Y = 941965;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1854678;
            aExtents.Cy = 2689824;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Background1;

            aSolidFill.Append(aSchemeColor);

            shapeProperties.Append(aSolidFill);

            aOutline = new A.Outline();

            aNoFill = new A.NoFill();

            aOutline.Append(aNoFill);

            shapeProperties.Append(aOutline);

            shape.Append(shapeProperties);

            shapeStyle = new ShapeStyle();

            aLineReference = new A.LineReference();
            aLineReference.Index = 2u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            aShade = new A.Shade();
            aShade.Val = 50000;

            aSchemeColor.Append(aShade);

            aLineReference.Append(aSchemeColor);

            shapeStyle.Append(aLineReference);

            aFillReference = new A.FillReference();
            aFillReference.Index = 1u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            aFillReference.Append(aSchemeColor);

            shapeStyle.Append(aFillReference);

            aEffectReference = new A.EffectReference();
            aEffectReference.Index = 0u;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Accent1;

            aEffectReference.Append(aSchemeColor);

            shapeStyle.Append(aEffectReference);

            aFontReference = new A.FontReference();
            aFontReference.Index = A.FontCollectionIndexValues.Minor;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Light1;

            aFontReference.Append(aSchemeColor);

            shapeStyle.Append(aFontReference);

            shape.Append(shapeStyle);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Center;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aParagraph.Append(aParagraphProperties);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 15u;
            nonVisualDrawingProperties.Name = "TextBox 14";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{DCB65578-90BF-4A72-B76C-3AA7F2B5BC47}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();
            nonVisualShapeDrawingProperties.TextBox = true;

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 2957227;
            aOffset.Y = 941175;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1857737;
            aExtents.Cy = 369332;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aNoFill = new A.NoFill();

            shapeProperties.Append(aNoFill);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Rotation = 0;
            aBodyProperties.UseParagraphSpacing = false;
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.ColumnCount = 1;
            aBodyProperties.ColumnSpacing = 0;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.FromWordArt = false;
            aBodyProperties.AnchorCenter = false;
            aBodyProperties.ForceAntiAlias = false;
            aBodyProperties.CompatibleLineSpacing = true;
            aBodyProperties.VerticalOverflow = A.TextVerticalOverflowValues.Overflow;
            aBodyProperties.HorizontalOverflow = A.TextHorizontalOverflowValues.Overflow;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Wrap = A.TextWrappingValues.Square;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            aPresetTextWrap = new A.PresetTextWrap();
            aPresetTextWrap.Preset = A.TextShapeValues.TextNoShape;

            aAdjustValueList = new A.AdjustValueList();

            aPresetTextWrap.Append(aAdjustValueList);

            aBodyProperties.Append(aPresetTextWrap);

            aShapeAutoFit = new A.ShapeAutoFit();

            aBodyProperties.Append(aShapeAutoFit);

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-lt";

            aRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-lt";

            aRunProperties.Append(aComplexScriptFont);

            aRun.Append(aRunProperties);

            aText = new A.Text("Exercise Name");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 16u;
            nonVisualDrawingProperties.Name = "TextBox 15";

            aNonVisualDrawingPropertiesExtensionList = new A.NonVisualDrawingPropertiesExtensionList();

            aNonVisualDrawingPropertiesExtension = new A.NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}";

            a16CreationId = new A16.CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = "{82570C7D-FA8B-47E2-B1F7-9F219F94AC2D}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();
            nonVisualShapeDrawingProperties.TextBox = true;

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 2955267;
            aOffset.Y = 3258778;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1857737;
            aExtents.Cy = 369332;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            aNoFill = new A.NoFill();

            shapeProperties.Append(aNoFill);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Rotation = 0;
            aBodyProperties.UseParagraphSpacing = false;
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.ColumnCount = 1;
            aBodyProperties.ColumnSpacing = 0;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.FromWordArt = false;
            aBodyProperties.AnchorCenter = false;
            aBodyProperties.ForceAntiAlias = false;
            aBodyProperties.CompatibleLineSpacing = true;
            aBodyProperties.VerticalOverflow = A.TextVerticalOverflowValues.Overflow;
            aBodyProperties.HorizontalOverflow = A.TextHorizontalOverflowValues.Overflow;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Wrap = A.TextWrappingValues.Square;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            aPresetTextWrap = new A.PresetTextWrap();
            aPresetTextWrap.Preset = A.TextShapeValues.TextNoShape;

            aAdjustValueList = new A.AdjustValueList();

            aPresetTextWrap.Append(aAdjustValueList);

            aBodyProperties.Append(aPresetTextWrap);

            aShapeAutoFit = new A.ShapeAutoFit();

            aBodyProperties.Append(aShapeAutoFit);

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Italic = true;
            aRunProperties.Dirty = false;

            aSolidFill = new A.SolidFill();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "ED7D31";

            aSolidFill.Append(aRgbColorModelHex);

            aRunProperties.Append(aSolidFill);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-lt";

            aRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-lt";

            aRunProperties.Append(aComplexScriptFont);

            aRun.Append(aRunProperties);

            aText = new A.Text("300m JUST ONCE");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Italic = true;

            aSolidFill = new A.SolidFill();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "ED7D31";

            aSolidFill.Append(aRgbColorModelHex);

            aEndParagraphRunProperties.Append(aSolidFill);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "Calibri";

            aEndParagraphRunProperties.Append(aComplexScriptFont);

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            commonSlideData.Append(shapeTree);

            CommonSlideDataExtensionList commonSlideDataExtensionList = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension = new CommonSlideDataExtension();
            commonSlideDataExtension.Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}";

            P14.CreationId p14CreationId = new P14.CreationId();

            p14CreationId.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            p14CreationId.Val = 109857222u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slide.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slide.Append(colorMapOverride);

            slidePart1.Slide = slide;
            return slidePart1;
        }

        private static SlideLayoutPart CreateSlideLayoutPart(SlidePart slidePart1)
        {
            SlideLayoutPart slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
            SlideLayout slideLayout = new SlideLayout(
            new CommonSlideData(new ShapeTree(
              new P.NonVisualGroupShapeProperties(
              new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
              new P.NonVisualGroupShapeDrawingProperties(),
              new ApplicationNonVisualDrawingProperties()),
              new GroupShapeProperties(new D.TransformGroup()),
              new P.Shape(
              new P.NonVisualShapeProperties(
                new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "" },
                new P.NonVisualShapeDrawingProperties(new D.ShapeLocks() { NoGrouping = true }),
                new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
              new P.ShapeProperties(),
              new P.TextBody(
                new D.BodyProperties(),
                new D.ListStyle(),
                new D.Paragraph(new D.EndParagraphRunProperties()))))),
            new ColorMapOverride(new D.MasterColorMapping()));
            slideLayoutPart1.SlideLayout = slideLayout;
            return slideLayoutPart1;
        }

        private static SlideMasterPart CreateSlideMasterPart(SlideLayoutPart slideLayoutPart1)
        {
            SlideMasterPart slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
            SlideMaster slideMaster = new SlideMaster(
            new CommonSlideData(new ShapeTree(
              new P.NonVisualGroupShapeProperties(
              new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
              new P.NonVisualGroupShapeDrawingProperties(),
              new ApplicationNonVisualDrawingProperties()),
              new GroupShapeProperties(new D.TransformGroup()),
              new P.Shape(
              new P.NonVisualShapeProperties(
                new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title Placeholder 1" },
                new P.NonVisualShapeDrawingProperties(new D.ShapeLocks() { NoGrouping = true }),
                new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title })),
              new P.ShapeProperties(),
              new P.TextBody(
                new D.BodyProperties(),
                new D.ListStyle(),
                new D.Paragraph())))),
            new P.ColorMap() { Background1 = D.ColorSchemeIndexValues.Light1, Text1 = D.ColorSchemeIndexValues.Dark1, Background2 = D.ColorSchemeIndexValues.Light2, Text2 = D.ColorSchemeIndexValues.Dark2, Accent1 = D.ColorSchemeIndexValues.Accent1, Accent2 = D.ColorSchemeIndexValues.Accent2, Accent3 = D.ColorSchemeIndexValues.Accent3, Accent4 = D.ColorSchemeIndexValues.Accent4, Accent5 = D.ColorSchemeIndexValues.Accent5, Accent6 = D.ColorSchemeIndexValues.Accent6, Hyperlink = D.ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = D.ColorSchemeIndexValues.FollowedHyperlink },
            new SlideLayoutIdList(new SlideLayoutId() { Id = (UInt32Value)2147483649U, RelationshipId = "rId1" }),
            new TextStyles(new TitleStyle(), new BodyStyle(), new OtherStyle()));
            slideMasterPart1.SlideMaster = slideMaster;

            return slideMasterPart1;
        }

        private static ThemePart CreateTheme(SlideMasterPart slideMasterPart1)
        {
            ThemePart themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId5");
            D.Theme theme1 = new D.Theme() { Name = "Office Theme" };

            D.ThemeElements themeElements1 = new D.ThemeElements(
            new D.ColorScheme(
              new D.Dark1Color(new D.SystemColor() { Val = D.SystemColorValues.WindowText, LastColor = "000000" }),
              new D.Light1Color(new D.SystemColor() { Val = D.SystemColorValues.Window, LastColor = "FFFFFF" }),
              new D.Dark2Color(new D.RgbColorModelHex() { Val = "1F497D" }),
              new D.Light2Color(new D.RgbColorModelHex() { Val = "EEECE1" }),
              new D.Accent1Color(new D.RgbColorModelHex() { Val = "4F81BD" }),
              new D.Accent2Color(new D.RgbColorModelHex() { Val = "C0504D" }),
              new D.Accent3Color(new D.RgbColorModelHex() { Val = "9BBB59" }),
              new D.Accent4Color(new D.RgbColorModelHex() { Val = "8064A2" }),
              new D.Accent5Color(new D.RgbColorModelHex() { Val = "4BACC6" }),
              new D.Accent6Color(new D.RgbColorModelHex() { Val = "F79646" }),
              new D.Hyperlink(new D.RgbColorModelHex() { Val = "0000FF" }),
              new D.FollowedHyperlinkColor(new D.RgbColorModelHex() { Val = "800080" }))
            { Name = "Office" },
              new D.FontScheme(
              new D.MajorFont(
              new D.LatinFont() { Typeface = "Calibri" },
              new D.EastAsianFont() { Typeface = "" },
              new D.ComplexScriptFont() { Typeface = "" }),
              new D.MinorFont(
              new D.LatinFont() { Typeface = "Calibri" },
              new D.EastAsianFont() { Typeface = "" },
              new D.ComplexScriptFont() { Typeface = "" }))
              { Name = "Office" },
              new D.FormatScheme(
              new D.FillStyleList(
              new D.SolidFill(new D.SchemeColor() { Val = D.SchemeColorValues.PhColor }),
              new D.GradientFill(
                new D.GradientStopList(
                new D.GradientStop(new D.SchemeColor(new D.Tint() { Val = 50000 },
                  new D.SaturationModulation() { Val = 300000 })
                { Val = D.SchemeColorValues.PhColor })
                { Position = 0 },
                new D.GradientStop(new D.SchemeColor(new D.Tint() { Val = 37000 },
                 new D.SaturationModulation() { Val = 300000 })
                { Val = D.SchemeColorValues.PhColor })
                { Position = 35000 },
                new D.GradientStop(new D.SchemeColor(new D.Tint() { Val = 15000 },
                 new D.SaturationModulation() { Val = 350000 })
                { Val = D.SchemeColorValues.PhColor })
                { Position = 100000 }
                ),
                new D.LinearGradientFill() { Angle = 16200000, Scaled = true }),
              new D.NoFill(),
              new D.PatternFill(),
              new D.GroupFill()),
              new D.LineStyleList(
              new D.Outline(
                new D.SolidFill(
                new D.SchemeColor(
                  new D.Shade() { Val = 95000 },
                  new D.SaturationModulation() { Val = 105000 })
                { Val = D.SchemeColorValues.PhColor }),
                new D.PresetDash() { Val = D.PresetLineDashValues.Solid })
              {
                  Width = 9525,
                  CapType = D.LineCapValues.Flat,
                  CompoundLineType = D.CompoundLineValues.Single,
                  Alignment = D.PenAlignmentValues.Center
              },
              new D.Outline(
                new D.SolidFill(
                new D.SchemeColor(
                  new D.Shade() { Val = 95000 },
                  new D.SaturationModulation() { Val = 105000 })
                { Val = D.SchemeColorValues.PhColor }),
                new D.PresetDash() { Val = D.PresetLineDashValues.Solid })
              {
                  Width = 9525,
                  CapType = D.LineCapValues.Flat,
                  CompoundLineType = D.CompoundLineValues.Single,
                  Alignment = D.PenAlignmentValues.Center
              },
              new D.Outline(
                new D.SolidFill(
                new D.SchemeColor(
                  new D.Shade() { Val = 95000 },
                  new D.SaturationModulation() { Val = 105000 })
                { Val = D.SchemeColorValues.PhColor }),
                new D.PresetDash() { Val = D.PresetLineDashValues.Solid })
              {
                  Width = 9525,
                  CapType = D.LineCapValues.Flat,
                  CompoundLineType = D.CompoundLineValues.Single,
                  Alignment = D.PenAlignmentValues.Center
              }),
              new D.EffectStyleList(
              new D.EffectStyle(
                new D.EffectList(
                new D.OuterShadow(
                  new D.RgbColorModelHex(
                  new D.Alpha() { Val = 38000 })
                  { Val = "000000" })
                { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false })),
              new D.EffectStyle(
                new D.EffectList(
                new D.OuterShadow(
                  new D.RgbColorModelHex(
                  new D.Alpha() { Val = 38000 })
                  { Val = "000000" })
                { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false })),
              new D.EffectStyle(
                new D.EffectList(
                new D.OuterShadow(
                  new D.RgbColorModelHex(
                  new D.Alpha() { Val = 38000 })
                  { Val = "000000" })
                { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false }))),
              new D.BackgroundFillStyleList(
              new D.SolidFill(new D.SchemeColor() { Val = D.SchemeColorValues.PhColor }),
              new D.GradientFill(
                new D.GradientStopList(
                new D.GradientStop(
                  new D.SchemeColor(new D.Tint() { Val = 50000 },
                    new D.SaturationModulation() { Val = 300000 })
                  { Val = D.SchemeColorValues.PhColor })
                { Position = 0 },
                new D.GradientStop(
                  new D.SchemeColor(new D.Tint() { Val = 50000 },
                    new D.SaturationModulation() { Val = 300000 })
                  { Val = D.SchemeColorValues.PhColor })
                { Position = 0 },
                new D.GradientStop(
                  new D.SchemeColor(new D.Tint() { Val = 50000 },
                    new D.SaturationModulation() { Val = 300000 })
                  { Val = D.SchemeColorValues.PhColor })
                { Position = 0 }),
                new D.LinearGradientFill() { Angle = 16200000, Scaled = true }),
              new D.GradientFill(
                new D.GradientStopList(
                new D.GradientStop(
                  new D.SchemeColor(new D.Tint() { Val = 50000 },
                    new D.SaturationModulation() { Val = 300000 })
                  { Val = D.SchemeColorValues.PhColor })
                { Position = 0 },
                new D.GradientStop(
                  new D.SchemeColor(new D.Tint() { Val = 50000 },
                    new D.SaturationModulation() { Val = 300000 })
                  { Val = D.SchemeColorValues.PhColor })
                { Position = 0 }),
                new D.LinearGradientFill() { Angle = 16200000, Scaled = true })))
              { Name = "Office" });

            theme1.Append(themeElements1);
            theme1.Append(new D.ObjectDefaults());
            theme1.Append(new D.ExtraColorSchemeList());

            themePart1.Theme = theme1;
            return themePart1;
        }
    }
}