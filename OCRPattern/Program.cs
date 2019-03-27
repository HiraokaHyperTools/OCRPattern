using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace OCRPattern {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //String s = Ocrad.Rec(new System.Drawing.Bitmap(@"C:\Users\ku_000\Documents\S50O5SiIlj.jpg"));

            for (int x = 0; x < args.Length; x++) {
                String a = args[x];
                if (a == "/e") {
                    ++x;
                    Application.Run(new EForm(args[x]));
                    return;
                }
                if (a == "/t") {
                    ++x;
                    String fp = args[x];
                    ++x;
                    bool run = false;
                    for (; x < args.Length; x++) {
                        if (args[x] == "/run") run = true;
                    }
                    Application.Run(new MForm(fp, run));
                    return;
                }
            }

        }
    }
}
