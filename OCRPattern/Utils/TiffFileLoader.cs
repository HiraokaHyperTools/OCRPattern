using OCRPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
    }
}
