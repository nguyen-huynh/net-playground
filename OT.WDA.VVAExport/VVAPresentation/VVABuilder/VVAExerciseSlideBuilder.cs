namespace OT.WDA.VVAExport.VVAPresentation.VVABuilder
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
    using System.Linq;
    using System.IO;
    using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
    using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
    using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;
    using OT.WDA.VVAExport.Models;
    using OT.WDA.VVAExport.VVAPresentation.Helpers;
    using System.Net;
    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

    public class VVAExerciseSlideBuilder : VVASlideBuilder, IVVASlideBuilder
    {
        private static readonly bool IS_CLONE_OTF_IMAGE = true;
        public ImagePart ExerciseVideoThumnailImagePart { get; set; }

        private Dictionary<int, MediaDataPart> _mapExerciseIdMedia { get => this._presentationBuilder.MapExerciseIdMedia; }
        private readonly VVAExerciseConfig _exerciseConfig;
        private readonly long _startExercisePosX;

        public VVAExerciseSlideBuilder(IPresentationBuilder presentationBuilder, VVASlide slide) : base(presentationBuilder, slide)
        {
            var exercisesLength = _slide?.Exercises?.Count() ?? 0;
            _exerciseConfig = VVAConstants.GetVVAExerciseConfigBySlideLength(exercisesLength);
            _startExercisePosX = (VVAConstants.SLIDE_WIDTH - (_exerciseConfig.Width * exercisesLength) - VVAConstants.PixelToOpenXmlUnit(10) * Math.Max(exercisesLength - 1, 0)) / 2;
        }

        private protected override void AddMultiMediaPart()
        {
            if (IS_CLONE_OTF_IMAGE)
            {
                var otfImagePart = _presentationBuilder.VVASlideBuilders.FirstOrDefault(x => x.OtfImagePart != null)?.OtfImagePart;
                if (otfImagePart == null)
                    throw new ArgumentNullException(nameof(otfImagePart));
                this.OtfImagePart = SlidePart.AddPart<ImagePart>(otfImagePart);
            }
            else
                base.AddMultiMediaPart();

            // Video thumnail
            _slide.Exercises.Where(x => !string.IsNullOrEmpty(x.ThumnailUrl))
                .ToList()
                .ForEach(exercise =>
                {
                    if (this._presentationBuilder.MapExerciseIdThumnail.ContainsKey(exercise.ExerciseId))
                    {
                        var imagePart = _presentationBuilder.MapExerciseIdThumnail[exercise.ExerciseId];
                        if (!SlidePart.ImageParts.Contains(imagePart))
                        {
                            SlidePart.AddPart<ImagePart>(imagePart);
                        }
                    }
                    else
                    {
                        var imagePart = SlidePart.AddImagePart(ImagePartType.Png);
                        using (var stream = DownloadImage(exercise.ThumnailUrl))
                        {
                            imagePart.FeedData(stream);
                        }

                        SlidePart.ChangeIdOfPart(imagePart, $"thumnail{exercise.ExerciseId}");
                        _presentationBuilder.MapExerciseIdThumnail[exercise.ExerciseId] = imagePart;
                    }
                });
            //ExerciseVideoThumnailImagePart = this.SlidePart.AddImagePart(ImagePartType.Png);
            //using (var stream = File.OpenRead("./video.png"))
            //{
            //    ExerciseVideoThumnailImagePart.FeedData(stream);
            //}

            // Add VideoExercise
            _slide.Exercises.Where(x => !string.IsNullOrEmpty(x.VideoUrl))
                .ToList()
                .ForEach(exercise =>
                {
                    if (_mapExerciseIdMedia.ContainsKey(exercise.ExerciseId))
                    {
                        var mediaDataPart = _mapExerciseIdMedia[exercise.ExerciseId];
                        var videoRef = this.SlidePart.DataPartReferenceRelationships.FirstOrDefault(x => x.GetType() == typeof(VideoReferenceRelationship) && x.DataPart == mediaDataPart);
                        if (videoRef == null)
                            this.SlidePart.AddVideoReferenceRelationship(mediaDataPart, $"video{exercise.ExerciseId}");

                        var mediaRef = this.SlidePart.DataPartReferenceRelationships.FirstOrDefault(x => x.GetType() == typeof(MediaReferenceRelationship) && x.DataPart == mediaDataPart);
                        if (mediaRef == null)
                            this.SlidePart.AddMediaReferenceRelationship(mediaDataPart, $"media{exercise.ExerciseId}");
                        return;
                    }
                    else
                    {
                        var videoUrl = VVAConstants.EXERCISE_VIDEO_DOMAIN + exercise.VideoUrl;
                        var videoExtension = GetExtensionFromUrl(videoUrl);
                        string contentType = null, extension = null;
                        if (".mp4".Equals(videoExtension, StringComparison.OrdinalIgnoreCase))
                        {
                            contentType = "video/mp4";
                            extension = "mp4";
                        }
                        else if (".mov".Equals(videoExtension, StringComparison.OrdinalIgnoreCase))
                        {
                            contentType = "video/quicktime";
                            extension = "mov";
                        }

                        if (string.IsNullOrEmpty(contentType)) return;

                        MediaDataPart mediaDataPart = this._presentationBuilder.PresentationDocument.CreateMediaDataPart(contentType, extension);
                        string tempFilePath = null;
                        using (var stream = DownloadVideo(videoUrl, out tempFilePath))
                        {
                            mediaDataPart.FeedData(stream);
                        }

                        var videoDuration = GetVideoDuration(tempFilePath);
                        this._presentationBuilder.MapExerciseVideoDuration[exercise.ExerciseId] = Math.Floor(videoDuration.TotalMilliseconds);

                        File.Delete(tempFilePath);
                        this.SlidePart.AddVideoReferenceRelationship(mediaDataPart, $"video{exercise.ExerciseId}");
                        this.SlidePart.AddMediaReferenceRelationship(mediaDataPart, $"media{exercise.ExerciseId}");
                        _mapExerciseIdMedia[exercise.ExerciseId] = mediaDataPart;
                    }
                });
        }

        private protected override void GenerateSlide()
        {
            base.GenerateSlide();
            GenerateExerciseTiming();
        }

        private protected override ShapeTree GenerateShapeTree()
        {
            var shapeTree = base.GenerateShapeTree();

            var exercisePosX = _startExercisePosX;
            var exerciseGroupShapes = _slide.Exercises.ToList()
                .Select((exercise) => GetExerciseGroupShape(exercise, ref exercisePosX));
            shapeTree.Append(exerciseGroupShapes);
            return shapeTree;
        }

        private GroupShape GetExerciseGroupShape(VVAExercise exercise, ref long exercisePosX)
        {
            var groupShape = new GroupShape();
            groupShape.AppendDefaultNonVisualGroupShapeProperties(id: _presentationBuilder.NewId, name: "VVAExercise");
            groupShape.AppendDefaultGroupShapeProperties(
                posX: exercisePosX,
                posY: VVAConstants.PixelToOpenXmlUnit(66),
                width: _exerciseConfig.Width,
                height: VVAConstants.EXERCISE_GROUP_SHAPE_HEIGHT);

            exercisePosX += _exerciseConfig.Width + VVAConstants.EXERCISE_GROUP_SHAPE_MARGIN;

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
            exerciseNameShape.AppendDefaultTextBody(text: exercise.Name,
                                                    fontSize: _exerciseConfig.FontSize,
                                                    italic: true,
                                                    //textAlignment: TextAlignmentTypeValues.Center,
                                                    textVerticalAlignment: ShapeBuilder.TextVerticalAlignment.MiddleCentered,
                                                    textBoxFit: ShapeBuilder.TextBoxFit.ShrinkTextOnOverflow);
            groupShape.Append(exerciseNameShape);

            if (_mapExerciseIdMedia.TryGetValue(exercise.ExerciseId, out var mediaDataPart) 
                && this._presentationBuilder.MapExerciseVideoDuration.TryGetValue(exercise.ExerciseId, out var videoDuration)
                && this._presentationBuilder.MapExerciseIdThumnail.TryGetValue(exercise.ExerciseId, out var thumnailImagePart))
            {
                groupShape.Append(GenerateExerciseVideo(mediaDataPart,
                                                        thumnailImagePart: thumnailImagePart,
                                                        videoDuration: videoDuration,
                                                        posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                        posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value + exerciseNameShape.ShapeProperties.Transform2D.Extents.Cy.Value,
                                                        width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                        height: VVAConstants.PixelToOpenXmlUnit(121)));
            }

            var prescriptionShape = new Shape();
            prescriptionShape.AppendDefaultNonVisualShapeProperties(id: _presentationBuilder.NewId, name: "ExercisePrescription");
            prescriptionShape.AppendDefaultShapeProperties(posX: groupShape.GroupShapeProperties.TransformGroup.Offset.X,
                                                           posY: groupShape.GroupShapeProperties.TransformGroup.Offset.Y.Value
                                                                 + groupShape.GroupShapeProperties.TransformGroup.Extents.Cy.Value
                                                                 - VVAConstants.PixelToOpenXmlUnit(64),
                                                           width: groupShape.GroupShapeProperties.TransformGroup.Extents.Cx,
                                                           height: VVAConstants.PixelToOpenXmlUnit(64));
            prescriptionShape.AppendDefaultShapeStyle(fontColor: "ED7D31");
            prescriptionShape.AppendDefaultTextBody(text: exercise.Prescription,
                                                    fontSize: 2000,
                                                    italic: true,
                                                    //ellipsis: true,
                                                    //textAlignment: TextAlignmentTypeValues.Center,
                                                    textVerticalAlignment: ShapeBuilder.TextVerticalAlignment.BottomCentered,
                                                    fontColor: "ED7D31",
                                                    textBoxFit: ShapeBuilder.TextBoxFit.ShrinkTextOnOverflow);

            groupShape.Append(prescriptionShape);

            return groupShape;
        }

        public Picture GenerateExerciseVideo(MediaDataPart mediaDataPart, ImagePart thumnailImagePart, double videoDuration, long? posX = null, long? posY = null,
            long? width = null, long? height = null)
        {
            if (mediaDataPart == null) throw new ArgumentNullException(nameof(mediaDataPart));

            var videoRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(VideoReferenceRelationship) && x.DataPart == mediaDataPart).First();
            var videoMediaRId = this.SlidePart.DataPartReferenceRelationships.Where(x => x.GetType() == typeof(MediaReferenceRelationship) && x.DataPart == mediaDataPart).First();
            var imageRId = this.SlidePart.GetIdOfPart(thumnailImagePart);

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
                                    MediaTrim = new P14.MediaTrim { End = ((int)Math.Max(0, videoDuration - VVAConstants.EXERCISE_VIDEO_DURATION)).ToString() }
                                }
                            )
                            { Uri = "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}" }
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
                                                                    Duration = VVAConstants.EXERCISE_VIDEO_DURATION.ToString(),
                                                                    Fill = TimeNodeFillValues.Hold
                                                                },
                                                                TargetElement = new TargetElement
                                                                {
                                                                    ShapeTarget = new ShapeTarget { ShapeId = videoId.ToString() }
                                                                }
                                                            }
                                                        }
                                                     ),
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

        private Stream DownloadVideo(string videoUrl, out string tempFilePath)
        {
            if (string.IsNullOrEmpty(videoUrl))
                throw new ArgumentNullException(nameof(videoUrl));

            using (var wc = new WebClient())
            {
                tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "VVAExports", $"Video_{DateTime.Now.ToString("yyyyMMdd_HHmmssffff")}{GetExtensionFromUrl(videoUrl)}");
                wc.DownloadFile(videoUrl, tempFilePath);
                Console.WriteLine($"Download video by url: {videoUrl}");

                return File.OpenRead(tempFilePath);
            }
        }

        private Stream DownloadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            using (var wc = new WebClient())
            {
                return new MemoryStream(wc.DownloadData(url));
            }
        }

        private string GetExtensionFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            var Uri = new Uri(url);

            return System.IO.Path.GetExtension(Uri.AbsolutePath);
        }

        private TimeSpan GetVideoDuration(string filePath)
        {
            using (var shell = ShellObject.FromParsingName(filePath))
            {
                IShellProperty prop = shell.Properties.System.Media.Duration;
                var t = (ulong)prop.ValueAsObject;
                return TimeSpan.FromTicks((long)t);
            }
        }
    }
}
