using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OCRPattern.Utils;

namespace OCRPattern
{
    public partial class OCRWIPForm : Form, RunCR.IProgress
    {
        public OCRWIPForm()
        {
            InitializeComponent();
        }


        internal static OCRWIPForm Show1()
        {
            OCRWIPForm form = new OCRWIPForm();
            form.Show();
            form.Update();
            return form;
        }

        internal void HintPage(int p)
        {
            lPage.Text = String.Format("{0:#,##0}", p);
            lRot.Text = "";
            lTempl.Text = "";
            progressBar1.Maximum = 1;
            progressBar1.Value = 0;
            Update();
        }

        void RunCR.IProgress.HintRot(int rot)
        {
            switch (rot)
            {
                case 0: lRot.Text = "0°"; break;
                case 1: lRot.Text = "90°"; break;
                case 2: lRot.Text = "180°"; break;
                case 3: lRot.Text = "270°"; break;
            }
            lTempl.Text = "";
            progressBar1.Maximum = 1;
            progressBar1.Value = 0;
            Update();
        }

        internal void HintPage(int p, bool poppler2com)
        {
            HintPage(p);
            if (poppler2com) lTempl.Text = "画像を PDFから poppler2comで作成";
            Update();
        }

        void RunCR.IProgress.HintTempl(string p, bool import)
        {
            lTempl.Text = "テンプレート " + p + " で" + (import ? "取り込み" : "解析");
            progressBar1.Maximum = 1;
            progressBar1.Value = 0;
            Update();
        }

        void RunCR.IProgress.HintForm(int x, int cx)
        {
            progressBar1.Maximum = cx;
            progressBar1.Value = x;
            Update();
        }
    }
}
