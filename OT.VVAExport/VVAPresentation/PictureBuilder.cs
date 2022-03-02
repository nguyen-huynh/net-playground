namespace OT.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;
    using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
    using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
    using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
    using Picture = DocumentFormat.OpenXml.Presentation.Picture;
    using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
    using ShapeStyle = DocumentFormat.OpenXml.Presentation.ShapeStyle;

    public static class PictureBuilder
    {
        public static NonVisualPictureProperties AppendNonVisualPictureProperties<T>(
            this T element,
            UInt32Value id = null,
            string name = null) where T : Picture
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            
            element.NonVisualPictureProperties = new NonVisualPictureProperties();
            element.NonVisualPictureProperties.Append(new NonVisualDrawingProperties
            {
                Name = name,
                Id = id
            });
            var nonVisualPictureDrawingProperties = new DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties();
            nonVisualPictureDrawingProperties.Append(new DocumentFormat.OpenXml.Drawing.PictureLocks()
            {
                NoChangeAspect = false
            });
            element.NonVisualPictureProperties.Append(nonVisualPictureDrawingProperties);
            element.NonVisualPictureProperties.Append(new DocumentFormat.OpenXml.Presentation.ApplicationNonVisualDrawingProperties());

            return element.NonVisualPictureProperties;
        }

        public static BlipFill AppendBlipFill<T>(
            this T element,
            string imageRId,
            bool isStrechShape = true) where T : Picture
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (string.IsNullOrEmpty(imageRId))
                throw new ArgumentNullException(nameof(imageRId));

            //var result = new BlipFill(new Blip() { Embed = imageRId });
            //if (isStrechShape)
            //{
            //    result.Append(new Stretch(new FillRectangle()));
            //}
            //else
            //{
            //    // TODO: Add another strech choice
            //}
            //element.Append(result);
            //return result;

            var blipFill = new DocumentFormat.OpenXml.Presentation.BlipFill();
            var blip1 = new DocumentFormat.OpenXml.Drawing.Blip()
            {
                Embed = imageRId,
                CompressionState = BlipCompressionValues.HighQualityPrint
            };
            var blipExtensionList1 = new DocumentFormat.OpenXml.Drawing.BlipExtensionList();
            var blipExtension1 = new DocumentFormat.OpenXml.Drawing.BlipExtension()
            {
                Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}"
            };
            var useLocalDpi1 = new DocumentFormat.OpenXml.Office2010.Drawing.UseLocalDpi()
            {
                Val = false
            };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");
            blipExtension1.Append(useLocalDpi1);
            blipExtensionList1.Append(blipExtension1);
            blip1.Append(blipExtensionList1);
            var stretch = new DocumentFormat.OpenXml.Drawing.Stretch();
            stretch.Append(new DocumentFormat.OpenXml.Drawing.FillRectangle());
            blipFill.Append(blip1);
            blipFill.Append(stretch);
            element.Append(blipFill);
            return blipFill;
        }

        public static ShapeStyle AppendDefaultShapeStyle<T>(this T element, HexBinaryValue backgroundColor = null) where T : Picture
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var picture = element as Picture;
            picture.ShapeStyle = new ShapeStyle(
                new LineReference(new NoFill()) { Index = 2u },
                new FillReference(new NoFill()) { Index = 1u },
                new EffectReference(new NoFill()) { Index = 0u },
                new FontReference(new NoFill()) { Index = FontCollectionIndexValues.Minor }
                );
            return picture.ShapeStyle;
        }

        public static ShapeProperties AppendShapeProperties<T>(
            this T element,
            int posX = 0,
            int posY = 0,
            int width = 0,
            int height = 0) where T : Picture
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var result = new ShapeProperties(
                new Transform2D(
                    new Offset() { X = posX, Y = posY },
                    new Extents() { Cx = width, Cy = height },
                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle}
                    ));

            element.Append(result);
            return result;
        }
    }
}