namespace OpenXmlSample
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Office2013.Theme;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.IO;
    using A = DocumentFormat.OpenXml.Drawing;
    using AP = DocumentFormat.OpenXml.ExtendedProperties;
    using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
    using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
    using VT = DocumentFormat.OpenXml.VariantTypes;
    
    
    public class PresentationDocumentBuilderClass
    {
        
        public void CreatePackage(String pathToFile)
        {
            PresentationDocument pkg = null;
            try
            {
                pkg = PresentationDocument.Create(pathToFile, PresentationDocumentType.Presentation);

                this.CreateParts(ref pkg);
            }
            finally
            {
                if ((pkg != null))
                {
                    pkg.Dispose();
                }
            }
        }
        
        private void CreateParts(ref PresentationDocument pkg)
        {
            CoreFilePropertiesPart coreFilePropertiesPart = pkg.AddCoreFilePropertiesPart();
            pkg.ChangeIdOfPart(coreFilePropertiesPart, "rId3");
            this.GenerateCoreFilePropertiesPart(ref coreFilePropertiesPart);

            ThumbnailPart thumbnailPart = pkg.AddThumbnailPart("image/jpeg");
            pkg.ChangeIdOfPart(thumbnailPart, "rId2");
            this.GenerateThumbnailPart(ref thumbnailPart);

            PresentationPart presentationPart = pkg.AddPresentationPart();
            this.GeneratePresentationPart(ref presentationPart);

            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>("rId3");
            this.GenerateSlidePart(ref slidePart);

            SlideLayoutPart slideLayoutPart = slidePart.AddNewPart<SlideLayoutPart>("rId1");
            this.GenerateSlideLayoutPart(ref slideLayoutPart);

            SlideMasterPart slideMasterPart = slideLayoutPart.AddNewPart<SlideMasterPart>("rId1");
            this.GenerateSlideMasterPart(ref slideMasterPart);

            SlideLayoutPart slideLayoutPart1 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId8");
            this.GenerateSlideLayoutPart1(ref slideLayoutPart1);

            slideLayoutPart1.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart2 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId3");
            this.GenerateSlideLayoutPart2(ref slideLayoutPart2);

            slideLayoutPart2.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart3 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId7");
            this.GenerateSlideLayoutPart3(ref slideLayoutPart3);

            slideLayoutPart3.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            ThemePart themePart = slideMasterPart.AddNewPart<ThemePart>("rId12");
            this.GenerateThemePart(ref themePart);

            slideMasterPart.AddPart<SlideLayoutPart>(slideLayoutPart, "rId2");
            SlideLayoutPart slideLayoutPart4 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId1");
            this.GenerateSlideLayoutPart4(ref slideLayoutPart4);

            slideLayoutPart4.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart5 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId6");
            this.GenerateSlideLayoutPart5(ref slideLayoutPart5);

            slideLayoutPart5.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart6 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId11");
            this.GenerateSlideLayoutPart6(ref slideLayoutPart6);

            slideLayoutPart6.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart7 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId5");
            this.GenerateSlideLayoutPart7(ref slideLayoutPart7);

            slideLayoutPart7.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart8 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId10");
            this.GenerateSlideLayoutPart8(ref slideLayoutPart8);

            slideLayoutPart8.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart9 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId4");
            this.GenerateSlideLayoutPart9(ref slideLayoutPart9);

            slideLayoutPart9.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            SlideLayoutPart slideLayoutPart10 = slideMasterPart.AddNewPart<SlideLayoutPart>("rId9");
            this.GenerateSlideLayoutPart10(ref slideLayoutPart10);

            slideLayoutPart10.AddPart<SlideMasterPart>(slideMasterPart, "rId1");
            TableStylesPart tableStylesPart = presentationPart.AddNewPart<TableStylesPart>("rId7");
            this.GenerateTableStylesPart(ref tableStylesPart);

            SlidePart slidePart1 = presentationPart.AddNewPart<SlidePart>("rId2");
            this.GenerateSlidePart1(ref slidePart1);

            slidePart1.AddPart<SlideLayoutPart>(slideLayoutPart4, "rId1");

            presentationPart.AddPart<SlideMasterPart>(slideMasterPart, "rId1");


            presentationPart.AddPart<ThemePart>(themePart, "rId6");

            ViewPropertiesPart viewPropertiesPart = presentationPart.AddNewPart<ViewPropertiesPart>("rId5");
            this.GenerateViewPropertiesPart(ref viewPropertiesPart);

            PresentationPropertiesPart presentationPropertiesPart = presentationPart.AddNewPart<PresentationPropertiesPart>("rId4");
            this.GeneratePresentationPropertiesPart(ref presentationPropertiesPart);

            ExtendedFilePropertiesPart extendedFilePropertiesPart = pkg.AddExtendedFilePropertiesPart();
            pkg.ChangeIdOfPart(extendedFilePropertiesPart, "rId4");
            this.GenerateExtendedFilePropertiesPart(ref extendedFilePropertiesPart);

        }
        
        private void GenerateCoreFilePropertiesPart(ref CoreFilePropertiesPart part)
        {
            string base64 = @"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pg0KPGNwOmNvcmVQcm9wZXJ0aWVzIHhtbG5zOmNwPSJodHRwOi8vc2NoZW1hcy5vcGVueG1sZm9ybWF0cy5vcmcvcGFja2FnZS8yMDA2L21ldGFkYXRhL2NvcmUtcHJvcGVydGllcyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpkY3Rlcm1zPSJodHRwOi8vcHVybC5vcmcvZGMvdGVybXMvIiB4bWxuczpkY21pdHlwZT0iaHR0cDovL3B1cmwub3JnL2RjL2RjbWl0eXBlLyIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSI+PGRjOnRpdGxlPlBvd2VyUG9pbnQgUHJlc2VudGF0aW9uPC9kYzp0aXRsZT48ZGM6Y3JlYXRvcj5OZ3V5ZW4gSHV5bmggTmhhdDwvZGM6Y3JlYXRvcj48Y3A6bGFzdE1vZGlmaWVkQnk+Tmd1eWVuIEh1eW5oIE5oYXQ8L2NwOmxhc3RNb2RpZmllZEJ5PjxjcDpyZXZpc2lvbj4yPC9jcDpyZXZpc2lvbj48ZGN0ZXJtczpjcmVhdGVkIHhzaTp0eXBlPSJkY3Rlcm1zOlczQ0RURiI+MjAyMi0wMy0wMVQwNjoxNzoxNVo8L2RjdGVybXM6Y3JlYXRlZD48ZGN0ZXJtczptb2RpZmllZCB4c2k6dHlwZT0iZGN0ZXJtczpXM0NEVEYiPjIwMjItMDMtMDFUMTA6MTU6MjRaPC9kY3Rlcm1zOm1vZGlmaWVkPjwvY3A6Y29yZVByb3BlcnRpZXM+";

            Stream mem = new MemoryStream(Convert.FromBase64String(base64), false);
            try
            {
                part.FeedData(mem);
            }
            finally
            {
                mem.Dispose();
            }
        }
        
        private void GenerateThumbnailPart(ref ThumbnailPart part)
        {
            string base64 = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsND" +
                "hIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUF" +
                "BQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCACVAQADASIAAhEBAxEB/8QAH" +
                "wAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhM" +
                "UEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV" +
                "1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx" +
                "8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFB" +
                "gcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVY" +
                "nLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEh" +
                "YaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8" +
                "vP09fb3+Pn6/9oADAMBAAIRAxEAPwD4aooor0ACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKAP/9k=";

            Stream mem = new MemoryStream(Convert.FromBase64String(base64), false);
            try
            {
                part.FeedData(mem);
            }
            finally
            {
                mem.Dispose();
            }
        }
        
        private void GeneratePresentationPart(ref PresentationPart part)
        {
            Presentation presentation = new Presentation();

            presentation.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            presentation.SaveSubsetFonts = true;

            SlideMasterIdList slideMasterIdList = new SlideMasterIdList();

            SlideMasterId slideMasterId = new SlideMasterId();
            slideMasterId.Id = 2147483696u;
            slideMasterId.RelationshipId = "rId1";

            slideMasterIdList.Append(slideMasterId);

            presentation.Append(slideMasterIdList);

            SlideIdList slideIdList = new SlideIdList();

            SlideId slideId = new SlideId();
            slideId.Id = 256u;
            slideId.RelationshipId = "rId2";

            slideIdList.Append(slideId);

            slideId = new SlideId();
            slideId.Id = 257u;
            slideId.RelationshipId = "rId3";

            slideIdList.Append(slideId);

            presentation.Append(slideIdList);

            SlideSize slideSize = new SlideSize();
            slideSize.Cx = 7864475;
            slideSize.Cy = 4572000;

            presentation.Append(slideSize);

            NotesSize notesSize = new NotesSize();
            notesSize.Cx = 6858000;
            notesSize.Cy = 9144000;

            presentation.Append(notesSize);

            DefaultTextStyle defaultTextStyle = new DefaultTextStyle();

            A.DefaultParagraphProperties aDefaultParagraphProperties = new A.DefaultParagraphProperties();

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.Language = "en-US";

            aDefaultParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aDefaultParagraphProperties);

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.DefaultTabSize = 914400;
            aLevel1ParagraphProperties.RightToLeft = false;
            aLevel1ParagraphProperties.EastAsianLineBreak = true;
            aLevel1ParagraphProperties.LatinLineBreak = false;
            aLevel1ParagraphProperties.Height = true;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            A.SolidFill aSolidFill = new A.SolidFill();

            A.SchemeColor aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            A.LatinFont aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            A.EastAsianFont aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            A.ComplexScriptFont aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 457200;
            aLevel2ParagraphProperties.DefaultTabSize = 914400;
            aLevel2ParagraphProperties.RightToLeft = false;
            aLevel2ParagraphProperties.EastAsianLineBreak = true;
            aLevel2ParagraphProperties.LatinLineBreak = false;
            aLevel2ParagraphProperties.Height = true;
            aLevel2ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 914400;
            aLevel3ParagraphProperties.DefaultTabSize = 914400;
            aLevel3ParagraphProperties.RightToLeft = false;
            aLevel3ParagraphProperties.EastAsianLineBreak = true;
            aLevel3ParagraphProperties.LatinLineBreak = false;
            aLevel3ParagraphProperties.Height = true;
            aLevel3ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 1371600;
            aLevel4ParagraphProperties.DefaultTabSize = 914400;
            aLevel4ParagraphProperties.RightToLeft = false;
            aLevel4ParagraphProperties.EastAsianLineBreak = true;
            aLevel4ParagraphProperties.LatinLineBreak = false;
            aLevel4ParagraphProperties.Height = true;
            aLevel4ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1828800;
            aLevel5ParagraphProperties.DefaultTabSize = 914400;
            aLevel5ParagraphProperties.RightToLeft = false;
            aLevel5ParagraphProperties.EastAsianLineBreak = true;
            aLevel5ParagraphProperties.LatinLineBreak = false;
            aLevel5ParagraphProperties.Height = true;
            aLevel5ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 2286000;
            aLevel6ParagraphProperties.DefaultTabSize = 914400;
            aLevel6ParagraphProperties.RightToLeft = false;
            aLevel6ParagraphProperties.EastAsianLineBreak = true;
            aLevel6ParagraphProperties.LatinLineBreak = false;
            aLevel6ParagraphProperties.Height = true;
            aLevel6ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 2743200;
            aLevel7ParagraphProperties.DefaultTabSize = 914400;
            aLevel7ParagraphProperties.RightToLeft = false;
            aLevel7ParagraphProperties.EastAsianLineBreak = true;
            aLevel7ParagraphProperties.LatinLineBreak = false;
            aLevel7ParagraphProperties.Height = true;
            aLevel7ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 3200400;
            aLevel8ParagraphProperties.DefaultTabSize = 914400;
            aLevel8ParagraphProperties.RightToLeft = false;
            aLevel8ParagraphProperties.EastAsianLineBreak = true;
            aLevel8ParagraphProperties.LatinLineBreak = false;
            aLevel8ParagraphProperties.Height = true;
            aLevel8ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 3657600;
            aLevel9ParagraphProperties.DefaultTabSize = 914400;
            aLevel9ParagraphProperties.RightToLeft = false;
            aLevel9ParagraphProperties.EastAsianLineBreak = true;
            aLevel9ParagraphProperties.LatinLineBreak = false;
            aLevel9ParagraphProperties.Height = true;
            aLevel9ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1800;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            defaultTextStyle.Append(aLevel9ParagraphProperties);

            presentation.Append(defaultTextStyle);

            PresentationExtensionList presentationExtensionList = new PresentationExtensionList();

            PresentationExtension presentationExtension = new PresentationExtension();
            presentationExtension.Uri = "{EFAFB233-063F-42B5-8137-9DF3F51BA10A}";

            P15.SlideGuideList p15SlideGuideList = new P15.SlideGuideList();

            p15SlideGuideList.AddNamespaceDeclaration("p15", "http://schemas.microsoft.com/office/powerpoint/2012/main");

            presentationExtension.Append(p15SlideGuideList);

            presentationExtensionList.Append(presentationExtension);

            presentation.Append(presentationExtensionList);

            part.Presentation = presentation;
        }
        
        private void GenerateSlidePart(ref SlidePart part)
        {
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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Content Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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

            p14CreationId.Val = 122519737u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slide.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slide.Append(colorMapOverride);

            part.Slide = slide;
        } 
        
        private void GenerateSlideLayoutPart(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.Object;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Title and Content";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Content Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 3046891659u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideMasterPart(ref SlideMasterPart part)
        {
            SlideMaster slideMaster = new SlideMaster();

            slideMaster.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideMaster.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideMaster.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData = new CommonSlideData();

            Background background = new Background();

            BackgroundStyleReference backgroundStyleReference = new BackgroundStyleReference();
            backgroundStyleReference.Index = 1001u;

            A.SchemeColor aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Background1;

            backgroundStyleReference.Append(aSchemeColor);

            background.Append(backgroundStyleReference);

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title Placeholder 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 540683;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6783110;
            aExtents.Cy = 883709;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            A.PresetGeometry aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            A.AdjustValueList aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Center;

            A.NormalAutoFit aNormalAutoFit = new A.NormalAutoFit();

            aBodyProperties.Append(aNormalAutoFit);

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Text Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Body;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 540683;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6783110;
            aExtents.Cy = 2900892;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;

            aNormalAutoFit = new A.NormalAutoFit();

            aBodyProperties.Append(aNormalAutoFit);

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 2u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 540683;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1769507;
            aExtents.Cy = 243417;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Center;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 774;

            A.SolidFill aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            A.Tint aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 3u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 2605108;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2654260;
            aExtents.Cy = 243417;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Center;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 774;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 4u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 5554285;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1769507;
            aExtents.Cy = 243417;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            aPresetGeometry = new A.PresetGeometry();
            aPresetGeometry.Preset = A.ShapeTypeValues.Rectangle;

            aAdjustValueList = new A.AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.LeftInset = 91440;
            aBodyProperties.TopInset = 45720;
            aBodyProperties.RightInset = 91440;
            aBodyProperties.BottomInset = 45720;
            aBodyProperties.RightToLeftColumns = false;
            aBodyProperties.Vertical = A.TextVerticalValues.Horizontal;
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Center;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Right;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 774;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 4193428203u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideMaster.Append(commonSlideData);

            ColorMap colorMap = new ColorMap();
            colorMap.Background1 = A.ColorSchemeIndexValues.Light1;
            colorMap.Text1 = A.ColorSchemeIndexValues.Dark1;
            colorMap.Background2 = A.ColorSchemeIndexValues.Light2;
            colorMap.Text2 = A.ColorSchemeIndexValues.Dark2;
            colorMap.Accent1 = A.ColorSchemeIndexValues.Accent1;
            colorMap.Accent2 = A.ColorSchemeIndexValues.Accent2;
            colorMap.Accent3 = A.ColorSchemeIndexValues.Accent3;
            colorMap.Accent4 = A.ColorSchemeIndexValues.Accent4;
            colorMap.Accent5 = A.ColorSchemeIndexValues.Accent5;
            colorMap.Accent6 = A.ColorSchemeIndexValues.Accent6;
            colorMap.Hyperlink = A.ColorSchemeIndexValues.Hyperlink;
            colorMap.FollowedHyperlink = A.ColorSchemeIndexValues.FollowedHyperlink;

            slideMaster.Append(colorMap);

            SlideLayoutIdList slideLayoutIdList = new SlideLayoutIdList();

            SlideLayoutId slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483697u;
            slideLayoutId.RelationshipId = "rId1";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483698u;
            slideLayoutId.RelationshipId = "rId2";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483699u;
            slideLayoutId.RelationshipId = "rId3";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483700u;
            slideLayoutId.RelationshipId = "rId4";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483701u;
            slideLayoutId.RelationshipId = "rId5";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483702u;
            slideLayoutId.RelationshipId = "rId6";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483703u;
            slideLayoutId.RelationshipId = "rId7";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483704u;
            slideLayoutId.RelationshipId = "rId8";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483705u;
            slideLayoutId.RelationshipId = "rId9";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483706u;
            slideLayoutId.RelationshipId = "rId10";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483707u;
            slideLayoutId.RelationshipId = "rId11";

            slideLayoutIdList.Append(slideLayoutId);

            slideMaster.Append(slideLayoutIdList);

            TextStyles textStyles = new TextStyles();

            TitleStyle titleStyle = new TitleStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.DefaultTabSize = 589879;
            aLevel1ParagraphProperties.RightToLeft = false;
            aLevel1ParagraphProperties.EastAsianLineBreak = true;
            aLevel1ParagraphProperties.LatinLineBreak = false;
            aLevel1ParagraphProperties.Height = true;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            A.LineSpacing aLineSpacing = new A.LineSpacing();

            A.SpacingPercent aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel1ParagraphProperties.Append(aLineSpacing);

            A.SpaceBefore aSpaceBefore = new A.SpaceBefore();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 0;

            aSpaceBefore.Append(aSpacingPercent);

            aLevel1ParagraphProperties.Append(aSpaceBefore);

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2838;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            A.LatinFont aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mj-lt";

            aDefaultRunProperties.Append(aLatinFont);

            A.EastAsianFont aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mj-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            A.ComplexScriptFont aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mj-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            titleStyle.Append(aLevel1ParagraphProperties);

            textStyles.Append(titleStyle);

            BodyStyle bodyStyle = new BodyStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 147470;
            aLevel1ParagraphProperties.Indent = -147470;
            aLevel1ParagraphProperties.DefaultTabSize = 589879;
            aLevel1ParagraphProperties.RightToLeft = false;
            aLevel1ParagraphProperties.EastAsianLineBreak = true;
            aLevel1ParagraphProperties.LatinLineBreak = false;
            aLevel1ParagraphProperties.Height = true;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel1ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            A.SpacingPoints aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 645;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel1ParagraphProperties.Append(aSpaceBefore);

            A.BulletFont aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel1ParagraphProperties.Append(aBulletFont);

            A.CharacterBullet aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel1ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1806;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 442410;
            aLevel2ParagraphProperties.Indent = -147470;
            aLevel2ParagraphProperties.DefaultTabSize = 589879;
            aLevel2ParagraphProperties.RightToLeft = false;
            aLevel2ParagraphProperties.EastAsianLineBreak = true;
            aLevel2ParagraphProperties.LatinLineBreak = false;
            aLevel2ParagraphProperties.Height = true;
            aLevel2ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel2ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel2ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel2ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel2ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 737349;
            aLevel3ParagraphProperties.Indent = -147470;
            aLevel3ParagraphProperties.DefaultTabSize = 589879;
            aLevel3ParagraphProperties.RightToLeft = false;
            aLevel3ParagraphProperties.EastAsianLineBreak = true;
            aLevel3ParagraphProperties.LatinLineBreak = false;
            aLevel3ParagraphProperties.Height = true;
            aLevel3ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel3ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel3ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel3ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel3ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 1032289;
            aLevel4ParagraphProperties.Indent = -147470;
            aLevel4ParagraphProperties.DefaultTabSize = 589879;
            aLevel4ParagraphProperties.RightToLeft = false;
            aLevel4ParagraphProperties.EastAsianLineBreak = true;
            aLevel4ParagraphProperties.LatinLineBreak = false;
            aLevel4ParagraphProperties.Height = true;
            aLevel4ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel4ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel4ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel4ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel4ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1327229;
            aLevel5ParagraphProperties.Indent = -147470;
            aLevel5ParagraphProperties.DefaultTabSize = 589879;
            aLevel5ParagraphProperties.RightToLeft = false;
            aLevel5ParagraphProperties.EastAsianLineBreak = true;
            aLevel5ParagraphProperties.LatinLineBreak = false;
            aLevel5ParagraphProperties.Height = true;
            aLevel5ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel5ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel5ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel5ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel5ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1622168;
            aLevel6ParagraphProperties.Indent = -147470;
            aLevel6ParagraphProperties.DefaultTabSize = 589879;
            aLevel6ParagraphProperties.RightToLeft = false;
            aLevel6ParagraphProperties.EastAsianLineBreak = true;
            aLevel6ParagraphProperties.LatinLineBreak = false;
            aLevel6ParagraphProperties.Height = true;
            aLevel6ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel6ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel6ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel6ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel6ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1917108;
            aLevel7ParagraphProperties.Indent = -147470;
            aLevel7ParagraphProperties.DefaultTabSize = 589879;
            aLevel7ParagraphProperties.RightToLeft = false;
            aLevel7ParagraphProperties.EastAsianLineBreak = true;
            aLevel7ParagraphProperties.LatinLineBreak = false;
            aLevel7ParagraphProperties.Height = true;
            aLevel7ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel7ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel7ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel7ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel7ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2212048;
            aLevel8ParagraphProperties.Indent = -147470;
            aLevel8ParagraphProperties.DefaultTabSize = 589879;
            aLevel8ParagraphProperties.RightToLeft = false;
            aLevel8ParagraphProperties.EastAsianLineBreak = true;
            aLevel8ParagraphProperties.LatinLineBreak = false;
            aLevel8ParagraphProperties.Height = true;
            aLevel8ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel8ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel8ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel8ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel8ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2506988;
            aLevel9ParagraphProperties.Indent = -147470;
            aLevel9ParagraphProperties.DefaultTabSize = 589879;
            aLevel9ParagraphProperties.RightToLeft = false;
            aLevel9ParagraphProperties.EastAsianLineBreak = true;
            aLevel9ParagraphProperties.LatinLineBreak = false;
            aLevel9ParagraphProperties.Height = true;
            aLevel9ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aLineSpacing = new A.LineSpacing();

            aSpacingPercent = new A.SpacingPercent();
            aSpacingPercent.Val = 90000;

            aLineSpacing.Append(aSpacingPercent);

            aLevel9ParagraphProperties.Append(aLineSpacing);

            aSpaceBefore = new A.SpaceBefore();

            aSpacingPoints = new A.SpacingPoints();
            aSpacingPoints.Val = 323;

            aSpaceBefore.Append(aSpacingPoints);

            aLevel9ParagraphProperties.Append(aSpaceBefore);

            aBulletFont = new A.BulletFont();
            aBulletFont.Typeface = "Arial";
            aBulletFont.Panose = "020B0604020202020204";
            aBulletFont.PitchFamily = 34;
            aBulletFont.CharacterSet = 0;

            aLevel9ParagraphProperties.Append(aBulletFont);

            aCharacterBullet = new A.CharacterBullet();
            aCharacterBullet.Char = "•";

            aLevel9ParagraphProperties.Append(aCharacterBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            bodyStyle.Append(aLevel9ParagraphProperties);

            textStyles.Append(bodyStyle);

            OtherStyle otherStyle = new OtherStyle();

            A.DefaultParagraphProperties aDefaultParagraphProperties = new A.DefaultParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.Language = "en-US";

            aDefaultParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aDefaultParagraphProperties);

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.DefaultTabSize = 589879;
            aLevel1ParagraphProperties.RightToLeft = false;
            aLevel1ParagraphProperties.EastAsianLineBreak = true;
            aLevel1ParagraphProperties.LatinLineBreak = false;
            aLevel1ParagraphProperties.Height = true;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.DefaultTabSize = 589879;
            aLevel2ParagraphProperties.RightToLeft = false;
            aLevel2ParagraphProperties.EastAsianLineBreak = true;
            aLevel2ParagraphProperties.LatinLineBreak = false;
            aLevel2ParagraphProperties.Height = true;
            aLevel2ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.DefaultTabSize = 589879;
            aLevel3ParagraphProperties.RightToLeft = false;
            aLevel3ParagraphProperties.EastAsianLineBreak = true;
            aLevel3ParagraphProperties.LatinLineBreak = false;
            aLevel3ParagraphProperties.Height = true;
            aLevel3ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.DefaultTabSize = 589879;
            aLevel4ParagraphProperties.RightToLeft = false;
            aLevel4ParagraphProperties.EastAsianLineBreak = true;
            aLevel4ParagraphProperties.LatinLineBreak = false;
            aLevel4ParagraphProperties.Height = true;
            aLevel4ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.DefaultTabSize = 589879;
            aLevel5ParagraphProperties.RightToLeft = false;
            aLevel5ParagraphProperties.EastAsianLineBreak = true;
            aLevel5ParagraphProperties.LatinLineBreak = false;
            aLevel5ParagraphProperties.Height = true;
            aLevel5ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.DefaultTabSize = 589879;
            aLevel6ParagraphProperties.RightToLeft = false;
            aLevel6ParagraphProperties.EastAsianLineBreak = true;
            aLevel6ParagraphProperties.LatinLineBreak = false;
            aLevel6ParagraphProperties.Height = true;
            aLevel6ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.DefaultTabSize = 589879;
            aLevel7ParagraphProperties.RightToLeft = false;
            aLevel7ParagraphProperties.EastAsianLineBreak = true;
            aLevel7ParagraphProperties.LatinLineBreak = false;
            aLevel7ParagraphProperties.Height = true;
            aLevel7ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.DefaultTabSize = 589879;
            aLevel8ParagraphProperties.RightToLeft = false;
            aLevel8ParagraphProperties.EastAsianLineBreak = true;
            aLevel8ParagraphProperties.LatinLineBreak = false;
            aLevel8ParagraphProperties.Height = true;
            aLevel8ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.DefaultTabSize = 589879;
            aLevel9ParagraphProperties.RightToLeft = false;
            aLevel9ParagraphProperties.EastAsianLineBreak = true;
            aLevel9ParagraphProperties.LatinLineBreak = false;
            aLevel9ParagraphProperties.Height = true;
            aLevel9ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Kerning = 1200;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "+mn-lt";

            aDefaultRunProperties.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "+mn-ea";

            aDefaultRunProperties.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "+mn-cs";

            aDefaultRunProperties.Append(aComplexScriptFont);

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel9ParagraphProperties);

            textStyles.Append(otherStyle);

            slideMaster.Append(textStyles);

            part.SlideMaster = slideMaster;
        }
        
        private void GenerateSlideLayoutPart1(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.ObjectText;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Content with Caption";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 304800;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2536498;
            aExtents.Cy = 1066800;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2064;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Content Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3343426;
            aOffset.Y = 658284;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3981390;
            aExtents.Cy = 3249083;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2064;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1806;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Text Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 2u;
            placeholderShape.Type = PlaceholderValues.Body;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 1371600;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2536498;
            aExtents.Cy = 2541059;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 903;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 774;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Date Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 7u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 6";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1026247448u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart2(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.SectionHeader;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Section Header";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 536586;
            aOffset.Y = 1139826;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6783110;
            aExtents.Cy = 1901825;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3871;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Text Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Body;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 536586;
            aOffset.Y = 3059642;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6783110;
            aExtents.Cy = 1000125;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;

            A.SolidFill aSolidFill = new A.SolidFill();

            A.SchemeColor aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            A.Tint aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.Text1;

            aTint = new A.Tint();
            aTint.Val = 75000;

            aSchemeColor.Append(aTint);

            aSolidFill.Append(aSchemeColor);

            aDefaultRunProperties.Append(aSolidFill);

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 2856708400u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart3(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.Blank;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Blank";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Date Placeholder 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            A.Text aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1986092909u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateThemePart(ref ThemePart part)
        {
            A.Theme aTheme = new A.Theme();

            aTheme.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            aTheme.Name = "Office Theme";

            A.ThemeElements aThemeElements = new A.ThemeElements();

            A.ColorScheme aColorScheme = new A.ColorScheme();
            aColorScheme.Name = "VVA Colors";

            A.Dark1Color aDark1Color = new A.Dark1Color();

            A.RgbColorModelHex aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "4C5154";

            aDark1Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aDark1Color);

            A.Light1Color aLight1Color = new A.Light1Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "FFFFFF";

            aLight1Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aLight1Color);

            A.Dark2Color aDark2Color = new A.Dark2Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "44546A";

            aDark2Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aDark2Color);

            A.Light2Color aLight2Color = new A.Light2Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "E7E6E6";

            aLight2Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aLight2Color);

            A.Accent1Color aAccent1Color = new A.Accent1Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "ED7D31";

            aAccent1Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent1Color);

            A.Accent2Color aAccent2Color = new A.Accent2Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "ED7D31";

            aAccent2Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent2Color);

            A.Accent3Color aAccent3Color = new A.Accent3Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "A5A5A5";

            aAccent3Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent3Color);

            A.Accent4Color aAccent4Color = new A.Accent4Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "FFC000";

            aAccent4Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent4Color);

            A.Accent5Color aAccent5Color = new A.Accent5Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "4472C4";

            aAccent5Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent5Color);

            A.Accent6Color aAccent6Color = new A.Accent6Color();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "70AD47";

            aAccent6Color.Append(aRgbColorModelHex);

            aColorScheme.Append(aAccent6Color);

            A.Hyperlink aHyperlink = new A.Hyperlink();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "0563C1";

            aHyperlink.Append(aRgbColorModelHex);

            aColorScheme.Append(aHyperlink);

            A.FollowedHyperlinkColor aFollowedHyperlinkColor = new A.FollowedHyperlinkColor();

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "954F72";

            aFollowedHyperlinkColor.Append(aRgbColorModelHex);

            aColorScheme.Append(aFollowedHyperlinkColor);

            aThemeElements.Append(aColorScheme);

            A.FontScheme aFontScheme = new A.FontScheme();
            aFontScheme.Name = "Klavika Font";

            A.MajorFont aMajorFont = new A.MajorFont();

            A.LatinFont aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "Klavika Medium Condensed";

            aMajorFont.Append(aLatinFont);

            A.EastAsianFont aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "";

            aMajorFont.Append(aEastAsianFont);

            A.ComplexScriptFont aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "";

            aMajorFont.Append(aComplexScriptFont);

            aFontScheme.Append(aMajorFont);

            A.MinorFont aMinorFont = new A.MinorFont();

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "Klavika Medium";

            aMinorFont.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "";

            aMinorFont.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "";

            aMinorFont.Append(aComplexScriptFont);

            aFontScheme.Append(aMinorFont);

            aThemeElements.Append(aFontScheme);

            A.FormatScheme aFormatScheme = new A.FormatScheme();
            aFormatScheme.Name = "Office";

            A.FillStyleList aFillStyleList = new A.FillStyleList();

            A.SolidFill aSolidFill = new A.SolidFill();

            A.SchemeColor aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSolidFill.Append(aSchemeColor);

            aFillStyleList.Append(aSolidFill);

            A.GradientFill aGradientFill = new A.GradientFill();
            aGradientFill.RotateWithShape = true;

            A.GradientStopList aGradientStopList = new A.GradientStopList();

            A.GradientStop aGradientStop = new A.GradientStop();
            aGradientStop.Position = 0;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            A.LuminanceModulation aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 110000;

            aSchemeColor.Append(aLuminanceModulation);

            A.SaturationModulation aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 105000;

            aSchemeColor.Append(aSaturationModulation);

            A.Tint aTint = new A.Tint();
            aTint.Val = 67000;

            aSchemeColor.Append(aTint);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 50000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 105000;

            aSchemeColor.Append(aLuminanceModulation);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 103000;

            aSchemeColor.Append(aSaturationModulation);

            aTint = new A.Tint();
            aTint.Val = 73000;

            aSchemeColor.Append(aTint);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 100000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 105000;

            aSchemeColor.Append(aLuminanceModulation);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 109000;

            aSchemeColor.Append(aSaturationModulation);

            aTint = new A.Tint();
            aTint.Val = 81000;

            aSchemeColor.Append(aTint);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientFill.Append(aGradientStopList);

            A.LinearGradientFill aLinearGradientFill = new A.LinearGradientFill();
            aLinearGradientFill.Angle = 5400000;
            aLinearGradientFill.Scaled = false;

            aGradientFill.Append(aLinearGradientFill);

            aFillStyleList.Append(aGradientFill);

            aGradientFill = new A.GradientFill();
            aGradientFill.RotateWithShape = true;

            aGradientStopList = new A.GradientStopList();

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 0;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 103000;

            aSchemeColor.Append(aSaturationModulation);

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 102000;

            aSchemeColor.Append(aLuminanceModulation);

            aTint = new A.Tint();
            aTint.Val = 94000;

            aSchemeColor.Append(aTint);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 50000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 110000;

            aSchemeColor.Append(aSaturationModulation);

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 100000;

            aSchemeColor.Append(aLuminanceModulation);

            A.Shade aShade = new A.Shade();
            aShade.Val = 100000;

            aSchemeColor.Append(aShade);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 100000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 99000;

            aSchemeColor.Append(aLuminanceModulation);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 120000;

            aSchemeColor.Append(aSaturationModulation);

            aShade = new A.Shade();
            aShade.Val = 78000;

            aSchemeColor.Append(aShade);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientFill.Append(aGradientStopList);

            aLinearGradientFill = new A.LinearGradientFill();
            aLinearGradientFill.Angle = 5400000;
            aLinearGradientFill.Scaled = false;

            aGradientFill.Append(aLinearGradientFill);

            aFillStyleList.Append(aGradientFill);

            aFormatScheme.Append(aFillStyleList);

            A.LineStyleList aLineStyleList = new A.LineStyleList();

            A.Outline aOutline = new A.Outline();
            aOutline.Width = 6350;
            aOutline.CapType = A.LineCapValues.Flat;
            aOutline.CompoundLineType = A.CompoundLineValues.Single;
            aOutline.Alignment = A.PenAlignmentValues.Center;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSolidFill.Append(aSchemeColor);

            aOutline.Append(aSolidFill);

            A.PresetDash aPresetDash = new A.PresetDash();
            aPresetDash.Val = A.PresetLineDashValues.Solid;

            aOutline.Append(aPresetDash);

            A.Miter aMiter = new A.Miter();
            aMiter.Limit = 800000;

            aOutline.Append(aMiter);

            aLineStyleList.Append(aOutline);

            aOutline = new A.Outline();
            aOutline.Width = 12700;
            aOutline.CapType = A.LineCapValues.Flat;
            aOutline.CompoundLineType = A.CompoundLineValues.Single;
            aOutline.Alignment = A.PenAlignmentValues.Center;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSolidFill.Append(aSchemeColor);

            aOutline.Append(aSolidFill);

            aPresetDash = new A.PresetDash();
            aPresetDash.Val = A.PresetLineDashValues.Solid;

            aOutline.Append(aPresetDash);

            aMiter = new A.Miter();
            aMiter.Limit = 800000;

            aOutline.Append(aMiter);

            aLineStyleList.Append(aOutline);

            aOutline = new A.Outline();
            aOutline.Width = 19050;
            aOutline.CapType = A.LineCapValues.Flat;
            aOutline.CompoundLineType = A.CompoundLineValues.Single;
            aOutline.Alignment = A.PenAlignmentValues.Center;

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSolidFill.Append(aSchemeColor);

            aOutline.Append(aSolidFill);

            aPresetDash = new A.PresetDash();
            aPresetDash.Val = A.PresetLineDashValues.Solid;

            aOutline.Append(aPresetDash);

            aMiter = new A.Miter();
            aMiter.Limit = 800000;

            aOutline.Append(aMiter);

            aLineStyleList.Append(aOutline);

            aFormatScheme.Append(aLineStyleList);

            A.EffectStyleList aEffectStyleList = new A.EffectStyleList();

            A.EffectStyle aEffectStyle = new A.EffectStyle();

            A.EffectList aEffectList = new A.EffectList();

            aEffectStyle.Append(aEffectList);

            aEffectStyleList.Append(aEffectStyle);

            aEffectStyle = new A.EffectStyle();

            aEffectList = new A.EffectList();

            aEffectStyle.Append(aEffectList);

            aEffectStyleList.Append(aEffectStyle);

            aEffectStyle = new A.EffectStyle();

            aEffectList = new A.EffectList();

            A.OuterShadow aOuterShadow = new A.OuterShadow();
            aOuterShadow.BlurRadius = 57150;
            aOuterShadow.Distance = 19050;
            aOuterShadow.Direction = 5400000;
            aOuterShadow.RotateWithShape = false;
            aOuterShadow.Alignment = A.RectangleAlignmentValues.Center;

            aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "000000";

            A.Alpha aAlpha = new A.Alpha();
            aAlpha.Val = 63000;

            aRgbColorModelHex.Append(aAlpha);

            aOuterShadow.Append(aRgbColorModelHex);

            aEffectList.Append(aOuterShadow);

            aEffectStyle.Append(aEffectList);

            aEffectStyleList.Append(aEffectStyle);

            aFormatScheme.Append(aEffectStyleList);

            A.BackgroundFillStyleList aBackgroundFillStyleList = new A.BackgroundFillStyleList();

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aSolidFill.Append(aSchemeColor);

            aBackgroundFillStyleList.Append(aSolidFill);

            aSolidFill = new A.SolidFill();

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aTint = new A.Tint();
            aTint.Val = 95000;

            aSchemeColor.Append(aTint);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 170000;

            aSchemeColor.Append(aSaturationModulation);

            aSolidFill.Append(aSchemeColor);

            aBackgroundFillStyleList.Append(aSolidFill);

            aGradientFill = new A.GradientFill();
            aGradientFill.RotateWithShape = true;

            aGradientStopList = new A.GradientStopList();

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 0;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aTint = new A.Tint();
            aTint.Val = 93000;

            aSchemeColor.Append(aTint);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 150000;

            aSchemeColor.Append(aSaturationModulation);

            aShade = new A.Shade();
            aShade.Val = 98000;

            aSchemeColor.Append(aShade);

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 102000;

            aSchemeColor.Append(aLuminanceModulation);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 50000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aTint = new A.Tint();
            aTint.Val = 98000;

            aSchemeColor.Append(aTint);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 130000;

            aSchemeColor.Append(aSaturationModulation);

            aShade = new A.Shade();
            aShade.Val = 90000;

            aSchemeColor.Append(aShade);

            aLuminanceModulation = new A.LuminanceModulation();
            aLuminanceModulation.Val = 103000;

            aSchemeColor.Append(aLuminanceModulation);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientStop = new A.GradientStop();
            aGradientStop.Position = 100000;

            aSchemeColor = new A.SchemeColor();
            aSchemeColor.Val = A.SchemeColorValues.PhColor;

            aShade = new A.Shade();
            aShade.Val = 63000;

            aSchemeColor.Append(aShade);

            aSaturationModulation = new A.SaturationModulation();
            aSaturationModulation.Val = 120000;

            aSchemeColor.Append(aSaturationModulation);

            aGradientStop.Append(aSchemeColor);

            aGradientStopList.Append(aGradientStop);

            aGradientFill.Append(aGradientStopList);

            aLinearGradientFill = new A.LinearGradientFill();
            aLinearGradientFill.Angle = 5400000;
            aLinearGradientFill.Scaled = false;

            aGradientFill.Append(aLinearGradientFill);

            aBackgroundFillStyleList.Append(aGradientFill);

            aFormatScheme.Append(aBackgroundFillStyleList);

            aThemeElements.Append(aFormatScheme);

            aTheme.Append(aThemeElements);

            A.ObjectDefaults aObjectDefaults = new A.ObjectDefaults();

            aTheme.Append(aObjectDefaults);

            A.ExtraColorSchemeList aExtraColorSchemeList = new A.ExtraColorSchemeList();

            aTheme.Append(aExtraColorSchemeList);

            A.OfficeStyleSheetExtensionList aOfficeStyleSheetExtensionList = new A.OfficeStyleSheetExtensionList();

            A.OfficeStyleSheetExtension aOfficeStyleSheetExtension = new A.OfficeStyleSheetExtension();
            aOfficeStyleSheetExtension.Uri = "{05A4C25C-085E-4340-85A3-A5531E510DB2}";

            ThemeFamily themeFamily = new ThemeFamily();

            themeFamily.AddNamespaceDeclaration("thm15", "http://schemas.microsoft.com/office/thememl/2012/main");

            themeFamily.Name = "Office Theme";
            themeFamily.Id = "{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}";
            themeFamily.Vid = "{4A3C46E8-61CC-4603-A589-7422A47A8E4A}";

            aOfficeStyleSheetExtension.Append(themeFamily);

            aOfficeStyleSheetExtensionList.Append(aOfficeStyleSheetExtension);

            aTheme.Append(aOfficeStyleSheetExtensionList);

            part.Theme = aTheme;
        }
        
        private void GenerateSlideLayoutPart4(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.Title;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Title Slide";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.CenteredTitle;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 983060;
            aOffset.Y = 748242;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 5898356;
            aExtents.Cy = 1591733;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3871;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Subtitle 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.SubTitle;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 983060;
            aOffset.Y = 2401359;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 5898356;
            aExtents.Cy = 1103841;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;
            aLevel2ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;
            aLevel3ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;
            aLevel4ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;
            aLevel5ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;
            aLevel6ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;
            aLevel7ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;
            aLevel8ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;
            aLevel9ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master subtitle style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1197529327u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart5(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.TitleOnly;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Title Only";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Date Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 3601297684u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart6(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.VerticalTitleAndText;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Vertical Title and Text";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Vertical Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;
            placeholderShape.Orientation = DirectionValues.Vertical;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 5628015;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1695777;
            aExtents.Cy = 3874559;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Vertical = A.TextVerticalValues.EastAsianVetical;

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Vertical Text Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Body;
            placeholderShape.Orientation = DirectionValues.Vertical;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 540683;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 4989026;
            aExtents.Cy = 3874559;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Vertical = A.TextVerticalValues.EastAsianVetical;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1247991428u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart7(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.TwoTextAndTwoObjects;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Comparison";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6783110;
            aExtents.Cy = 883709;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Text Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Body;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 1120775;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3327041;
            aExtents.Cy = 549275;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;
            aDefaultRunProperties.Bold = true;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;
            aDefaultRunProperties.Bold = true;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Bold = true;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Content Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 2u;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 1670050;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3327041;
            aExtents.Cy = 2456392;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Text Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 3u;
            placeholderShape.Type = PlaceholderValues.Body;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3981391;
            aOffset.Y = 1120775;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3343426;
            aExtents.Cy = 549275;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;
            aDefaultRunProperties.Bold = true;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;
            aDefaultRunProperties.Bold = true;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1161;
            aDefaultRunProperties.Bold = true;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;
            aDefaultRunProperties.Bold = true;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Content Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 4u;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3981391;
            aOffset.Y = 1670050;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3343426;
            aExtents.Cy = 2456392;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 7u;
            nonVisualDrawingProperties.Name = "Date Placeholder 6";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 8u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 7";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 9u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 8";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1188106220u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart8(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.VerticalText;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Title and Vertical Text";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Vertical Text Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Body;
            placeholderShape.Orientation = DirectionValues.Vertical;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Vertical = A.TextVerticalValues.EastAsianVetical;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Date Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 965865838u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart9(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.TwoObjects;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Two Content";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Content Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 540683;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3342402;
            aExtents.Cy = 2900892;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Content Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 2u;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3981390;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3342402;
            aExtents.Cy = 2900892;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 1;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Second level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 2;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Third level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 3;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fourth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            aParagraph = new A.Paragraph();

            aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 4;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Date Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 7u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 6";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 1673863041u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateSlideLayoutPart10(ref SlideLayoutPart part)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.PictureText;

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.Name = "Picture with Caption";

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
            nonVisualDrawingProperties.Id = 2u;
            nonVisualDrawingProperties.Name = "Title 1";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            A.ShapeLocks aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            PlaceholderShape placeholderShape = new PlaceholderShape();
            placeholderShape.Type = PlaceholderValues.Title;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            ShapeProperties shapeProperties = new ShapeProperties();

            A.Transform2D aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 304800;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2536498;
            aExtents.Cy = 1066800;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            TextBody textBody = new TextBody();

            A.BodyProperties aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Bottom;

            textBody.Append(aBodyProperties);

            A.ListStyle aListStyle = new A.ListStyle();

            A.Level1ParagraphProperties aLevel1ParagraphProperties = new A.Level1ParagraphProperties();

            A.DefaultRunProperties aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2064;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 3u;
            nonVisualDrawingProperties.Name = "Picture Placeholder 2";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 1u;
            placeholderShape.Type = PlaceholderValues.Picture;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 3343426;
            aOffset.Y = 658284;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3981390;
            aExtents.Cy = 3249083;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2064;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1806;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1548;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1290;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 4u;
            nonVisualDrawingProperties.Name = "Text Placeholder 3";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 2u;
            placeholderShape.Type = PlaceholderValues.Body;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 541707;
            aOffset.Y = 1371600;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2536498;
            aExtents.Cy = 2541059;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1032;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 294940;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 903;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 589879;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 774;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 884819;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 1179759;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 1474699;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 1769638;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 2064578;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 2359518;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 645;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.ParagraphProperties aParagraphProperties = new A.ParagraphProperties();
            aParagraphProperties.Level = 0;

            aParagraph.Append(aParagraphProperties);

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Edit Master text styles");

            aRun.Append(aText);

            aParagraph.Append(aRun);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 5u;
            nonVisualDrawingProperties.Name = "Date Placeholder 4";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 10u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.Field aField = new A.Field();
            aField.Id = "{A1FBC250-1B80-4E75-8888-D9E66CC3F60C}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("3/1/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 6u;
            nonVisualDrawingProperties.Name = "Footer Placeholder 5";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 11u;
            placeholderShape.Type = PlaceholderValues.Footer;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

            aParagraph.Append(aEndParagraphRunProperties);

            textBody.Append(aParagraph);

            shape.Append(textBody);

            shapeTree.Append(shape);

            shape = new Shape();

            nonVisualShapeProperties = new NonVisualShapeProperties();

            nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = 7u;
            nonVisualDrawingProperties.Name = "Slide Number Placeholder 6";

            nonVisualShapeProperties.Append(nonVisualDrawingProperties);

            nonVisualShapeDrawingProperties = new NonVisualShapeDrawingProperties();

            aShapeLocks = new A.ShapeLocks();
            aShapeLocks.NoGrouping = true;

            nonVisualShapeDrawingProperties.Append(aShapeLocks);

            nonVisualShapeProperties.Append(nonVisualShapeDrawingProperties);

            applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            placeholderShape = new PlaceholderShape();
            placeholderShape.Index = 12u;
            placeholderShape.Type = PlaceholderValues.SlideNumber;
            placeholderShape.Size = PlaceholderSizeValues.Quarter;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aField = new A.Field();
            aField.Id = "{74417419-5DB7-47F3-898B-4EA3A59F0139}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.SmartTagClean = false;
            aRunProperties.SmtClean = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

            aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";

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

            p14CreationId.Val = 561821252u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slideLayout.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slideLayout.Append(colorMapOverride);

            part.SlideLayout = slideLayout;
        }
        
        private void GenerateTableStylesPart(ref TableStylesPart part)
        {
            A.TableStyleList aTableStyleList = new A.TableStyleList();

            aTableStyleList.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            aTableStyleList.Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}";

            part.TableStyleList = aTableStyleList;
        }
        
        private void GenerateSlidePart1(ref SlidePart part)
        {
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

            commonSlideData.Append(shapeTree);

            CommonSlideDataExtensionList commonSlideDataExtensionList = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension = new CommonSlideDataExtension();
            commonSlideDataExtension.Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}";

            P14.CreationId p14CreationId = new P14.CreationId();

            p14CreationId.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            p14CreationId.Val = 1727193387u;

            commonSlideDataExtension.Append(p14CreationId);

            commonSlideDataExtensionList.Append(commonSlideDataExtension);

            commonSlideData.Append(commonSlideDataExtensionList);

            slide.Append(commonSlideData);

            ColorMapOverride colorMapOverride = new ColorMapOverride();

            A.MasterColorMapping aMasterColorMapping = new A.MasterColorMapping();

            colorMapOverride.Append(aMasterColorMapping);

            slide.Append(colorMapOverride);

            part.Slide = slide;
        }
        
        private void GenerateViewPropertiesPart(ref ViewPropertiesPart part)
        {
            ViewProperties viewProperties = new ViewProperties();

            viewProperties.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            NormalViewProperties normalViewProperties = new NormalViewProperties();
            normalViewProperties.HorizontalBarState = SplitterBarStateValues.Maximized;

            RestoredLeft restoredLeft = new RestoredLeft();
            restoredLeft.Size = 15987;
            restoredLeft.AutoAdjust = false;

            normalViewProperties.Append(restoredLeft);

            RestoredTop restoredTop = new RestoredTop();
            restoredTop.Size = 94660;

            normalViewProperties.Append(restoredTop);

            viewProperties.Append(normalViewProperties);

            SlideViewProperties slideViewProperties = new SlideViewProperties();

            CommonSlideViewProperties commonSlideViewProperties = new CommonSlideViewProperties();
            commonSlideViewProperties.SnapToGrid = false;

            CommonViewProperties commonViewProperties = new CommonViewProperties();
            commonViewProperties.VariableScale = true;

            ScaleFactor scaleFactor = new ScaleFactor();

            A.ScaleX aScaleX = new A.ScaleX();
            aScaleX.Numerator = 134;
            aScaleX.Denominator = 100;

            scaleFactor.Append(aScaleX);

            A.ScaleY aScaleY = new A.ScaleY();
            aScaleY.Numerator = 134;
            aScaleY.Denominator = 100;

            scaleFactor.Append(aScaleY);

            commonViewProperties.Append(scaleFactor);

            Origin origin = new Origin();
            origin.X = 126;
            origin.Y = 660;

            commonViewProperties.Append(origin);

            commonSlideViewProperties.Append(commonViewProperties);

            GuideList guideList = new GuideList();

            commonSlideViewProperties.Append(guideList);

            slideViewProperties.Append(commonSlideViewProperties);

            viewProperties.Append(slideViewProperties);

            NotesTextViewProperties notesTextViewProperties = new NotesTextViewProperties();

            commonViewProperties = new CommonViewProperties();

            scaleFactor = new ScaleFactor();

            aScaleX = new A.ScaleX();
            aScaleX.Numerator = 1;
            aScaleX.Denominator = 1;

            scaleFactor.Append(aScaleX);

            aScaleY = new A.ScaleY();
            aScaleY.Numerator = 1;
            aScaleY.Denominator = 1;

            scaleFactor.Append(aScaleY);

            commonViewProperties.Append(scaleFactor);

            origin = new Origin();
            origin.X = 0;
            origin.Y = 0;

            commonViewProperties.Append(origin);

            notesTextViewProperties.Append(commonViewProperties);

            viewProperties.Append(notesTextViewProperties);

            GridSpacing gridSpacing = new GridSpacing();
            gridSpacing.Cx = 76200;
            gridSpacing.Cy = 76200;

            viewProperties.Append(gridSpacing);

            part.ViewProperties = viewProperties;
        }
        
        private void GeneratePresentationPropertiesPart(ref PresentationPropertiesPart part)
        {
            PresentationProperties presentationProperties = new PresentationProperties();

            presentationProperties.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            ColorMostRecentlyUsed colorMostRecentlyUsed = new ColorMostRecentlyUsed();

            A.RgbColorModelHex aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "2A2835";

            colorMostRecentlyUsed.Append(aRgbColorModelHex);

            presentationProperties.Append(colorMostRecentlyUsed);

            PresentationPropertiesExtensionList presentationPropertiesExtensionList = new PresentationPropertiesExtensionList();

            PresentationPropertiesExtension presentationPropertiesExtension = new PresentationPropertiesExtension();
            presentationPropertiesExtension.Uri = "{E76CE94A-603C-4142-B9EB-6D1370010A27}";

            P14.DiscardImageEditData p14DiscardImageEditData = new P14.DiscardImageEditData();

            p14DiscardImageEditData.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            p14DiscardImageEditData.Val = false;

            presentationPropertiesExtension.Append(p14DiscardImageEditData);

            presentationPropertiesExtensionList.Append(presentationPropertiesExtension);

            presentationPropertiesExtension = new PresentationPropertiesExtension();
            presentationPropertiesExtension.Uri = "{D31A062A-798A-4329-ABDD-BBA856620510}";

            P14.DefaultImageDpi p14DefaultImageDpi = new P14.DefaultImageDpi();

            p14DefaultImageDpi.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            p14DefaultImageDpi.Val = 220u;

            presentationPropertiesExtension.Append(p14DefaultImageDpi);

            presentationPropertiesExtensionList.Append(presentationPropertiesExtension);

            presentationPropertiesExtension = new PresentationPropertiesExtension();
            presentationPropertiesExtension.Uri = "{FD5EFAAD-0ECE-453E-9831-46B23BE46B34}";

            P15.ChartTrackingReferenceBased p15ChartTrackingReferenceBased = new P15.ChartTrackingReferenceBased();

            p15ChartTrackingReferenceBased.AddNamespaceDeclaration("p15", "http://schemas.microsoft.com/office/powerpoint/2012/main");

            p15ChartTrackingReferenceBased.Val = true;

            presentationPropertiesExtension.Append(p15ChartTrackingReferenceBased);

            presentationPropertiesExtensionList.Append(presentationPropertiesExtension);

            presentationProperties.Append(presentationPropertiesExtensionList);

            part.PresentationProperties = presentationProperties;
        }
        
        private void GenerateExtendedFilePropertiesPart(ref ExtendedFilePropertiesPart part)
        {
            AP.Properties apProperties = new AP.Properties();

            apProperties.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");

            AP.Template apTemplate = new AP.Template("");

            apProperties.Append(apTemplate);

            AP.TotalTime apTotalTime = new AP.TotalTime("7");

            apProperties.Append(apTotalTime);

            AP.Words apWords = new AP.Words("0");

            apProperties.Append(apWords);

            AP.Application apApplication = new AP.Application("Microsoft Office PowerPoint");

            apProperties.Append(apApplication);

            AP.PresentationFormat apPresentationFormat = new AP.PresentationFormat("Custom");

            apProperties.Append(apPresentationFormat);

            AP.Paragraphs apParagraphs = new AP.Paragraphs("0");

            apProperties.Append(apParagraphs);

            AP.Slides apSlides = new AP.Slides("2");

            apProperties.Append(apSlides);

            AP.Notes apNotes = new AP.Notes("0");

            apProperties.Append(apNotes);

            AP.HiddenSlides apHiddenSlides = new AP.HiddenSlides("0");

            apProperties.Append(apHiddenSlides);

            AP.MultimediaClips apMultimediaClips = new AP.MultimediaClips("0");

            apProperties.Append(apMultimediaClips);

            AP.ScaleCrop apScaleCrop = new AP.ScaleCrop("false");

            apProperties.Append(apScaleCrop);

            AP.HeadingPairs apHeadingPairs = new AP.HeadingPairs();

            VT.VTVector vtVTVector = new VT.VTVector();
            vtVTVector.Size = 6u;
            vtVTVector.BaseType = VT.VectorBaseValues.Variant;

            VT.Variant vtVariant = new VT.Variant();

            VT.VTLPSTR vtVTLPSTR = new VT.VTLPSTR("Fonts Used");

            vtVariant.Append(vtVTLPSTR);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            VT.VTInt32 vtVTInt32 = new VT.VTInt32("3");

            vtVariant.Append(vtVTInt32);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTLPSTR = new VT.VTLPSTR("Theme");

            vtVariant.Append(vtVTLPSTR);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTInt32 = new VT.VTInt32("1");

            vtVariant.Append(vtVTInt32);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTLPSTR = new VT.VTLPSTR("Slide Titles");

            vtVariant.Append(vtVTLPSTR);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTInt32 = new VT.VTInt32("2");

            vtVariant.Append(vtVTInt32);

            vtVTVector.Append(vtVariant);

            apHeadingPairs.Append(vtVTVector);

            apProperties.Append(apHeadingPairs);

            AP.TitlesOfParts apTitlesOfParts = new AP.TitlesOfParts();

            vtVTVector = new VT.VTVector();
            vtVTVector.Size = 6u;
            vtVTVector.BaseType = VT.VectorBaseValues.Lpstr;

            vtVTLPSTR = new VT.VTLPSTR("Arial");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("Klavika Medium");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("Klavika Medium Condensed");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("Office Theme");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("PowerPoint Presentation");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("PowerPoint Presentation");

            vtVTVector.Append(vtVTLPSTR);

            apTitlesOfParts.Append(vtVTVector);

            apProperties.Append(apTitlesOfParts);

            AP.Company apCompany = new AP.Company("TMA");

            apProperties.Append(apCompany);

            AP.LinksUpToDate apLinksUpToDate = new AP.LinksUpToDate("false");

            apProperties.Append(apLinksUpToDate);

            AP.SharedDocument apSharedDocument = new AP.SharedDocument("false");

            apProperties.Append(apSharedDocument);

            AP.HyperlinksChanged apHyperlinksChanged = new AP.HyperlinksChanged("false");

            apProperties.Append(apHyperlinksChanged);

            AP.ApplicationVersion apApplicationVersion = new AP.ApplicationVersion("16.0000");

            apProperties.Append(apApplicationVersion);

            part.Properties = apProperties;
        }
    }
}