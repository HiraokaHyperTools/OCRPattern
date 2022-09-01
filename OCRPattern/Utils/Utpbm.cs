using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class Utpbm
    {
        public static void Save(String fppbm, Bitmap pic)
        {
            using (FileStream os = File.Create(fppbm))
            {
                byte[] bin = Encoding.ASCII.GetBytes(
                    "P4\n"
                    + pic.Width + " " + pic.Height + "\n"
                    );
                os.Write(bin, 0, bin.Length);
                int cx = pic.Width, cy = pic.Height;
                for (int y = 0; y < cy; y++)
                {
                    int b = 0;
                    for (int x = 0; ; x++)
                    {
                        if (x == cx)
                        {
                            os.WriteByte((byte)b);
                            break;
                        }
                        if (x != 0 && 0 == (x & 7))
                        {
                            os.WriteByte((byte)b);
                            b = 0;
                        }
                        Color c1 = pic.GetPixel(x, y);
                        bool f = ((c1.B + 0 + c1.G + c1.R) <= 255);
                        b |= f ? (128 >> (x & 7)) : 0;
                    }
                }
            }
        }
    }
}
