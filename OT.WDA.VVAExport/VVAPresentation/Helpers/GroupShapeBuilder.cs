namespace OT.WDA.VVAExport.VVAPresentation.Helpers
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using GroupShape = DocumentFormat.OpenXml.Presentation.GroupShape;
    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
    using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;

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
            long? posX = 0, long? posY = 0,
            long? width = 0, long? height = 0) where T : GroupShape
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