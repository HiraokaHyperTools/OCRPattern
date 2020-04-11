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

namespace OCRPattern
{
    public partial class TemplateForm : Form
    {
        String fpxml;

        public TemplateForm(String fpxml)
        {
            this.fpxml = fpxml;

            InitializeComponent();

            Icon = Resources.e;
        }

        private void EForm_Load(object sender, EventArgs e)
        {
            {
                List<KeyValuePair<string, string>> alkv = new List<KeyValuePair<string, string>>();
                alkv.Add(new KeyValuePair<string, string>("ocr.jpn", "日本語OCR"));
                alkv.Add(new KeyValuePair<string, string>("ocr.eng", "英語OCR"));
                alkv.Add(new KeyValuePair<string, string>("gocr", "英語OCR (GOCR)"));
                alkv.Add(new KeyValuePair<string, string>("ocrad", "英語OCR (Ocrad)"));
                alkv.Add(new KeyValuePair<string, string>("nhocr", "英語OCR (NHocr)"));
                alkv.Add(new KeyValuePair<string, string>("ocr.chi_sim", "中国語(sim)OCR"));
                alkv.Add(new KeyValuePair<string, string>("ocr.chi_tra", "中国語(tra)OCR"));
                alkv.Add(new KeyValuePair<string, string>("zxing", "バーコードOCR"));
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
                alkv.Add(new KeyValuePair<string, string>("-median 3 -trim -threshold 100", "並+(メディアン・切取・境界値)"));
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
                if (LPUt.Eat(ofdPic.FileName, out pic))
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

            if (!TOcr.IsInstalled)
            {
                if (MessageBox.Show(this, "Tesseract-OCR 3.01以上が必要です。\n\n見付かりませんでした。\n\nOCRは使用できません。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                    return;
            }
            if (!Magick.IsInstalled)
            {
                if (MessageBox.Show(this, "ImageMagick 6.7.6以上が必要です。\n\n見付かりませんでした。\n\n画像処理は使用できません。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                    return;
            }

            bool all = Object.ReferenceEquals(sender, bTestAll);
            using (OCRWIPForm form = OCRWIPForm.Show1())
                Recognize(all);
        }

        public void Recognize(bool all)
        {
            Bitmap picSrc = (Bitmap)picPane.Image; //ocrs.Picture;

            foreach (DataGridViewRow vr in gvRes.Rows)
            {
                if (!all && (!vr.Selected && !Object.ReferenceEquals(blkBindingSource.Current, vr.DataBoundItem))) continue;
                DCR.BlkRow row = (DCR.BlkRow)((DataRowView)vr.DataBoundItem).Row;

                Bitmap picUsed = null;
                vr.Cells[cRes.Name].Value = RUt.Recognize3(picSrc, row, out picUsed);
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

        class LPUt
        {
            internal static bool Eat(String fp, out Bitmap pic2)
            {
                int cz = 0;
                if (String.Compare(Path.GetExtension(fp), ".pdf", true) == 0)
                {
                    using (PdfFileLoader io = new PdfFileLoader(fp))
                    {
                        cz = io.NumPages;
                    }
                }
                else
                {
                    using (Bitmap pic = new Bitmap(fp))
                    {
                        cz = pic.GetFrameCount(FrameDimension.Page);
                    }
                }
                using (PageSelForm form = new PageSelForm())
                {
                    form.numPage.Maximum = cz;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int z = (int)form.numPage.Value;
                        if (String.Compare(Path.GetExtension(fp), ".pdf", true) == 0)
                        {
                            using (PdfFileLoader io = new PdfFileLoader(fp))
                            {
                                pic2 = (io.Rasterize(z - 1));
                            }
                        }
                        else
                        {
                            using (Bitmap pic = new Bitmap(fp))
                            {
                                pic.SelectActiveFrame(FrameDimension.Page, z - 1);
                                pic2 = ((Bitmap)pic.Clone());
                            }
                        }
                        return true;
                    }
                    else
                    {
                        pic2 = null;
                        return false;
                    }
                }
            }
        }

        private void bAnother_Click(object sender, EventArgs e)
        {
            if (ofdAnother.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap pic;
                if (LPUt.Eat(ofdAnother.FileName, out pic))
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
                XmlDocument xmlo = new XmlDocument();
                XmlElement elhtml = XUt.NewTag(xmlo, "html");
                XmlElement elhead = XUt.NewTag(elhtml, "head");
                XmlElement elbody = XUt.NewTag(elhtml, "body");

                Bitmap picSrc = PUt.Clone((Bitmap)picPane.Image); //ocrs.Picture;


                List<string> alNum = new List<string>();
                SortedDictionary<string, string> dictRes = new SortedDictionary<string, string>();

                XmlElement eltable = XUt.NewTag(elbody, "table");
                eltable.SetAttribute("border", "1");
                XUt.NewTag(eltable, "caption").AppendChild(xmlo.CreateTextNode(dt2.TableName));
                {
                    XmlElement elthead = XUt.NewTag(eltable, "thead");
                    {
                        XmlElement eltr = XUt.NewTag(elthead, "tr");
                        foreach (DataColumn col in dt2.Columns)
                        {
                            XmlElement elth = XUt.NewTag(eltr, "th");
                            elth.SetAttribute("nowrap", "nowrap");
                            elth.AppendChild(xmlo.CreateTextNode(col.Caption));
                        }
                    }
                }
                {
                    XmlElement eltbody = XUt.NewTag(eltable, "tbody");
                    {
                        foreach (DataRow row in dt2.Rows)
                        {
                            XmlElement eltr = XUt.NewTag(eltbody, "tr");
                            foreach (DataColumn col in dt2.Columns)
                            {
                                XmlElement eltd = XUt.NewTag(eltr, "td");
                                eltd.SetAttribute("nowrap", "nowrap");
                                Object val = row[col];
                                if (val is Image)
                                    val = "";
                                else if (val is bool)
                                    val = ((bool)val) ? "はい" : "いいえ";
                                else if (col.ColumnName == "CRType") val = VUt.Resolve(val, cbType);
                                else if (col.ColumnName == "NoiseReduction") val = VUt.Resolve(val, cbNR);
                                else if (col.ColumnName == "PSM") val = VUt.Resolve(val, cbPSM);
                                if (col == dcOutRes)
                                {
                                    XmlElement elpre = XUt.NewTag(eltd, "pre");
                                    elpre.AppendChild(xmlo.CreateTextNode(Convert.ToString(val)));
                                }
                                else
                                {
                                    eltd.AppendChild(xmlo.CreateTextNode(Convert.ToString(val)));
                                }
                            }

                            int num = Convert.ToInt32(row["番号"]);
                            dictRes[num.ToString()] = Convert.ToString(row["認識結果"]);

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
                                    pic.Save(Path.Combine(outDir, num + ".jpg"), ImageFormat.Jpeg);
                                    alNum.Add(num.ToString());
                                }
                            }
                        }
                    }
                }
                {
                    XmlElement elp = XUt.NewTag(elbody, "p");
                    elp.AppendChild(xmlo.CreateTextNode("全体の画像："));
                }
                {
                    XmlElement elimg = XUt.NewTag(elbody, "img");
                    elimg.SetAttribute("src", "pic.jpg");
                    elimg.SetAttribute("style", "width: 80%;");
                }

                {
                    XmlElement elp = XUt.NewTag(elbody, "p");
                    elp.AppendChild(xmlo.CreateTextNode("文字認識で使用した画像："));
                }
                {
                    XmlElement elpdiv = XUt.NewTag(elbody, "div");

                    foreach (String num in alNum)
                    {
                        XmlElement elt2 = XUt.NewTag(elpdiv, "table");
                        elt2.SetAttribute("border", "1");
                        elt2.SetAttribute("cellpadding", "5");
                        elt2.SetAttribute("cellspacing", "1");
                        elt2.SetAttribute("style", "margin-right: 1em; margin-bottom: 1em;");
                        XUt.NewTag(elt2, "caption").AppendChild(xmlo.CreateTextNode(num + "の画像"));
                        {
                            XmlElement elthead = XUt.NewTag(elt2, "thead");
                            {
                                XmlElement eltr = XUt.NewTag(elthead, "tr");
                                {
                                    XmlElement eltd = XUt.NewTag(eltr, "th");
                                    eltd.AppendChild(xmlo.CreateTextNode("画像"));
                                }
                                {
                                    XmlElement eltd = XUt.NewTag(eltr, "th");
                                    eltd.AppendChild(xmlo.CreateTextNode("認識結果"));
                                }
                            }
                        }
                        {
                            XmlElement eltbody = XUt.NewTag(elt2, "tbody");
                            {
                                XmlElement eltr = XUt.NewTag(eltbody, "tr");
                                {
                                    XmlElement eltd = XUt.NewTag(eltr, "td");
                                    {
                                        XmlElement elimg = XUt.NewTag(eltd, "img");
                                        elimg.SetAttribute("src", num + ".jpg");
                                        elimg.SetAttribute("style", "border: solid 2px blue; float: left; ");
                                    }
                                }
                                {
                                    XmlElement eltd = XUt.NewTag(eltr, "td");
                                    {
                                        XmlElement elpre = XUt.NewTag(eltd, "pre");
                                        elpre.AppendChild(xmlo.CreateTextNode(Convert.ToString(dictRes[num])));
                                    }
                                }
                            }
                        }
                    }
                }

                String fpHtml = Path.Combine(outDir, "report.html");
                using (XmlTextWriter wr = new XmlTextWriter(fpHtml, Encoding.UTF8))
                {
                    wr.Formatting = Formatting.Indented;
                    xmlo.Save(wr);
                }
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
    }

    public class RUt
    {
        class CUt
        {
            internal static Bitmap Cut(Bitmap picSrc, Rectangle rc)
            {
                Bitmap pic = new Bitmap(rc.Width, rc.Height);
                pic.SetResolution(picSrc.HorizontalResolution, picSrc.VerticalResolution);
                using (Graphics cv = Graphics.FromImage(pic))
                {
                    cv.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    cv.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;

                    cv.DrawImageUnscaled(picSrc, new Point(-rc.X, -rc.Y));
                }
                return pic;
            }

            internal static Bitmap CutDPI(Bitmap picSrc, Rectangle rc, int dpi)
            {
                int cx = (int)(((float)rc.Width / picSrc.HorizontalResolution) * dpi);
                int cy = (int)(((float)rc.Height / picSrc.VerticalResolution) * dpi);
                Bitmap pic = new Bitmap(cx, cy);
                pic.SetResolution(dpi, dpi);
                using (Graphics cv = Graphics.FromImage(pic))
                {
                    cv.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    cv.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;

                    cv.DrawImage(
                        picSrc,
                        new Rectangle(0, 0, cx, cy),
                        rc,
                        GraphicsUnit.Pixel
                        );
                }
                return pic;
            }
        }

        public static object Recognize2(Bitmap picSrc, DCR.BlkRow row)
        {
            Bitmap picUsed;
            Object res = Recognize3(picSrc, row, out picUsed);
            if (picUsed != null) picUsed.Dispose();
            return res;
        }

        public static object Recognize3(Bitmap picSrc, DCR.BlkRow row, out Bitmap picUsed)
        {
            SizeF PPM = UtPelsPerMeter.Compute(picSrc);

            Rectangle rc = new Rectangle(
                (int)(row.x * PPM.Width * 1000),
                (int)(row.y * PPM.Height * 1000),
                (int)(row.cx * PPM.Width * 1000),
                (int)(row.cy * PPM.Height * 1000)
                );

            Object textrec = null;

            Bitmap picS = (row.ResampleDPI == 0) ? CUt.Cut(picSrc, rc) : CUt.CutDPI(picSrc, rc, row.ResampleDPI);
            {
                Bitmap pic = picS;
                if (!String.IsNullOrEmpty(row.NoiseReduction) && Magick.IsInstalled)
                {
                    pic = Magick.Run(pic, row.NoiseReduction);
                }
                picUsed = pic;
                String ty = row.CRType;
                if (ty == "zxing")
                {
                    if (pic.Width >= 8 && pic.Height >= 8)
                    {
                        IBarcodeReader reader = new BarcodeReader();
                        try
                        {
                            Result result = reader.Decode(pic);
                            if (result != null)
                                textrec = result.Text;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // 画像が小さいなど
                        }
                    }
                }
                else if (ty == "zxing.code128")
                {
                    if (pic.Width >= 8 && pic.Height >= 8)
                    {
                        IBarcodeReader reader = new BarcodeReader();
                        reader.Options.PossibleFormats = new BarcodeFormat[] { BarcodeFormat.CODE_128 };
                        try
                        {
                            Result result = reader.Decode(pic);
                            if (result != null)
                                textrec = result.Text;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // 画像が小さいなど
                        }
                    }
                }
                else if (ty == "gocr")
                {
                    textrec = GOcr.Rec(pic);
                }
                else if (ty == "ocrad")
                {
                    textrec = Ocrad.Rec(pic);
                }
                else if (ty == "nhocr")
                {
                    textrec = NHocr.Rec(pic);
                }
                else if (ty.StartsWith("ocr.") && TOcr.IsInstalled)
                {
                    textrec = TOcr.Rec(pic, ty.Substring(4), row.Whitelist, row.Blacklist, row.PSM);
                    if (textrec is String)
                    {
                        textrec = ((String)textrec).Replace("—", "-");
                    }
                }
            }

            if (textrec is String && row.PostProcess != null)
            {
                String[] alpp = row.PostProcess.Replace("\r\n", "\n").Split('\n');
                String ntr = "";
                foreach (char c in "" + textrec)
                {
                    foreach (String pp in alpp)
                    {
                        if (false) { }
                        else if (pp.Length == 2 && pp[0] == '×')
                        {
                            if (pp[1] == c)
                            {
                                goto _SkipIt;
                            }
                        }
                        else if (pp.Length == 3)
                        {
                            if (false) { }
                            else if (pp[1] == '⇔')
                            {
                                if (false) { }
                                else if (pp[0] == c)
                                {
                                    ntr += pp[2];
                                    goto _SkipIt;
                                }
                                else if (pp[2] == c)
                                {
                                    ntr += pp[0];
                                    goto _SkipIt;
                                }
                            }
                            else if (pp[1] == '→')
                            {
                                if (false) { }
                                else if (pp[0] == c)
                                {
                                    ntr += pp[2];
                                    goto _SkipIt;
                                }
                            }
                            else if (pp[1] == '←')
                            {
                                if (false) { }
                                else if (pp[2] == c)
                                {
                                    ntr += pp[0];
                                    goto _SkipIt;
                                }
                            }
                        }
                    }
                    ntr += c;

                _SkipIt:;
                }
                textrec = ntr;
            }

            return textrec;
        }
    }

    public class Magick
    {
        internal static string InstallDir
        {
            get
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ImageMagick\Current", false);
                if (rk != null)
                {
                    return rk.GetValue("BinPath") as String;
                }
                return null;
            }
        }
        internal static string Convertexe
        {
            get
            {
                String dir = InstallDir;
                if (dir != null)
                    return Path.Combine(dir, "convert.exe");
                return null;
            }
        }
        internal static Version Ver
        {
            get
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ImageMagick\Current", false);
                if (rk != null)
                {
                    String ver = rk.GetValue("Version") as String;
                    if (ver != null)
                        return new Version(ver);
                }
                return null;
            }
        }

        public static bool IsInstalled
        {
            get
            {
                String fp = Convertexe;
                if (fp != null && File.Exists(fp) && Ver != null && Ver >= new Version(6, 7, 6))
                    return true;
                return false;
            }
        }

        public static Bitmap Run(Bitmap picSrc, String parms)
        {
            String prefix = Guid.NewGuid().ToString("N");

            String fpSrc = Path.Combine(Path.GetTempPath(), prefix) + ".s.png";
            picSrc.Save(fpSrc, System.Drawing.Imaging.ImageFormat.Png);

            String fpDst = Path.Combine(Path.GetTempPath(), prefix) + ".t.png";

            ProcessStartInfo psi = new ProcessStartInfo(Convertexe, " " + parms + "  \"" + fpSrc + "\" \"" + fpDst + "\" ");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            p.WaitForExit();

            Bitmap res = new Bitmap(new MemoryStream(File.ReadAllBytes(fpDst)));

            if (File.Exists(fpSrc))
                File.Delete(fpSrc);
            if (File.Exists(fpDst))
                File.Delete(fpDst);

            return res;
        }
    }

    public class TOcr
    {
        class RUt
        {
            internal static RegistryKey OpenSubKey(String p)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(p, false);
                if (rk == null)
                    rk = Registry.LocalMachine.OpenSubKey(p, false);
                return rk;
            }
        }

        internal static string InstallDir
        {
            get
            {
                RegistryKey rk = RUt.OpenSubKey(@"Software\Tesseract-OCR");
                if (rk != null)
                {
                    return rk.GetValue("InstallDir") as String;
                }
                return null;
            }
        }
        internal static string Tessexe
        {
            get
            {
                String dir = InstallDir;
                if (dir == null) return null;
                return Path.Combine(dir, "tesseract.exe");
            }
        }
        internal static Version Ver
        {
            get
            {
                RegistryKey rk = RUt.OpenSubKey(@"Software\Tesseract-OCR");
                if (rk != null)
                {
                    String ver = rk.GetValue("CurrentVersion") as String;
                    if (ver != null)
                        return SemVerToVersion.Parse(ver);
                }
                return null;
            }
        }

        public static bool IsInstalled
        {
            get
            {
                String fp = Tessexe;
                if (fp != null && File.Exists(fp) && Ver != null && Ver >= new Version(3, 1))
                    return true;
                return false;
            }
        }

        public static string Rec(Bitmap pic, String lang, String whitelist, String blacklist, String psm)
        {
            String prefix = Guid.NewGuid().ToString("N");

            String fp = Path.Combine(Path.GetTempPath(), prefix) + ".bmp";
            pic.Save(fp, System.Drawing.Imaging.ImageFormat.Bmp);

            String fpOut = Path.Combine(Path.GetTempPath(), prefix);
            String fpOuttxt = fpOut + ".txt";

            String fpConfig = Path.Combine(Path.GetTempPath(), prefix) + ".cfg";
            {
                StringWriter wr = new StringWriter();
                if (!String.IsNullOrEmpty(whitelist)) wr.WriteLine("tessedit_char_whitelist " + whitelist + "");
                if (!String.IsNullOrEmpty(blacklist)) wr.WriteLine("tessedit_char_blacklist " + blacklist + "");
                //wr.WriteLine("chop_enable T");
                //wr.WriteLine("use_new_state_cost F");
                //wr.WriteLine("segment_segcost_rating F");
                //wr.WriteLine("enable_new_segsearch 0");
                //wr.WriteLine("language_model_ngram_on 0");
                //wr.WriteLine("textord_force_make_prop_words F");
                File.WriteAllBytes(fpConfig, Encoding.UTF8.GetBytes(wr.ToString()));
                //File.WriteAllText(fpConfig, wr.ToString(), Encoding.UTF8);
            }

            using (FileStream fs = File.Create(fpOuttxt)) { }

            ProcessStartInfo psi = new ProcessStartInfo(Tessexe, " \"" + fp + "\" \"" + fpOut + "\" -l " + lang + " " + (String.IsNullOrEmpty(psm) ? "" : " -psm " + psm + " ") + " \"" + fpConfig + "\"");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            p.WaitForExit();

            String res = File.ReadAllText(fpOuttxt);

            if (File.Exists(fp))
                File.Delete(fp);
            if (File.Exists(fpOuttxt))
                File.Delete(fpOuttxt);
            if (File.Exists(fpConfig))
                File.Delete(fpConfig);

            return res;
        }
    }

    [XmlType("OCRSettei")]
    public class OCRSettei
    {
        Bitmap _Picture = null;

        [XmlIgnore()]
        public Bitmap Picture
        {
            get { return _Picture; }
            set
            {
                if (_Picture != value)
                {
                    _Picture = value;
                    OnPictureChanged();
                }
            }
        }

        [XmlElement("PictureBinary")]
        public byte[] PictureBinary
        {
            get
            {
                if (_Picture != null)
                {
                    TypeConverter cvt = TypeDescriptor.GetConverter(typeof(Bitmap));
                    return (byte[])cvt.ConvertTo(_Picture, typeof(byte[]));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    Picture = new Bitmap(new MemoryStream(value));
                }
                else
                {
                    Picture = null;
                }
            }
        }

        [XmlElement("DCR")]
        public DCR DCR = new DCR();

        public event EventHandler PictureChanged;

        internal void OnPictureChanged()
        {
            if (PictureChanged != null) PictureChanged(this, new EventArgs());
        }

        String _PWay = "";

        [XmlAttribute("PWay")]
        public String PWay { get { return _PWay; } set { _PWay = value; } }
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
