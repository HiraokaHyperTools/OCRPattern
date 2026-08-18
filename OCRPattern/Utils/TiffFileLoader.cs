using OCRPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class TiffFileLoader : IMultiPageFileLoader, IDisposable
    {
        Bitmap bitmap;

        public int NumPages => bitmap.GetFrameCount(FrameDimension.Page);

        public TiffFileLoader(String fp)
        {
            bitmap = new Bitmap(fp);
        }

        public Bitmap Rasterize(int z)
        {
            bitmap.SelectActiveFrame(FrameDimension.Page, z);
            return (Bitmap)bitmap.Clone();
        }

        public void SavePageAs(string fp, int page)
        {
            if (NumPages != 1)
            {
                bitmap.SelectActiveFrame(FrameDimension.Page, page);
            }
            bitmap.Save(fp, ImageFormat.Tiff);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            bitmap.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SavePagesWithoutFirstPageTo(string fileSaveTo)
        {
            var encoder = ImageCodecInfo.GetImageEncoders()
                .Single(it => it.MimeType == "image/tiff");
            var encoderParams = new EncoderParameters(1);

            encoderParams.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.SaveFlag,
                Convert.ToInt32(EncoderValue.MultiFrame)
            );

            using (FileStream fileStream = File.Create(fileSaveTo))
            {
                bitmap.Save(fileStream, encoder, encoderParams);

                var numPages = NumPages;

                for (int pageNum = 2; pageNum < numPages; pageNum++)
                {
                    bitmap.SelectActiveFrame(FrameDimension.Page, pageNum);

                    encoderParams.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.SaveFlag, 
                        Convert.ToInt32(System.Drawing.Imaging.EncoderValue.FrameDimensionPage)
                    );

                    bitmap.SaveAdd(bitmap, encoderParams);
                }

                if (numPages == 1)
                {
                    using (var dummy = new Bitmap(256, 256))
                    {
                        dummy.Save(fileSaveTo, ImageFormat.Tiff);
                    }
                }
            }
        }
    }
}
