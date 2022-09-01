using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ZXing;

namespace OCRPattern.Utils
{
    public class RecogUtil
    {
        private class CUt
        {
            internal static Bitmap Cut(Bitmap picSrc, Rectangle rc)
            {
                Bitmap pic = new Bitmap(rc.Width, rc.Height);
                pic.SetResolution(picSrc.HorizontalResolution, picSrc.VerticalResolution);
                using (Graphics cv = Graphics.FromImage(pic))
                {
                    cv.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    cv.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;

                    cv.DrawImageUnscaled(picSrc, new Point(-rc.X, -rc.Y));
                }
                return pic;
            }

            internal static Bitmap CutDPI(Bitmap picSrc, Rectangle rc, int dpi)
            {
                int cx = (int)(((float)rc.Width / picSrc.HorizontalResolution) * dpi);
                int cy = (int)(((float)rc.Height / picSrc.VerticalResolution) * dpi);
                Bitmap pic = new Bitmap(cx, cy);
                pic.SetResolution(dpi, dpi);
                using (Graphics cv = Graphics.FromImage(pic))
                {
                    cv.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    cv.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;

                    cv.DrawImage(
                        picSrc,
                        new Rectangle(0, 0, cx, cy),
                        rc,
                        GraphicsUnit.Pixel
                        );
                }
                return pic;
            }
        }

        public static string Recognize2(
            Bitmap picSrc,
            RecogOption row,
            Func<Bitmap, string, Bitmap> noiseReducer,
            TextRecogEngine engine
        )
        {
            Bitmap picUsed;
            var res = Recognize3(
                picSrc, 
                row, 
                noiseReducer, 
                engine,
                out picUsed
            );
            if (picUsed != null)
            {
                picUsed.Dispose();
            }
            return res;
        }

        public static string Recognize3(
            Bitmap picSrc,
            RecogOption row,
            Func<Bitmap, string, Bitmap> noiseReducer,
            TextRecogEngine engine,
            out Bitmap picUsed
        )
        {
            SizeF PPM = UtPelsPerMeter.Compute(picSrc);

            Rectangle rc = new Rectangle(
                (int)(row.X * PPM.Width * 1000),
                (int)(row.Y * PPM.Height * 1000),
                (int)(row.Width * PPM.Width * 1000),
                (int)(row.Height * PPM.Height * 1000)
                );

            string textrec = null;

            Bitmap picS = (row.ResampleDPI == 0) ? CUt.Cut(picSrc, rc) : CUt.CutDPI(picSrc, rc, row.ResampleDPI);
            {
                Bitmap pic = picS;
                if (!String.IsNullOrEmpty(row.NoiseReduction) && noiseReducer != null)
                {
                    pic = noiseReducer(pic, row.NoiseReduction);
                }
                picUsed = pic;

                if (engine != null)
                {
                    textrec = engine.Recognize(pic, row);
                }
            }

            if (textrec is string && row.PostProcess != null)
            {
                String[] alpp = row.PostProcess.Replace("\r\n", "\n").Split('\n');
                String ntr = "";
                foreach (char c in "" + textrec)
                {
                    foreach (String pp in alpp)
                    {
                        if (false) { }
                        else if (pp.Length == 2 && pp[0] == '×')
                        {
                            if (pp[1] == c)
                            {
                                goto _SkipIt;
                            }
                        }
                        else if (pp.Length == 3)
                        {
                            if (false) { }
                            else if (pp[1] == '⇔')
                            {
                                if (false) { }
                                else if (pp[0] == c)
                                {
                                    ntr += pp[2];
                                    goto _SkipIt;
                                }
                                else if (pp[2] == c)
                                {
                                    ntr += pp[0];
                                    goto _SkipIt;
                                }
                            }
                            else if (pp[1] == '→')
                            {
                                if (false) { }
                                else if (pp[0] == c)
                                {
                                    ntr += pp[2];
                                    goto _SkipIt;
                                }
                            }
                            else if (pp[1] == '←')
                            {
                                if (false) { }
                                else if (pp[2] == c)
                                {
                                    ntr += pp[0];
                                    goto _SkipIt;
                                }
                            }
                        }
                    }
                    ntr += c;

                _SkipIt:;
                }
                textrec = ntr;
            }

            return textrec;
        }
    }
}
