namespace OT.VVAExport
{
    using Newtonsoft.Json;
    using OT.VVAExport.VVAPresentation;
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(args));
            //var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            var toolChoice = args.Length > 0 ? args[0] : string.Empty;
            if (string.IsNullOrEmpty(toolChoice))
            {
                Console.WriteLine("1. Generate CSharp file , 2. Export VVA");
                toolChoice = Console.ReadLine();
            }
            if(toolChoice == "1")
            {
                var exportTool = new ExportCSharp();
                exportTool.Excute("./Examples/Inputs/VideoExample.pptx");
                //exportTool.Excute("./Examples/Outputs/VVAExported191416.pptx");
            }
            else if (toolChoice == "2")
            {
                //// Export VVA Slides
                if (!Directory.Exists(Path.GetFullPath("./Examples/Outputs")))
                    _ = Directory.CreateDirectory(Path.GetFullPath("./Examples/Outputs"));

                var filePath = Path.Combine(Path.GetFullPath("./Examples/Outputs"), $@"VVAExported{DateTime.Now.ToString("HHmmss")}.pptx");
                var builder = new PresentationBuilder();
                builder.Create(filePath);

                //var builder = new OpenXmlSample.PresentationDocumentBuilderClass();
                //builder.CreatePackage(filePath);

                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = filePath;

                    process.Start();
                }
            }
        }
    }
}