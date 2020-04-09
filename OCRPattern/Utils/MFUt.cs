using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class MFUt
    {
        internal static void MoveTo(string fp, string dirTo)
        {
            for (int x = 1; x < 1000; x++)
            {
                String fpTo = Path.Combine(dirTo, Path.GetFileNameWithoutExtension(fp) + ((x >= 2) ? " (" + x + ")" : "") + Path.GetExtension(fp));
                if (File.Exists(fpTo))
                {
                    continue;
                }
                File.Move(fp, fpTo);
                break;
            }
        }
    }
}
