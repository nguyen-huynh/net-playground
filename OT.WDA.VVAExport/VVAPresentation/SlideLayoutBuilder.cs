namespace OT.WDA.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;

    using P = DocumentFormat.OpenXml.Presentation;

    public partial class PresentationBuilder
    {
        private void GenerateSlideLayoutPart(ref SlideLayoutPart openingSlideLayoutPart)
        {
            SlideLayout slideLayout = new SlideLayout();

            slideLayout.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideLayout.Preserve = true;
            slideLayout.Type = SlideLayoutValues.Object;

            slideLayout.Append(new CommonSlideData(new ShapeTree(
              new P.NonVisualGroupShapeProperties(
              new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
              new P.NonVisualGroupShapeDrawingProperties(),
              new ApplicationNonVisualDrawingProperties()),
              new GroupShapeProperties(new TransformGroup()),
              new P.Shape(
              new P.NonVisualShapeProperties(
                new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "" },
                new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
              new P.ShapeProperties(),
              new P.TextBody(
                new BodyProperties(),
                new ListStyle(),
                new Paragraph(new EndParagraphRunProperties()))))),
            new ColorMapOverride(new MasterColorMapping()));

            openingSlideLayoutPart.SlideLayout = slideLayout;
        }
    }
}