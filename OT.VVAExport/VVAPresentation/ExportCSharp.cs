using DocumentFormat.OpenXml.Packaging;
using Microsoft.CSharp;
using Serialize.OpenXml.CodeGen;
using System.IO;

namespace OT.VVAExport.VVAPresentation
{
    public class ExportCSharp
    {
        public void Excute(string sourcePath = @"./VVASample.pptx")
        {
            var sourceFile = new FileInfo(sourcePath);
            var targetFile = new FileInfo(Path.GetFileNameWithoutExtension(sourcePath) + ".cs");

            using (var source = sourceFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var ppt = PresentationDocument.Open(source, false))
                {
                    if (ppt != null)
                    {
                        // Generate VB.NET source code
#pragma warning disable CA1416 // Validate platform compatibility
                        var cSharp = new CSharpCodeProvider();
#pragma warning restore CA1416 // Validate platform compatibility

                        // Save the source code to the target file
                        using (var target = targetFile.Open(FileMode.Create, FileAccess.ReadWrite))
                        {
                            using (var tw = new StreamWriter(target))
                            {
                                // Providing the CodeDomProvider object as a parameter will
                                // cause the method to return the source code as a string
                                tw.Write(ppt.GenerateSourceCode(cSharp).Trim());
                            }
                            target.Close();
                        }
                    }
                }
                source.Close();
            }
        }
    }
}