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
using System.Diagnostics;
using OCRPattern.Properties;
using NLog;
using OCRPattern.Utils;
using PdfiumViewer;
using OCRPattern.Interfaces;
using OCRPattern.Models;

namespace OCRPattern
{
    public partial class MForm : Form
    {
        bool run;

        public MForm(String fpxml, bool run)
        {
            this.fpxml = fpxml;
            this.run = run;
            InitializeComponent();
            Icon = Resources.t;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (ofdAdd.ShowDialog(this) == DialogResult.OK)
            {
                AddFiles(ofdAdd.FileNames);
            }
        }

        private void AddFiles(string[] p)
        {
            if (p == null || p.Length == 0) return;
            List<string> files = new List<string>(tbFiles.Lines);
            files.AddRange(p);
            tbFiles.Lines = files.ToArray();
            tbFiles.DataBindings["Text"].WriteValue();
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            tsc.ContentPanel.AutoScroll = true;

            if (File.Exists(fpxml) && new FileInfo(fpxml).Length != 0)
            {
                XmlSerializer xs = new XmlSerializer(typeof(OCRTask));
                using (FileStream fs = File.OpenRead(fpxml))
                {
                    ocrTask = (OCRTask)xs.Deserialize(fs);
                    task.Merge(ocrTask.Task, true, MissingSchemaAction.Add);
                    ocrTask.Task = task;
                }
                this.Text += "：" + Path.GetFileNameWithoutExtension(fpxml);
            }
            else
            {
                ocrTask.Task = task;
            }
            if (task.Cfg.Rows.Count == 0)
            {
                task.Cfg.AddCfgRow(task.Cfg.NewCfgRow());
            }

            cfgBindingSource.DataSource = ocrTask.Task;

            Updatefl();

            if (run)
            {
                bRun.PerformClick();
                Close();
            }
        }

        private void Updatefl()
        {
            foreach (Task.CfgRow row in task.Cfg.Rows)
            {
                if (row.ClearAlways)
                {
                    row.BeginEdit();
                    row.Files = "";
                    row.EndEdit();
                }
                if (row.ImportAlways)
                {
                    try
                    {
                        List<string> files = new List<string>();
                        foreach (String fext in "tif,tiff,pdf".Split(','))
                        {
                            files.AddRange(Directory.GetFiles(row.DirIn, "*." + fext));
                        }
                        files.Sort();
                        AddFiles(files.ToArray());
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(this, "自動入力に失敗しました:\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                break;
            }
        }

        OCRTask ocrTask = new OCRTask();

        String fpxml;

        private void bRefDirIn_Click(object sender, EventArgs e)
        {
            if (fbdDirIn.ShowDialog(this) == DialogResult.OK)
            {
                tbDirIn.Text = fbdDirIn.SelectedPath;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fpxml)) return;

            if (!ValidateChildren()) return;

            cfgBindingSource.EndEdit();

            XmlSerializer xs = new XmlSerializer(typeof(OCRTask));
            using (FileStream fs = File.Create(fpxml))
            {
                xs.Serialize(fs, ocrTask);
            }
            MessageBox.Show(this, "保存しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        Logger log = LogManager.GetCurrentClassLogger();

        private void bRun_Click(object sender, EventArgs e)
        {
            CRContext crc = new CRContext();
            if (!crc.ReadSet(Path.GetDirectoryName(fpxml)))
            {
                MessageBox.Show(this, "OCRPattern テンプレート ファイルが見付かりません。\n\n先に作成してください。\n\n中止します。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String outDir = tbDirOut.Text;
            if (String.IsNullOrEmpty(outDir) || !Directory.Exists(outDir))
            {
                MessageBox.Show(this, "保存できる出力フォルダを先に設定してください。\n\n中止します。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String recycDir = cbUseRecyc.Checked ? tbRecycDir.Text : null;
            String formSel = cbOnlyThis.Checked ? tbSeledForm.Text : "";
            FPUt fput = new FPUt(outDir);
            FPUt fputRecyc = (recycDir != null) ? new FPUt(recycDir) : null;
            using (Move2Temp m2t = new Move2Temp())
            using (OCRWIPForm form = OCRWIPForm.Show1())
            {
                form.panelWIP.Show();
                if (cbEraseOlderOutFiles.Checked)
                {
                    EraseOldFiles.Run(outDir, "\\.(tif|tiff|pdf|csv|tmp)$", TimeSpan.FromDays(31));
                }
                if (cbEraseOlderTempFiles.Checked)
                {
                    EraseOldFiles.Run(Path.GetTempPath(), "\\.(tif|tiff|pdf|csv|tmp)$", TimeSpan.FromDays(31));
                }
                foreach (String fp in tbFiles.Lines)
                {
                    if (!File.Exists(fp)) continue;
                    form.lfn.Text = Path.GetFileName(fp);
                    form.ldir.Text = Path.GetDirectoryName(fp);
                    fput.Flush();
                    String fext = Path.GetExtension(fp);
                    bool isPDF = String.Compare(fext, ".pdf", true) == 0;

                    using (IMultiPageFileLoader pdf = isPDF ? new PdfFileLoader(fp) as IMultiPageFileLoader : new TiffFileLoader(fp))
                    {
                        int cz = pdf.NumPages;
                        for (int z = 0; z < cz; z++)
                        {
                            if (cbDoNotSplit.Checked && z != 0) continue;
                            form.HintPage(1 + z, true);
                            using (Bitmap pic = pdf.Rasterize(z))
                            {
                                crc.dtCR.Columns.Clear();
                                crc.dtCR.Rows.Clear();
                                CRRes resc;
                                if (CanSave(resc = TryCR(pic, fp, z, crc, form, cbRotate4.Checked, formSel)))
                                {
                                    // 認識：成功
                                    if (resc == CRRes.SaveAll)
                                    {
                                        fput.Prepare(fext, ".csv");
                                        File.Copy(fp, fput.fp1, true);
                                        SCUt.SaveCsv(fput.fp2, crc.dtCR, Encoding.Default);
                                        RunCmd(fp, fput.fp1, fput.fp2, m2t);
                                        crc.ClearTempl();
                                        break;
                                    }
                                    else
                                    {
                                        fput.Prepare(fext, ".csv");
                                        pdf.SavePageAs(fput.fp1, 1 + z);
                                        SCUt.SaveCsv(fput.fp2, crc.dtCR, Encoding.Default);
                                        RunCmd(fp, fput.fp1, fput.fp2, m2t);
                                    }
                                }
                                else if (fputRecyc != null)
                                {
                                    // 認識：失敗、保存有り
                                    if (cbDoNotSplit.Checked)
                                    {
                                        fputRecyc.Prepare(fext, fext);
                                        File.Copy(fp, fputRecyc.fp1, true);
                                        pdf.Dispose();
                                        try
                                        {
                                            File.Delete(fp);
                                        }
                                        catch (Exception ex)
                                        {
                                            log.Warn(ex, "認識失敗ファイルの削除に失敗: {0}", fp);
                                        }
                                        break;
                                    }
                                    else
                                    {
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

        Logger runCmdLog = LogManager.GetLogger("RunCmd");

        private void RunCmd(string fp, string fppic, string fpcsv, Move2Temp m2t)
        {
            if (cbMoveInAfter.Checked)
            {
                m2t.Add(fp);
            }

            if (cbRunOutCmd.Checked)
            {
                ProcessStartInfo psi = new ProcessStartInfo(Environment.ExpandEnvironmentVariables(tbOutCmd.Text), tbOutParm.Text
                    .Replace("%csv%", fpcsv)
                    .Replace("%pic%", fppic)
                    );
                String cwd = Path.GetDirectoryName(fpxml); // new cwd at fpxml.
                if (cwd != null && Directory.Exists(cwd)) psi.WorkingDirectory = cwd;
                runCmdLog.Debug("実行: {0}\n{1}", psi.FileName, psi.Arguments);
                Process p = Process.Start(psi);
                p.WaitForExit();
                runCmdLog.Debug("結果: {0}", p.ExitCode);
            }

            if (cbMoveOutAfter.Checked)
            {
                m2t.Add(fpcsv);
                m2t.Add(fppic);
            }
        }

        private bool CanSave(CRRes res)
        {
            switch (res)
            {
                case CRRes.Avail:
                case CRRes.SaveAll:
                    //case CRRes.Sepa:
                    return true;
            }
            return false;
        }

        delegate void SavePicDelegate(String fpTo);

        enum CRRes
        {
            Avail, Fail, Sepa, SaveAll,
        }

        Logger ocrLog = LogManager.GetLogger("OCR");

        private CRRes TryCR(Bitmap picSrc, String fp, int z, CRContext crc, OCRWIPForm wipper, bool rotate4, String formSel)
        {
            String baseDir = Path.GetDirectoryName(fpxml);
            ocrLog.Info("認識対象＝{0}", fp);
            ocrLog.Debug("ページ＝{0}", 1 + z);

            if (formSel == null) formSel = "";
            bool fSelForm = formSel != "";

            for (int rot = 0; rot < (rotate4 ? 4 : 1); rot++)
            {
                ocrLog.Debug("回転回数＝{0}", rot);
                wipper.HintRot(rot);
                Bitmap pic = PiUt.Rotate(picSrc, rot);
                foreach (KeyValuePair<string, OCRSettei> kvs in crc.dictSet)
                {
                    ocrLog.Info("フォーム＝{0}", kvs.Key);

                    bool forceThis = false;
                    if (fSelForm)
                    {
                        if (String.Compare(formSel, Path.GetFileNameWithoutExtension(kvs.Key), true) != 0)
                            continue;
                        forceThis = true;
                    }

                    wipper.HintTempl(Path.GetFileNameWithoutExtension(kvs.Key), false);

                    bool fail = false, any = false;
                    {
                        DataRow[] rows = kvs.Value.DCR.Blk.Select("IfTest");
                        for (int x = 0; x < rows.Length; x++)
                        {
                            DCR.BlkRow row = (DCR.BlkRow)rows[x];
                            wipper.HintForm(x, rows.Length * 2);

                            Object res = RUt.Recognize2(pic, row);
                            if (res != null && UtKwt.PartMatch2(Convert.ToString(res), row.TestKeyword, row.SkipWs))
                            {
                                any = true;
                            }
                            else
                            {
                                fail = true;
                            }
                        }
                    }

                    ocrLog.Debug("fail={0}, any={1}", fail, any);

                    if (fail)
                    {
                        if (forceThis)
                        {

                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!any) continue;
                    }

                    ocrLog.Info("通過");

                    bool needVerify = kvs.Value.DCR.Blk.Select("NeedVerify").Length != 0;

                    wipper.HintTempl(Path.GetFileNameWithoutExtension(kvs.Key), true);

                    if (kvs.Value.PWay == "S1" && z == 0)
                    {
                        ocrLog.Info("種類＝表紙付きモード");
                        if (fail)
                        {
                            ocrLog.Info("検出：失敗");
                        }
                        else
                        {
                            ocrLog.Info("検出：成功");
                            // 表紙付き(フォーム検出成功)
                            crc.StartTemplPage();
                            crc.AddTempl("TEMPLATE", Path.GetFileNameWithoutExtension(kvs.Key));
                            DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                            for (int x = 0; x < rows.Length; x++)
                            {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                wipper.HintForm(rows.Length + x, 2 * rows.Length);

                                Object res = RUt.Recognize2(pic, row);
                                crc.AddTempl(row.FieldName, res ?? "");
                            }

                            crc.NewRecord();
                            crc.AddFrmTempl();
                            crc.SetValue("OCR", 1);
                            if (needVerify)
                            {
                                using (ConfirmForm form = new ConfirmForm(kvs.Value, pic))
                                {
                                    form.Read(crc, kvs.Value.DCR.Blk);
                                    switch (form.ShowDialog())
                                    {
                                        case DialogResult.OK:
                                            form.SaveTo(crc);
                                            break;
                                        case DialogResult.No:
                                            continue;
                                        default:
                                            log.Info("中止しました。");
                                            throw new ApplicationException("中止しました。");
                                    }
                                }
                            }
                            crc.CommitRecord();

                            crc.TemplAvail = true;
                            return CRRes.SaveAll;
                        }
                    }
                    else if (kvs.Value.PWay == "S")
                    {
                        ocrLog.Info("種類＝区切り/代表ページ");
                        if (fail)
                        {
                            ocrLog.Info("検出：失敗");
                        }
                        else
                        {
                            ocrLog.Info("検出：成功");
                            // 区切り(フォーム検出成功)
                            crc.StartTemplPage();
                            crc.AddTempl("TEMPLATE", Path.GetFileNameWithoutExtension(kvs.Key));
                            DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                            for (int x = 0; x < rows.Length; x++)
                            {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                wipper.HintForm(rows.Length + x, 2 * rows.Length);

                                Object res = RUt.Recognize2(pic, row);
                                crc.AddTempl(row.FieldName, res ?? "");
                            }
                            crc.TemplAvail = true;
                            return CRRes.Sepa;
                        }
                    }
                    else if (kvs.Value.PWay == "")
                    {
                        ocrLog.Info("種類＝通常フォーム認識");
                        // 通常(フォーム検出成功)
                        crc.ClearTempl();
                        crc.NewRecord();
                        crc.SetValue("OCR", 1);
                        crc.SetValue("FORM", Path.GetFileNameWithoutExtension(kvs.Key));
                        DataRow[] rows = kvs.Value.DCR.Blk.Select("IfImport");
                        for (int x = 0; x < rows.Length; x++)
                        {
                            DCR.BlkRow row = (DCR.BlkRow)rows[x];
                            wipper.HintForm(rows.Length + x, 2 * rows.Length);

                            Object res = RUt.Recognize2(pic, row);
                            crc.SetValue(row.FieldName, res ?? "");
                        }
                        if (needVerify)
                        {
                            using (ConfirmForm form = new ConfirmForm(kvs.Value, pic))
                            {
                                form.Read(crc, kvs.Value.DCR.Blk);
                                switch (form.ShowDialog())
                                {
                                    case DialogResult.OK:
                                        form.SaveTo(crc);
                                        break;
                                    case DialogResult.No:
                                        continue;
                                    default:
                                        log.Info("中止しました。");
                                        throw new ApplicationException("中止しました。");
                                }
                            }
                        }
                        crc.CommitRecord();
                        crc.TemplAvail = false;
                        return CRRes.Avail;
                    }
                    ocrLog.Info("終了");
                }
            }
            ocrLog.Debug("crc.TemplAvail={0}", crc.TemplAvail);
            if (crc.TemplAvail)
            {
                // 区切り従属
                crc.NewRecord();
                crc.AddFrmTempl();
                crc.SetValue("OCR", 1);
                crc.CommitRecord();
                return CRRes.Avail;
            }
            return CRRes.Fail;
        }

        private void bRefDirOut_Click(object sender, EventArgs e)
        {
            if (fbdDirOut.ShowDialog(this) == DialogResult.OK)
            {
                tbDirOut.Text = fbdDirOut.SelectedPath;
            }
        }

        private void tbFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect & (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None);
        }

        private void tbFiles_DragDrop(object sender, DragEventArgs e)
        {
            String[] alfp = e.Data.GetData(DataFormats.FileDrop) as String[];
            if (alfp != null)
                AddFiles(alfp);
        }

        private void bRefOutCmd_Click(object sender, EventArgs e)
        {
            if (ofdOutCmd.ShowDialog(this) == DialogResult.OK)
            {
                tbOutCmd.Text = ofdOutCmd.FileName;
            }
        }

        private void bAddOutParm_Click(object sender, EventArgs e)
        {
            cmsOutCmd.Show(bAddOutParm, new Point(0, bAddOutParm.Height));
        }

        private void mParmcsv_Click(object sender, EventArgs e)
        {
            tbOutParm.AppendText(" \"%csv%\"");
        }

        private void mParmpic_Click(object sender, EventArgs e)
        {
            tbOutParm.AppendText(" \"%pic%\"");
        }

        private void bSelForm_Click(object sender, EventArgs e)
        {
            using (SelForm form = new SelForm(Path.GetDirectoryName(fpxml)))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    tbSeledForm.Text = form.SeledForm;
                    tbSeledForm.DataBindings["Text"].WriteValue();

                    bool f = tbSeledForm.TextLength != 0;
                    bool c = cbOnlyThis.Checked;
                    if (c != f) cbOnlyThis.Checked = f;
                }
            }
        }

        private void cbRotate4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRotate4.Checked && cbOnlyThis.Checked)
            {
                //MessageBox.Show(this, "「" + cbRotate4.Text + "」と「" + cbOnlyThis.Text + "」は、両方一緒には使用できません。片方だけにしてください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bRefRecycDir_Click(object sender, EventArgs e)
        {
            if (fbdRecycDir.ShowDialog(this) == DialogResult.OK)
            {
                tbRecycDir.Text = fbdRecycDir.SelectedPath;
                cbUseRecyc.Checked = true;
                cbUseRecyc.DataBindings["Checked"].WriteValue();
            }
        }

        string LogDir => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "OCRPattern",
            "logs"
            );

        private void bDebugOutput_Click(object sender, EventArgs e)
        {
            var dir = LogDir;

            try
            {
                Directory.CreateDirectory(dir);
                Process.Start(dir);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました。\n\n{ex}");
                log.Warn(ex, "ログフォルダを開くことができませんでした: {0}", dir);
            }
        }

    }
}
