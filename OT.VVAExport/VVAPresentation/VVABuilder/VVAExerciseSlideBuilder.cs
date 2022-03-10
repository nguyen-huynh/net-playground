namespace OT.VVAExport.VVAPresentation.VVABuilder
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.Diagnostics;
    using P = DocumentFormat.OpenXml.Presentation;
    using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
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
    using Picture = DocumentFormat.OpenXml.Presentation.Picture;
    using System.Collections.Generic;
    using OT.VVAExport.Models;
    using System.Linq;
    using System.IO;

    public class VVAExerciseSlideBuilder : VVASlideBuilder
    {
        private readonly PresentationDocument _presentationDocument;

        public string BlockName { get; set; }
        public string BlockDuration { get; set; }
        public IEnumerable<VVAExercise> Exercises { get; set; }

        public ImagePart ExerciseVideoImagePart { get; set; }
        public MediaDataPart ExerciseMediaDataPart { get; set; }

        public VVAExerciseSlideBuilder(PresentationBuilder presentationBuilder, PresentationPart presentationPart, PresentationDocument presentationDocument) : base(presentationBuilder, presentationPart)
        {
            this._presentationDocument = presentationDocument;
        }

        public override void GenerateSlide()
        {
            base.GenerateSlide();

            ExerciseVideoImagePart = this.SlidePart.AddImagePart(ImagePartType.Png);
            using (var stream = File.OpenRead("./video.png"))
            {
                ExerciseVideoImagePart.FeedData(stream);
            }
            this.SlidePart.ChangeIdOfPart(ExerciseVideoImagePart, this._presentationBuilder.LastRelationshipIdOf<Picture>());

            ExerciseMediaDataPart = _presentationDocument.CreateMediaDataPart("video/mp4", "mp4");
            using (var stream = File.OpenRead("./video.mp4"))
            {
                ExerciseMediaDataPart.FeedData(stream);
            }

            this.SlidePart.AddVideoReferenceRelationship(ExerciseMediaDataPart, this._presentationBuilder.LastRelationshipIdOf<Video>());
            this.SlidePart.AddMediaReferenceRelationship(ExerciseMediaDataPart, this._presentationBuilder.LastRelationshipIdOf<P14.Media>());
            this.SlidePart.Slide.Save();
            //this.AddExerciseTiming();
        }

        private void AddExerciseTiming()
        {
            var videoId = this.SlidePart.Slide.Descendants<Picture>()
                .Where(x => x.NonVisualPictureProperties?.NonVisualDrawingProperties?.Name == "ExerciseVideo")
                .FirstOrDefault()
                ?.NonVisualPictureProperties?.NonVisualDrawingProperties?.Id;

            if (videoId == null) return;

            Timing timing = new Timing();

            TimeNodeList timeNodeList = new TimeNodeList();

            ParallelTimeNode parallelTimeNode = new ParallelTimeNode();

            CommonTimeNode commonTimeNode = new CommonTimeNode();
            commonTimeNode.Id = 1u;
            commonTimeNode.Duration = "indefinite";
            commonTimeNode.Restart = TimeNodeRestartValues.Never;
            commonTimeNode.NodeType = TimeNodeValues.TmingRoot;

            ChildTimeNodeList childTimeNodeList = new ChildTimeNodeList();

            SequenceTimeNode sequenceTimeNode = new SequenceTimeNode();
            sequenceTimeNode.Concurrent = true;
            sequenceTimeNode.NextAction = NextActionValues.Seek;

            CommonTimeNode commonTimeNode1 = new CommonTimeNode();
            commonTimeNode1.Id = 2u;
            commonTimeNode1.Duration = "indefinite";
            commonTimeNode1.NodeType = TimeNodeValues.MainSequence;

            ChildTimeNodeList childTimeNodeList1 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode1 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode2 = new CommonTimeNode();
            commonTimeNode2.Id = 3u;
            commonTimeNode2.Fill = TimeNodeFillValues.Hold;

            StartConditionList startConditionList = new StartConditionList();

            Condition condition = new Condition();
            condition.Delay = "indefinite";

            startConditionList.Append(condition);

            condition = new Condition();
            condition.Delay = "0";
            condition.Event = TriggerEventValues.OnBegin;

            TimeNode timeNode = new TimeNode();
            timeNode.Val = 2u;

            condition.Append(timeNode);

            startConditionList.Append(condition);

            commonTimeNode2.Append(startConditionList);

            ChildTimeNodeList childTimeNodeList2 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode2 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode3 = new CommonTimeNode();
            commonTimeNode3.Id = 4u;
            commonTimeNode3.Fill = TimeNodeFillValues.Hold;

            startConditionList = new StartConditionList();

            condition = new Condition();
            condition.Delay = "0";

            startConditionList.Append(condition);

            commonTimeNode3.Append(startConditionList);

            ChildTimeNodeList childTimeNodeList3 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode3 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode4 = new CommonTimeNode();
            commonTimeNode4.Id = 5u;
            commonTimeNode4.PresetId = 1;
            commonTimeNode4.PresetSubtype = 0;
            commonTimeNode4.PresetClass = TimeNodePresetClassValues.MediaCall;
            commonTimeNode4.Fill = TimeNodeFillValues.Hold;
            commonTimeNode4.NodeType = TimeNodeValues.WithEffect;

            startConditionList = new StartConditionList();

            condition = new Condition();
            condition.Delay = "0";

            startConditionList.Append(condition);

            commonTimeNode4.Append(startConditionList);

            ChildTimeNodeList childTimeNodeList4 = new ChildTimeNodeList();

            Command command = new Command();
            command.CommandName = "playFrom(0.0)";
            command.Type = CommandValues.Call;

            CommonBehavior commonBehavior = new CommonBehavior();

            CommonTimeNode commonTimeNode5 = new CommonTimeNode();
            commonTimeNode5.Id = 6u;
            commonTimeNode5.Duration = "5000";
            commonTimeNode5.Fill = TimeNodeFillValues.Hold;

            commonBehavior.Append(commonTimeNode5);

            TargetElement targetElement = new TargetElement();

            ShapeTarget shapeTarget = new ShapeTarget();
            shapeTarget.ShapeId = videoId.ToString();

            targetElement.Append(shapeTarget);

            commonBehavior.Append(targetElement);

            command.Append(commonBehavior);

            childTimeNodeList4.Append(command);

            commonTimeNode4.Append(childTimeNodeList4);

            parallelTimeNode3.Append(commonTimeNode4);

            childTimeNodeList3.Append(parallelTimeNode3);

            commonTimeNode3.Append(childTimeNodeList3);

            parallelTimeNode2.Append(commonTimeNode3);

            childTimeNodeList2.Append(parallelTimeNode2);

            commonTimeNode2.Append(childTimeNodeList2);

            parallelTimeNode1.Append(commonTimeNode2);

            childTimeNodeList1.Append(parallelTimeNode1);

            commonTimeNode1.Append(childTimeNodeList1);

            sequenceTimeNode.Append(commonTimeNode1);

            PreviousConditionList previousConditionList = new PreviousConditionList();

            condition = new Condition();
            condition.Delay = "0";
            condition.Event = TriggerEventValues.OnPrevious;

            targetElement = new TargetElement();

            SlideTarget slideTarget = new SlideTarget();

            targetElement.Append(slideTarget);

            condition.Append(targetElement);

            previousConditionList.Append(condition);

            sequenceTimeNode.Append(previousConditionList);

            NextConditionList nextConditionList = new NextConditionList();

            condition = new Condition();
            condition.Delay = "0";
            condition.Event = TriggerEventValues.OnNext;

            targetElement = new TargetElement();

            slideTarget = new SlideTarget();

            targetElement.Append(slideTarget);

            condition.Append(targetElement);

            nextConditionList.Append(condition);

            sequenceTimeNode.Append(nextConditionList);

            childTimeNodeList.Append(sequenceTimeNode);

            Video video = new Video();

            CommonMediaNode commonMediaNode = new CommonMediaNode();
            commonMediaNode.Volume = 80000;

            commonTimeNode5 = new CommonTimeNode();
            commonTimeNode5.Id = 7u;
            commonTimeNode5.RepeatCount = "indefinite";
            commonTimeNode5.Display = false;
            commonTimeNode5.Fill = TimeNodeFillValues.Hold;

            startConditionList = new StartConditionList();

            condition = new Condition();
            condition.Delay = "indefinite";

            startConditionList.Append(condition);

            commonTimeNode5.Append(startConditionList);

            commonMediaNode.Append(commonTimeNode5);

            targetElement = new TargetElement();

            shapeTarget = new ShapeTarget();
            shapeTarget.ShapeId = videoId.ToString();

            targetElement.Append(shapeTarget);

            commonMediaNode.Append(targetElement);

            video.Append(commonMediaNode);

            childTimeNodeList.Append(video);

            commonTimeNode.Append(childTimeNodeList);

            parallelTimeNode.Append(commonTimeNode);

            timeNodeList.Append(parallelTimeNode);

            timing.Append(timeNodeList);

            SlidePart.Slide.Append(timing);
        }

        public override Shape GetBlockDuration()
        {
            if (string.IsNullOrEmpty(BlockDuration)) return null;

            var blockNameShape = new Shape();
            blockNameShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "BlockDuration");
            blockNameShape.AppendDefaultShapeProperties(posX: (VVAConstants.SLIDE_WIDTH + VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        width: (VVAConstants.SLIDE_WIDTH - VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        height: VVAConstants.TOP_WHITE_REC_HEIGHT);
            blockNameShape.AppendDefaultShapeStyle();
            blockNameShape.AppendDefaultTextBody(text: BlockDuration, textAlignment: TextAlignmentTypeValues.Right);
            return blockNameShape;
        }

        public override Shape GetBlockName()
        {
            if (string.IsNullOrEmpty(BlockName)) return null;

            var blockNameShape = new Shape();
            blockNameShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "BlockName");
            blockNameShape.AppendDefaultShapeProperties(width: (VVAConstants.SLIDE_WIDTH - VVAConstants.OTF_IMAGE_WIDTH) / 2,
                                                        height: VVAConstants.TOP_WHITE_REC_HEIGHT);
            blockNameShape.AppendDefaultShapeStyle();
            blockNameShape.AppendDefaultTextBody(text: BlockName);
            return blockNameShape;
        }

        public override ShapeTree GetShapeTree()
        {
            var shapeTree = new ShapeTree();
            shapeTree.Append(new NonVisualGroupShapeProperties(
                                new NonVisualDrawingProperties() { Id = _presentationBuilder.NewId, Name = "" },
                                new NonVisualGroupShapeDrawingProperties(),
                                new ApplicationNonVisualDrawingProperties()));

            shapeTree.Append(new GroupShapeProperties(new TransformGroup()));

            var topWhiteGroupShape = this.GenerateTopWhiteRectangle(ref shapeTree);
            shapeTree.Append(topWhiteGroupShape);

            var exerciseGroupShape = GetExerciseGroupShape();
            shapeTree.Append(exerciseGroupShape);

            return shapeTree;
        }

        public GroupShape GetExerciseGroupShape()
        {
            if (Exercises?.Any() != true) return null;
            var vvaExerciseConfig = VVAConstants.GetVVAExerciseConfigBySlideLength(Exercises.Count());

            var groupShape = new GroupShape();
            groupShape.AppendDefaultNonVisualGroupShapeProperties(id: _presentationBuilder.NewId, name: "VVAExercise");
            groupShape.AppendDefaultGroupShapeProperties(
                posX: (VVAConstants.SLIDE_WIDTH - vvaExerciseConfig.Width) / 2,
                posY: VVAConstants.PixelToOpenXmlUnit(66),
                width: vvaExerciseConfig.Width,
                height: VVAConstants.EXERCISE_GROUP_SHAPE_HEIGHT);

            var whiteShape = new Shape();
            whiteShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "ExerciseRec");
            whiteShape.AppendDefaultShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                    posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y,
                                                    width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                    height: groupShape.GroupShapeProperties.TransformGroup.Extents.Cy,
                                                    backgroundColor: "FFFFFF");
            whiteShape.AppendDefaultShapeStyle();
            whiteShape.AppendDefaultTextBody(" ");
            groupShape.Append(whiteShape);


            var exerciseNameShape = new Shape();
            exerciseNameShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "ExerciseName");
            exerciseNameShape.AppendDefaultShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                           posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y,
                                                           width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                           height: VVAConstants.PixelToOpenXmlUnit(64));
            exerciseNameShape.AppendDefaultShapeStyle();
            exerciseNameShape.AppendDefaultTextBody(text: "Exercise Name",
                                                    fontSize: vvaExerciseConfig.FontSize,
                                                    italic: true,
                                                    //textAlignment: TextAlignmentTypeValues.Center,
                                                    textVerticalAlignment: ShapeBuilder.TextVerticalAlignment.MiddleCentered,
                                                    textBoxFit: ShapeBuilder.TextBoxFit.ShrinkTextOnOverflow);
            groupShape.Append(exerciseNameShape);

            //if (ExerciseVideoImagePart != null && ExerciseMediaDataPart != null)
            //{
                var videoPicture = new Picture();
                videoPicture.AppendNonVisualPictureProperties(id: _presentationBuilder.NewId, name: "ExerciseVideo", uri: $@"{{{Guid.NewGuid()}}}");

                videoPicture.NonVisualPictureProperties.NonVisualDrawingProperties.Append(new HyperlinkOnClick { Id = "", Action = "ppaction://media" });

                //var videoRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(VideoReferenceRelationship) && x.DataPart == ExerciseMediaDataPart).First();
                videoPicture.NonVisualPictureProperties.ApplicationNonVisualDrawingProperties.Append(new VideoFromFile() { Link = /*videoRId.Id*/ this._presentationBuilder.GenerateRelationshipId<Video>() });

                //var videoMediaRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(MediaReferenceRelationship) && x.DataPart == ExerciseMediaDataPart).First();
                P14.Media videoMedia = new P14.Media() { Embed = /*videoMediaRId.Id*/ this._presentationBuilder.GenerateRelationshipId<P14.Media>() };
                videoMedia.Append(new P14.MediaTrim() { End = "5000" });

                videoMedia.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");
                videoPicture.NonVisualPictureProperties.ApplicationNonVisualDrawingProperties.Append(
                    new ApplicationNonVisualDrawingPropertiesExtensionList(
                        new ApplicationNonVisualDrawingPropertiesExtension(videoMedia)
                        ));

                videoPicture.AppendBlipFill(imageRId: /*SlidePart.GetIdOfPart(ExerciseVideoImagePart)*/ this._presentationBuilder.GenerateRelationshipId<Picture>(), isStrechShape: true);
                videoPicture.AppendShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                     posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value + exerciseNameShape.ShapeProperties.Transform2D.Extents.Cy.Value,
                                                     width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                     height: VVAConstants.PixelToOpenXmlUnit(121));
                groupShape.Append(videoPicture);

            //}

            //var videoShape = new Shape();
            //videoShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "VideoRec");
            //videoShape.AppendDefaultShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
            //                                        posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value + exerciseNameShape.ShapeProperties.Transform2D.Extents.Cy.Value,
            //                                        width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
            //                                        height: VVAConstants.PixelToOpenXmlUnit(121),
            //                                        backgroundColor: "ED7D31");
            //videoShape.AppendDefaultShapeStyle();
            //videoShape.AppendDefaultTextBody(" ");
            //groupShape.Append(videoShape);

            var prescriptionShape = new Shape();
            prescriptionShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "ExercisePrescription");
            prescriptionShape.AppendDefaultShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                           posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value
                                                                 + groupShape.GroupShapeProperties.TransformGroup.Extents.Cy.Value
                                                                 - VVAConstants.PixelToOpenXmlUnit(64),
                                                           width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                           height: VVAConstants.PixelToOpenXmlUnit(64));
            prescriptionShape.AppendDefaultShapeStyle(fontColor: "ED7D31");
            prescriptionShape.AppendDefaultTextBody(text: "300m JUST ONCE",
                                                    fontSize: 2000,
                                                    italic: true,
                                                    ellipsis: true,
                                                    //textAlignment: TextAlignmentTypeValues.Center,
                                                    textVerticalAlignment: ShapeBuilder.TextVerticalAlignment.BottomCentered,
                                                    fontColor: "ED7D31",
                                                    textBoxFit: ShapeBuilder.TextBoxFit.ShrinkTextOnOverflow);
            groupShape.Append(prescriptionShape);

            return groupShape;
        }
    }
}