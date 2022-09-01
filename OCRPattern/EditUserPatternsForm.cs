using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCRPattern
{
    public partial class EditUserPatternsForm : Form
    {
        public EditUserPatternsForm()
        {
            InitializeComponent();
        }

        private void showMenu_Click(object sender, EventArgs e)
        {
            var me = (Control)showMenu;
            patterns.Show(me, new Point(0, me.Height));
        }

        private void 郵便番号item_Click(object sender, EventArgs e)
        {
            AddPattern(@"\d\d\d-\d\d\d\d");
        }

        private void AddPattern(string line)
        {
            editor.Text = editor.Text.TrimEnd('\r', '\n') + "\r\n" + line;
        }

        private void 電話番号item_Click(object sender, EventArgs e)
        {
            AddPattern(@"\d\*-\d\*-\d\*");
        }

        private void helpItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://stackoverflow.com/a/27159887");
        }

        private void アルファベット一文字item_Click(object sender, EventArgs e) => AddMark(@"\c");

        private void AddMark(string mark)
        {
            editor.SelectedText = mark;
            editor.Select(editor.SelectionStart + editor.SelectionLength, 0);
        }

        private void 数字一文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\d");
        }

        private void アルファベットまたは数字一文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\n");

        }

        private void 区切り文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\p");

        }

        private void 大文字一文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\A");

        }

        private void 小文字一文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\a");

        }

        private void 複数形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMark(@"\*");

        }
    }
}
