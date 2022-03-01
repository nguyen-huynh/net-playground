namespace OT.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using A = DocumentFormat.OpenXml.Drawing;

    using System;
    using System.IO;
    using A16 = DocumentFormat.OpenXml.Office2016.Drawing;
    using AP = DocumentFormat.OpenXml.ExtendedProperties;
    using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
    using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
    using VT = DocumentFormat.OpenXml.VariantTypes;
    using IO = System.IO;

    /// <summary>
    /// Follow the OpenXml Docs
    /// <para>Refs: 
    ///     <see href="https://docs.microsoft.com/en-us/office/open-xml/working-with-presentationml-documents">Working with PresentationML documents (Open XML SDK)</see>
    /// </para>
    /// </summary>
    public class PresentationBuilder
    {
        public void Create(string? filePath = null)
        {
            PresentationDocument presentationDocument = null;
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetTempPath(), $"Presentation_{DateTime.Now.ToString("HHmmss")}.pptx");

                if (!IO.Path.IsPathFullyQualified(filePath))
                    filePath = IO.Path.Combine(IO.Path.GetFullPath(filePath));

                presentationDocument = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation);
                PresentationPart presentationPart = presentationDocument.AddPresentationPart();
                presentationPart.Presentation = new Presentation();

                // Close the presentation handle
                presentationDocument.Close();
            }
            finally
            {
                if ((presentationDocument != null))
                {
                    presentationDocument.Dispose();
                }
            }
        }

        
    }
}