using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OCRPattern.Utils
{
    internal static class BlkRowUtil
    {
        public static RecogOption ToRecogOption(DCR.BlkRow row)
        {
            return new RecogOption
            {
                X = row.x,
                Y = row.y,
                Width = row.cx,
                Height = row.cy,
                ResampleDPI = row.ResampleDPI,
                NoiseReduction = row.NoiseReduction,
                Whitelist = row.Whitelist,
                Blacklist = row.Blacklist,
                PSM = row.PSM,
                PostProcess = row.PostProcess,
                CutSpaces = row.CutSpaces,
                UserWords = row.UserWords,
                UserPatterns = row.UserPatterns,
            };
        }
    }
}
