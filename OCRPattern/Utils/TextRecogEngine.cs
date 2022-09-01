using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class TextRecogEngine
    {
        /// <summary>
        /// 文字認識エンジン
        /// </summary>
        /// <remarks>
        /// - `zxing`
        ///   zxing BarcodeReader
        /// - `zxing.code128`
        ///   zxing BarcodeReader CODE_128
        /// - `gocr`
        ///   ocr
        /// - `ocrad`
        ///   ocrad
        /// - `nhocr`
        ///   nhocr
        /// - `ocr.` で始まる `ocr.jpn` `ocr.eng` `ocr.chi_sim` `ocr.chi_tra`
        ///   Tesseract-OCR
        /// </remarks>
        public string Name { get; set; }

        public string Version { get; set; }

        public Func<Bitmap, RecogOption, string> Recognize { get; set; }
    }
}
