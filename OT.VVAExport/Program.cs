namespace OT.VVAExport
{
    using OT.VVAExport.VVAPresentation;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            // var exportTool = new ExportCSharp();
            // exportTool.Excute();

            ////CreatePresentation($@"./Outputs/VVAExported_{DateTime.Now.ToString("HHmmss")}.pptx");
            var filePath = System.IO.Path.GetFullPath($@"./Outputs/VVAExported{DateTime.Now.ToString("HHmmss")}.pptx");
            //PresentationBuilder presentationBuilder = new PresentationBuilder();
            //presentationBuilder.Create(filePath);
            var builder = new PresentationBuilder();
            builder.Create(filePath);

            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = filePath;

                process.Start();
            }
        }
    }
}