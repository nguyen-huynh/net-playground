namespace OpenXmlSample
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Office2013.Theme;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.IO;
    using A = DocumentFormat.OpenXml.Drawing;
    using A16 = DocumentFormat.OpenXml.Office2016.Drawing;
    using AP = DocumentFormat.OpenXml.ExtendedProperties;
    using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
    using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
    using VT = DocumentFormat.OpenXml.VariantTypes;
    using P = DocumentFormat.OpenXml.Presentation;


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

            ExtendedPart extendedPart = presentationPart.AddExtendedPart("","","");
            presentationPart.ChangeIdOfPart(extendedPart, "rId8");
            this.GenerateExtendedPart(ref extendedPart);

            PresentationPropertiesPart presentationPropertiesPart = presentationPart.AddNewPart<PresentationPropertiesPart>("rId3");
            this.GeneratePresentationPropertiesPart(ref presentationPropertiesPart);

            ExtendedPart extendedPart1 = presentationPart.AddExtendedPart("", "", "");
            presentationPart.ChangeIdOfPart(extendedPart1, "rId7");
            this.GenerateExtendedPart1(ref extendedPart1);

            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>("rId2");
            this.GenerateSlidePart(ref slidePart);

            ImagePart imagePart = slidePart.AddImagePart("image/png");
            slidePart.ChangeIdOfPart(imagePart, "rId2");
            this.GenerateImagePart(ref imagePart);

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

            presentationPart.AddPart<SlideMasterPart>(slideMasterPart, "rId1");

            TableStylesPart tableStylesPart = presentationPart.AddNewPart<TableStylesPart>("rId6");
            this.GenerateTableStylesPart(ref tableStylesPart);


            presentationPart.AddPart<ThemePart>(themePart, "rId5");

            ViewPropertiesPart viewPropertiesPart = presentationPart.AddNewPart<ViewPropertiesPart>("rId4");
            this.GenerateViewPropertiesPart(ref viewPropertiesPart);

            ExtendedFilePropertiesPart extendedFilePropertiesPart = pkg.AddExtendedFilePropertiesPart();
            pkg.ChangeIdOfPart(extendedFilePropertiesPart, "rId4");
            this.GenerateExtendedFilePropertiesPart(ref extendedFilePropertiesPart);

        }
        
        private void GenerateCoreFilePropertiesPart(ref CoreFilePropertiesPart part)
        {
            string base64 = @"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pg0KPGNwOmNvcmVQcm9wZXJ0aWVzIHhtbG5zOmNwPSJodHRwOi8vc2NoZW1hcy5vcGVueG1sZm9ybWF0cy5vcmcvcGFja2FnZS8yMDA2L21ldGFkYXRhL2NvcmUtcHJvcGVydGllcyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpkY3Rlcm1zPSJodHRwOi8vcHVybC5vcmcvZGMvdGVybXMvIiB4bWxuczpkY21pdHlwZT0iaHR0cDovL3B1cmwub3JnL2RjL2RjbWl0eXBlLyIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSI+PGRjOnRpdGxlPlBvd2VyUG9pbnQgUHJlc2VudGF0aW9uPC9kYzp0aXRsZT48ZGM6Y3JlYXRvcj48L2RjOmNyZWF0b3I+PGNwOmxhc3RNb2RpZmllZEJ5PjwvY3A6bGFzdE1vZGlmaWVkQnk+PGNwOnJldmlzaW9uPjcyPC9jcDpyZXZpc2lvbj48ZGN0ZXJtczpjcmVhdGVkIHhzaTp0eXBlPSJkY3Rlcm1zOlczQ0RURiI+MjAyMi0wMi0yNFQwODoyNDoxNlo8L2RjdGVybXM6Y3JlYXRlZD48ZGN0ZXJtczptb2RpZmllZCB4c2k6dHlwZT0iZGN0ZXJtczpXM0NEVEYiPjIwMjItMDItMjRUMDg6NTE6MTZaPC9kY3Rlcm1zOm1vZGlmaWVkPjwvY3A6Y29yZVByb3BlcnRpZXM+";

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
                "BQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCACXAQADASIAAhEBAxEB/8QAH" +
                "wAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhM" +
                "UEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV" +
                "1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx" +
                "8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFB" +
                "gcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVY" +
                "nLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEh" +
                "YaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8" +
                "vP09fb3+Pn6/9oADAMBAAIRAxEAPwD74+OH7S3hr4Ca14Y0zX7O9up9fS6ktmtbmxhCrA0CuMXNzC00h" +
                "Nym2GASyvhtqEjBnX9ozwtp1w9vrrXOl3H9rXemr9ns7m9ijSG5+zi4uZYoilrEzEfPMUQfN852sR8af" +
                "Fz9vT4LfF28sp7o/FHQFh02/wBGuYdIsNIKX9leGA3EE32hpSA32aMBoyjjLYbnjLvv2z/gPc6hJPar8" +
                "VdLtbyWY6rp9rbaWYNVgkuDcfZp/MkZ1jVnlAMLRybZXDO3GL5JdgPtrWv2lPCumapp0EIvprGTWpdGv" +
                "NTudPu7W2idLS+nLW8skIS9O+xaLbAzYaReclVboPEfxh0Pwt4y8GeHL6G/juPFUVxLZ3Rt9kFv5RgUL" +
                "cbyrRM73UMaAry7hTgkA/n7q37YXwE8RadHpWsf8LW1XQrPVW1jStLntdKVNJnMV1GDbyo6zZRrsyo0k" +
                "jvHJBCyMu0hut8Wf8FBvgV45ktJdc0b4h38tvot5ohk+yWEbSJcvayPOSk42Tq9nE6PHtCMSQM7dpyS7" +
                "AfXmn/tJeCrrQ9G1W7fWNItNV0NPEEE19ol2IPs5tTdlPtKRtA0ywo7GFJGfCNgHFR6N+1D8N9c1C6so" +
                "NZvraa0illuG1HRL+yjhEcH2hlaSaBEV/I/fKhO5osSKCh3V+e4/aC/ZqOoaVdvZfFCaTTdAHh2F5NN0" +
                "QzeR/Zradu+0f68fuXZvKWQQeafM8rcTXbeJP21/wBnjxbFrMGqaD8Rri11e7nu7u3+z2Ko/naOukyRj" +
                "E+Qht13dc7yTnHy0ckuwH6D+CfHmkfELS5r/R2vRHBObaeDUtOudPuYJAqvtkt7iOOVCVdGG5RlXVhkE" +
                "Guhr87fgv8A8FAPgR8DvCc2gaF4f8ZyWs1295JIvh3Q9PLSMqKSY7E28ROEUbim4gAFiAAO9/4eyfCL/" +
                "oXPGv8A4A2f/wAlUckuwH2rRXxV/wAPZPhF/wBC541/8AbP/wCSqP8Ah7J8Iv8AoXPGv/gDZ/8AyVRyS" +
                "7AfatFfFX/D2T4Rf9C541/8AbP/AOSqP+Hsnwi/6Fzxr/4A2f8A8lUckuwH2rRXxV/w9k+EX/QueNf/A" +
                "ABs/wD5Ko/4eyfCL/oXPGv/AIA2f/yVRyS7Afatcn8QdS1Pw/Z2utWV6qWllJi6094123auyoo8w8x7S" +
                "c7hx1zXyt/w9k+EX/QueNf/AABs/wD5KrF1/wD4KdfBnxJdafJeaJ4/+zWjs7WKWtmLe5JAAEyfafnC4" +
                "yBnGeua5cVRq1KMo0vi6a2s77/LdrqtOp14WcKdaMqvw9dL3Vtvnsn0evQ+0fC2vXmvNqLXNtb2qWs/2" +
                "cLDP52XCgud2ACPmXHfrkCt6vhvTf8AgqP8EtFaZrDwh4vs/NCh1g06zRTtBA4F1gYyav8A/D2T4Rf9C" +
                "541/wDAGz/+SqujSqxppVdX/Xp+RnWlTlNukrL+vN/mfatFfFX/AA9k+EX/AELnjX/wBs//AJKo/wCHs" +
                "nwi/wChc8a/+ANn/wDJVb8kuxgfatFfFX/D2T4Rf9C541/8AbP/AOSqP+Hsnwi/6Fzxr/4A2f8A8lUck" +
                "uwH2rRXxV/w9k+EX/QueNf/AABs/wD5Ko/4eyfCL/oXPGv/AIA2f/yVRyS7AfatFfFX/D2T4Rf9C541/" +
                "wDAGz/+SqP+Hsnwi/6Fzxr/AOANn/8AJVHJLsB9q0V8Vf8AD2T4Rf8AQueNf/AGz/8Akqj/AIeyfCL/A" +
                "KFzxr/4A2f/AMlUckuwH1x438XWngPwtf65eQ3F3HaqoS0tApnuZnYJFBHvZV3ySMiLuZV3OMsoyR5hc" +
                "ftUaVZ27PP4N8Uw3Ni0x1+zK2Jl8PQxyqhnuyLoq6MG8xfszTMUVjtyMV87+PP+CmXwY+IHhS+0K80Xx" +
                "/ZR3Ox0vLGzsVntpo5FkimjL3DLvSREcblZcqMgjIPmk37YPwNumjknvfi5NcXXmJ4gnaz0UN4kieZZP" +
                "JvAPlVAFMY+zCBgjsM9CDkl2A+7vFP7QGkeGdYhsl8P+ItTgj2Pql7b2aQR6RC929rHPcR3MkUzRPJDM" +
                "VaGOXckTOAUKs1z4afGzT/idqc9pbaHrGjxPZx6npt5qa2/k6tYu7Kl1bmKaRghwp2yiN8SIdvPHw/4i" +
                "/br+DHijxBFq19dfFfdII4dStY7HR1h1W2iu5Lm3trgZyI4WmkRTEY3ZGIkeQksbnwv/b6+CXwtuZJLW" +
                "D4na1FFZx6Zptvq1nphTS7GNmZLWDypI2KDKjdKZHIjQFzijkl2A/OCiiiu0AooooAKKKKACiiigAooo" +
                "oAKKKKACiu20/4HfEfVrC2vrH4f+Kb2yuolmgubfRbmSOWNgCrqwTDKQQQRwQasf8M/fFH/AKJt4u/8E" +
                "V1/8bpXQHA0V33/AAz98Uf+ibeLv/BFdf8Axuj/AIZ++KP/AETbxd/4Irr/AON0XQHA0V33/DP3xR/6J" +
                "t4u/wDBFdf/ABuj/hn74o/9E28Xf+CK6/8AjdF0BwNFd9/wz98Uf+ibeLv/AARXX/xuq+ofA74j6TYXN" +
                "9ffD/xTZWVrE009zcaLcxxxRqCWdmKYVQASSeABRdAcTRRRTAKKKKACiiigAooooAKKKKACiiigAoooo" +
                "AKKKKACiiigAooooAKKKKACiiigD98f2a/+TdPhZ/2Kmlf+kcVYHjD47XngrxV4qt7nT11DTtGEBjs7P" +
                "yftlz5gt8rGpuPMeTM7EKIAjBQPM3cVv/s1/wDJunws/wCxU0r/ANI4q9Hrge4Hz/a/tXC+hv57bw1Fd" +
                "QWf2h3e21ZJN8cEdzJIUUR5JItSUBADiRPmX5gs+oftORaFqGoLd2um6jbQw3EyvpOqC4V2htBceXCRE" +
                "DLu+cF2CKmwgkkqG95opAeMeIvjhrFp4F0LxVp2kWslpK17LqNqspu3FtAZEaWF4yN23aJSu0sUVkChy" +
                "McvbftdPMtvbQeH7XVtQNqk0rW9+8MYcWV3dTIQ8RKMPsbKoywPmKd2Bk/R9FAHlGh/HKfUviZb+CrvQ" +
                "I7PUDv+0TLqKuiYFwVMYZFaUYtxuwAVMg4IBYaH7Sn/ACbp8U/+xU1X/wBI5a9Hrzj9pT/k3T4p/wDYq" +
                "ar/AOkctNbgfgdRRRXeAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAH7" +
                "4/s1/8AJunws/7FTSv/AEjir0evOP2a/wDk3T4Wf9ippX/pHFXo9cD3AKKKKQBRRRQAV5x+0p/ybp8U/" +
                "wDsVNV/9I5a9Hrzj9pT/k3T4p/9ipqv/pHLTW4H4HUUUV3gFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAF" +
                "FFFABRRRQAUUUUAFFFFABRRRQB++P7Nf/Junws/7FTSv/SOKvR684/Zr/5N0+Fn/YqaV/6RxV6PXA9wC" +
                "iiikAUUUUAFecftKf8AJunxT/7FTVf/AEjlr0evOP2lP+TdPin/ANipqv8A6Ry01uB+B1FFFd4BRRRQA" +
                "UUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAfvj+zX/wAm6fCz/sVNK/8ASOKvR" +
                "684/Zr/AOTdPhZ/2Kmlf+kcVej1wPcAooopAFFFFABXnH7Sn/JunxT/AOxU1X/0jlr0evOP2lP+TdPin" +
                "/2Kmq/+kctNbgfgdRRRXeAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFA" +
                "H74/s1/8m6fCz/sVNK/9I4q9Hrzj9mv/k3T4Wf9ippX/pHFXof2iLaD5qYK7wdw+76/T3rz3uPUkopAw" +
                "YAg5B6GloEFFIGDEgEEqcH270nmJ5nl7l8zG7bnnHrigY6vOP2lP+TdPin/ANipqv8A6Ry16MWCkAkAs" +
                "cD3715z+0p/ybp8U/8AsVNV/wDSOWmtxH4HUUUV3gFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                "RRQAUUUUAFFFFABRRRQB+8nwFtZb79l/wCGlvCkckknhLSlCykBebSLOco46Z6qaitPhPqlqLAPHpdwL" +
                "aZZpN0jqZ12RgxMfLOEDKzdwSfurkivw3g8Ya/awxww63qUUMahEjju5FVVAwAADwAKf/wnHiP/AKD+q" +
                "f8AgbJ/8VXk4jLqeJkpVHsd+HxtXCxcafU/dvSPAWuadHZxnVmRLdkzHBdyrHtV4eAmMAbEmOO5kAPAq" +
                "zqHhDV7691C6AsY5b+O4gf9+58lZEgjVlPl/MQImOPl5cjPJNfg3/wnHiP/AKD+qf8AgbJ/8VR/wnHiP" +
                "/oP6p/4Gyf/ABVR/ZdLl5E3Yv8AtCs5c7tf07n7xaf8O8TW4vLHTTax6g935OPNYIYmGzeY1L/vHz8w4" +
                "CgZPQR6p8PbvWriQXC2SrJeSSzXiuzXFzA5KGFvl+VRC5XAJBKL05r8If8AhOPEf/Qf1T/wNk/+Ko/4T" +
                "jxH/wBB/VP/AANk/wDiqP7Lo8vK9v6/r/gB/aFfm509f6/r/go/dK1+HOrw2+oC6On6pdXFr5MNzcSsG" +
                "t5FDIkigxt8xRYCxGCCh64FUPjdo40P9lr4mWeyNGj8Katu8vbgn7JLySqICcY52j8etfh5/wAJx4j/A" +
                "Og/qn/gbJ/8VTJ/GGv3UMkM2t6lLDIpR45LuRlZSMEEE8gitKGX08PLmg/63M6+Mq4hcs/66GRRRRXqn" +
                "CFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUU" +
                "AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUU" +
                "AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAH/9k=";

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
            slideMasterId.Id = 2147483672u;
            slideMasterId.RelationshipId = "rId1";

            slideMasterIdList.Append(slideMasterId);

            presentation.Append(slideMasterIdList);

            SlideIdList slideIdList = new SlideIdList();

            SlideId slideId = new SlideId();
            slideId.Id = 256u;
            slideId.RelationshipId = "rId2";

            slideIdList.Append(slideId);

            presentation.Append(slideIdList);

            SlideSize slideSize = new SlideSize();
            slideSize.Cx = 7772400;
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
        
        private void GenerateExtendedPart(ref ExtendedPart part)
        {
            string base64 = @"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pg0KPHAxNTEwOnJldkluZm8geG1sbnM6YT0iaHR0cDovL3NjaGVtYXMub3BlbnhtbGZvcm1hdHMub3JnL2RyYXdpbmdtbC8yMDA2L21haW4iIHhtbG5zOnI9Imh0dHA6Ly9zY2hlbWFzLm9wZW54bWxmb3JtYXRzLm9yZy9vZmZpY2VEb2N1bWVudC8yMDA2L3JlbGF0aW9uc2hpcHMiIHhtbG5zOnAxNTEwPSJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL29mZmljZS9wb3dlcnBvaW50LzIwMTUvMTAvbWFpbiI+PHAxNTEwOnJldkxzdD48cDE1MTA6Y2xpZW50IGlkPSJ7Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgdj0iMTE1IiBkdD0iMjAyMi0wMi0yNFQwODo1MToxMC4zODQiLz48L3AxNTEwOnJldkxzdD48L3AxNTEwOnJldkluZm8+";

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
        
        private void GeneratePresentationPropertiesPart(ref PresentationPropertiesPart part)
        {
            PresentationProperties presentationProperties = new PresentationProperties();

            presentationProperties.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            ColorMostRecentlyUsed colorMostRecentlyUsed = new ColorMostRecentlyUsed();

            A.RgbColorModelHex aRgbColorModelHex = new A.RgbColorModelHex();
            aRgbColorModelHex.Val = "ED7D31";

            colorMostRecentlyUsed.Append(aRgbColorModelHex);

            aRgbColorModelHex = new A.RgbColorModelHex();
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
        
        private void GenerateExtendedPart1(ref ExtendedPart part)
        {
            string base64 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pg0KPHBjO" +
                "mNoZ0luZm8geG1sbnM6YT0iaHR0cDovL3NjaGVtYXMub3BlbnhtbGZvcm1hdHMub3JnL2RyYXdpbmdtb" +
                "C8yMDA2L21haW4iIHhtbG5zOnI9Imh0dHA6Ly9zY2hlbWFzLm9wZW54bWxmb3JtYXRzLm9yZy9vZmZpY" +
                "2VEb2N1bWVudC8yMDA2L3JlbGF0aW9uc2hpcHMiIHhtbG5zOmFjPSJodHRwOi8vc2NoZW1hcy5taWNyb" +
                "3NvZnQuY29tL29mZmljZS9kcmF3aW5nLzIwMTMvbWFpbi9jb21tYW5kIiB4bWxuczpwYz0iaHR0cDovL" +
                "3NjaGVtYXMubWljcm9zb2Z0LmNvbS9vZmZpY2UvcG93ZXJwb2ludC8yMDEzL21haW4vY29tbWFuZCI+P" +
                "HBjOmRvY0NoZ0xzdD48cGM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VyS" +
                "WQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDR" +
                "UIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9Ii8+PHBjOmRvY0NoZyBjaGc9Im1vZCBtb" +
                "2RTbGQgYWRkTWFpbk1hc3RlciBkZWxNYWluTWFzdGVyIG1vZE1haW5NYXN0ZXIgc2V0U2xkU3oiPjxwY" +
                "zpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxM" +
                "TRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2M" +
                "C04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjUxOjEwLjEwMiIgdj0iOTEiIGFjd" +
                "ElkPSIyMDU3NyIvPjxwYzpkb2NNa0xzdD48cGM6ZG9jTWsvPjwvcGM6ZG9jTWtMc3Q+PHBjOnNsZENoZ" +
                "yBjaGc9ImFkZFNwIGRlbFNwIG1vZFNwIG1vZCBzZXRCZyBtb2RDbHJTY2hlbWUgY2hnTGF5b3V0Ij48c" +
                "GM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2M" +
                "TE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBN" +
                "jAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODo1MToxMC4xMDIiIHY9IjkxIiBhY" +
                "3RJZD0iMjA1NzciLz48cGM6c2xkTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWsgY0lkPSIxMDk4NTcyM" +
                "jIiIHNsZElkPSIyNTYiLz48L3BjOnNsZE1rTHN0PjxwYzpzcENoZyBjaGc9ImRlbCI+PGFjOmNoZ0Rhd" +
                "GEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwc" +
                "m92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtR" +
                "Dk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6MjQ6MzkuMjUwIiB2PSIwIi8+PGFjOnNwTWtMc" +
                "3Q+PHBjOmRvY01rLz48cGM6c2xkTWsgY0lkPSIxMDk4NTcyMjIiIHNsZElkPSIyNTYiLz48YWM6c3BNa" +
                "yBpZD0iMiIgY3JlYXRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iL" +
                "z48L2FjOnNwTWtMc3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJkZWwiPjxhYzpjaGdEYXRhIG5hb" +
                "WU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZ" +
                "XJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1Q" +
                "TZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI0OjQzLjUxNiIgdj0iMSIvPjxhYzpzcE1rTHN0PjxwY" +
                "zpkb2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3MjIyIiBzbGRJZD0iMjU2Ii8+PGFjOnNwTWsgaWQ9I" +
                "jMiIGNyZWF0aW9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hY" +
                "zpzcE1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0iYWRkIG1vZCI+PGFjOmNoZ0RhdGEgbmFtZ" +
                "T0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlc" +
                "klkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBN" +
                "kNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6MzE6MDIuMjQ0IiB2PSIyMiIgYWN0SWQ9IjE0MTAwIi8+P" +
                "GFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWsgY0lkPSIxMDk4NTcyMjIiIHNsZElkPSIyNTYiL" +
                "z48YWM6c3BNayBpZD0iNCIgY3JlYXRpb25JZD0iezYzQzE5OTUyLTY3ODMtNEM5MC04M0UwLTMzMzg5N" +
                "zAwQTc2RX0iLz48L2FjOnNwTWtMc3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJhZGQgZGVsIG1vZ" +
                "CBvcmQiPjxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZ" +
                "mIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0L" +
                "UM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjMwOjM0LjU1NiIgd" +
                "j0iMjEiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNayBjSWQ9IjEwOTg1NzIyMiIgc2xkS" +
                "WQ9IjI1NiIvPjxhYzpzcE1rIGlkPSI1IiBjcmVhdGlvbklkPSJ7NzAyRTgzM0ItRTE3My00MzlGLUI4N" +
                "UYtOEI4OTdDNjdGN0RBfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9ImFkZ" +
                "CBkZWwgbW9kIG9yZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlc" +
                "klkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q" +
                "0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6MzA6M" +
                "zMuMTM0IiB2PSIyMCIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3M" +
                "jIyIiBzbGRJZD0iMjU2Ii8+PGFjOnNwTWsgaWQ9IjYiIGNyZWF0aW9uSWQ9IntGMjdCMTMzMi1EQUEwL" +
                "TQ5QzUtOTNDMy0wOUNDMDRCQTJCMkN9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnI" +
                "GNoZz0iYWRkIG1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlc" +
                "klkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q" +
                "0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6NDE6N" +
                "TAuNTczIiB2PSI0OCIgYWN0SWQ9IjEwNzYiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNa" +
                "yBjSWQ9IjEwOTg1NzIyMiIgc2xkSWQ9IjI1NiIvPjxhYzpzcE1rIGlkPSI5IiBjcmVhdGlvbklkPSJ7M" +
                "zY2NjhGMDMtQTk4Qy00OEY5LTlCMkUtQ0FBRjJGRjNBQzZFfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ" +
                "2hnPjxwYzpzcENoZyBjaGc9ImFkZCBtb2QiPjxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7Nua" +
                "CBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlI" +
                "iBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyL" +
                "TAyLTI0VDA4OjQyOjMxLjYyMSIgdj0iNTMiIGFjdElkPSIyMDU3NyIvPjxhYzpzcE1rTHN0PjxwYzpkb" +
                "2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3MjIyIiBzbGRJZD0iMjU2Ii8+PGFjOnNwTWsgaWQ9IjEwI" +
                "iBjcmVhdGlvbklkPSJ7MkIzRjNCNUMtNDcxMi00RjU4LThCMEYtMjIxOTM3NjZCODYzfSIvPjwvYWM6c" +
                "3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9ImFkZCBkZWwgbW9kIG1vZFZpcyI+PGFjOmNoZ" +
                "0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzI" +
                "iBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDR" +
                "EEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6NDg6MDkuNTUxIiB2PSI3MiIvPjxhYzpzc" +
                "E1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3MjIyIiBzbGRJZD0iMjU2Ii8+PGFjO" +
                "nNwTWsgaWQ9IjExIiBjcmVhdGlvbklkPSJ7REJCNDk4NjYtNUNEMy00M0U1LUE4RDItMURBMjBCRDQ5R" +
                "DcxfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9ImFkZCBkZWwiPjxhYzpja" +
                "GdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhM" +
                "yIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q" +
                "0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjQ3OjMwLjg2MyIgdj0iNjQiLz48YWM6c" +
                "3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNayBjSWQ9IjEwOTg1NzIyMiIgc2xkSWQ9IjI1NiIvPjxhY" +
                "zpzcE1rIGlkPSIxMiIgY3JlYXRpb25JZD0iezFGNEE4MEI0LTZFODgtNDdDNy1CRkVELTlCN0FGNkZEQ" +
                "zg2QX0iLz48L2FjOnNwTWtMc3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJhZGQgZGVsIj48YWM6Y" +
                "2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0Y" +
                "TMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtO" +
                "ENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODo0NzozNS4zMTYiIHY9IjY2Ii8+PGFjO" +
                "nNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWsgY0lkPSIxMDk4NTcyMjIiIHNsZElkPSIyNTYiLz48Y" +
                "WM6c3BNayBpZD0iMTMiIGNyZWF0aW9uSWQ9Ins1QzNDRDJCNC1FMUY2LTQxMTEtOTlBMy1BMjBBNzg4M" +
                "DAyRkJ9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0iYWRkIG1vZCI+PGFjO" +
                "mNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExN" +
                "GEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwL" +
                "ThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6NDg6NDQuNjYxIiB2PSI3NiIvPjxhY" +
                "zpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3MjIyIiBzbGRJZD0iMjU2Ii8+P" +
                "GFjOnNwTWsgaWQ9IjE0IiBjcmVhdGlvbklkPSJ7RTQ4NDk2NjAtMUVDQi00REYxLTkwMjAtNjIxQTFCN" +
                "TkzQzJGfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9ImFkZCBtb2QiPjxhY" +
                "zpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxM" +
                "TRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2M" +
                "C04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjQ5OjU4Ljg4MiIgdj0iODIiIGFjd" +
                "ElkPSIyMDU3NyIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1rIGNJZD0iMTA5ODU3MjIyI" +
                "iBzbGRJZD0iMjU2Ii8+PGFjOnNwTWsgaWQ9IjE1IiBjcmVhdGlvbklkPSJ7RENCNjU1NzgtOTBCRi00Q" +
                "TcyLUI3NkMtM0FBN0YyQjVCQzQ3fSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBja" +
                "Gc9ImFkZCBtb2QiPjxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZ" +
                "D0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQ" +
                "jJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjUxOjEwL" +
                "jEwMiIgdj0iOTEiIGFjdElkPSIyMDU3NyIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1rI" +
                "GNJZD0iMTA5ODU3MjIyIiBzbGRJZD0iMjU2Ii8+PGFjOnNwTWsgaWQ9IjE2IiBjcmVhdGlvbklkPSJ7O" +
                "DI1NzBDN0QtRkE4Qi00N0UyLUIxRjctOUYyMTlGOTRBQzJEfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ" +
                "2hnPjxwYzpwaWNDaGcgY2hnPSJhZGQgZGVsIG1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBId" +
                "eG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzI" +
                "ExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9I" +
                "jIwMjItMDItMjRUMDg6MzI6MjQuMTUyIiB2PSIyOSIvPjxhYzpwaWNNa0xzdD48cGM6ZG9jTWsvPjxwY" +
                "zpzbGRNayBjSWQ9IjEwOTg1NzIyMiIgc2xkSWQ9IjI1NiIvPjxhYzpwaWNNayBpZD0iNyIgY3JlYXRpb" +
                "25JZD0ie0I2MTZBRUVGLTdERTEtNDE5NS05QTE0LTgzMkQ1MjMxREY4NX0iLz48L2FjOnBpY01rTHN0P" +
                "jwvcGM6cGljQ2hnPjxwYzpwaWNDaGcgY2hnPSJhZGQgbW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w" +
                "6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9Ildpb" +
                "mRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9I" +
                "iBkdD0iMjAyMi0wMi0yNFQwODozMzowNi43NDciIHY9IjMxIiBhY3RJZD0iMTA3NiIvPjxhYzpwaWNNa" +
                "0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNayBjSWQ9IjEwOTg1NzIyMiIgc2xkSWQ9IjI1NiIvPjxhYzpwa" +
                "WNNayBpZD0iOCIgY3JlYXRpb25JZD0ie0JBRjExRTU1LUQxNUQtNDc1RS1BQ0NCLUZDNzVEREMwRjREN" +
                "H0iLz48L2FjOnBpY01rTHN0PjwvcGM6cGljQ2hnPjwvcGM6c2xkQ2hnPjxwYzpzbGRNYXN0ZXJDaGcgY" +
                "2hnPSJtb2RTcCBkZWwgZGVsU2xkTGF5b3V0IG1vZFNsZExheW91dCI+PHBjOmNoZ0RhdGEgbmFtZT0iT" +
                "md1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkP" +
                "SJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCN" +
                "UI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZE1hc3Rlck1rTHN0P" +
                "jxwYzpkb2NNay8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxNDc0ODM2N" +
                "jAiLz48L3BjOnNsZE1hc3Rlck1rTHN0PjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZ" +
                "T0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlc" +
                "klkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBN" +
                "kNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjO" +
                "mRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvP" +
                "jxhYzpzcE1rIGlkPSIyIiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwM" +
                "DAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ" +
                "0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzI" +
                "iBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDR" +
                "EEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwT" +
                "WtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0N" +
                "zQ4MzY2MCIvPjxhYzpzcE1rIGlkPSIzIiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwM" +
                "DAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9Im1vZ" +
                "CI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwN" +
                "zU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBM" +
                "C00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyI" +
                "i8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzb" +
                "GRJZD0iMjE0NzQ4MzY2MCIvPjxhYzpzcE1rIGlkPSI0IiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwM" +
                "C0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZ" +
                "yBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkP" +
                "SIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCM" +
                "kUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuN" +
                "DQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwO" +
                "TU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxhYzpzcE1rIGlkPSI1IiBjcmVhdGlvbklkPSJ7MDAwM" +
                "DAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnP" +
                "jxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtd" +
                "CIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9I" +
                "ldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUM" +
                "Dg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY" +
                "0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxhYzpzcE1rIGlkPSI2IiBjcmVhdGlvb" +
                "klkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L" +
                "3BjOnNwQ2hnPjxwYzpzbGRMYXlvdXRDaGcgY2hnPSJtb2RTcCBkZWwiPjxwYzpjaGdEYXRhIG5hbWU9I" +
                "k5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZ" +
                "D0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQ" +
                "jVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzd" +
                "D48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzN" +
                "jYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMjM4NTM4Nzg5MCIgc2xkSWQ9IjIxNDc0ODM2NjEiLz48L" +
                "3BjOnNsZExheW91dE1rTHN0PjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1e" +
                "cOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXa" +
                "W5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2f" +
                "SIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rL" +
                "z48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzb" +
                "GRMYXlvdXRNayBjSWQ9IjIzODUzODc4OTAiIHNsZElkPSIyMTQ3NDgzNjYxIi8+PGFjOnNwTWsgaWQ9I" +
                "jIiIGNyZWF0aW9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hY" +
                "zpzcE1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ" +
                "3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9I" +
                "ldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1Q" +
                "jZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jT" +
                "WsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjO" +
                "nNsZExheW91dE1rIGNJZD0iMjM4NTM4Nzg5MCIgc2xkSWQ9IjIxNDc0ODM2NjEiLz48YWM6c3BNayBpZ" +
                "D0iMyIgY3JlYXRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L" +
                "2FjOnNwTWtMc3Q+PC9wYzpzcENoZz48L3BjOnNsZExheW91dENoZz48cGM6c2xkTGF5b3V0Q2hnIGNoZ" +
                "z0iZGVsIj48cGM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5Z" +
                "GZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzN" +
                "C1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi41MDQiI" +
                "HY9IjMiLz48cGM6c2xkTGF5b3V0TWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyN" +
                "DYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9Ijk0OTEzODQ1M" +
                "iIgc2xkSWQ9IjIxNDc0ODM2NjIiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnP" +
                "jxwYzpzbGRMYXlvdXRDaGcgY2hnPSJtb2RTcCBkZWwiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gS" +
                "HXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93c" +
                "yBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0P" +
                "SIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6ZG9jT" +
                "WsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjO" +
                "nNsZExheW91dE1rIGNJZD0iMjU5MTUyNDUyMCIgc2xkSWQ9IjIxNDc0ODM2NjMiLz48L3BjOnNsZExhe" +
                "W91dE1rTHN0PjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s" +
                "25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpd" +
                "mUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwM" +
                "jItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkT" +
                "WFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNa" +
                "yBjSWQ9IjI1OTE1MjQ1MjAiIHNsZElkPSIyMTQ3NDgzNjYzIi8+PGFjOnNwTWsgaWQ9IjIiIGNyZWF0a" +
                "W9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hYzpzcE1rTHN0P" +
                "jwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14" +
                "buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgT" +
                "Gl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iM" +
                "jAyMi0wMi0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzb" +
                "GRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91d" +
                "E1rIGNJZD0iMjU5MTUyNDUyMCIgc2xkSWQ9IjIxNDc0ODM2NjMiLz48YWM6c3BNayBpZD0iMyIgY3JlY" +
                "XRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L2FjOnNwTWtMc" +
                "3Q+PC9wYzpzcENoZz48L3BjOnNsZExheW91dENoZz48cGM6c2xkTGF5b3V0Q2hnIGNoZz0ibW9kU3AgZ" +
                "GVsIj48cGM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiM" +
                "jA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DN" +
                "EEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi41MDQiIHY9I" +
                "jMiLz48cGM6c2xkTGF5b3V0TWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwO" +
                "TU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjEyMDMwOTIwMzkiI" +
                "HNsZElkPSIyMTQ3NDgzNjY0Ii8+PC9wYzpzbGRMYXlvdXRNa0xzdD48cGM6c3BDaGcgY2hnPSJtb2QiP" +
                "jxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1N" +
                "DYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtN" +
                "EE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjQ0MSIgdj0iMiIvP" +
                "jxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkS" +
                "WQ9IjIxNDc0ODM2NjAiLz48cGM6c2xkTGF5b3V0TWsgY0lkPSIxMjAzMDkyMDM5IiBzbGRJZD0iMjE0N" +
                "zQ4MzY2NCIvPjxhYzpzcE1rIGlkPSIzIiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwM" +
                "DAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9Im1vZ" +
                "CI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwN" +
                "zU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBM" +
                "C00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyI" +
                "i8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzb" +
                "GRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjEyMDMwOTIwMzkiIHNsZElkPSIyM" +
                "TQ3NDgzNjY0Ii8+PGFjOnNwTWsgaWQ9IjQiIGNyZWF0aW9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtM" +
                "DAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c3BDaGc+PC9wYzpzbGRMYXlvdXRDa" +
                "Gc+PHBjOnNsZExheW91dENoZyBjaGc9Im1vZFNwIGRlbCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqb" +
                "iBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb" +
                "3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZ" +
                "HQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb" +
                "2NNay8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxNDc0ODM2NjAiLz48c" +
                "GM6c2xkTGF5b3V0TWsgY0lkPSIzNzMzMTcyMzM5IiBzbGRJZD0iMjE0NzQ4MzY2NSIvPjwvcGM6c2xkT" +
                "GF5b3V0TWtMc3Q+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14" +
                "buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgT" +
                "Gl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iM" +
                "jAyMi0wMi0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzb" +
                "GRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91d" +
                "E1rIGNJZD0iMzczMzE3MjMzOSIgc2xkSWQ9IjIxNDc0ODM2NjUiLz48YWM6c3BNayBpZD0iMiIgY3JlY" +
                "XRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L2FjOnNwTWtMc" +
                "3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJtb2QiPjxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gS" +
                "HXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93c" +
                "yBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0P" +
                "SIyMDIyLTAyLTI0VDA4OjI3OjE2LjQ0MSIgdj0iMiIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjO" +
                "nNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxNDc0ODM2NjAiLz48cGM6c2xkTGF5b" +
                "3V0TWsgY0lkPSIzNzMzMTcyMzM5IiBzbGRJZD0iMjE0NzQ4MzY2NSIvPjxhYzpzcE1rIGlkPSIzIiBjc" +
                "mVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa" +
                "0xzdD48L3BjOnNwQ2hnPjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqb" +
                "iBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb" +
                "3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZ" +
                "HQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48c" +
                "GM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMY" +
                "XlvdXRNayBjSWQ9IjM3MzMxNzIzMzkiIHNsZElkPSIyMTQ3NDgzNjY1Ii8+PGFjOnNwTWsgaWQ9IjQiI" +
                "GNyZWF0aW9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hYzpzc" +
                "E1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w" +
                "6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9Ildpb" +
                "mRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9I" +
                "iBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvP" +
                "jxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZ" +
                "ExheW91dE1rIGNJZD0iMzczMzE3MjMzOSIgc2xkSWQ9IjIxNDc0ODM2NjUiLz48YWM6c3BNayBpZD0iN" +
                "SIgY3JlYXRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L2FjO" +
                "nNwTWtMc3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJtb2QiPjxhYzpjaGdEYXRhIG5hbWU9Ik5nd" +
                "XnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV" +
                "2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCN" +
                "n0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjQ0MSIgdj0iMiIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNa" +
                "y8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxNDc0ODM2NjAiLz48cGM6c" +
                "2xkTGF5b3V0TWsgY0lkPSIzNzMzMTcyMzM5IiBzbGRJZD0iMjE0NzQ4MzY2NSIvPjxhYzpzcE1rIGlkP" +
                "SI2IiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvY" +
                "WM6c3BNa0xzdD48L3BjOnNwQ2hnPjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvdXRDaGcgY2hnP" +
                "SJkZWwiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZ" +
                "mIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0L" +
                "UM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgd" +
                "j0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0N" +
                "jA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzIxMDMxMjU1O" +
                "CIgc2xkSWQ9IjIxNDc0ODM2NjYiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnP" +
                "jxwYzpzbGRMYXlvdXRDaGcgY2hnPSJkZWwiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7Nua" +
                "CBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlI" +
                "iBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyL" +
                "TAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwY" +
                "zpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExhe" +
                "W91dE1rIGNJZD0iMzE0NjM4ODk4NCIgc2xkSWQ9IjIxNDc0ODM2NjciLz48L3BjOnNsZExheW91dE1rT" +
                "HN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvdXRDaGcgY2hnPSJtb2RTcCBkZWwiPjxwYzpja" +
                "GdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhM" +
                "yIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q" +
                "0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzb" +
                "GRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZ" +
                "ElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzE3MTg0MTQ1NCIgc2xkSWQ9IjIxN" +
                "Dc0ODM2NjgiLz48L3BjOnNsZExheW91dE1rTHN0PjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0Rhd" +
                "GEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwc" +
                "m92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtR" +
                "Dk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc" +
                "3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4M" +
                "zY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjMxNzE4NDE0NTQiIHNsZElkPSIyMTQ3NDgzNjY4Ii8+P" +
                "GFjOnNwTWsgaWQ9IjIiIGNyZWF0aW9uSWQ9InswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwM" +
                "DAwMDB9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c3BDaGc+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnR" +
                "GF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiI" +
                "HByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQ" +
                "S1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa" +
                "0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3N" +
                "DgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzE3MTg0MTQ1NCIgc2xkSWQ9IjIxNDc0ODM2NjgiL" +
                "z48YWM6c3BNayBpZD0iMyIgY3JlYXRpb25JZD0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwM" +
                "DAwMDAwMH0iLz48L2FjOnNwTWtMc3Q+PC9wYzpzcENoZz48cGM6c3BDaGcgY2hnPSJtb2QiPjxhYzpja" +
                "GdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhM" +
                "yIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q" +
                "0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjQ0MSIgdj0iMiIvPjxhYzpzc" +
                "E1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxN" +
                "Dc0ODM2NjAiLz48cGM6c2xkTGF5b3V0TWsgY0lkPSIzMTcxODQxNDU0IiBzbGRJZD0iMjE0NzQ4MzY2O" +
                "CIvPjxhYzpzcE1rIGlkPSI0IiBjcmVhdGlvbklkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwM" +
                "DAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L3BjOnNwQ2hnPjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzb" +
                "GRMYXlvdXRDaGcgY2hnPSJtb2RTcCBkZWwiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7Nua" +
                "CBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlI" +
                "iBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyL" +
                "TAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwY" +
                "zpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExhe" +
                "W91dE1rIGNJZD0iMTcxODk1ODI3NCIgc2xkSWQ9IjIxNDc0ODM2NjkiLz48L3BjOnNsZExheW91dE1rT" +
                "HN0PjxwYzpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4" +
                "bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsS" +
                "WQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItM" +
                "jRUMDg6Mjc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyT" +
                "WsgY0lkPSIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9I" +
                "jE3MTg5NTgyNzQiIHNsZElkPSIyMTQ3NDgzNjY5Ii8+PGFjOnNwTWsgaWQ9IjIiIGNyZWF0aW9uSWQ9I" +
                "nswMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c" +
                "3BDaGc+PHBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggT" +
                "mjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY" +
                "2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wM" +
                "i0yNFQwODoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0Z" +
                "XJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZ" +
                "D0iMTcxODk1ODI3NCIgc2xkSWQ9IjIxNDc0ODM2NjkiLz48YWM6c3BNayBpZD0iMyIgY3JlYXRpb25JZ" +
                "D0iezAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L2FjOnNwTWtMc3Q+PC9wY" +
                "zpzcENoZz48cGM6c3BDaGcgY2hnPSJtb2QiPjxhYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7Nua" +
                "CBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlI" +
                "iBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyL" +
                "TAyLTI0VDA4OjI3OjE2LjQ0MSIgdj0iMiIvPjxhYzpzcE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1hc" +
                "3Rlck1rIGNJZD0iMjQ2MDk1NDA3MCIgc2xkSWQ9IjIxNDc0ODM2NjAiLz48cGM6c2xkTGF5b3V0TWsgY" +
                "0lkPSIxNzE4OTU4Mjc0IiBzbGRJZD0iMjE0NzQ4MzY2OSIvPjxhYzpzcE1rIGlkPSI0IiBjcmVhdGlvb" +
                "klkPSJ7MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwfSIvPjwvYWM6c3BNa0xzdD48L" +
                "3BjOnNwQ2hnPjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvdXRDaGcgY2hnPSJkZWwiPjxwYzpja" +
                "GdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhM" +
                "yIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q" +
                "0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzb" +
                "GRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZ" +
                "ElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMjIwMjkwNTQ1MSIgc2xkSWQ9IjIxN" +
                "Dc0ODM2NzAiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvd" +
                "XRDaGcgY2hnPSJtb2RTcCBkZWwiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6r" +
                "XQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkP" +
                "SJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0V" +
                "DA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNY" +
                "XN0ZXJNayBjSWQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rI" +
                "GNJZD0iMzQ3OTQ0NTY1NyIgc2xkSWQ9IjIxNDc0ODM2NzEiLz48L3BjOnNsZExheW91dE1rTHN0PjxwY" +
                "zpzcENoZyBjaGc9Im1vZCI+PGFjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgd" +
                "XNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlY" +
                "i17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6M" +
                "jc6MTYuNDQxIiB2PSIyIi8+PGFjOnNwTWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkP" +
                "SIyNDYwOTU0MDcwIiBzbGRJZD0iMjE0NzQ4MzY2MCIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjM0Nzk0N" +
                "DU2NTciIHNsZElkPSIyMTQ3NDgzNjcxIi8+PGFjOnNwTWsgaWQ9IjIiIGNyZWF0aW9uSWQ9InswMDAwM" +
                "DAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDB9Ii8+PC9hYzpzcE1rTHN0PjwvcGM6c3BDaGc+P" +
                "HBjOnNwQ2hnIGNoZz0ibW9kIj48YWM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10I" +
                "iB1c2VySWQ9IjE5ZGZiMjA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV" +
                "2ViLXtDRUIyRTMzNC1DNEEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwO" +
                "DoyNzoxNi40NDEiIHY9IjIiLz48YWM6c3BNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjS" +
                "WQ9IjI0NjA5NTQwNzAiIHNsZElkPSIyMTQ3NDgzNjYwIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzQ3O" +
                "TQ0NTY1NyIgc2xkSWQ9IjIxNDc0ODM2NzEiLz48YWM6c3BNayBpZD0iMyIgY3JlYXRpb25JZD0iezAwM" +
                "DAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMH0iLz48L2FjOnNwTWtMc3Q+PC9wYzpzcENoZ" +
                "z48L3BjOnNsZExheW91dENoZz48L3BjOnNsZE1hc3RlckNoZz48cGM6c2xkTWFzdGVyQ2hnIGNoZz0iY" +
                "WRkIGFkZFNsZExheW91dCBtb2RTbGRMYXlvdXQiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu" +
                "7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZG93cyBMa" +
                "XZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyM" +
                "DIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRNYXN0ZXJNa0xzdD48cGM6ZG9jTWsvP" +
                "jxwYzpzbGRNYXN0ZXJNayBjSWQ9IjE0MTIzMTkzNjMiIHNsZElkPSIyMTQ3NDgzNjcyIi8+PC9wYzpzb" +
                "GRNYXN0ZXJNa0xzdD48cGM6c2xkTGF5b3V0Q2hnIGNoZz0iYWRkIG1vZCByZXBsSWQiPjxwYzpjaGdEY" +
                "XRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgc" +
                "HJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBL" +
                "UQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMY" +
                "XlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjE0MTIzMTkzNjMiIHNsZElkP" +
                "SIyMTQ3NDgzNjcyIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzQ2OTUyMTYzNSIgc2xkSWQ9IjIxNDc0O" +
                "DM2NzMiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvdXRDa" +
                "GcgY2hnPSJhZGQgbW9kIHJlcGxJZCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4" +
                "bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsS" +
                "WQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItM" +
                "jRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZ" +
                "E1hc3Rlck1rIGNJZD0iMTQxMjMxOTM2MyIgc2xkSWQ9IjIxNDc0ODM2NzIiLz48cGM6c2xkTGF5b3V0T" +
                "WsgY0lkPSIxNTk5NjM3NDYiIHNsZElkPSIyMTQ3NDgzNjc0Ii8+PC9wYzpzbGRMYXlvdXRNa0xzdD48L" +
                "3BjOnNsZExheW91dENoZz48cGM6c2xkTGF5b3V0Q2hnIGNoZz0iYWRkIG1vZCByZXBsSWQiPjxwYzpja" +
                "GdEYXRhIG5hbWU9Ik5ndXnDqm4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhM" +
                "yIgcHJvdmlkZXJJZD0iV2luZG93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q" +
                "0RBLUQ5NzA1QTZDQjVCNn0iIGR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzb" +
                "GRMYXlvdXRNa0xzdD48cGM6ZG9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjE0MTIzMTkzNjMiIHNsZ" +
                "ElkPSIyMTQ3NDgzNjcyIi8+PHBjOnNsZExheW91dE1rIGNJZD0iMzQ1MzE4ODU0MyIgc2xkSWQ9IjIxN" +
                "Dc0ODM2NzUiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvd" +
                "XRDaGcgY2hnPSJhZGQgbW9kIHJlcGxJZCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oI" +
                "E5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiI" +
                "GNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItM" +
                "DItMjRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb2NNay8+PHBjO" +
                "nNsZE1hc3Rlck1rIGNJZD0iMTQxMjMxOTM2MyIgc2xkSWQ9IjIxNDc0ODM2NzIiLz48cGM6c2xkTGF5b" +
                "3V0TWsgY0lkPSIxOTY3NjI2NDI4IiBzbGRJZD0iMjE0NzQ4MzY3NiIvPjwvcGM6c2xkTGF5b3V0TWtMc" +
                "3Q+PC9wYzpzbGRMYXlvdXRDaGc+PHBjOnNsZExheW91dENoZyBjaGc9ImFkZCBtb2QgcmVwbElkIj48c" +
                "GM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3NTQ2M" +
                "TE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwLTRBN" +
                "jAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi41MDQiIHY9IjMiLz48c" +
                "GM6c2xkTGF5b3V0TWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIxNDEyMzE5MzYzI" +
                "iBzbGRJZD0iMjE0NzQ4MzY3MiIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjUzMzcwODM0NCIgc2xkSWQ9I" +
                "jIxNDc0ODM2NzciLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMY" +
                "XlvdXRDaGcgY2hnPSJhZGQgbW9kIHJlcGxJZCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s" +
                "25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpd" +
                "mUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwM" +
                "jItMDItMjRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb2NNay8+P" +
                "HBjOnNsZE1hc3Rlck1rIGNJZD0iMTQxMjMxOTM2MyIgc2xkSWQ9IjIxNDc0ODM2NzIiLz48cGM6c2xkT" +
                "GF5b3V0TWsgY0lkPSIyODg1MTM1MDQ4IiBzbGRJZD0iMjE0NzQ4MzY3OCIvPjwvcGM6c2xkTGF5b3V0T" +
                "WtMc3Q+PC9wYzpzbGRMYXlvdXRDaGc+PHBjOnNsZExheW91dENoZyBjaGc9ImFkZCBtb2QgcmVwbElkI" +
                "j48cGM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiMjA3N" +
                "TQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DNEEwL" +
                "TRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi41MDQiIHY9IjMiL" +
                "z48cGM6c2xkTGF5b3V0TWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIxNDEyMzE5M" +
                "zYzIiBzbGRJZD0iMjE0NzQ4MzY3MiIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjQzNjgyMjA2NSIgc2xkS" +
                "WQ9IjIxNDc0ODM2NzkiLz48L3BjOnNsZExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzb" +
                "GRMYXlvdXRDaGcgY2hnPSJhZGQgbW9kIHJlcGxJZCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBId" +
                "eG7s25oIE5o4bqtdCIgdXNlcklkPSIxOWRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzI" +
                "ExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzMzQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9I" +
                "jIwMjItMDItMjRUMDg6Mjc6MTYuNTA0IiB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb2NNa" +
                "y8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iMTQxMjMxOTM2MyIgc2xkSWQ9IjIxNDc0ODM2NzIiLz48cGM6c" +
                "2xkTGF5b3V0TWsgY0lkPSIyOTI0MTM0NjE2IiBzbGRJZD0iMjE0NzQ4MzY4MCIvPjwvcGM6c2xkTGF5b" +
                "3V0TWtMc3Q+PC9wYzpzbGRMYXlvdXRDaGc+PHBjOnNsZExheW91dENoZyBjaGc9ImFkZCBtb2QgcmVwb" +
                "ElkIj48cGM6Y2hnRGF0YSBuYW1lPSJOZ3V5w6puIEh14buzbmggTmjhuq10IiB1c2VySWQ9IjE5ZGZiM" +
                "jA3NTQ2MTE0YTMiIHByb3ZpZGVySWQ9IldpbmRvd3MgTGl2ZSIgY2xJZD0iV2ViLXtDRUIyRTMzNC1DN" +
                "EEwLTRBNjAtOENEQS1EOTcwNUE2Q0I1QjZ9IiBkdD0iMjAyMi0wMi0yNFQwODoyNzoxNi41MDQiIHY9I" +
                "jMiLz48cGM6c2xkTGF5b3V0TWtMc3Q+PHBjOmRvY01rLz48cGM6c2xkTWFzdGVyTWsgY0lkPSIxNDEyM" +
                "zE5MzYzIiBzbGRJZD0iMjE0NzQ4MzY3MiIvPjxwYzpzbGRMYXlvdXRNayBjSWQ9IjI3ODk4MjE5ODciI" +
                "HNsZElkPSIyMTQ3NDgzNjgxIi8+PC9wYzpzbGRMYXlvdXRNa0xzdD48L3BjOnNsZExheW91dENoZz48c" +
                "GM6c2xkTGF5b3V0Q2hnIGNoZz0iYWRkIG1vZCByZXBsSWQiPjxwYzpjaGdEYXRhIG5hbWU9Ik5ndXnDq" +
                "m4gSHXhu7NuaCBOaOG6rXQiIHVzZXJJZD0iMTlkZmIyMDc1NDYxMTRhMyIgcHJvdmlkZXJJZD0iV2luZ" +
                "G93cyBMaXZlIiBjbElkPSJXZWIte0NFQjJFMzM0LUM0QTAtNEE2MC04Q0RBLUQ5NzA1QTZDQjVCNn0iI" +
                "GR0PSIyMDIyLTAyLTI0VDA4OjI3OjE2LjUwNCIgdj0iMyIvPjxwYzpzbGRMYXlvdXRNa0xzdD48cGM6Z" +
                "G9jTWsvPjxwYzpzbGRNYXN0ZXJNayBjSWQ9IjE0MTIzMTkzNjMiIHNsZElkPSIyMTQ3NDgzNjcyIi8+P" +
                "HBjOnNsZExheW91dE1rIGNJZD0iMjQ0MDg2ODA4NiIgc2xkSWQ9IjIxNDc0ODM2ODIiLz48L3BjOnNsZ" +
                "ExheW91dE1rTHN0PjwvcGM6c2xkTGF5b3V0Q2hnPjxwYzpzbGRMYXlvdXRDaGcgY2hnPSJhZGQgbW9kI" +
                "HJlcGxJZCI+PHBjOmNoZ0RhdGEgbmFtZT0iTmd1ecOqbiBIdeG7s25oIE5o4bqtdCIgdXNlcklkPSIxO" +
                "WRmYjIwNzU0NjExNGEzIiBwcm92aWRlcklkPSJXaW5kb3dzIExpdmUiIGNsSWQ9IldlYi17Q0VCMkUzM" +
                "zQtQzRBMC00QTYwLThDREEtRDk3MDVBNkNCNUI2fSIgZHQ9IjIwMjItMDItMjRUMDg6Mjc6MTYuNTA0I" +
                "iB2PSIzIi8+PHBjOnNsZExheW91dE1rTHN0PjxwYzpkb2NNay8+PHBjOnNsZE1hc3Rlck1rIGNJZD0iM" +
                "TQxMjMxOTM2MyIgc2xkSWQ9IjIxNDc0ODM2NzIiLz48cGM6c2xkTGF5b3V0TWsgY0lkPSIyMzU1NDg2M" +
                "TkyIiBzbGRJZD0iMjE0NzQ4MzY4MyIvPjwvcGM6c2xkTGF5b3V0TWtMc3Q+PC9wYzpzbGRMYXlvdXRDa" +
                "Gc+PC9wYzpzbGRNYXN0ZXJDaGc+PC9wYzpkb2NDaGc+PC9wYzpkb2NDaGdMc3Q+PC9wYzpjaGdJbmZvP" +
                "g==";

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

            part.Slide = slide;
        }
        
        private void GenerateImagePart(ref ImagePart part)
        {
            string base64 = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAeCAYAAAA2Lt7lAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAKoSURBVHgBrVbdcdpAEP72xIMfHEYeEr9GqSC4gkAFIRXYqcCiAnAFFhWEVGBcAaSCkAqiPGUmxoN4czKgy67+ODSSEDbfjJDE7e23u7c/oqVrOxr6iwY6AAJATxTUzZkX+DgClKFcYAN0FUJPhRhHgDKUm4i8wjEICPCLFoT4t3vi4KUEGjQqW2zgcAIOrf3gnnYygpYXeCHopkhYI2zjMOUOn993BWv66DZvIwL5eeMFQybpcty/cmjmyDygSxyANdYO35z4jVzxhsos2SAcUkSgx2naxq6rTkROWEKrezOdF+6rHkHdpe//8PcdoQIPbtNToOvklWtE0jiPrQELtzmmrdd+y1tVEyQx/Yn98FlRoKP0pj7f/QaHmkmDRtWuDadqzoKAz2pE2TmFvcRiVizyun/urcbmhkoCgh6YVnK4uq3dFjJ5dG0m07dlOlTZQpLLzlaQukX9SdJcsi+2lj7WJtBQ7e0zZlXNj2XHiVxHUrMWARnWs4XfUAGuo1n6/ISn2gSmoI1nopQgNCraAr1HBTgsWThPcBLUIuCKzAgktn8MJXlw1buJnJxVPQKJq97xQt8VDaFlv3mdVi8X5X1+vbIOeAt32ay3SFVPuX2wknDCSh1uEZeh3g4sBR3kNezpRacdab3Yj1QxV/rmc2x5I2oVqmqXBWtgKAiKZCTuXIQXfEljC8QguWQulHpgfmnIMJJ5If8vXLsnQ4g3vbUI87VWP8wa4PUrMmb5TrtOen2PU/IDK26n1r32Vl3URD6k7NVZI7a4OWBLh4nSDBaFYxwAiXsYH7QtXbclZyBupcrzWGvrFw5AfKh0wTPhE4cuqo1GriXvQJcc7B4SH8ankGSRUyLrn3vBHC+EfHjNipRL/8cRwAQkhTFJ3rlQ9KhsuDwH/wGwHyVceIMuPAAAAABJRU5ErkJggg==";

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 159963746u;

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
            aOffset.X = 534353;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6703695;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 534353;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6703695;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            placeholderShape.Index = 2u;
            placeholderShape.Type = PlaceholderValues.DateAndTime;
            placeholderShape.Size = PlaceholderSizeValues.Half;

            applicationNonVisualDrawingProperties.Append(placeholderShape);

            nonVisualShapeProperties.Append(applicationNonVisualDrawingProperties);

            shape.Append(nonVisualShapeProperties);

            shapeProperties = new ShapeProperties();

            aTransform2D = new A.Transform2D();

            aOffset = new A.Offset();
            aOffset.X = 534353;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1748790;
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
            aDefaultRunProperties.FontSize = 2040;

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aOffset.X = 2574608;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2623185;
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
            aDefaultRunProperties.FontSize = 2040;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aOffset.X = 5489258;
            aOffset.Y = 4237567;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1748790;
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
            aDefaultRunProperties.FontSize = 2040;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 1412319363u;

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
            slideLayoutId.Id = 2147483673u;
            slideLayoutId.RelationshipId = "rId1";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483674u;
            slideLayoutId.RelationshipId = "rId2";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483675u;
            slideLayoutId.RelationshipId = "rId3";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483676u;
            slideLayoutId.RelationshipId = "rId4";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483677u;
            slideLayoutId.RelationshipId = "rId5";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483678u;
            slideLayoutId.RelationshipId = "rId6";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483679u;
            slideLayoutId.RelationshipId = "rId7";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483680u;
            slideLayoutId.RelationshipId = "rId8";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483681u;
            slideLayoutId.RelationshipId = "rId9";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483682u;
            slideLayoutId.RelationshipId = "rId10";

            slideLayoutIdList.Append(slideLayoutId);

            slideLayoutId = new SlideLayoutId();
            slideLayoutId.Id = 2147483683u;
            slideLayoutId.RelationshipId = "rId11";

            slideLayoutIdList.Append(slideLayoutId);

            slideMaster.Append(slideLayoutIdList);

            TextStyles textStyles = new TextStyles();

            TitleStyle titleStyle = new TitleStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.DefaultTabSize = 914400;
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
            aDefaultRunProperties.FontSize = 4400;
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
            aLevel1ParagraphProperties.LeftMargin = 228600;
            aLevel1ParagraphProperties.Indent = -228600;
            aLevel1ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 1000;

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
            aDefaultRunProperties.FontSize = 2800;
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
            aLevel2ParagraphProperties.LeftMargin = 685800;
            aLevel2ParagraphProperties.Indent = -228600;
            aLevel2ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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
            aDefaultRunProperties.FontSize = 2400;
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
            aLevel3ParagraphProperties.LeftMargin = 1143000;
            aLevel3ParagraphProperties.Indent = -228600;
            aLevel3ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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
            aDefaultRunProperties.FontSize = 2000;
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
            aLevel4ParagraphProperties.LeftMargin = 1600200;
            aLevel4ParagraphProperties.Indent = -228600;
            aLevel4ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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

            bodyStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 2057400;
            aLevel5ParagraphProperties.Indent = -228600;
            aLevel5ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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

            bodyStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 2514600;
            aLevel6ParagraphProperties.Indent = -228600;
            aLevel6ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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

            bodyStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 2971800;
            aLevel7ParagraphProperties.Indent = -228600;
            aLevel7ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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

            bodyStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 3429000;
            aLevel8ParagraphProperties.Indent = -228600;
            aLevel8ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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

            bodyStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 3886200;
            aLevel9ParagraphProperties.Indent = -228600;
            aLevel9ParagraphProperties.DefaultTabSize = 914400;
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
            aSpacingPoints.Val = 500;

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
            aLevel1ParagraphProperties.DefaultTabSize = 914400;
            aLevel1ParagraphProperties.RightToLeft = false;
            aLevel1ParagraphProperties.EastAsianLineBreak = true;
            aLevel1ParagraphProperties.LatinLineBreak = false;
            aLevel1ParagraphProperties.Height = true;
            aLevel1ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Left;

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

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            otherStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
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

            otherStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
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

            otherStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
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

            otherStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
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

            otherStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
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

            otherStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
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

            otherStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
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

            otherStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
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
            aOffset.X = 535365;
            aOffset.Y = 304800;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2506801;
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
            aDefaultRunProperties.FontSize = 5440;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 3304282;
            aOffset.Y = 658284;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3934778;
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
            aDefaultRunProperties.FontSize = 5440;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 4760;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 4080;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 535365;
            aOffset.Y = 1371600;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2506801;
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
            aDefaultRunProperties.FontSize = 2720;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2380;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2040;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 2924134616u;

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
            aOffset.X = 530304;
            aOffset.Y = 1139826;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6703695;
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
            aDefaultRunProperties.FontSize = 10200;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 530304;
            aOffset.Y = 3059642;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6703695;
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
            aDefaultRunProperties.FontSize = 4080;

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
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

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
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3060;

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
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 3453188543u;

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            A.Text aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 436822065u;

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
            aColorScheme.Name = "Office Theme";

            A.Dark1Color aDark1Color = new A.Dark1Color();

            A.SystemColor aSystemColor = new A.SystemColor();
            aSystemColor.LastColor = "000000";
            aSystemColor.Val = A.SystemColorValues.WindowText;

            aDark1Color.Append(aSystemColor);

            aColorScheme.Append(aDark1Color);

            A.Light1Color aLight1Color = new A.Light1Color();

            aSystemColor = new A.SystemColor();
            aSystemColor.LastColor = "FFFFFF";
            aSystemColor.Val = A.SystemColorValues.Window;

            aLight1Color.Append(aSystemColor);

            aColorScheme.Append(aLight1Color);

            A.Dark2Color aDark2Color = new A.Dark2Color();

            A.RgbColorModelHex aRgbColorModelHex = new A.RgbColorModelHex();
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
            aRgbColorModelHex.Val = "4472C4";

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
            aRgbColorModelHex.Val = "5B9BD5";

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
            aFontScheme.Name = "Office Theme";

            A.MajorFont aMajorFont = new A.MajorFont();

            A.LatinFont aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "Calibri Light";
            aLatinFont.Panose = "020F0302020204030204";

            aMajorFont.Append(aLatinFont);

            A.EastAsianFont aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "";

            aMajorFont.Append(aEastAsianFont);

            A.ComplexScriptFont aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "";

            aMajorFont.Append(aComplexScriptFont);

            A.SupplementalFont aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Jpan";
            aSupplementalFont.Typeface = "游ゴシック Light";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hang";
            aSupplementalFont.Typeface = "맑은 고딕";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hans";
            aSupplementalFont.Typeface = "等线 Light";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hant";
            aSupplementalFont.Typeface = "新細明體";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Arab";
            aSupplementalFont.Typeface = "Times New Roman";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hebr";
            aSupplementalFont.Typeface = "Times New Roman";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Thai";
            aSupplementalFont.Typeface = "Angsana New";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Ethi";
            aSupplementalFont.Typeface = "Nyala";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Beng";
            aSupplementalFont.Typeface = "Vrinda";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Gujr";
            aSupplementalFont.Typeface = "Shruti";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Khmr";
            aSupplementalFont.Typeface = "MoolBoran";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Knda";
            aSupplementalFont.Typeface = "Tunga";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Guru";
            aSupplementalFont.Typeface = "Raavi";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Cans";
            aSupplementalFont.Typeface = "Euphemia";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Cher";
            aSupplementalFont.Typeface = "Plantagenet Cherokee";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Yiii";
            aSupplementalFont.Typeface = "Microsoft Yi Baiti";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Tibt";
            aSupplementalFont.Typeface = "Microsoft Himalaya";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Thaa";
            aSupplementalFont.Typeface = "MV Boli";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Deva";
            aSupplementalFont.Typeface = "Mangal";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Telu";
            aSupplementalFont.Typeface = "Gautami";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Taml";
            aSupplementalFont.Typeface = "Latha";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Syrc";
            aSupplementalFont.Typeface = "Estrangelo Edessa";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Orya";
            aSupplementalFont.Typeface = "Kalinga";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Mlym";
            aSupplementalFont.Typeface = "Kartika";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Laoo";
            aSupplementalFont.Typeface = "DokChampa";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Sinh";
            aSupplementalFont.Typeface = "Iskoola Pota";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Mong";
            aSupplementalFont.Typeface = "Mongolian Baiti";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Viet";
            aSupplementalFont.Typeface = "Times New Roman";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Uigh";
            aSupplementalFont.Typeface = "Microsoft Uighur";

            aMajorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Geor";
            aSupplementalFont.Typeface = "Sylfaen";

            aMajorFont.Append(aSupplementalFont);

            aFontScheme.Append(aMajorFont);

            A.MinorFont aMinorFont = new A.MinorFont();

            aLatinFont = new A.LatinFont();
            aLatinFont.Typeface = "Calibri";
            aLatinFont.Panose = "020F0502020204030204";

            aMinorFont.Append(aLatinFont);

            aEastAsianFont = new A.EastAsianFont();
            aEastAsianFont.Typeface = "";

            aMinorFont.Append(aEastAsianFont);

            aComplexScriptFont = new A.ComplexScriptFont();
            aComplexScriptFont.Typeface = "";

            aMinorFont.Append(aComplexScriptFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Jpan";
            aSupplementalFont.Typeface = "游ゴシック";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hang";
            aSupplementalFont.Typeface = "맑은 고딕";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hans";
            aSupplementalFont.Typeface = "等线";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hant";
            aSupplementalFont.Typeface = "新細明體";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Arab";
            aSupplementalFont.Typeface = "Arial";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Hebr";
            aSupplementalFont.Typeface = "Arial";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Thai";
            aSupplementalFont.Typeface = "Cordia New";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Ethi";
            aSupplementalFont.Typeface = "Nyala";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Beng";
            aSupplementalFont.Typeface = "Vrinda";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Gujr";
            aSupplementalFont.Typeface = "Shruti";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Khmr";
            aSupplementalFont.Typeface = "DaunPenh";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Knda";
            aSupplementalFont.Typeface = "Tunga";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Guru";
            aSupplementalFont.Typeface = "Raavi";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Cans";
            aSupplementalFont.Typeface = "Euphemia";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Cher";
            aSupplementalFont.Typeface = "Plantagenet Cherokee";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Yiii";
            aSupplementalFont.Typeface = "Microsoft Yi Baiti";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Tibt";
            aSupplementalFont.Typeface = "Microsoft Himalaya";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Thaa";
            aSupplementalFont.Typeface = "MV Boli";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Deva";
            aSupplementalFont.Typeface = "Mangal";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Telu";
            aSupplementalFont.Typeface = "Gautami";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Taml";
            aSupplementalFont.Typeface = "Latha";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Syrc";
            aSupplementalFont.Typeface = "Estrangelo Edessa";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Orya";
            aSupplementalFont.Typeface = "Kalinga";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Mlym";
            aSupplementalFont.Typeface = "Kartika";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Laoo";
            aSupplementalFont.Typeface = "DokChampa";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Sinh";
            aSupplementalFont.Typeface = "Iskoola Pota";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Mong";
            aSupplementalFont.Typeface = "Mongolian Baiti";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Viet";
            aSupplementalFont.Typeface = "Arial";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Uigh";
            aSupplementalFont.Typeface = "Microsoft Uighur";

            aMinorFont.Append(aSupplementalFont);

            aSupplementalFont = new A.SupplementalFont();
            aSupplementalFont.Script = "Geor";
            aSupplementalFont.Typeface = "Sylfaen";

            aMinorFont.Append(aSupplementalFont);

            aFontScheme.Append(aMinorFont);

            aThemeElements.Append(aFontScheme);

            A.FormatScheme aFormatScheme = new A.FormatScheme();
            aFormatScheme.Name = "Office Theme";

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
            aOffset.X = 971550;
            aOffset.Y = 748242;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 5829300;
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
            aDefaultRunProperties.FontSize = 10200;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 971550;
            aOffset.Y = 2401359;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 5829300;
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
            aDefaultRunProperties.FontSize = 4080;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;
            aLevel2ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;
            aLevel3ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3060;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;
            aLevel4ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;
            aLevel5ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;
            aLevel6ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;
            aLevel7ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;
            aLevel8ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;
            aLevel9ParagraphProperties.Alignment = A.TextAlignmentTypeValues.Center;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            aRun = new A.Run();

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master subtitle style");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 3469521635u;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 2885135048u;

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
            aOffset.X = 5562124;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 1675924;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 534353;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 4930616;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 2355486192u;

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
            aOffset.X = 535365;
            aOffset.Y = 243417;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 6703695;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 535365;
            aOffset.Y = 1120775;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3288089;
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
            aDefaultRunProperties.FontSize = 4080;
            aDefaultRunProperties.Bold = true;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;
            aDefaultRunProperties.Bold = true;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3060;
            aDefaultRunProperties.Bold = true;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aOffset.X = 535365;
            aOffset.Y = 1670050;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3288089;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 3934778;
            aOffset.Y = 1120775;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3304282;
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
            aDefaultRunProperties.FontSize = 4080;
            aDefaultRunProperties.Bold = true;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;
            aDefaultRunProperties.Bold = true;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3060;
            aDefaultRunProperties.Bold = true;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
            aDefaultRunProperties.Bold = true;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2720;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aOffset.X = 3934778;
            aOffset.Y = 1670050;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3304282;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 533708344u;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 2440868086u;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aOffset.X = 534353;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3303270;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            aOffset.X = 3934778;
            aOffset.Y = 1217083;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3303270;
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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Fifth level");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 1967626428u;

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
            aOffset.X = 535365;
            aOffset.Y = 304800;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2506801;
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
            aDefaultRunProperties.FontSize = 5440;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            textBody.Append(aListStyle);

            A.Paragraph aParagraph = new A.Paragraph();

            A.Run aRun = new A.Run();

            A.RunProperties aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            A.Text aText = new A.Text("Click to edit Master title style");

            aRun.Append(aText);

            aParagraph.Append(aRun);

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
            aShapeLocks.NoChangeAspect = true;

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
            aOffset.X = 3304282;
            aOffset.Y = 658284;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 3934778;
            aExtents.Cy = 3249083;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            shape.Append(shapeProperties);

            textBody = new TextBody();

            aBodyProperties = new A.BodyProperties();
            aBodyProperties.Anchor = A.TextAnchoringTypeValues.Top;

            textBody.Append(aBodyProperties);

            aListStyle = new A.ListStyle();

            aLevel1ParagraphProperties = new A.Level1ParagraphProperties();
            aLevel1ParagraphProperties.LeftMargin = 0;
            aLevel1ParagraphProperties.Indent = 0;

            A.NoBullet aNoBullet = new A.NoBullet();

            aLevel1ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 5440;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            A.Level2ParagraphProperties aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 4760;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            A.Level3ParagraphProperties aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 4080;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            A.Level4ParagraphProperties aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            A.Level5ParagraphProperties aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            A.Level6ParagraphProperties aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            A.Level7ParagraphProperties aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            A.Level8ParagraphProperties aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            A.Level9ParagraphProperties aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 3400;

            aLevel9ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel9ParagraphProperties);

            textBody.Append(aListStyle);

            aParagraph = new A.Paragraph();

            A.EndParagraphRunProperties aEndParagraphRunProperties = new A.EndParagraphRunProperties();
            aEndParagraphRunProperties.Language = "en-US";
            aEndParagraphRunProperties.Dirty = false;

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
            aOffset.X = 535365;
            aOffset.Y = 1371600;

            aTransform2D.Append(aOffset);

            aExtents = new A.Extents();
            aExtents.Cx = 2506801;
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
            aDefaultRunProperties.FontSize = 2720;

            aLevel1ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel1ParagraphProperties);

            aLevel2ParagraphProperties = new A.Level2ParagraphProperties();
            aLevel2ParagraphProperties.LeftMargin = 777240;
            aLevel2ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel2ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2380;

            aLevel2ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel2ParagraphProperties);

            aLevel3ParagraphProperties = new A.Level3ParagraphProperties();
            aLevel3ParagraphProperties.LeftMargin = 1554480;
            aLevel3ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel3ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 2040;

            aLevel3ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel3ParagraphProperties);

            aLevel4ParagraphProperties = new A.Level4ParagraphProperties();
            aLevel4ParagraphProperties.LeftMargin = 2331720;
            aLevel4ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel4ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel4ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel4ParagraphProperties);

            aLevel5ParagraphProperties = new A.Level5ParagraphProperties();
            aLevel5ParagraphProperties.LeftMargin = 3108960;
            aLevel5ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel5ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel5ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel5ParagraphProperties);

            aLevel6ParagraphProperties = new A.Level6ParagraphProperties();
            aLevel6ParagraphProperties.LeftMargin = 3886200;
            aLevel6ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel6ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel6ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel6ParagraphProperties);

            aLevel7ParagraphProperties = new A.Level7ParagraphProperties();
            aLevel7ParagraphProperties.LeftMargin = 4663440;
            aLevel7ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel7ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel7ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel7ParagraphProperties);

            aLevel8ParagraphProperties = new A.Level8ParagraphProperties();
            aLevel8ParagraphProperties.LeftMargin = 5440680;
            aLevel8ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel8ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

            aLevel8ParagraphProperties.Append(aDefaultRunProperties);

            aListStyle.Append(aLevel8ParagraphProperties);

            aLevel9ParagraphProperties = new A.Level9ParagraphProperties();
            aLevel9ParagraphProperties.LeftMargin = 6217920;
            aLevel9ParagraphProperties.Indent = 0;

            aNoBullet = new A.NoBullet();

            aLevel9ParagraphProperties.Append(aNoBullet);

            aDefaultRunProperties = new A.DefaultRunProperties();
            aDefaultRunProperties.FontSize = 1700;

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
            aRunProperties.Dirty = false;

            aRun.Append(aRunProperties);

            aText = new A.Text("Click to edit Master text styles");

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
            aField.Id = "{C764DE79-268F-4C1A-8933-263129D2AF90}";
            aField.Type = "datetimeFigureOut";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("2/24/2022");

            aField.Append(aText);

            aParagraph.Append(aField);

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
            aEndParagraphRunProperties.Dirty = false;

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
            aField.Id = "{48F63A3B-78C7-47BE-AE5E-E10140E04643}";
            aField.Type = "slidenum";

            aRunProperties = new A.RunProperties();
            aRunProperties.Language = "en-US";
            aRunProperties.Dirty = false;

            aField.Append(aRunProperties);

            aText = new A.Text("‹#›");

            aField.Append(aText);

            aParagraph.Append(aField);

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

            p14CreationId.Val = 2789821987u;

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
        
        private void GenerateViewPropertiesPart(ref ViewPropertiesPart part)
        {
            ViewProperties viewProperties = new ViewProperties();

            viewProperties.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            NormalViewProperties normalViewProperties = new NormalViewProperties();
            normalViewProperties.HorizontalBarState = SplitterBarStateValues.Maximized;

            RestoredLeft restoredLeft = new RestoredLeft();
            restoredLeft.Size = 19972;
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
            aScaleX.Numerator = 86;
            aScaleX.Denominator = 100;

            scaleFactor.Append(aScaleX);

            A.ScaleY aScaleY = new A.ScaleY();
            aScaleY.Numerator = 86;
            aScaleY.Denominator = 100;

            scaleFactor.Append(aScaleY);

            commonViewProperties.Append(scaleFactor);

            Origin origin = new Origin();
            origin.X = 96;
            origin.Y = 888;

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
        
        private void GenerateExtendedFilePropertiesPart(ref ExtendedFilePropertiesPart part)
        {
            AP.Properties apProperties = new AP.Properties();

            apProperties.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");

            AP.Template apTemplate = new AP.Template("office theme");

            apProperties.Append(apTemplate);

            AP.TotalTime apTotalTime = new AP.TotalTime("0");

            apProperties.Append(apTotalTime);

            AP.Words apWords = new AP.Words("0");

            apProperties.Append(apWords);

            AP.Application apApplication = new AP.Application("Microsoft Office PowerPoint");

            apProperties.Append(apApplication);

            AP.PresentationFormat apPresentationFormat = new AP.PresentationFormat("Custom");

            apProperties.Append(apPresentationFormat);

            AP.Paragraphs apParagraphs = new AP.Paragraphs("0");

            apProperties.Append(apParagraphs);

            AP.Slides apSlides = new AP.Slides("1");

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
            vtVTVector.Size = 4u;
            vtVTVector.BaseType = VT.VectorBaseValues.Variant;

            VT.Variant vtVariant = new VT.Variant();

            VT.VTLPSTR vtVTLPSTR = new VT.VTLPSTR("Theme");

            vtVariant.Append(vtVTLPSTR);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            VT.VTInt32 vtVTInt32 = new VT.VTInt32("1");

            vtVariant.Append(vtVTInt32);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTLPSTR = new VT.VTLPSTR("Slide Titles");

            vtVariant.Append(vtVTLPSTR);

            vtVTVector.Append(vtVariant);

            vtVariant = new VT.Variant();

            vtVTInt32 = new VT.VTInt32("1");

            vtVariant.Append(vtVTInt32);

            vtVTVector.Append(vtVariant);

            apHeadingPairs.Append(vtVTVector);

            apProperties.Append(apHeadingPairs);

            AP.TitlesOfParts apTitlesOfParts = new AP.TitlesOfParts();

            vtVTVector = new VT.VTVector();
            vtVTVector.Size = 2u;
            vtVTVector.BaseType = VT.VectorBaseValues.Lpstr;

            vtVTLPSTR = new VT.VTLPSTR("Office Theme");

            vtVTVector.Append(vtVTLPSTR);

            vtVTLPSTR = new VT.VTLPSTR("PowerPoint Presentation");

            vtVTVector.Append(vtVTLPSTR);

            apTitlesOfParts.Append(vtVTVector);

            apProperties.Append(apTitlesOfParts);

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