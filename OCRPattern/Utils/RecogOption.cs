using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class RecogOption
    {
        /// <summary>
        /// 画像の左端からの距離 (mm)
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// 画像の上端からの距離 (mm)
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// 幅 (mm)
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// 高さ (mm)
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// 0 以外の場合、指定 DPI へ解像度を変更
        /// </summary>
        public int ResampleDPI { get; set; }

        /// <summary>
        /// ノイズ除去を委任する際のオプション
        /// </summary>
        public string NoiseReduction { get; set; }

        public string Whitelist { get; set; }

        public string Blacklist { get; set; }

        /// <summary>
        /// ページ分割
        /// </summary>
        /// <remarks>
        /// (Empty): (標準)
        /// `0`: Orientation and script detection (OSD) only.
        /// `1`: Automatic page segmentation with OSD.
        /// `2`: Automatic page segmentation, but no OSD, or OCR
        /// `3`: Fully automatic page segmentation, but no OSD. (Default)
        /// `4`: 可変長；単縦列
        /// `5`: 固定長；縦書き
        /// `6`: 固定長；横書き
        /// `7`: 一行
        /// `8`: 一単語
        /// `9`: 一単語(丸記号の中)
        /// `10`: 一文字
        /// </remarks>
        public string PSM { get; set; }

        public string PostProcess { get; set; }

        /// <summary>
        /// 空白を詰める (preserve_interword_spaces=1)
        /// </summary>
        public bool CutSpaces { get; set; }

        public string UserWords { get; set; }

        public string UserPatterns { get; set; }
    }
}
