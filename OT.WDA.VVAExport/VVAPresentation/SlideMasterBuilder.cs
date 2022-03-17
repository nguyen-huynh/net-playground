namespace OT.WDA.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;

    using D = DocumentFormat.OpenXml.Drawing;
    using P = DocumentFormat.OpenXml.Presentation;

    public partial class PresentationBuilder
    {
        private void GenerateSlideMasterPart(ref SlideMasterPart slideMasterPart)
        {
            SlideMaster slideMaster = new SlideMaster();

            slideMaster.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideMaster.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideMaster.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            slideMaster.Append(
                new CommonSlideData(new ShapeTree(
              new P.NonVisualGroupShapeProperties(
              new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" },
              new P.NonVisualGroupShapeDrawingProperties(),
              new ApplicationNonVisualDrawingProperties()),
              new GroupShapeProperties(new TransformGroup()),
              new P.Shape(
              new P.NonVisualShapeProperties(
                new P.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title Placeholder 1" },
                new P.NonVisualShapeDrawingProperties(new ShapeLocks() { NoGrouping = true }),
                new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title })),
              new P.ShapeProperties(),
              new P.TextBody(
                new BodyProperties(),
                new ListStyle(),
                new Paragraph())))),
            new P.ColorMap() { Background1 = D.ColorSchemeIndexValues.Light1, Text1 = D.ColorSchemeIndexValues.Dark1, Background2 = D.ColorSchemeIndexValues.Light2, Text2 = D.ColorSchemeIndexValues.Dark2, Accent1 = D.ColorSchemeIndexValues.Accent1, Accent2 = D.ColorSchemeIndexValues.Accent2, Accent3 = D.ColorSchemeIndexValues.Accent3, Accent4 = D.ColorSchemeIndexValues.Accent4, Accent5 = D.ColorSchemeIndexValues.Accent5, Accent6 = D.ColorSchemeIndexValues.Accent6, Hyperlink = D.ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = D.ColorSchemeIndexValues.FollowedHyperlink },
            new SlideLayoutIdList(new SlideLayoutId() { Id = (UInt32Value)2147483649U, RelationshipId = this.LastRelationshipIdOf<SlideMasterId>() }),
            new TextStyles(new TitleStyle(), new BodyStyle(), new OtherStyle()));

            slideMasterPart.SlideMaster = slideMaster;
        }
    }
}