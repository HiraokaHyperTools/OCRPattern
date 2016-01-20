using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OCRPattern {
    public partial class SelForm : Form {
        public SelForm(String dir) {
            InitializeComponent();

            foreach (String fp in Directory.GetFiles(dir, "*.OCR-Settei")) {
                ListViewItem lvi = lvF.Items.Add(Path.GetFileNameWithoutExtension(fp));
                lvi.Tag = lvi.Text;
            }
        }

        internal String SeledForm = null;

        private void SelForm_Load(object sender, EventArgs e) {

        }

        private void lvF_ItemActivate(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lvF.SelectedItems) {
                SeledForm = (String)lvi.Tag;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void bCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e) {
            lvF_ItemActivate(sender, e);
        }
    }
}