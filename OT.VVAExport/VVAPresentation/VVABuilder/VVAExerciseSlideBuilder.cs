namespace OT.VVAExport.VVAPresentation.VVABuilder
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using System;
    using System.Diagnostics;
    using A = DocumentFormat.OpenXml.Drawing;
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
    using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
    using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
    using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;

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
            if (SlidePart == null) return;
            SlidePart.Slide = SlidePart.Slide ?? new Slide();

            ExerciseVideoImagePart = this.SlidePart.AddImagePart(ImagePartType.Png);
            using (var stream = File.OpenRead("./video.png"))
            {
                ExerciseVideoImagePart.FeedData(stream);
            }

            //ExerciseMediaDataPart = _presentationDocument.CreateMediaDataPart(MediaDataPartType.Wmv);
            //using (var stream = File.OpenRead("./video.wmv"))
            //{
            //    ExerciseMediaDataPart.FeedData(stream);
            //}
            //_presentationDocument.Save();

            //this.SlidePart.AddVideoReferenceRelationship(ExerciseMediaDataPart);
            //this.SlidePart.AddMediaReferenceRelationship(ExerciseMediaDataPart);
            //this.SlidePart.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/video", new System.Uri("NULL"), "rId1");

            SlidePart.Slide.Save();

            base.GenerateSlide();

            GenerateExerciseTiming();
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

            groupShape.Append(GenerateExerciseVideo(ExerciseMediaDataPart,
                                                        imagePart: ExerciseVideoImagePart,
                                                        posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                        posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value + exerciseNameShape.ShapeProperties.Transform2D.Extents.Cy.Value,
                                                        width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                        height: VVAConstants.PixelToOpenXmlUnit(121)));

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

        public Picture GenerateExerciseVideo(MediaDataPart mediaDataPart, ImagePart imagePart, long? posX = null, long? posY = null,
            long? width = null, long? height = null)
        {
            if (mediaDataPart == null) return null;

            var videoRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(VideoReferenceRelationship) && x.DataPart == ExerciseMediaDataPart).First();
            var videoMediaRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(MediaReferenceRelationship) && x.DataPart == ExerciseMediaDataPart).First();
            var imageRId = this.SlidePart.GetIdOfPart(imagePart);

            Picture videoPicture = new Picture();
            videoPicture.NonVisualPictureProperties = new NonVisualPictureProperties
            {
                NonVisualDrawingProperties = new NonVisualDrawingProperties
                {
                    Id = _presentationBuilder.NewId,
                    Name = "ExerciseVideo",
                    HyperlinkOnClick = new HyperlinkOnClick() { Id = "", Action = "ppaction://media" },
                    NonVisualDrawingPropertiesExtensionList = new NonVisualDrawingPropertiesExtensionList(
                        new NonVisualDrawingPropertiesExtension(
                            OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<a16:creationId xmlns:a16=\"http://schemas.microsoft.com/office/drawing/2014/main\" id=\"{57DC4828-7E9A-4825-9672-17359C5EBFFC}\" />")
                        )
                        { Uri = "{FF2B5EF4-FFF2-40B4-BE49-F238E27FC236}" }
                    )
                },
                NonVisualPictureDrawingProperties = new NonVisualPictureDrawingProperties
                {
                    PictureLocks = new PictureLocks { NoChangeAspect = false }
                },
                ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties(
                    new VideoFromFile { Link = videoRId.Id },
                    new ApplicationNonVisualDrawingPropertiesExtensionList(
                            new ApplicationNonVisualDrawingPropertiesExtension(
                                new P14.Media()
                                {
                                    Embed = videoMediaRId.Id,
                                    MediaTrim = new P14.MediaTrim { End = VVAConstants.EXERCISE_VIDEO_DURATION }
                                }
                            ){ Uri = "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}" }
                        )
                    )
            };

            videoPicture.BlipFill = new BlipFill
            {
                Blip = new Blip { Embed = imageRId },
            };
            videoPicture.BlipFill.Append(new Stretch
            {
                FillRectangle = new FillRectangle()
            });

            videoPicture.ShapeProperties = new ShapeProperties
            {
                Transform2D = new Transform2D
                {
                    Offset = new Offset { X = posX, Y = posY },
                    Extents = new A.Extents { Cx = width, Cy = height }
                }
            };
            videoPicture.ShapeProperties.Append(new PresetGeometry
            {
                Preset = ShapeTypeValues.Rectangle,
                AdjustValueList = new AdjustValueList()
            });

            return videoPicture;
        }

        private void GenerateExerciseTiming()
        {
            var videoIds = this.SlidePart.Slide.Descendants<Picture>()
                .Where(x => x.NonVisualPictureProperties?.NonVisualDrawingProperties?.Name == "ExerciseVideo")
                .Select(x => x.NonVisualPictureProperties?.NonVisualDrawingProperties?.Id)
                .Where(x => x.HasValue);

            if (!videoIds.Any()) return;

            var timing = new Timing()
            {
                TimeNodeList = new TimeNodeList
                {
                    ParallelTimeNode = new ParallelTimeNode
                    {
                        CommonTimeNode = new CommonTimeNode
                        {
                            Id = _presentationBuilder.NewId,
                            Duration = "indefinite",
                            Restart = TimeNodeRestartValues.Never,
                            NodeType = TimeNodeValues.TmingRoot,
                            ChildTimeNodeList = new ChildTimeNodeList()
                        }
                    }
                }
            };

            var childTimeNodeList = timing.TimeNodeList.ParallelTimeNode.CommonTimeNode.ChildTimeNodeList;
            var seqId = _presentationBuilder.NewId;
            childTimeNodeList.Append(new SequenceTimeNode
            {
                Concurrent = true,
                NextAction = NextActionValues.Seek,
                CommonTimeNode = new CommonTimeNode
                {
                    Id = seqId,
                    Duration = "indefinite",
                    NodeType = TimeNodeValues.MainSequence,
                    ChildTimeNodeList = new ChildTimeNodeList(
                        new ParallelTimeNode
                        {
                            CommonTimeNode = new CommonTimeNode
                            {
                                Id = this._presentationBuilder.NewId,
                                Fill = TimeNodeFillValues.Hold,
                                StartConditionList = new StartConditionList(
                                 new Condition { Delay = "indefinite" },
                                 new Condition
                                 {
                                     Delay = "0",
                                     Event = TriggerEventValues.OnBegin,
                                     TimeNode = new TimeNode { Val = seqId }
                                 }
                                ),
                                ChildTimeNodeList = new ChildTimeNodeList(
                                 new ParallelTimeNode
                                 {
                                     CommonTimeNode = new CommonTimeNode
                                     {
                                         Id = _presentationBuilder.NewId,
                                         Fill = TimeNodeFillValues.Hold,
                                         StartConditionList = new StartConditionList(
                                             new Condition { Delay = "0" }
                                         ),
                                         ChildTimeNodeList = new ChildTimeNodeList(
                                             videoIds.Select(videoId => new ParallelTimeNode
                                             {
                                                 CommonTimeNode = new CommonTimeNode
                                                 {
                                                     Id = _presentationBuilder.NewId,
                                                     PresetId = Int32.Parse(seqId),
                                                     PresetClass = TimeNodePresetClassValues.MediaCall,
                                                     PresetSubtype = 0,
                                                     Fill = TimeNodeFillValues.Hold,
                                                     NodeType = TimeNodeValues.WithEffect,
                                                     StartConditionList = new StartConditionList(new Condition { Delay = "0" }),
                                                     ChildTimeNodeList = new ChildTimeNodeList(
                                                        new Command
                                                        {
                                                            Type = CommandValues.Call,
                                                            CommandName = "playFrom(0.0)",
                                                            CommonBehavior = new CommonBehavior
                                                            {
                                                                CommonTimeNode = new CommonTimeNode
                                                                {
                                                                    Id = _presentationBuilder.NewId,
                                                                    Duration = VVAConstants.EXERCISE_VIDEO_DURATION,
                                                                    Fill = TimeNodeFillValues.Hold
                                                                },
                                                                TargetElement = new TargetElement
                                                                {
                                                                    ShapeTarget = new ShapeTarget { ShapeId = videoId.ToString() }
                                                                }
                                                            }
                                                        }
                                                     )
                                                 }
                                             })
                                         )
                                     }
                                 }
                                )
                            }
                        }
                        )
                },
                PreviousConditionList = new PreviousConditionList(
                 new Condition() { Event = TriggerEventValues.OnPrevious, Delay = "0", TargetElement = new TargetElement { SlideTarget = new SlideTarget() } }
                ),
                NextConditionList = new NextConditionList(
                  new Condition() { Event = TriggerEventValues.OnNext, Delay = "0", TargetElement = new TargetElement { SlideTarget = new SlideTarget() } }
                ),
            });

            childTimeNodeList.Append(videoIds.Select(videoId => new Video
            {
                CommonMediaNode = new CommonMediaNode
                {
                    Volume = 0,
                    CommonTimeNode = new CommonTimeNode
                    {
                        Id = _presentationBuilder.NewId,
                        RepeatCount = "indefinite",
                        Fill = TimeNodeFillValues.Hold,
                        Display = false,
                        StartConditionList = new StartConditionList(new Condition { Delay = "indefinite" })
                    },
                    TargetElement = new TargetElement
                    {
                        ShapeTarget = new ShapeTarget { ShapeId = videoId.ToString() }
                    }
                }
            }));

            SlidePart.Slide.Timing = timing;
        }

        // Creates an Timing instance and adds its children.
        public Timing GenerateTiming()
        {
            var videoId = this.SlidePart.Slide.Descendants<Picture>()
                .Where(x => x.NonVisualPictureProperties?.NonVisualDrawingProperties?.Name == "ExerciseVideo")
                .FirstOrDefault()
                ?.NonVisualPictureProperties?.NonVisualDrawingProperties?.Id;

            if (videoId == null) return null;

            Timing timing = new Timing();

            TimeNodeList timeNodeList = new TimeNodeList();

            ParallelTimeNode parallelTimeNode = new ParallelTimeNode();

            CommonTimeNode commonTimeNode = new CommonTimeNode();
            commonTimeNode.Id = this._presentationBuilder.NewId;
            commonTimeNode.Duration = "indefinite";
            commonTimeNode.Restart = TimeNodeRestartValues.Never;
            commonTimeNode.NodeType = TimeNodeValues.TmingRoot;

            ChildTimeNodeList childTimeNodeList = new ChildTimeNodeList();

            SequenceTimeNode sequenceTimeNode = new SequenceTimeNode();
            sequenceTimeNode.Concurrent = true;
            sequenceTimeNode.NextAction = NextActionValues.Seek;

            CommonTimeNode commonTimeNode1 = new CommonTimeNode();
            commonTimeNode1.Id = this._presentationBuilder.NewId;
            commonTimeNode1.Duration = "indefinite";
            commonTimeNode1.NodeType = TimeNodeValues.MainSequence;

            ChildTimeNodeList childTimeNodeList1 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode1 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode2 = new CommonTimeNode();
            commonTimeNode2.Id = this._presentationBuilder.NewId;
            commonTimeNode2.Fill = TimeNodeFillValues.Hold;

            StartConditionList startConditionList = new StartConditionList();

            Condition condition = new Condition();
            condition.Delay = "indefinite";

            startConditionList.Append(condition);

            condition = new Condition();
            condition.Delay = "0";
            condition.Event = TriggerEventValues.OnBegin;

            TimeNode timeNode = new TimeNode();
            timeNode.Val = this._presentationBuilder.NewId;

            condition.Append(timeNode);

            startConditionList.Append(condition);

            commonTimeNode2.Append(startConditionList);

            ChildTimeNodeList childTimeNodeList2 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode2 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode3 = new CommonTimeNode();
            commonTimeNode3.Id = this._presentationBuilder.NewId;
            commonTimeNode3.Fill = TimeNodeFillValues.Hold;

            startConditionList = new StartConditionList();

            condition = new Condition();
            condition.Delay = "0";

            startConditionList.Append(condition);

            commonTimeNode3.Append(startConditionList);

            ChildTimeNodeList childTimeNodeList3 = new ChildTimeNodeList();

            ParallelTimeNode parallelTimeNode3 = new ParallelTimeNode();

            CommonTimeNode commonTimeNode4 = new CommonTimeNode();
            commonTimeNode4.Id = this._presentationBuilder.NewId;
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
            commonTimeNode5.Id = this._presentationBuilder.NewId;
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
            commonTimeNode5.Id = this._presentationBuilder.NewId;
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
            return timing;
        }

    }
}