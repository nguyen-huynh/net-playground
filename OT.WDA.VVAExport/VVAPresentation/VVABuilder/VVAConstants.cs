using System;
using System.Collections.Generic;
using System.Linq;

namespace OT.WDA.VVAExport.VVAPresentation.VVABuilder
{
    public static class VVAConstants
    {
        /// <summary>
        /// 8096250 / 850
        /// </summary>
        public static readonly int PIXEL_TO_OPEN_XML_UNIT = 9525;

        public static readonly int SLIDE_WIDTH = (int)PixelToOpenXmlUnit(850);
        public static readonly int SLIDE_HEIGHT = (int)PixelToOpenXmlUnit(477);
        public static readonly long NOTE_WIDTH = 6858000;
        public static readonly long NOTE_HEIGHT = 9144000;

        public static readonly long TOP_WHITE_REC_HEIGHT = PixelToOpenXmlUnit(40);
        public static readonly long OTF_IMAGE_WIDTH = PixelToOpenXmlUnit(23.18);
        public static readonly long OTF_IMAGE_HEIGHT = PixelToOpenXmlUnit(30);
        public static readonly long OTF_IMAGE_LEFT = (SLIDE_WIDTH - OTF_IMAGE_WIDTH) / 2;
        public static readonly long OTF_IMAGE_TOP = PixelToOpenXmlUnit(5);

        public static readonly long EXERCISE_GROUP_SHAPE_HEIGHT = PixelToOpenXmlUnit(282);
        public static readonly long EXERCISE_GROUP_SHAPE_MARGIN = 2 * PixelToOpenXmlUnit(5);
        public static readonly long EXERCISE_VIDEO_DURATION = 5000;    // 5s
        public static readonly string EXERCISE_VIDEO_DOMAIN = "";//"https://videos.dev.orangetheoryfitness.net";

        public static readonly string OTF_IMAGE_PATH = "./otf-logo.png";

        private static readonly List<VVAExerciseConfig> VVAExerciseConfigs = new List<VVAExerciseConfig>
        {
            new VVAExerciseConfig { SlideLength = new[]{ 0 }, Width = 0, FontSize = 0 },
            new VVAExerciseConfig { SlideLength = new[]{ 1, 2, 3, 4 }, Width = PixelToOpenXmlUnit(195) , FontSize = 2400 },
            new VVAExerciseConfig { SlideLength = new[]{ 5 }, Width = PixelToOpenXmlUnit(154) , FontSize = 2400 },
            new VVAExerciseConfig { SlideLength = new[]{ 6 }, Width = PixelToOpenXmlUnit(127), FontSize = 2000 },
            new VVAExerciseConfig { SlideLength = new[]{ 7 }, Width = PixelToOpenXmlUnit(107), FontSize = 1800 },
            new VVAExerciseConfig { SlideLength = new[]{ 8 }, Width = PixelToOpenXmlUnit(92), FontSize = 1800 },
            new VVAExerciseConfig { SlideLength = new[]{ 9 }, Width = PixelToOpenXmlUnit(81), FontSize = 1600 },
            new VVAExerciseConfig { SlideLength = new[]{ 10 }, Width = PixelToOpenXmlUnit(72), FontSize = 1600 },
        };

        public static VVAExerciseConfig GetVVAExerciseConfigBySlideLength(int length)
            => VVAExerciseConfigs.FirstOrDefault(x => x.SlideLength.Contains(length)) ?? VVAExerciseConfigs[0];

        public static long PixelToOpenXmlUnit(double pixel)
            => (long)Math.Floor(pixel * PIXEL_TO_OPEN_XML_UNIT);
    }

    public class VVAExerciseConfig
    {
        public IEnumerable<int> SlideLength { get; set; }
        public long Width { get; set; }
        public int FontSize { get; set; }
    }
}