using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils.TextRecogWrappers
{
    public class NHocr
    {
        public static string AppExe => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gocr\\nhocr.exe");

        public static string Rec(Bitmap pic)
        {
            String fppbm = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".pbm");
            Utpbm.Save(fppbm, pic);

            ProcessStartInfo psi = new ProcessStartInfo(
                AppExe,
                " -line -o - \"" + fppbm + "\""
                );
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.StandardOutputEncoding = Encoding.UTF8;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
            psi.EnvironmentVariables["NHOCR_DICDIR"] = psi.WorkingDirectory;
            Process p = Process.Start(psi);
            String res = p.StandardOutput.ReadToEnd();
            String errs = p.StandardError.ReadToEnd();
            p.WaitForExit();
            File.Delete(fppbm);
            return res.Trim();
        }
    }
}
