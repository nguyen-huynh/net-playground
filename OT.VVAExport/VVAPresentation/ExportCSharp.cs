using DocumentFormat.OpenXml.Packaging;
using Microsoft.CSharp;
using Serialize.OpenXml.CodeGen;
using System.IO;

namespace OT.VVAExport.VVAPresentation
{
    public class ExportCSharp
    {
        public void Excute(string sourcePath = @"./VVAVideo1.pptx", string targetPath = @"./VVAVideo1.cs")
        {
            var sourceFile = new FileInfo(sourcePath);
            var targetFile = new FileInfo(targetPath);

            using (var source = sourceFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var ppt = PresentationDocument.Open(source, false))
                {
                    if (ppt != null)
                    {
                        // Generate VB.NET source code
                        var cSharp = new CSharpCodeProvider();

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