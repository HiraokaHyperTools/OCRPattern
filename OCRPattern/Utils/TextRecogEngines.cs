using OCRPattern.Utils.TextRecogWrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using ZXing;

namespace OCRPattern.Utils
{
    public class TextRecogEngines
    {
        public IEnumerable<TextRecogEngine> SearchInstalled()
        {
            yield return new TextRecogEngine
            {
                Name = "zxing",
                Version = "0.14.0.1",
                Recognize = RunZxing,
            };

            yield return new TextRecogEngine
            {
                Name = "zxing.code128",
                Version = "0.14.0.1",
                Recognize = RunZxingCode128,
            };

            yield return new TextRecogEngine
            {
                Name = "gocr",
                Version = "0.50 20130305",
                Recognize = RunGOcr,
            };

            yield return new TextRecogEngine
            {
                Name = "ocrad",
                Version= "0.25",
                Recognize = RunOcrad,
            };

            yield return new TextRecogEngine
            {
                Name = "nhocr",
                Version= "0.22",
                Recognize = RunNHocr,
            };

            foreach (var tess in TesseractOcr.SearchInstalled())
            {
                var tessdata = Path.Combine(tess.InstallDir, "tessdata");
                if (Directory.Exists(tessdata))
                {
                    foreach (var traineddata in Directory.GetFiles(tessdata, "*.traineddata"))
                    {
                        var lang = Path.GetFileNameWithoutExtension(traineddata).ToLowerInvariant();

                        yield return new TextRecogEngine
                        {
                            Name = $"ocr.{lang}",
                            Version = tess.CurrentVersion,
                            Recognize = (bitmap, opt) =>
                            {
                                var result = tess.Recognize(
                                    bitmap,
                                    lang,
                                    opt.Whitelist,
                                    opt.Blacklist,
                                    opt.PSM,
                                    opt.CutSpaces,
                                    opt.UserWords,
                                    opt.UserPatterns
                                );
                                if (result != null)
                                {
                                    result = result.Replace("—", "-");
                                }
                                return result;
                            },
                        };
                    }
                }
            }
        }

        public string RunNHocr(Bitmap pic, RecogOption arg2)
        {
            return NHocr.Rec(pic);
        }

        public string RunOcrad(Bitmap pic, RecogOption arg2)
        {
            return Ocrad.Rec(pic);
        }

        public string RunGOcr(Bitmap pic, RecogOption opt)
        {
            return GOcr.Rec(pic);
        }

        public string RunZxingCode128(Bitmap pic, RecogOption opt)
        {
            if (pic.Width >= 8 && pic.Height >= 8)
            {
                IBarcodeReader reader = new BarcodeReader();
                reader.Options.PossibleFormats = new BarcodeFormat[] { BarcodeFormat.CODE_128 };
                try
                {
                    Result result = reader.Decode(pic);
                    if (result != null)
                    {
                        return result.Text;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // 画像が小さいなど
                }
            }
            return null;
        }

        public string RunZxing(Bitmap pic, RecogOption opt)
        {
            if (pic.Width >= 8 && pic.Height >= 8)
            {
                IBarcodeReader reader = new BarcodeReader();
                try
                {
                    Result result = reader.Decode(pic);
                    if (result != null)
                    {
                        return result.Text;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // 画像が小さいなど
                }
            }
            return null;
        }
    }
}
