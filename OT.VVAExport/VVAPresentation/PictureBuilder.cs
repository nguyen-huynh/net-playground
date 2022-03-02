﻿namespace OT.VVAExport.VVAPresentation
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Office2016.Drawing;
    using DocumentFormat.OpenXml.Packaging;
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
            string name = null,
            string uri = null) where T : Picture
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            NonVisualPictureProperties nonVisualPictureProperties = element.NonVisualPictureProperties = new NonVisualPictureProperties();

            var nonVisualDrawingProperties = new NonVisualDrawingProperties();
            nonVisualDrawingProperties.Id = id;
            nonVisualDrawingProperties.Name = name;

            var aNonVisualDrawingPropertiesExtensionList = new NonVisualDrawingPropertiesExtensionList();

            var aNonVisualDrawingPropertiesExtension = new NonVisualDrawingPropertiesExtension();
            aNonVisualDrawingPropertiesExtension.Uri = uri;

            var a16CreationId = new CreationId();

            a16CreationId.AddNamespaceDeclaration("a16", "http://schemas.microsoft.com/office/drawing/2014/main");

            a16CreationId.Id = $@"{{{Guid.NewGuid()}}}";

            aNonVisualDrawingPropertiesExtension.Append(a16CreationId);

            aNonVisualDrawingPropertiesExtensionList.Append(aNonVisualDrawingPropertiesExtension);

            nonVisualDrawingProperties.Append(aNonVisualDrawingPropertiesExtensionList);

            nonVisualPictureProperties.Append(nonVisualDrawingProperties);

            NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties = new NonVisualPictureDrawingProperties();

            PictureLocks aPictureLocks = new PictureLocks();
            aPictureLocks.NoChangeAspect = true;

            nonVisualPictureDrawingProperties.Append(aPictureLocks);

            nonVisualPictureProperties.Append(nonVisualPictureDrawingProperties);

            var applicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

            nonVisualPictureProperties.Append(applicationNonVisualDrawingProperties);

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

            BlipFill blipFill = (element as Picture).BlipFill = new BlipFill();

            var aBlip = new Blip();
            aBlip.Embed = imageRId;

            blipFill.Append(aBlip);

            Stretch aStretch = new Stretch();

            FillRectangle aFillRectangle = new FillRectangle();

            aStretch.Append(aFillRectangle);

            blipFill.Append(aStretch);
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

            //var result = new ShapeProperties(
            //    new Transform2D(
            //        new Offset() { X = posX, Y = posY },
            //        new Extents() { Cx = width, Cy = height },
            //        new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle},
            //        new SolidFill(new NoFill()),
            //        new Outline(new NoFill())
            //        ));

            var shapeProperties = (element as Picture).ShapeProperties = new ShapeProperties();

            var aTransform2D = new Transform2D();

            var aOffset = new Offset();
            aOffset.X = 3767260;
            aOffset.Y = 50259;

            aTransform2D.Append(aOffset);

            var aExtents = new Extents();
            aExtents.Cx = 228745;
            aExtents.Cy = 285750;

            aTransform2D.Append(aExtents);

            shapeProperties.Append(aTransform2D);

            var aPresetGeometry = new PresetGeometry();
            aPresetGeometry.Preset = ShapeTypeValues.Rectangle;

            var aAdjustValueList = new AdjustValueList();

            aPresetGeometry.Append(aAdjustValueList);

            shapeProperties.Append(aPresetGeometry);

            //element.Append(result);
            return shapeProperties;
        }
    }
}