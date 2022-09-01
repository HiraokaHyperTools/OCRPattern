using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils.TextRecogWrappers
{
    public class GOcr
    {
        public static string Rec(Bitmap pic)
        {
            String fppbm = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".pbm");
            Utpbm.Save(fppbm, pic);

            ProcessStartInfo psi = new ProcessStartInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gocr\\gocr.exe"),
                " \"" + fppbm + "\""
                );
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            Process p = Process.Start(psi);
            String res = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            File.Delete(fppbm);
            return res.Trim();
        }
    }
}
