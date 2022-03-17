using Newtonsoft.Json;
using OT.WDA.VVAExport.Models;
using OT.WDA.VVAExport.VVAPresentation;
using System.Collections.Generic;
using System.Diagnostics;

namespace OT.WDA.VVAExport
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            IPresentationBuilder presentationBuilder = new PresentationBuilder();
            var filePath = presentationBuilder.CreatePackage(slides);

            using (var process = new Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = filePath;

                process.Start();
            }
        }
    }
}