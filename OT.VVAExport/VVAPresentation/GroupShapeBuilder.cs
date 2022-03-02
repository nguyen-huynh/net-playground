namespace OT.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.Diagnostics;
    using P = DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
    using Shape = DocumentFormat.OpenXml.Presentation.Shape;
    using NonVisualShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeProperties;
    using NonVisualShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeDrawingProperties;
    using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
    using TextBody = DocumentFormat.OpenXml.Presentation.TextBody;
    using GroupShape = DocumentFormat.OpenXml.Presentation.GroupShape;

    public static class GroupShapeBuilder
    {
        public static NonVisualGroupShapeProperties AppendDefaultNonVisualGroupShapeProperties<T>(this T element, UInt32Value id = null, string name = null) where T : GroupShape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            var result = new NonVisualGroupShapeProperties(
                    new NonVisualDrawingProperties() { Id = id, Name = name },
                    new NonVisualGroupShapeDrawingProperties(),
                    new ApplicationNonVisualDrawingProperties()
                    );
            element.Append(result);
            return result;
        }

        public static GroupShapeProperties AppendDefaultGroupShapeProperties<T>(this T element,
            int? posX = 0, int? posY = 0,
            int? width = 0, int? height = 0) where T : GroupShape
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new GroupShapeProperties(
                new TransformGroup(
                    new Offset { X = posX, Y = posY },
                    new Extents { Cx = width, Cy = height },
                    new ChildOffset { X = posX, Y = posY },
                    new ChildExtents { Cx = width, Cy = height })
                );
            element.Append(result);
            return result;
        }
    }
}