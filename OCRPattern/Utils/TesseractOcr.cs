using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace OCRPattern.Utils
{
    public class TesseractOcr
    {
        public string CurrentVersion { get; }
        public string InstallDir { get; }
        public string AppExe { get; }

        private static Encoding utf8 = new UTF8Encoding(false);

        public TesseractOcr(
            string currentVersion,
            string installDir,
            string exe
        )
        {
            CurrentVersion = currentVersion;
            InstallDir = installDir;
            AppExe = exe;
        }

        public static IEnumerable<TesseractOcr> SearchInstalled()
        {
            using (var appKey = RUt.OpenSubKey(@"Software\Tesseract-OCR"))
            {
                if (appKey != null)
                {
                    var CurrentVersion = (appKey.GetValue("CurrentVersion") as string ?? "").TrimStart('v');
                    if (true
                        && CurrentVersion.Length != 0
                        && SemVerComparer.Instance.Compare(CurrentVersion, "3.0.1") >= 0
                    )
                    {
                        var InstallDir = appKey.GetValue("InstallDir") as string;
                        if (InstallDir != null && Directory.Exists(InstallDir))
                        {
                            var exe = Path.Combine(InstallDir, "tesseract.exe");
                            if (File.Exists(exe))
                            {
                                yield return new TesseractOcr(
                                    CurrentVersion,
                                    InstallDir,
                                    exe
                                );
                            }
                        }
                    }
                }
            }
        }

        private class RUt
        {
            internal static RegistryKey OpenSubKey(String p)
            {
                var key = Registry.CurrentUser.OpenSubKey(p, false);
                if (key == null)
                {
                    key = Registry.LocalMachine.OpenSubKey(p, false);
                }
                return key;
            }
        }

        public string Recognize(
            Bitmap pic,
            string lang,
            string whitelist,
            string blacklist,
            string psm,
            bool cutSpaces,
            string userWords,
            string userPatterns
        )
        {
            using (var temp = new TempFiles())
            {
                var bmpFile = temp.NewOne(".bmp");
                pic.Save(bmpFile, System.Drawing.Imaging.ImageFormat.Bmp);

                var outFile = temp.NewOne(".txt");

                var cfgFile = temp.NewOne(".cfg");
                {
                    var writer = new StringWriter();
                    writer.NewLine = "\n";

                    if (!String.IsNullOrEmpty(whitelist))
                    {
                        writer.WriteLine("tessedit_char_whitelist " + whitelist + "");
                    }

                    if (!String.IsNullOrEmpty(blacklist))
                    {
                        writer.WriteLine("tessedit_char_blacklist " + blacklist + "");
                    }

                    if (cutSpaces)
                    {
                        writer.WriteLine("preserve_interword_spaces 1");
                    }

                    //wr.WriteLine("chop_enable T");
                    //wr.WriteLine("use_new_state_cost F");
                    //wr.WriteLine("segment_segcost_rating F");
                    //wr.WriteLine("enable_new_segsearch 0");
                    //wr.WriteLine("language_model_ngram_on 0");
                    //wr.WriteLine("textord_force_make_prop_words F");

                    File.WriteAllText(cfgFile, writer.ToString(), utf8);
                }

                var isVersion4OrLater = SemVerComparer.Instance.Compare(CurrentVersion, "4.0") >= 0;

                var userWordsFile = isVersion4OrLater && string.IsNullOrWhiteSpace(userWords) ? null : temp.NewOne(".txt");
                if (userWordsFile != null)
                {
                    File.WriteAllText(userWordsFile, userWords, utf8);
                }

                var userPatternsFile = isVersion4OrLater && string.IsNullOrWhiteSpace(userPatterns) ? null : temp.NewOne(".txt");
                if (userPatternsFile != null)
                {
                    File.WriteAllText(userPatternsFile, userPatterns, utf8);
                }

                using (FileStream fs = File.Create(outFile)) { }

                string Escape(string text) => "\"" + text + "\"";

                var psmSpecifier = isVersion4OrLater
                    ? "--psm"
                    : "-psm";

                ProcessStartInfo psi = new ProcessStartInfo(AppExe, String.Join(" "
                    , Escape(bmpFile)
                    , Escape(outFile.Remove(outFile.Length - 4)) // no file extension
                    , "-l", lang
                    , (string.IsNullOrEmpty(psm) ? "" : psmSpecifier + " " + psm)
                    , (userWordsFile != null) ? "--user-words " + Escape(userWordsFile) : ""
                    , (userPatternsFile != null) ? "--user-patterns " + Escape(userPatternsFile) : ""
                    , Escape(cfgFile)
                ));
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardError = true;
                if (isVersion4OrLater)
                {
                    // 4.x, 5.x and later
                    psi.EnvironmentVariables["TESSDATA_PREFIX"] = Path.Combine(InstallDir, "tessdata");
                }
                else
                {
                    // 3.x
                    psi.EnvironmentVariables["TESSDATA_PREFIX"] = InstallDir;
                }
                Process p = Process.Start(psi);
                string stderr = "";
                System.Threading.Tasks.Task.Factory.StartNew(() => stderr = p.StandardError.ReadToEnd());
                p.WaitForExit();

                var res = File.ReadAllText(outFile);

                if (p.ExitCode != 0)
                {
                    throw new Exception($"テッセラクトの実行中にエラーが発生しました。\n番号 = {p.ExitCode}\n詳細 = {stderr}");
                }

                return res;
            }
        }
    }
}
