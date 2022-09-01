using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal class Magick
    {
        private static readonly string[] exeList = new string[] { "magick.exe", "convert.exe" };

        public static IEnumerable<Magick> GetAll()
        {
            using (var ImageMagick = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ImageMagick", false))
            {
                if (ImageMagick != null)
                {
                    foreach (var verName in ImageMagick.GetSubKeyNames())
                    {
                        using (var verKey = ImageMagick.OpenSubKey(verName, false))
                        {
                            if (verKey != null)
                            {
                                foreach (var specName in verKey.GetSubKeyNames())
                                {
                                    using (var specKey = verKey.OpenSubKey(specName, false))
                                    {
                                        if (specKey != null)
                                        {
                                            var BinPath = specKey.GetValue("BinPath") as string;
                                            if (BinPath != null && Directory.Exists(BinPath))
                                            {
                                                foreach (var exe in exeList
                                                    .Select(exe => Path.Combine(BinPath, exe))
                                                    .Where(File.Exists)
                                                    .Take(1)
                                                )
                                                {
                                                    yield return new Magick
                                                    {
                                                        Version = verName,
                                                        Spec = specName,
                                                        BinPath = BinPath,
                                                        MagickExe = exe,
                                                    };
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public string Version { get; private set; }
        public string Spec { get; private set; }
        public string BinPath { get; private set; }
        public string MagickExe { get; private set; }

        public Bitmap Run(Bitmap picSrc, String parms)
        {
            String prefix = Guid.NewGuid().ToString("N");

            String fpSrc = Path.Combine(Path.GetTempPath(), prefix) + ".s.png";
            picSrc.Save(fpSrc, System.Drawing.Imaging.ImageFormat.Png);

            String fpDst = Path.Combine(Path.GetTempPath(), prefix) + ".t.png";

            ProcessStartInfo psi = new ProcessStartInfo(MagickExe, string.Join(" "
                , "\"" + fpSrc + "\""
                , "-background white"
                , "-alpha remove"
                , parms
                , "\"" + fpDst + "\""
            ));
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            string stderr = "";
            System.Threading.Tasks.Task.Factory.StartNew(() => stderr = p.StandardError.ReadToEnd());
            p.WaitForExit();

            if (p.ExitCode != 0)
            {
                throw new Exception($"ImageMagick でエラーが発生しました。\n番号 = {p.ExitCode}\n詳細 = {stderr}");
            }

            Bitmap res = new Bitmap(new MemoryStream(File.ReadAllBytes(fpDst)));

            if (File.Exists(fpSrc))
            {
                File.Delete(fpSrc);
            }
            if (File.Exists(fpDst))
            {
                File.Delete(fpDst);
            }

            return res;
        }
    }
}
