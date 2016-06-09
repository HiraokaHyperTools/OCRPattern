using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern {
    public class Utpbm {
        public static void Save(String fppbm, Bitmap pic) {
            using (FileStream os = File.Create(fppbm)) {
                byte[] bin = Encoding.ASCII.GetBytes(
                    "P4\n"
                    + pic.Width + " " + pic.Height + "\n"
                    );
                os.Write(bin, 0, bin.Length);
                int cx = pic.Width, cy = pic.Height;
                for (int y = 0; y < cy; y++) {
                    int b = 0;
                    for (int x = 0; ; x++) {
                        if (x == cx) {
                            os.WriteByte((byte)b);
                            break;
                        }
                        if (x != 0 && 0 == (x & 7)) {
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

    public class GOcr {
        public static string Rec(Bitmap pic) {
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

    public class Ocrad {
        public static string Rec(Bitmap pic) {
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

    public class NHocr {
        public static string Rec(Bitmap pic) {
            String fppbm = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".pbm");
            Utpbm.Save(fppbm, pic);

            ProcessStartInfo psi = new ProcessStartInfo(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gocr\\nhocr.exe"),
                " -line -o - \"" + fppbm + "\""
                );
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
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
