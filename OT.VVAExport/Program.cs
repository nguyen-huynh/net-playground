using DocumentFormat.OpenXml.Drawing;

namespace OT.VVAExport
{
    using OT.VVAExport.VVAPresentation;
    using System;

    internal class Program
    {
        private static RgbColorModelHex _darkColor = new RgbColorModelHex() { Val = "2A2835" };
        private static RgbColorModelHex _orangeColor = new RgbColorModelHex() { Val = "ED7D31" };
        private static RgbColorModelHex _whiteColor = new RgbColorModelHex() { Val = "FFFFFF" };

        private static void Main(string[] args)
        {
            //var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            //var sourceFile = new FileInfo(@"./VVAExported.pptx");
            //var targetFile = new FileInfo(@"./VVAExported.cs");

            //using (var source = sourceFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    using (var ppt = PresentationDocument.Open(source, false))
            //    {
            //        if (ppt != null)
            //        {
            //            // Generate VB.NET source code
            //            var cSharp = new CSharpCodeProvider();

            //            // Save the source code to the target file
            //            using (var target = targetFile.Open(FileMode.Create, FileAccess.ReadWrite))
            //            {
            //                using (var tw = new StreamWriter(target))
            //                {
            //                    // Providing the CodeDomProvider object as a parameter will
            //                    // cause the method to return the source code as a string
            //                    tw.Write(ppt.GenerateSourceCode(cSharp).Trim());
            //                }
            //                target.Close();
            //            }
            //        }
            //    }
            //    source.Close();
            //}

            //CreatePresentation($@"./Outputs/VVAExported_{DateTime.Now.ToString("HHmmss")}.pptx");
            var filePath = System.IO.Path.GetFullPath($@"./Outputs/VVAExported{DateTime.Now.ToString("HHmmss")}.pptx");
            PresentationBuilder presentationBuilder = new PresentationBuilder();
            presentationBuilder.Create(filePath);

            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = filePath;

                process.Start();
            }
        }
    }
}