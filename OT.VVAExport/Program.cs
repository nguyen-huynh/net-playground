namespace OT.VVAExport
{
    using OT.VVAExport.VVAPresentation;
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            Console.WriteLine("1. Generate CSharp file , 2. Export VVA");
            var toolChoice = Console.ReadLine();

            if(toolChoice == "1")
            {
                var exportTool = new ExportCSharp();
                exportTool.Excute();
            }
            else if (toolChoice == "2")
            {
                //// Export VVA Slides
                if (!Directory.Exists(Path.Combine(@"C:\Users\hnnguyen\Desktop\Outputs")))
                    _ = Directory.CreateDirectory(Path.Combine(@"C:\Users\hnnguyen\Desktop\Outputs"));

                var filePath = Path.Combine(@"C:\Users\hnnguyen\Desktop", $@"Outputs/VVAExported{DateTime.Now.ToString("HHmmss")}.pptx");
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
}