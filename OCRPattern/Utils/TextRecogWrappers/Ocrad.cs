using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils.TextRecogWrappers
{
    public class Ocrad
    {
        public static string Rec(Bitmap pic)
        {
            String fppbm = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".pbm");
            Utpbm.Save(fppbm, pic);

            ProcessStartInfo psi = new ProcessStartInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gocr\\ocrad.exe"),
                " -F utf8 \"" + fppbm + "\""
                );
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.StandardOutputEncoding = Encoding.UTF8;
            Process p = Process.Start(psi);
            String res = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            File.Delete(fppbm);
            return res.Trim();
        }
    }
}
