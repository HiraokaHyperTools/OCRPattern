using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using ZXing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Xml;
using Microsoft.VisualBasic;
using OCRPattern.Properties;
using OCRPattern.Utils;
using OCRPattern.Models;
using System.Linq;

namespace OCRPattern
{
    public partial class TemplateForm : Form
    {
        private string fpxml;
        private readonly TextRecogEngines engines = new TextRecogEngines();

        public TemplateForm(String fpxml)
        {
            this.fpxml = fpxml;

            InitializeComponent();

            Icon = Resources.e;
        }

        private void EForm_Load(object sender, EventArgs e)
        {
            this.Text += " v" + Application.ProductVersion;

            {
                List<KeyValuePair<string, string>> alkv = new List<KeyValuePair<string, string>>();
                alkv.Add(new KeyValuePair<string, string>("ocr.jpn", "日本語 OCR"));
                alkv.Add(new KeyValuePair<string, string>("ocr.eng", "英語 OCR"));
                alkv.Add(new KeyValuePair<string, string>("gocr", "英語 OCR (GOCR)"));
                alkv.Add(new KeyValuePair<string, string>("ocrad", "英語 OCR (Ocrad)"));
                alkv.Add(new KeyValuePair<string, string>("nhocr", "日本語 OCR (NHocr)"));
                alkv.Add(new KeyValuePair<string, string>("ocr.chi_sim", "中国語 (sim) OCR"));
                alkv.Add(new KeyValuePair<string, string>("ocr.chi_tra", "中国語 (tra) OCR"));
                alkv.Add(new KeyValuePair<string, string>("zxing", "バーコード OCR"));
                alkv.Add(new KeyValuePair<string, string>("zxing.code128", "CODE128 OCR"));
                cbType.DataSource = alkv;
                cbType.ValueMember = "Key";
                cbType.DisplayMember = "Value";
            }

            {
                List<KeyValuePair<string, string>> alkv = new List<KeyValuePair<string, string>>();
                alkv.Add(new KeyValuePair<string, string>("", "(標準)"));
                alkv.Add(new KeyValuePair<string, string>("0", "Orientation and script detection (OSD) only."));
                alkv.Add(new KeyValuePair<string, string>("1", "Automatic page segmentation with OSD."));
                alkv.Add(new KeyValuePair<string, string>("2", "Automatic page segmentation, but no OSD, or OCR"));
                alkv.Add(new KeyValuePair<string, string>("3", "Fully automatic page segmentation, but no OSD. (Default)"));
                alkv.Add(new KeyValuePair<string, string>("4", "可変長；単縦列"));
                alkv.Add(new KeyValuePair<string, string>("5", "固定長；縦書き"));
                alkv.Add(new KeyValuePair<string, string>("6", "固定長；横書き"));
                alkv.Add(new KeyValuePair<string, string>("7", "一行"));
                alkv.Add(new KeyValuePair<string, string>("8", "一単語"));
                alkv.Add(new KeyValuePair<string, string>("9", "一単語(丸記号の中)"));
                alkv.Add(new KeyValuePair<string, string>("10", "一文字"));
                cbPSM.DataSource = alkv;
                cbPSM.ValueMember = "Key";
                cbPSM.DisplayMember = "Value";
            }

            {
                List<KeyValuePair<string, string>> alkv = new List<KeyValuePair<string, string>>();
                alkv.Add(new KeyValuePair<string, string>("", "未使用"));
                alkv.Add(new KeyValuePair<string, string>("-median 3 -trim", "並"));
                alkv.Add(new KeyValuePair<string, string>("-median 3 -trim -threshold 100", "並+(メディアン・切取・低い境界値)"));
                alkv.Add(new KeyValuePair<string, string>("-median 3 -trim -threshold 200", "並2+(メディアン・切取・高い境界値)"));
                alkv.Add(new KeyValuePair<string, string>("-median 6 -trim", "強1(メディアン・切取)"));
                alkv.Add(new KeyValuePair<string, string>("-gaussian-blur 3x3 -threshold 100 -trim", "強2(ぼかし・境界値・切取)"));
                cbNR.DataSource = alkv;
                cbNR.ValueMember = "Key";
                cbNR.DisplayMember = "Value";
            }

            if (File.Exists(fpxml) && new FileInfo(fpxml).Length != 0)
            {
                XmlSerializer xs = new XmlSerializer(typeof(OCRSettei));
                using (FileStream fs = File.OpenRead(fpxml))
                {
                    ocrs = (OCRSettei)xs.Deserialize(fs);
                    dcr.Merge(ocrs.DCR, true, MissingSchemaAction.Add);
                    ocrs.DCR = dcr;
                }
                this.Text += "：" + Path.GetFileNameWithoutExtension(fpxml);
            }

            foreach (DataTable dt1 in ocrs.DCR.Tables)
            {
                foreach (DataRow dr1 in dt1.Rows)
                {
                    foreach (DataColumn dc in dt1.Columns)
                    {
                        if (dr1.IsNull(dc))
                        {
                            //dr1[dc] = dc.DefaultValue;
                        }
                    }
                }
            }

            ocrs.PictureChanged += new EventHandler(ocrs_PictureChanged);
            ocrs.OnPictureChanged();
            blkBindingSource.DataSource = ocrs.DCR;
            blkBindingSource.CurrentItemChanged += new EventHandler(blkBindingSource_CurrentItemChanged);
            blkBindingSource_CurrentItemChanged(sender, e);

            tscbZoom.SelectedIndex = 2;

            {
                List<KeyValuePair<string, string>> alkv = new List<KeyValuePair<string, string>>();
                alkv.Add(new KeyValuePair<string, string>("", "通常フォーム認識"));
                alkv.Add(new KeyValuePair<string, string>("S", "区切り/代表ページ"));
                alkv.Add(new KeyValuePair<string, string>("S1", "表紙付きモード"));
                cbPWay.DataSource = alkv;
                cbPWay.ValueMember = "Key";
                cbPWay.DisplayMember = "Value";

                cbPWay.DataBindings.Add("SelectedValue", ocrs, "PWay");
            }
        }

        void blkBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            DataRowView drv = blkBindingSource.Current as DataRowView;
            if (drv != null)
            {
                picPane.SelRect = new RectangleF(
                    (float)drv["x"],
                    (float)drv["y"],
                    (float)drv["cx"],
                    (float)drv["cy"]
                );
            }
        }

        void ocrs_PictureChanged(object sender, EventArgs e)
        {
            picPane.Image = ((OCRSettei)sender).Picture;
            tscbZoom_SelectedIndexChanged(sender, e);
        }

        OCRSettei ocrs = new OCRSettei();

        private void bSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fpxml)) return;

            if (!ValidateChildren())
                return;
            blkBindingSource.EndEdit();

            XmlSerializer xs = new XmlSerializer(typeof(OCRSettei));
            using (FileStream fs = File.Create(fpxml))
            {
                xs.Serialize(fs, ocrs);
            }
            MessageBox.Show(this, "保存しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bSpecifyPic_Click(object sender, EventArgs e)
        {
            if (ofdPic.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap pic;
                if (PagesUtil.ExtractUserSelectedPageBitmap(ofdPic.FileName, out pic))
                {
                    ocrs.Picture = pic;
                }
            }
        }

        private void tscbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tscbZoom.Text))
                picPane.Zoom = float.Parse(tscbZoom.Text.Split('%')[0]) / 100.0f;
        }

        private void picPane_SelRectChanged(object sender, SelRectChangedEventArgs e)
        {
            RectangleF rc = picPane.SelRect;

            DataRowView drv = blkBindingSource.Current as DataRowView;
            if (drv != null)
            {
                drv.BeginEdit();
                drv["x"] = rc.Left;
                drv["y"] = rc.Top;
                drv["cx"] = rc.Width;
                drv["cy"] = rc.Height;
                drv.EndEdit();
            }

            if (e.Final) cbSelArea.Checked = false;
        }

        private void bTestAll_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            blkBindingSource.EndEdit();

            if (!TesseractOcr.SearchInstalled().Any())
            {
                if (MessageBox.Show(this, "Tesseract-OCR 3.01 以上が必要です。\n\n見付かりませんでした。\n\nOCRは使用できません。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    return;
                }
            }

            if (NoiseReducers.UseMagick() == null)
            {
                if (MessageBox.Show(this, "ImageMagick 6.7.6 (Q:8) 以上が必要です。\n\n見付かりませんでした。\n\n画像処理は使用できません。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    return;
                }
            }

            bool all = Object.ReferenceEquals(sender, bTestAll);
            using (OCRWIPForm form = OCRWIPForm.Show1())
            {
                Recognize(all);
            }
        }

        public void Recognize(bool all)
        {
            Bitmap picSrc = (Bitmap)picPane.Image; //ocrs.Picture;

            foreach (DataGridViewRow vr in gvRes.Rows)
            {
                if (!all && (!vr.Selected && !Object.ReferenceEquals(blkBindingSource.Current, vr.DataBoundItem))) continue;
                DCR.BlkRow row = (DCR.BlkRow)((DataRowView)vr.DataBoundItem).Row;

                Bitmap picUsed = null;
                var opt = BlkRowUtil.ToRecogOption(row);
                vr.Cells[cRes.Name].Value = RecogUtil.Recognize3(
                    picSrc,
                    opt,
                    NoiseReducers.UseMagick(),
                    engines.SearchInstalled()
                        .FirstOrDefault(it => it.Name == row.CRType),
                    out picUsed
                );
                vr.Cells[cPic.Name].Value = picUsed;
            }
        }

        private void EForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "保存しますか?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        bSave.PerformClick();
                        return;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        return;
                }
            }
        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog(this);
        }

        private void cbSelArea_CheckedChanged(object sender, EventArgs e)
        {
            picPane.CanSelRect = cbSelArea.Checked;
        }

        private void cmsPicPane_Opening(object sender, CancelEventArgs e)
        {
            mSelArea.Checked = cbSelArea.Checked;
        }

        private void mSelArea_Click(object sender, EventArgs e)
        {
            cbSelArea.Checked = !cbSelArea.Checked;
        }

        private void mCLDigit_Click(object sender, EventArgs e)
        {
            Button la = cmsCharList.SourceControl as Button;
            if (la == null) return;

            TextBox tb = Object.ReferenceEquals(la, bWL) ? whitelistTextBox : blacklistTextBox;

            String set = "";
            set += (Object.ReferenceEquals(sender, mCLDigit) ? "1234567890" : "");
            set += (Object.ReferenceEquals(sender, mCLLetterL) ? "abcdefghijklmnopqrstuvwxyz" : "");
            set += (Object.ReferenceEquals(sender, mCLLetterU) ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : "");

            set += tb.Text;

            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            foreach (char c in set) dict[c.ToString()] = null;

            tb.Text = String.Join("", new List<string>(dict.Keys).ToArray());
        }

        private void bBL_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            cmsCharList.Show(b, new Point(0, b.Height));
        }

        private static class PagesUtil
        {
            internal static bool ExtractUserSelectedPageBitmap(string inputFile, out Bitmap pageBitmap)
            {
                using (var pages = MultiPageFileLoader.LoadFromFile(inputFile))
                {
                    int numPages = pages.NumPages;

                    using (PageSelForm form = new PageSelForm())
                    {
                        form.numPage.Maximum = numPages;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            int pageNum = (int)form.numPage.Value;
                            pageBitmap = pages.Rasterize(pageNum - 1);
                            return true;
                        }
                        else
                        {
                            pageBitmap = null;
                            return false;
                        }
                    }
                }
            }
        }

        private void bAnother_Click(object sender, EventArgs e)
        {
            if (ofdAnother.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap pic;
                if (PagesUtil.ExtractUserSelectedPageBitmap(ofdAnother.FileName, out pic))
                {
                    SetPv(pic);
                }
            }
        }

        private void SetPv(Bitmap bitmap)
        {
            picPane.Image = bitmap;
            llRevertPic.Show();
        }

        private void llRevertPic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picPane.Image = ocrs.Picture;
            llRevertPic.Hide();
        }

        private void gvRes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picPane_ImageChanged(object sender, EventArgs e)
        {
            Image p = picPane.Image;
            lRes.Text = (p == null) ? "" : String.Format("画像サイズ={2}x{3} DPI={0:0}x{1:0}", p.HorizontalResolution, p.VerticalResolution
                , p.Width, p.Height);
        }

        class XUt
        {
            internal static XmlElement NewTag(XmlDocument xmlo, String tag)
            {
                XmlElement el = xmlo.CreateElement(tag);
                xmlo.AppendChild(el);
                return el;
            }
            internal static XmlElement NewTag(XmlElement elparent, String tag)
            {
                XmlElement el = elparent.OwnerDocument.CreateElement(tag);
                elparent.AppendChild(el);
                return el;
            }
        }

        class PUt
        {
            internal static Bitmap Clone(Bitmap pic)
            {
                switch (pic.PixelFormat)
                {
                    case PixelFormat.Format1bppIndexed:
                    case PixelFormat.Format4bppIndexed:
                    case PixelFormat.Format8bppIndexed:
                        Bitmap pic2 = new Bitmap(pic.Width, pic.Height);
                        pic2.SetResolution(pic.HorizontalResolution, pic.VerticalResolution);
                        using (Graphics cv = Graphics.FromImage(pic2))
                        {
                            cv.DrawImageUnscaledAndClipped(pic, new Rectangle(Point.Empty, pic2.Size));
                        }
                        return pic2;
                }
                return (Bitmap)pic.Clone();
            }
        }

        private class CellValue
        {
            public string text;
            public bool pre;
        }

        private class Result
        {
            public string number;
            public string imgsrc;
            public string text;
        }

        private void bReportAll_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable("OCRPattern レポート");
            DataColumn dcOutNum = dt2.Columns.Add("番号", typeof(int));
            foreach (DataColumn dc in ocrs.DCR.Blk.Columns)
                dt2.Columns.Add(dc.ColumnName, dc.DataType);
            DataColumn dcOutRes = dt2.Columns.Add("認識結果");
            DataColumn dcOutPic = dt2.Columns.Add("画像", typeof(Bitmap));

            foreach (DataColumn dc in dt2.Columns)
            {
                if (dc.ColumnName == "CRType") dc.Caption = "認識タイプ";
                if (dc.ColumnName == "IfImport") dc.Caption = "CSVへ";
                if (dc.ColumnName == "IfTest") dc.Caption = "フォーム判定用";
                if (dc.ColumnName == "PSM") dc.Caption = "ページ分活(PSM)";
                if (dc.ColumnName == "TestKeyword") dc.Caption = "判定キーワード";
                if (dc.ColumnName == "NoiseReduction") dc.Caption = "ノイズ除去";
                if (dc.ColumnName == "ResampleDPI") dc.Caption = "DPIを変更";
            }

            int y = 0;
            foreach (DataGridViewRow row in gvRes.Rows)
            {
                DataRowView drvSrc = (DataRowView)row.DataBoundItem;
                DataRowView drvDst = dt2.DefaultView.AddNew();
                foreach (DataColumn dc in drvSrc.Row.Table.Columns)
                {
                    drvDst[dc.ColumnName] = drvSrc[dc.ColumnName];
                }
                y++;
                drvDst[dcOutNum.ColumnName] = y;
                drvDst[dcOutRes.ColumnName] = row.Cells[cRes.Index].Value;
                drvDst[dcOutPic.ColumnName] = row.Cells[cPic.Index].Value;

                drvDst.EndEdit();

                if (drvDst[dcOutPic.ColumnName] is ICloneable)
                    drvDst[dcOutPic.ColumnName] = ((ICloneable)drvDst[dcOutPic.ColumnName]).Clone();
            }

            String outDir = Path.Combine(Path.GetTempPath(), "OCRP" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.CreateDirectory(outDir);

            {
                var template = Scriban.Template.Parse(Resources.Report);

                Bitmap picSrc = PUt.Clone((Bitmap)picPane.Image); //ocrs.Picture;

                var results = new List<Result>();

                foreach (DataRow row in dt2.Rows)
                {
                    int num = Convert.ToInt32(row["番号"]);
                    var result = new Result();
                    result.text = Convert.ToString(row["認識結果"]);

                    GUt.Mark(picSrc, lnum.Font, num, new RectangleF(
                        Convert.ToSingle(row["x"]),
                        Convert.ToSingle(row["y"]),
                        Convert.ToSingle(row["cx"]),
                        Convert.ToSingle(row["cy"])
                        ));

                    if (!row.IsNull("画像"))
                    {
                        Bitmap pic = (Bitmap)row["画像"];
                        if (pic != null)
                        {
                            pic.Save(Path.Combine(outDir, num + ".png"), ImageFormat.Png);
                            result.number = num.ToString();
                            result.imgsrc = num + ".png";
                        }

                        results.Add(result);
                    }
                }

                var columns = dt2.Columns
                    .Cast<DataColumn>()
                    .ToArray();

                var html = template.Render(
                    new
                    {
                        TableTitle = dt2.TableName,
                        Columns = columns
                            .Select(it => it.Caption)
                            .ToArray(),
                        Rows = dt2.Rows.Cast<DataRow>()
                            .Select(
                                dataRow =>
                                {
                                    return columns
                                        .Select(
                                            dataColumn =>
                                            {
                                                var value = dataRow[dataColumn];

                                                if (value is Image)
                                                {
                                                    value = "";
                                                }
                                                else if (value is bool)
                                                {
                                                    value = ((bool)value) ? "はい" : "いいえ";
                                                }
                                                else if (dataColumn.ColumnName == "CRType")
                                                {
                                                    value = VUt.Resolve(value, cbType);
                                                }
                                                else if (dataColumn.ColumnName == "NoiseReduction")
                                                {
                                                    value = VUt.Resolve(value, cbNR);
                                                }
                                                else if (dataColumn.ColumnName == "PSM")
                                                {
                                                    value = VUt.Resolve(value, cbPSM);
                                                }

                                                if (dataColumn == dcOutRes)
                                                {
                                                    return new CellValue
                                                    {
                                                        pre = true,
                                                        text = value + "",
                                                    };
                                                }
                                                else
                                                {
                                                    return new CellValue
                                                    {
                                                        pre = false,
                                                        text = value + "",
                                                    };
                                                }
                                            }
                                        )
                                        .ToArray();
                                }
                            )
                            .ToArray(),

                        Results = results,

                        OcrEngines = string.Join("\r\n",
                            engines.SearchInstalled()
                                .Select(it => $"{it.Name} v{it.Version} \"{it.AppExe}\"")
                        ),

                        Magicks = string.Join("\r\n"
                            , NoiseReducers.DetectMagicks()
                                .Select(it => $"v{it.Version} {it.Spec} \"{it.MagickExe}\"")
                        ),
                    }
                );

                String fpHtml = Path.Combine(outDir, "report.html");
                File.WriteAllText(fpHtml, html);

                picSrc.Save(Path.Combine(outDir, "pic.jpg"), ImageFormat.Jpeg);
            }

            Process.Start(outDir);
        }

        class VUt
        {
            internal static object Resolve(object input, ComboBox cb)
            {
                foreach (Object row in (cb.DataSource as System.Collections.IEnumerable))
                {
                    if (row == null) continue;
                    System.Reflection.PropertyInfo valueMember = row.GetType().GetProperty(cb.ValueMember);
                    if (valueMember == null || !valueMember.CanRead) continue;
                    System.Reflection.PropertyInfo displayMember = row.GetType().GetProperty(cb.DisplayMember);
                    if (displayMember == null || !displayMember.CanRead) continue;

                    Object value = valueMember.GetValue(row, new Object[0]);
                    if (value is IComparable)
                    {
                        if (((IComparable)value).CompareTo(input) != 0)
                            continue;
                    }
                    else if (value != input)
                    {
                        continue;
                    }
                    return displayMember.GetValue(row, new Object[0]);
                }
                return null;
            }
        }

        class GUt
        {
            internal static void Mark(Bitmap pic, Font font, int num, RectangleF rc)
            {
                using (Graphics cv = Graphics.FromImage(pic))
                {
                    cv.PageUnit = GraphicsUnit.Millimeter;
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    SizeF size = new SizeF(10, 8);
                    RectangleF rcText = new RectangleF(rc.Location - size, size);
                    cv.FillRectangle(Brushes.Yellow, rcText);
                    cv.DrawString("[" + num + "]", font, Brushes.Blue, rcText, sf);
                    cv.DrawRectangle(Pens.Blue, rc.X, rc.Y, rc.Width, rc.Height);
                }
            }
        }

        private void bVerifyKw_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = gvRes.CurrentRow;
            String dv = null;
            if (row != null)
            {
                dv = (row.Cells[cRes.Index].Value as String);
            }

            String s = Interaction.InputBox("認識結果を入力してください。指定した内容で合格するかどうかを検定します。", "", dv ?? "", -1, -1);
            if (s.Length == 0) return;

            bool f = UtKwt.PartMatch2(s, testKeywordTextBox.Text, cbSkipWs.Checked);

            MessageBox.Show(this,
                f ? "合格" : "不合格",
                Application.ProductName,
                MessageBoxButtons.OK,
                f ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );
        }

        private void bA4_Click(object sender, EventArgs e)
        {
            ocrs.Picture = Resources.A4V300;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "この枠を削除しますか?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                return;

            blkBindingSource.RemoveCurrent();
        }

        private void Add2PP(string p)
        {
            var tb = postProcessTextBox;
            var rows = new List<string>(tb.Lines);
            while (rows.Count > 0 && rows[rows.Count - 1].Length == 0)
            {
                rows.RemoveAt(rows.Count - 1);
            }
            rows.Add(p);
            tb.Lines = rows.ToArray();
        }

        private void mPPErase_Click(object sender, EventArgs e)
        {
            String s = Interaction.InputBox("文字を入力");
            if (s.Length != 1) { MessageBox.Show("キャンセルしました。"); return; }
            Add2PP("×" + s);
        }

        private void mPPRepl_Click(object sender, EventArgs e)
        {
            String s = Interaction.InputBox("どの文字を？");
            if (s.Length != 1) { MessageBox.Show("キャンセルしました。"); return; }
            String t = Interaction.InputBox("どの文字に変更？");
            if (t.Length != 1) { MessageBox.Show("キャンセルしました。"); return; }
            Add2PP(s + "→" + t);
        }

        private void mPPSwap_Click(object sender, EventArgs e)
        {
            String s = Interaction.InputBox("どの文字と？");
            if (s.Length != 1) { MessageBox.Show("キャンセルしました。"); return; }
            String t = Interaction.InputBox("どの文字を入れ替え？");
            if (t.Length != 1) { MessageBox.Show("キャンセルしました。"); return; }
            Add2PP(s + "⇔" + t);
        }

        private void bAddPP_Click(object sender, EventArgs e)
        {
            cmsPP.Show(bAddPP, new Point(0, bAddPP.Height));
        }

        private const int SC_CONTEXTHELP = 0xf180;
        private const int WM_SYSCOMMAND = 0x112;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void bSQLServer_Click(object sender, EventArgs e)
        {
            using (var form = new SQLServerLookupForm(blkBindingSource))
            {
                form.ShowDialog();
            }
        }

        private void mNone_Click(object sender, EventArgs e)
        {
            passPatternTextBox.Text = "";
        }

        private void mNaturalNums_Click(object sender, EventArgs e)
        {
            passPatternTextBox.Text = "^\\d+$";
        }

        private void bPassPatternSel_Click(object sender, EventArgs e)
        {
            menuPattern.Show(bPassPatternSel, Point.Empty);
        }

        private void bFieldDetailMenu_Click(object sender, EventArgs e)
        {
            var me = (Control)sender;
            fieldDetailMenu.Show(me, new Point(0, me.Height));
        }

        private DCR.BlkRow GetBlkRow()
        {
            var rowView = blkBindingSource.Current as DataRowView;
            return rowView?.Row as DCR.BlkRow;
        }

        private void fieldDetailMenu_Opening(object sender, CancelEventArgs e)
        {
            var row = GetBlkRow();
            cutSpacesMenuItem.Checked = row?.CutSpaces ?? false;

        }

        private void cutSpacesMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetBlkRow();
            if (row != null)
            {
                row.BeginEdit();
                row.CutSpaces = !row.CutSpaces;
                row.EndEdit();
            }

        }

        private void editUserWordsMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetBlkRow();
            if (row != null)
            {
                using (var form = new EditUserWordsForm())
                {
                    form.editor.Text = row.UserWords;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        row.BeginEdit();
                        row.UserWords = form.editor.Text;
                        row.EndEdit();
                    }
                }
            }
        }

        private void editUserPatternsMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetBlkRow();
            if (row != null)
            {
                using (var form = new EditUserPatternsForm())
                {
                    form.editor.Text = row.UserPatterns;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        row.BeginEdit();
                        row.UserPatterns = form.editor.Text;
                        row.EndEdit();
                    }
                }
            }
        }
    }


    public class UtPelsPerMeter
    {
        public static SizeF Compute(Image _Image)
        {
            return new SizeF(
                _Image.HorizontalResolution * 1.0f / 25.4f / 1000.0f,
                _Image.VerticalResolution * 1.0f / 25.4f / 1000.0f
                );
        }
    }

    // http://d.hatena.ne.jp/alcy/20071103/1194087513
    public class ScrollLessPanel : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return new Point(-this.HorizontalScroll.Value, -this.VerticalScroll.Value);
        }
    }
}
