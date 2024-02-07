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
using System.Data.SqlClient;
using System.Linq;

namespace OCRPattern
{
    public partial class TaskEditForm : Form
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly bool autoRun;
        private readonly TextRecogEngines engines = new TextRecogEngines();

        private string BaseDir => Path.GetDirectoryName(fpxml);

        public TaskEditForm(String fpxml, bool autoRun)
        {
            this.fpxml = fpxml;
            this.autoRun = autoRun;
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

        private void AddFiles(string[] fileList)
        {
            if (fileList == null || fileList.Length == 0) return;
            List<string> files = new List<string>(tbFiles.Lines);
            files.AddRange(fileList);
            tbFiles.Lines = files.ToArray();
            tbFiles.DataBindings["Text"].WriteValue();
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            tsc.ContentPanel.AutoScroll = true;

            this.Text += " v" + Application.ProductVersion;

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

            TryToUpdateFileList();

            if (autoRun)
            {
                bRun.PerformClick();
                Close();
            }
        }

        private void TryToUpdateFileList()
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
                        var extensions = ".tif|.tiff|.pdf".Split('|');

                        List<string> files = new List<string>(
                            Directory.GetFiles(Path.GetFullPath(Path.Combine(BaseDir, row.DirIn)))
                                .Where(it => extensions.Contains(Path.GetExtension(it).ToLowerInvariant()))
                        );
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

        private RunCR.VerifyResult DoVerify(
            OCRSettei settei,
            Bitmap pic,
            IEnumerable<KeyValuePair<string, string>> pairs,
            Action<string, string> setter
        )
        {
            using (ConfirmForm confirm = new ConfirmForm(settei, pic))
            {
                confirm.Read(pairs, settei.DCR.Blk);
                switch (confirm.ShowDialog())
                {
                    case DialogResult.OK:
                        confirm.SaveTo(setter);
                        return RunCR.VerifyResult.Submit;
                    case DialogResult.No:
                        return RunCR.VerifyResult.Skip;
                    default:
                        return RunCR.VerifyResult.Abort;
                }
            }
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            cfgBindingSource.EndEdit();

            var setteiLoader = new SetteiLoader(Path.GetDirectoryName(fpxml));
            if (!setteiLoader.GetAll().Any())
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
            outDir = Path.GetFullPath(Path.Combine(BaseDir, outDir));
            var recycDir = cbUseRecyc.Checked ? tbRecycDir.Text : null;
            var formSel = cbOnlyThis.Checked ? tbSeledForm.Text : "";
            var toOutDir = new ReserveNewFilePair(outDir);
            var toRecycDir = (recycDir != null) ? new ReserveNewFilePair(recycDir) : null;
            var magick = NoiseReducers.UseMagick();
            var filePostProcessor = new FilePostProcessor();
            string DoRecognize(Bitmap bitmap, DCR.BlkRow row)
            {
                var opt = BlkRowUtil.ToRecogOption(row);
                var resp = RecogUtil.Recognize2(
                    bitmap,
                    opt,
                    magick,
                    engines.SearchInstalled()
                        .FirstOrDefault(it => it.Name == row.CRType)
                );
                return "" + resp;
            }
            using (Move2Temp m2t = new Move2Temp())
            using (FileEraser eraser = new FileEraser())
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
                foreach (String sourceFile in tbFiles.Lines)
                {
                    if (!File.Exists(sourceFile))
                    {
                        continue;
                    }
                    form.lfn.Text = Path.GetFileName(sourceFile);
                    form.ldir.Text = Path.GetDirectoryName(sourceFile);
                    var sourceFileExt = Path.GetExtension(sourceFile);
                    var runCR = new RunCR();
                    var recogCore = new RecogCore();
                    var crc = new CRContext();

                    using (IMultiPageFileLoader pdf = MultiPageFileLoader.LoadFromFile(sourceFile))
                    {
                        recogCore.Run(
                            pdf.NumPages,
                            cbDoNotSplit.Checked,
                            pageNum =>
                            {
                                crc.ClearRecords();

                                form.HintPage(pageNum, true);

                                using (var pic = pdf.Rasterize(pageNum - 1))
                                {
                                    var resp = runCR.TryCR(
                                        pic,
                                        sourceFile,
                                        pageNum - 1,
                                        () => setteiLoader.GetAll()
                                            .Where(pair => cbOnlyThis.Checked
                                                ? string.Compare(
                                                    Path.GetFileNameWithoutExtension(pair.Key),
                                                    tbSeledForm.Text,
                                                    true
                                                ) == 0
                                                : true
                                            )
                                            .ToArray(),
                                        crc,
                                        form,
                                        cbRotate4.Checked,
                                        cbOnlyThis.Checked,
                                        DoVerify,
                                        DoRecognize,
                                        RunCR.TrySQLServerLookup
                                    );

                                    bool RunOutCmd(string picFile, string csvFile)
                                    {
                                        if (cbRunOutCmd.Checked)
                                        {
                                            ProcessStartInfo psi = new ProcessStartInfo(Environment.ExpandEnvironmentVariables(tbOutCmd.Text), tbOutParm.Text
                                                .Replace("%csv%", csvFile)
                                                .Replace("%pic%", picFile)
                                                );
                                            String cwd = Path.GetDirectoryName(fpxml); // new cwd at fpxml.
                                            if (cwd != null && Directory.Exists(cwd)) psi.WorkingDirectory = cwd;
                                            runCmdLog.Debug("実行: {0}\n{1}", psi.FileName, psi.Arguments);
                                            Process p = Process.Start(psi);
                                            p.WaitForExit();
                                            runCmdLog.Debug("結果: {0}", p.ExitCode);
                                            if (p.ExitCode != 0 && cbApplyRecycOnOutCmdFailure.Checked)
                                            {
                                                return false;
                                            }
                                        }

                                        if (cbEraseInAfter.Checked)
                                        {
                                            eraser.Add(sourceFile);
                                        }
                                        else if (cbMoveInAfter.Checked)
                                        {
                                            m2t.Add(sourceFile);
                                        }

                                        if (cbEraseOutAfter.Checked)
                                        {
                                            eraser.Add(csvFile);
                                            eraser.Add(picFile);
                                        }
                                        else if (cbMoveOutAfter.Checked)
                                        {
                                            m2t.Add(csvFile);
                                            m2t.Add(picFile);
                                        }

                                        return true;
                                    }

                                    return filePostProcessor.Apply(
                                        resp: resp,
                                        reserveOut: () => toOutDir.Reserve(sourceFileExt, ".csv"),
                                        saveEntireTo: copyTo => File.Copy(sourceFile, copyTo, true),
                                        savePartTo: saveTo => pdf.SavePageAs(saveTo, pageNum),
                                        saveCsvFileTo: saveTo => SCUt.SaveCsv(saveTo, crc.GetExported(), Encoding.Default),
                                        useRecyc: toRecycDir != null,
                                        doNotSplit: cbDoNotSplit.Checked,
                                        reserveRecyc: () => toRecycDir.Reserve(sourceFileExt, sourceFileExt).File1,
                                        closeSourceFile: () => pdf.Dispose(),
                                        recycSourceFile: () =>
                                        {
                                            try
                                            {
                                                File.Delete(sourceFile);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Warn(ex, "認識失敗ファイルの削除に失敗: {0}", sourceFile);
                                            }
                                        },
                                        runOutCmd: RunOutCmd
                                    );
                                }
                            }
                        );
                    }

                }
            }

            TryToUpdateFileList();
            MessageBox.Show(this, "完了しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        Logger runCmdLog = LogManager.GetLogger("RunCmd");

        delegate void SavePicDelegate(String fpTo);

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
