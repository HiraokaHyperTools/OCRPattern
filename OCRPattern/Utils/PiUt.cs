using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class PiUt
    {
        internal static Bitmap Rotate(Bitmap picSrc, int rot)
        {
            if (rot == 0)
            {
                return picSrc;
            }
            Bitmap pic2 = new Bitmap(picSrc);
            pic2.SetResolution(picSrc.HorizontalResolution, picSrc.VerticalResolution);
            switch (rot)
            {
                case 1: pic2.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                case 2: pic2.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                case 3: pic2.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                default: throw new NotSupportedException();
            }
            return pic2;
        }
    }
}
