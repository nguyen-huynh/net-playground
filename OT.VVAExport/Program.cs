﻿using DocumentFormat.OpenXml.Packaging;
using Microsoft.CSharp;
using Serialize.OpenXml.CodeGen;
using System;
using System.IO;

namespace OT.VVAExport
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var slides = JsonConvert.DeserializeObject<IEnumerable<VVASlide>>(System.IO.File.ReadAllText("./data.json"));

            var sourceFile = new FileInfo(@"./Sample1.xlsx");
            var targetFile = new FileInfo(@"./Sample1.cs");

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
            Console.WriteLine("Press any key to quit");
            Console.ReadKey(true);
        }
    }
}