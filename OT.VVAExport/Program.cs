using DocumentFormat.OpenXml.Drawing;

namespace OT.VVAExport
{
  using OpenXmlSample;
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

            // var exportTool = new ExportCSharp();
            // exportTool.Excute();

            ////CreatePresentation($@"./Outputs/VVAExported_{DateTime.Now.ToString("HHmmss")}.pptx");
            var filePath = System.IO.Path.GetFullPath($@"./Outputs/VVAExported{DateTime.Now.ToString("HHmmss")}.pptx");
            //PresentationBuilder presentationBuilder = new PresentationBuilder();
            //presentationBuilder.Create(filePath);
            var builder = new PresentationDocumentBuilderClass();
            builder.CreatePackage(filePath);

            using (var process = new System.Diagnostics.Process())
            {
               process.StartInfo.UseShellExecute = true;
               process.StartInfo.FileName = filePath;

               process.Start();
            }
        }
    }
}