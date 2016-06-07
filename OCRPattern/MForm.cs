using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using poppler2com;
using System.Diagnostics;
using OCRPattern.Properties;

namespace OCRPattern {
    public partial class MForm : Form {
        bool run;

        public MForm(String fpxml, bool run) {
            this.fpxml = fpxml;
            this.run = run;
            InitializeComponent();
            Icon = Resources.t;
        }

        private void bAdd_Click(object sender, EventArgs e) {
            if (ofdAdd.ShowDialog(this) == DialogResult.OK) {
                AddFiles(ofdAdd.FileNames);
            }
        }

        private void AddFiles(string[] p) {
            if (p == null || p.Length == 0) return;
            List<string> files = new List<string>(tbFiles.Lines);
            files.AddRange(p);
            tbFiles.Lines = files.ToArray();
            tbFiles.DataBindings["Text"].WriteValue();
        }

        private void MForm_Load(object sender, EventArgs e) {
            tsc.ContentPanel.AutoScroll = true;

            if (File.Exists(fpxml) && new FileInfo(fpxml).Length != 0) {
                XmlSerializer xs = new XmlSerializer(typeof(OCRTask));
                using (FileStream fs = File.OpenRead(fpxml)) {
                    ocrt = (OCRTask)xs.Deserialize(fs);
                    task.Merge(ocrt.Task, true, MissingSchemaAction.Add);
                    ocrt.Task = task;
                }
                this.Text += "：" + Path.GetFileNameWithoutExtension(fpxml);
            }
            else {
                ocrt.Task = task;
            }
            if (task.Cfg.Rows.Count == 0) {
                task.Cfg.AddCfgRow(task.Cfg.NewCfgRow());
            }

            cfgBindingSource.DataSource = ocrt.Task;

            Updatefl();

            if (run) {
                bRun.PerformClick();
                Close();
            }
        }

        private void Updatefl() {
            foreach (Task.CfgRow row in task.Cfg.Rows) {
                if (row.ClearAlways) {
                    row.BeginEdit();
                    row.Files = "";
                    row.EndEdit();
                }
                if (row.ImportAlways) {
                    try {
                        List<string> files = new List<string>();
                        foreach (String fext in "tif,tiff,pdf".Split(',')) {
                            files.AddRange(Directory.GetFiles(row.DirIn, "*." + fext));
                        }
                        files.Sort();
                        AddFiles(files.ToArray());
                    }
                    catch (Exception err) {
                        MessageBox.Show(this, "自動入力に失敗しました:\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                break;
            }
        }

        OCRTask ocrt = new OCRTask();

        String fpxml;

        private void bRefDirIn_Click(object sender, EventArgs e) {
            if (fbdDirIn.ShowDialog(this) == DialogResult.OK) {
                tbDirIn.Text = fbdDirIn.SelectedPath;
            }
        }

        private void bSave_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(fpxml)) return;

            if (!ValidateChildren()) return;

            cfgBindingSource.EndEdit();

            XmlSerializer xs = new XmlSerializer(typeof(OCRTask));
            using (FileStream fs = File.Create(fpxml)) {
                xs.Serialize(fs, ocrt);
            }
            MessageBox.Show(this, "保存しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        class Move2Temp : IDisposable {
            List<string> alfp = new List<string>();

            internal void Add(string fp) {
                alfp.Add(fp);
            }

            #region IDisposable メンバ

            public void Dispose() {
                foreach (String fp in alfp) {
                    try {
                        MFUt.MoveTo(fp, Path.GetTempPath());
                    }
                    catch (Exception err) {
                        Debug.Fail("削除に失敗しました(" + fp + ")", err.ToString());
                    }
                }
            }

            #endregion
        }

        private void bRun_Click(object sender, EventArgs e) {
            CRContext crc = new CRContext();
            if (!crc.ReadSet(Path.GetDirectoryName(fpxml))) {
                MessageBox.Show(this, "OCRPattern テンプレート ファイルが見付かりません。\n\n先に作成してください。\n\n中止します。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String outDir = tbDirOut.Text;
            if (String.IsNullOrEmpty(outDir) || !Directory.Exists(outDir)) {
                MessageBox.Show(this, "保存できる出力フォルダを先に設定してください。\n\n中止します。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String recycDir = cbUseRecyc.Checked ? tbRecycDir.Text : null;
            String formSel = cbOnlyThis.Checked ? tbSeledForm.Text : "";
            FPUt fput = new FPUt(outDir);
            FPUt fputRecyc = (recycDir != null) ? new FPUt(recycDir) : null;
            using (Move2Temp m2t = new Move2Temp())
            using (OCRWIPForm form = OCRWIPForm.Show1()) {
                form.panelWIP.Show();
                foreach (String fp in tbFiles.Lines) {
                    if (!File.Exists(fp)) continue;
                    form.lfn.Text = Path.GetFileName(fp);
                    form.ldir.Text = Path.GetDirectoryName(fp);
                    fput.Flush();
                    String fext = Path.GetExtension(fp);
                    bool isPDF = String.Compare(fext, ".pdf", true) == 0;

                    using (UtPICio pdf = isPDF ? new UtPDFio(fp) as UtPICio : new UtTIFio(fp)) {
                        int cz = pdf.NumPages;
                        for (int z = 0; z < cz; z++) {
                            if (cbDoNotSplit.Checked && z != 0) continue;
                            form.HintPage(1 + z, true);
                            using (Bitmap pic = pdf.Rasterize(z)) {
                                crc.dtCR.Columns.Clear();
                                crc.dtCR.Rows.Clear();
                                CRRes resc;
                                if (CanSave(resc = TryCR(pic, fp, z, crc, form, cbRotate4.Checked, formSel))) {
                                    // 認識：成功
                                    if (resc == CRRes.SaveAll) {
                                        fput.Prepare(fext, ".csv");
                                        File.Copy(fp, fput.fp1, true);
                                        SCUt.SaveCsv(fput.fp2, crc.dtCR, Encoding.Default);
                                        RunCmd(fp, fput.fp1, fput.fp2, m2t);
                                        crc.ClearTempl();
                                        break;
                                    }
                                    else {
                                        fput.Prepare(fext, ".csv");
                                        pdf.SavePageAs(fput.fp1, 1 + z);
                                        SCUt.SaveCsv(fput.fp2, crc.dtCR, Encoding.Default);
                                        RunCmd(fp, fput.fp1, fput.fp2, m2t);
                                    }
                                }
                                else if (fputRecyc != null) {
                                    // 認識：失敗、保存有り
                                    if (cbDoNotSplit.Checked) {
                                        fputRecyc.Prepare(fext, fext);
                                        File.Copy(fp, fputRecyc.fp1, true);
                                        pdf.Dispose();
                                        try {
                                            File.Delete(fp);
                                        }
                                        catch (Exception) { }
                                        break;
                                    }
                                    else {
                                        fputRecyc.Prepare(fext, fext);
                                        pdf.SavePageAs(fputRecyc.fp1, 1 + z);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            Updatefl();
            MessageBox.Show(this, "完了しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunCmd(string fp, string fppic, string fpcsv, Move2Temp m2t) {
            if (cbMoveInAfter.Checked) {
                m2t.Add(fp);
            }

            if (cbRunOutCmd.Checked) {
                ProcessStartInfo psi = new ProcessStartInfo(Environment.ExpandEnvironmentVariables(tbOutCmd.Text), tbOutParm.Text
                    .Replace("%csv%", fpcsv)
                    .Replace("%pic%", fppic)
                    );
                String cwd = Path.GetDirectoryName(fpxml); // new cwd at fpxml.
                if (cwd != null && Directory.Exists(cwd)) psi.WorkingDirectory = cwd;
                Process p = Process.Start(psi);
                p.WaitForExit();
            }

            if (cbMoveOutAfter.Checked) {
                m2t.Add(fpcsv);
                m2t.Add(fppic);
            }
        }

        class MFUt {
            internal static void MoveTo(string fp, string dirTo) {
                for (int x = 1; x < 1000; x++) {
                    String fpTo = Path.Combine(dirTo, Path.GetFileNameWithoutExtension(fp) + ((x >= 2) ? " (" + x + ")" : "") + Path.GetExtension(fp));
                    if (File.Exists(fpTo))
                        continue;
                    File.Move(fp, fpTo);
                    break;
                }
            }
        }

        private bool CanSave(CRRes res) {
            switch (res) {
                case CRRes.Avail:
                case CRRes.SaveAll:
                    //case CRRes.Sepa:
                    return true;
            }
            return false;
        }

        delegate void SavePicDelegate(String fpTo);

        class FPUt {
            String outDir;
            int num = 1;
            DateTime dt = DateTime.Now;

            public FPUt(String outDir) {
                this.outDir = outDir;
            }

            public void Prepare(String fext1, String fext2) {
                while (true) {
                    String id = String.Format("{0:yyyyMMdd}_{1:0000}", dt, num);
                    ++num;
                    if (File.Exists(fp1 = Path.Combine(outDir, id + fext1))) continue;
                    if (File.Exists(fp2 = Path.Combine(outDir, id + fext2))) continue;
                    break;
                }
            }

            public String fp1 = String.Empty;
            public String fp2 = String.Empty;

            internal void Flush() {
                fp1 = String.Empty;
                fp2 = String.Empty;
            }
        }

        class SCUt {
            public static void SaveCsv(String fpcsv, DataTable dt, Encoding enc) {
                Csvw wr = new Csvw();
                foreach (DataColumn dc in dt.Columns)
                    wr.AddCol(dc.ColumnName);
                wr.NewRow();
                foreach (DataRow dr in dt.Rows) {
                    foreach (DataColumn dc in dt.Columns) {
                        wr.AddCol(Convert.ToString(dr[dc]));
                    }
                    wr.NewRow();
                }
                File.WriteAllText(fpcsv, wr.ToString(), enc);
            }
        }

        class PiUt {
            internal static Bitmap Rotate(Bitmap picSrc, int rot) {
                if (rot == 0)
                    return picSrc;
                Bitmap pic2 = new Bitmap(picSrc);
                pic2.SetResolution(picSrc.HorizontalResolution, picSrc.VerticalResolution);
                switch (rot) {
                    case 1: pic2.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                    case 2: pic2.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                    case 3: pic2.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                    default: throw new NotSupportedException();
                }
                return pic2;
            }
        }

        enum CRRes {
            Avail, Fail, Sepa, SaveAll,
        }

        private CRRes TryCR(Bitmap picSrc, String fp, int z, CRContext crc, OCRWIPForm wipper, bool rotate4, String formSel) {
            String baseDir = Path.GetDirectoryName(fpxml);
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "認識対象＝" + fp);

            if (formSel == null) formSel = "";
            bool fSelForm = formSel != "";

            for (int rot = 0; rot < (rotate4 ? 4 : 1); rot++) {
                wipper.HintRot(rot);
                Bitmap pic = PiUt.Rotate(picSrc, rot);
                foreach (KeyValuePair<string, OCRSettei> kvs in crc.dictSet) {
                    Program.appTrace.TraceEvent(TraceEventType.Information, 0, "フォーム＝" + kvs.Key);

                    bool forceThis = false;
                    if (fSelForm) {
                        if (String.Compare(formSel, Path.GetFileNameWithoutExtension(kvs.Key), true) != 0)
                            continue;
                        forceThis = true;
                    }

                    wipper.HintTempl(Path.GetFileNameWithoutExtension(kvs.Key), false);

                    bool fail = false, any = false;
                    {
                        DataRow[] rows = kvs.Value.DCR.Blk.Select("IfTest");
                        for (int x = 0; x < rows.Length; x++) {
                            DCR.BlkRow row = (DCR.BlkRow)rows[x];
                            wipper.HintForm(x, rows.Length * 2);

                            Object res = RUt.Recognize2(pic, row);
                            if (res != null && UtKwt.PartMatch2(Convert.ToString(res), row.TestKeyword, row.SkipWs)) {
                                any = true;
                            }
                            else {
                                fail = true;
                            }
                        }
                    }

                    Program.appTrace.TraceEvent(TraceEventType.Information, 0, "fail=" + fail + ", " + "any=" + any);

                    if (fail) {
                        if (forceThis) {

                        }
                        else {
                            continue;
                        }
                    }
                    else {
                        if (!any) continue;
                    }

                    Program.appTrace.TraceEvent(TraceEventType.Information, 0, "通過");

                    bool needVerify = kvs.Value.DCR.Blk.Select("NeedVerify").Length != 0;

                    wipper.HintTempl(Path.GetFileNameWithoutExtension(kvs.Key), true);

                    if (kvs.Value.PWay == "S1" && z == 0) {
                        Program.appTrace.TraceEvent(TraceEventType.Information, 0, "種類＝表紙付きモード");
                        if (fail) {
                            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "検出：失敗");
                        }
                        else {
                            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "検出：成功");
                            // 表紙付き(フォーム検出成功)
                            crc.StartTemplPage();
                            crc.AddTempl("TEMPLATE", Path.GetFileNameWithoutExtension(kvs.Key));
                            DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                            for (int x = 0; x < rows.Length; x++) {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                wipper.HintForm(rows.Length + x, 2 * rows.Length);

                                Object res = RUt.Recognize2(pic, row);
                                crc.AddTempl(row.FieldName, res ?? "");
                            }

                            crc.NewRecord();
                            crc.AddFrmTempl();
                            crc.SetValue("OCR", 1);
                            if (needVerify) {
                                using (ConfirmForm form = new ConfirmForm(kvs.Value, pic)) {
                                    form.Read(crc, kvs.Value.DCR.Blk);
                                    switch (form.ShowDialog()) {
                                        case DialogResult.OK:
                                            form.SaveTo(crc);
                                            break;
                                        case DialogResult.No:
                                            continue;
                                        default:
                                            throw new ApplicationException("中止しました。");
                                    }
                                }
                            }
                            crc.CommitRecord();

                            crc.TemplAvail = true;
                            return CRRes.SaveAll;
                        }
                    }
                    else if (kvs.Value.PWay == "S") {
                        Program.appTrace.TraceEvent(TraceEventType.Information, 0, "種類＝区切り/代表ページ");
                        if (fail) {
                            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "検出：失敗");
                        }
                        else {
                            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "検出：成功");
                            // 区切り(フォーム検出成功)
                            crc.StartTemplPage();
                            crc.AddTempl("TEMPLATE", Path.GetFileNameWithoutExtension(kvs.Key));
                            DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                            for (int x = 0; x < rows.Length; x++) {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                wipper.HintForm(rows.Length + x, 2 * rows.Length);

                                Object res = RUt.Recognize2(pic, row);
                                crc.AddTempl(row.FieldName, res ?? "");
                            }
                            crc.TemplAvail = true;
                            return CRRes.Sepa;
                        }
                    }
                    else if (kvs.Value.PWay == "") {
                        Program.appTrace.TraceEvent(TraceEventType.Information, 0, "種類＝通常フォーム認識");
                        // 通常(フォーム検出成功)
                        crc.ClearTempl();
                        crc.NewRecord();
                        crc.SetValue("OCR", 1);
                        crc.SetValue("FORM", Path.GetFileNameWithoutExtension(kvs.Key));
                        DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                        for (int x = 0; x < rows.Length; x++) {
                            DCR.BlkRow row = (DCR.BlkRow)rows[x];
                            wipper.HintForm(rows.Length + x, 2 * rows.Length);

                            Object res = RUt.Recognize2(pic, row);
                            crc.SetValue(row.FieldName, res ?? "");
                        }
                        if (needVerify) {
                            using (ConfirmForm form = new ConfirmForm(kvs.Value, pic)) {
                                form.Read(crc, kvs.Value.DCR.Blk);
                                switch (form.ShowDialog()) {
                                    case DialogResult.OK:
                                        form.SaveTo(crc);
                                        break;
                                    case DialogResult.No:
                                        continue;
                                    default:
                                        throw new ApplicationException("中止しました。");
                                }
                            }
                        }
                        crc.CommitRecord();
                        crc.TemplAvail = false;
                        return CRRes.Avail;
                    }
                    Program.appTrace.TraceEvent(TraceEventType.Information, 0, "終了");
                }
            }
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "crc.TemplAvail=" + crc.TemplAvail);
            if (crc.TemplAvail) {
                // 区切り従属
                crc.NewRecord();
                crc.AddFrmTempl();
                crc.SetValue("OCR", 1);
                crc.CommitRecord();
                return CRRes.Avail;
            }
            return CRRes.Fail;
        }

        [DllImport("poppler2com.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        static extern int GetMyPoppler(out IMyPoppler pprv);

        private void bRefDirOut_Click(object sender, EventArgs e) {
            if (fbdDirOut.ShowDialog(this) == DialogResult.OK) {
                tbDirOut.Text = fbdDirOut.SelectedPath;
            }
        }

        class Csvw {
            StringWriter wr = new StringWriter();
            int x = 0;
            static char[] alcWeak = ",\"\r\n\t;|".ToCharArray();

            public void AddCol(string s) {
                if (x != 0)
                    wr.Write(",");
                x++;

                if (s.IndexOfAny(alcWeak) >= 0) {
                    wr.Write("\"" + s.Replace("\"", "\"\"") + "\"");
                }
                else {
                    wr.Write(s);
                }
            }
            public void NewRow() {
                wr.WriteLine();
                x = 0;
            }
            public override string ToString() {
                return wr.ToString();
            }
        }

        private void tbFiles_DragEnter(object sender, DragEventArgs e) {
            e.Effect = e.AllowedEffect & (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None);
        }

        private void tbFiles_DragDrop(object sender, DragEventArgs e) {
            String[] alfp = e.Data.GetData(DataFormats.FileDrop) as String[];
            if (alfp != null)
                AddFiles(alfp);
        }

        private void bRefOutCmd_Click(object sender, EventArgs e) {
            if (ofdOutCmd.ShowDialog(this) == DialogResult.OK) {
                tbOutCmd.Text = ofdOutCmd.FileName;
            }
        }

        private void bAddOutParm_Click(object sender, EventArgs e) {
            cmsOutCmd.Show(bAddOutParm, new Point(0, bAddOutParm.Height));
        }

        private void mParmcsv_Click(object sender, EventArgs e) {
            tbOutParm.AppendText(" \"%csv%\"");
        }

        private void mParmpic_Click(object sender, EventArgs e) {
            tbOutParm.AppendText(" \"%pic%\"");
        }

        private void bSelForm_Click(object sender, EventArgs e) {
            using (SelForm form = new SelForm(Path.GetDirectoryName(fpxml))) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    tbSeledForm.Text = form.SeledForm;
                    tbSeledForm.DataBindings["Text"].WriteValue();

                    bool f = tbSeledForm.TextLength != 0;
                    bool c = cbOnlyThis.Checked;
                    if (c != f) cbOnlyThis.Checked = f;
                }
            }
        }

        private void cbRotate4_CheckedChanged(object sender, EventArgs e) {
            if (cbRotate4.Checked && cbOnlyThis.Checked) {
                //MessageBox.Show(this, "「" + cbRotate4.Text + "」と「" + cbOnlyThis.Text + "」は、両方一緒には使用できません。片方だけにしてください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bRefRecycDir_Click(object sender, EventArgs e) {
            if (fbdRecycDir.ShowDialog(this) == DialogResult.OK) {
                tbRecycDir.Text = fbdRecycDir.SelectedPath;
                cbUseRecyc.Checked = true;
                cbUseRecyc.DataBindings["Checked"].WriteValue();
            }
        }

        private void bDebugOutput_Click(object sender, EventArgs e) {
            DebugOutForm form = new DebugOutForm();
            form.Show();
        }

    }

    public abstract class UtPICio : IDisposable {
        public abstract int NumPages { get; }
        public abstract Bitmap Rasterize(int z);
        public abstract void SavePageAs(string fp, int page);

        #region IDisposable メンバ

        public abstract void Dispose();

        #endregion
    }

    public class UtTIFio : UtPICio {
        Bitmap pic;

        public override int NumPages { get { return pic.GetFrameCount(FrameDimension.Page); } }

        public UtTIFio(String fp) {
            pic = new Bitmap(fp);
        }

        public override Bitmap Rasterize(int z) {
            pic.SelectActiveFrame(FrameDimension.Page, z);
            return pic;
        }

        public override void SavePageAs(string fp, int page) {
            if (NumPages != 1) pic.SelectActiveFrame(FrameDimension.Page, page);
            pic.Save(fp, ImageFormat.Tiff);
        }

        public override void Dispose() {
            pic.Dispose();
        }
    }

    public class UtPDFio : UtPICio {
        IMyPoppler pop = null;
        IMyPDFDoc doc = null;

        public float DPI = 200;

        public override int NumPages { get { return doc.getNumPages(); } }

        public UtPDFio(String fp) {
            GetMyPoppler(out pop);
            doc = pop.NewPDFDoc(fp);
        }

        public override Bitmap Rasterize(int z) {
            IMySplashOutputDev dev = doc.displayPage(1 + z, DPI, DPI, 0, 1, 0, 0);
            try {
                int cx = dev.BitmapWidth;
                int cy = dev.BitmapHeight;
                Bitmap pic = new Bitmap(cx, cy, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                {
                    pic.SetResolution(DPI, DPI);
                    BitmapData bd = pic.LockBits(new Rectangle(0, 0, cx, cy), System.Drawing.Imaging.ImageLockMode.WriteOnly, pic.PixelFormat);
                    try {
                        byte[] bin = new byte[bd.Stride];
                        for (int y = 0; y < cy; y++) {
                            Marshal.Copy(new IntPtr(dev.DataPtr.ToInt64() + bin.Length * y), bin, 0, bin.Length);
                            for (int x = 0; x < cx; x++) {
                                int i = 3 * x;
                                byte b = bin[i + 2];
                                bin[i + 2] = bin[i];
                                bin[i] = b;
                            }
                            Marshal.Copy(bin, 0, new IntPtr(bd.Scan0.ToInt64() + bin.Length * y), bin.Length);
                        }
                    }
                    finally {
                        pic.UnlockBits(bd);
                    }
                    return pic;
                }
            }
            finally {
                Marshal.ReleaseComObject(dev);
            }
        }

        public override void SavePageAs(string fp, int page) {
            doc.savePageAs(fp, page);
        }

        [DllImport("poppler2com.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        static extern int GetMyPoppler(out IMyPoppler pprv);

        #region IDisposable メンバ

        public override void Dispose() {
            if (doc != null) Marshal.ReleaseComObject(doc);
            if (pop != null) Marshal.ReleaseComObject(pop);
        }

        #endregion
    }

    public class UtKwt {
        [Obsolete("Use PartMatch instead.", true)]
        public static bool Match(String input, String test) {
            input = Regex.Replace(input, "\\s+", "");
            test = Regex.Replace(test, "\\s+", "");
            return String.Compare(input, test) == 0;
        }

        public static bool PartMatch(String input, String test) {
            input = Regex.Replace(input, "\\s+", " ");
            test = Regex.Replace(test, "\\s+", " ").Trim();
            return input.Contains(test);
        }

        public static bool PartMatch2(String input, String test, bool skipws) {
            input = Regex.Replace(input, "\\s+", skipws ? "" : " ");
            test = Regex.Replace(test, "\\s+", skipws ? "" : " ").Trim();
            return input.Contains(test);
        }
    }

    public class CRContext {
        public DataTable dtCR = new DataTable();
        public SortedDictionary<string, OCRSettei> dictSet = new SortedDictionary<string, OCRSettei>();
        public SortedDictionary<string, string> dictTempl = new SortedDictionary<string, string>();

        public bool ReadSet(String baseDir) {
            dictSet.Clear();
            foreach (String fpSet in Directory.GetFiles(baseDir, "*.OCR-Settei")) {
                using (FileStream fs = File.OpenRead(fpSet)) {
                    XmlSerializer xs = new XmlSerializer(typeof(OCRSettei));
                    OCRSettei ocrs = dictSet[fpSet] = (OCRSettei)xs.Deserialize(fs);
                    DCR dcr = new DCR();
                    dcr.Merge(ocrs.DCR, true, MissingSchemaAction.Add);
                    ocrs.DCR = dcr;
                }
            }
            return dictSet.Count != 0;
        }

        public void AddTempl(String field, Object value) {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.AddTempl(" + field + "," + value + ")");
            dictTempl[field] = Convert.ToString(value);
        }

        internal void StartTemplPage() {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.StartTemplPage");
            dictTempl.Clear();
        }

        internal DataRow drCR = null;

        bool templAvail = false;

        public bool TemplAvail { get { return templAvail; } set { templAvail = value; } }

        internal void NewRecord() {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.NewRecord");
            drCR = dtCR.NewRow();
        }

        internal void SetValue(String field, Object val) {
            if (dtCR.Columns.IndexOf(field) < 0) {
                dtCR.Columns.Add(field, typeof(string));
            }
            drCR[field] = val;
        }

        internal void CommitRecord() {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.CommitRecord");
            dtCR.Rows.Add(drCR);
        }

        internal void AddFrmTempl() {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.AddFrmTempl");
            foreach (KeyValuePair<string, string> kv in dictTempl) {
                SetValue(kv.Key, kv.Value);
            }
        }

        internal void ClearTempl() {
            Program.appTrace.TraceEvent(TraceEventType.Information, 0, "CRContext.ClearTempl");
            dictTempl.Clear();
            TemplAvail = false;
        }
    }

    [XmlType("OCRTask")]
    public class OCRTask {

        [XmlElement("Task")]
        public Task Task = new Task();
    }
}