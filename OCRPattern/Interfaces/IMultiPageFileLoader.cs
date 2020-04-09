using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Interfaces
{
    public interface IMultiPageFileLoader : IDisposable
    {
        int NumPages { get; }
        Bitmap Rasterize(int pageIndex);
        void SavePageAs(string fileSaveTo, int pageIndex);
    }
}
