using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal class BitmapRotateUtil : IDisposable
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        internal Bitmap Rotate(Bitmap picSrc, int numRotates)
        {
            if (numRotates == 0)
            {
                return picSrc;
            }
            Bitmap newPic = new Bitmap(picSrc);
            disposables.Add(newPic);
            newPic.SetResolution(picSrc.HorizontalResolution, picSrc.VerticalResolution);
            switch (numRotates)
            {
                case 1: newPic.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                case 2: newPic.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                case 3: newPic.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                default: throw new ArgumentOutOfRangeException();
            }
            return newPic;
        }

        public void Dispose()
        {
            foreach (var it in disposables)
            {
                it?.Dispose();
            }

            disposables.Clear();
        }
    }
}
