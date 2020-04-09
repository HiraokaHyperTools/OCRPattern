using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OCRPattern
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm(OCRSettei ocrs, Bitmap pic)
        {
            InitializeComponent();

            picPane.Image = pic ?? ocrs.Picture;
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            tbRes.SelectAll();
            tbRes.SelectionFont = tbRes.Font;
            tbRes.LanguageOption = RichTextBoxLanguageOptions.UIFonts;

            bsRes_CurrentChanged(sender, e);
        }

        internal void SaveTo(CRContext crc)
        {
            foreach (DSRes.TResRow row in dsRes.TRes)
            {
                crc.drCR[row.Nam] = row.Dat;
            }
        }

        internal void Read(CRContext crc, DCR.BlkDataTable blkdt)
        {
            DataTable dt = crc.dtCR;
            int cx = dt.Columns.Count;
            DataRow dr = crc.drCR;
            if (dr == null) return;
            for (int x = 0; x < cx; x++)
            {
                String nam = dt.Columns[x].ColumnName;
                String dat = Convert.ToString(dr[x]);
                if (String.IsNullOrEmpty(nam)) continue;
                foreach (DCR.BlkRow blk in blkdt.Select("FieldName = '" + (nam.Replace("'", "''")) + "'"))
                {
                    if (!blk.IfImport) break;
                    DSRes.TResRow row = dsRes.TRes.AddTResRow(nam, dat, 0, 0, 0, 0);
                    row.x = blk.x;
                    row.y = blk.y;
                    row.cx = blk.cx;
                    row.cy = blk.cy;
                    break;
                }
            }
        }

        private void bsRes_CurrentChanged(object sender, EventArgs e)
        {
            Image _Image = picPane.Image;
            if (_Image == null) return;

            DataRowView drv = (DataRowView)bsRes.Current;
            if (drv == null) return;
            DSRes.TResRow row = (DSRes.TResRow)drv.Row;
            if (row == null) return;

            picPane.SelRect = new RectangleF(
                (float)row.x,
                (float)row.y,
                (float)row.cx,
                (float)row.cy
            );
            picPane.UseBright = true;

            SizeF PPM = UtPelsPerMeter.Compute(_Image);

            Rectangle rc = new Rectangle(
                (int)(row.x * PPM.Width * 1000),
                (int)(row.y * PPM.Height * 1000),
                (int)(row.cx * PPM.Width * 1000),
                (int)(row.cy * PPM.Height * 1000)
                );

            Size clis = slp.ClientSize;
            if (rc.Width < clis.Width)
            {
                rc.X = Math.Max(0, rc.X - (clis.Width / 2 - rc.Width / 2));
            }
            if (rc.Height < clis.Height)
            {
                rc.Y = Math.Max(0, rc.Y - (clis.Height / 2 - rc.Height / 2));
            }

            slp.AutoScrollPosition = (rc.Location);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void slp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfirmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel && e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show(this, "’†Ž~‚µ‚Ü‚·‚©H", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
