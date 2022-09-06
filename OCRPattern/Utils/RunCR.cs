using NLog;
using OCRPattern.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OCRPattern.Utils
{
    internal class RunCR
    {
        private readonly Logger ocrLog = LogManager.GetLogger("OCR");

        public enum VerifyResult
        {
            Submit,
            Skip,
            Abort
        }

        public delegate VerifyResult Verifier(
            OCRSettei settei,
            Bitmap pic,
            IEnumerable<KeyValuePair<string, string>> pairs,
            Action<string, string> setter
        );
        public delegate string Recognizer(Bitmap bitmap, DCR.BlkRow row);
        public delegate void TryExternalLookupDelegate(
            DCR.BlkRow row,
            string inputArg,
            Action<string, string> setter
        );

        public interface IProgress
        {
            void HintRot(int rot);
            void HintTempl(string inputFile, bool import);
            void HintForm(int x, int cx);
        }

        public CRRes TryCR(
            Bitmap picSrc,
            string inputFile,
            int pageIndex,
            Func<IEnumerable<KeyValuePair<string, OCRSettei>>> formsProvider,
            CRContext crc,
            IProgress progress,
            bool rotate4,
            bool forceSingleForm,
            Verifier doVerify,
            Recognizer recognizer,
            TryExternalLookupDelegate tryExternalLookup
        )
        {
            ocrLog.Info("認識対象＝{0}", inputFile);
            ocrLog.Debug("ページ＝{0}", 1 + pageIndex);

            using (var rotator = new BitmapRotateUtil())
            {
                var treatAsAvailable = false;
                for (int rot = 0; rot < (rotate4 ? 4 : 1); rot++)
                {
                    ocrLog.Debug("回転回数＝{0}", rot);
                    progress.HintRot(rot);
                    Bitmap pic = rotator.Rotate(picSrc, rot);
                    var anyForm = false;
                    foreach (KeyValuePair<string, OCRSettei> oneForm in formsProvider())
                    {
                        anyForm = true;
                        ocrLog.Info("フォーム＝{0}", oneForm.Key);

                        var formKey = Path.GetFileNameWithoutExtension(oneForm.Key);

                        progress.HintTempl(formKey, false);

                        bool fail = false, any = false;
                        {
                            DataRow[] rows = oneForm.Value.DCR.Blk.Select("IfTest");
                            for (int x = 0; x < rows.Length; x++)
                            {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                progress.HintForm(x, rows.Length * 2);

                                var res = recognizer(pic, row);
                                if (res != null && UtKwt.PartMatch2(res, row.TestKeyword, row.SkipWs))
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
                            if (!forceSingleForm && oneForm.Value.PWay != "S")
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (!any)
                            {
                                continue;
                            }
                        }

                        ocrLog.Info("通過");

                        bool needVerify = oneForm.Value.DCR.Blk.Select("NeedVerify").Length != 0;

                        progress.HintTempl(formKey, true);

                        if (oneForm.Value.PWay == "S1" && pageIndex == 0)
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
                                var template = crc.StartNewTemplate();
                                template.set("TEMPLATE", formKey);
                                DataRow[] rows = oneForm.Value.DCR.Blk.Select("IfImport");
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                    progress.HintForm(rows.Length + x, 2 * rows.Length);

                                    var res = recognizer(pic, row) ?? "";
                                    template.set(row.FieldName, res);

                                    needVerify |= TestPattern(row.PassPattern, res);
                                }

                                var record = crc.AddRecord();
                                record.set("OCR", "1");
                                if (needVerify)
                                {
                                    switch (doVerify(oneForm.Value, pic, template.pairs().Concat(record.pairs()), (a, b) => record.set(a, b)))
                                    {
                                        case VerifyResult.Submit:
                                            break;
                                        case VerifyResult.Skip:
                                            continue;
                                        case VerifyResult.Abort:
                                            ocrLog.Info("中止しました。");
                                            throw new Exception("中止しました。");
                                    }
                                }
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    DCR.BlkRow row = (DCR.BlkRow)rows[x];

                                    tryExternalLookup?.Invoke(
                                        row,
                                        "" + record.tryGet(row.FieldName),
                                        (key, value) => record.set(key, value)
                                    );
                                }

                                return CRRes.SaveAll;
                            }
                        }
                        else if (oneForm.Value.PWay == "S")
                        {
                            ocrLog.Info("種類＝区切り/代表ページ");
                            if (fail)
                            {
                                ocrLog.Info("検出：失敗");

                                treatAsAvailable = crc.TemplateAvailable;
                            }
                            else
                            {
                                ocrLog.Info("検出：成功");
                                // 区切り(フォーム検出成功)
                                var template = crc.StartNewTemplate();
                                template.set("TEMPLATE", formKey);
                                DataRow[] rows = oneForm.Value.DCR.Blk.Select("IfImport");
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                    progress.HintForm(rows.Length + x, 2 * rows.Length);

                                    var res = recognizer(pic, row) ?? "";
                                    template.set(row.FieldName, res);

                                    tryExternalLookup?.Invoke(
                                        row,
                                        res,
                                        (key, value) => template.set(key, value)
                                    );
                                }
                                return CRRes.TemplatePage;
                            }
                        }
                        else if (oneForm.Value.PWay == "")
                        {
                            ocrLog.Info("種類＝通常フォーム認識");
                            // 通常(フォーム検出成功)
                            var record = crc.AddRecord();
                            record.set("OCR", "1");
                            record.set("FORM", formKey);
                            DataRow[] rows = oneForm.Value.DCR.Blk.Select("IfImport");
                            for (int x = 0; x < rows.Length; x++)
                            {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];
                                progress.HintForm(rows.Length + x, 2 * rows.Length);

                                var res = recognizer(pic, row) ?? "";
                                record.set(row.FieldName, res);

                                needVerify |= TestPattern(row.PassPattern, res);
                            }
                            if (needVerify)
                            {
                                switch (doVerify(oneForm.Value, pic, record.pairs(), (a, b) => record.set(a, b)))
                                {
                                    case VerifyResult.Submit:
                                        break;
                                    case VerifyResult.Skip:
                                        continue;
                                    case VerifyResult.Abort:
                                        ocrLog.Info("中止しました。");
                                        throw new Exception("中止しました。");
                                }
                            }
                            for (int x = 0; x < rows.Length; x++)
                            {
                                DCR.BlkRow row = (DCR.BlkRow)rows[x];

                                tryExternalLookup?.Invoke(
                                    row,
                                    "" + record.tryGet(row.FieldName),
                                    (key, value) => record.set(key, value)
                                );
                            }
                            return CRRes.Avail;
                        }
                        ocrLog.Info("終了");

                        if (forceSingleForm)
                        {
                            break;
                        }
                    }
                    if (!anyForm)
                    {
                        break;
                    }
                }
                if (treatAsAvailable)
                {
                    var recordSetter = crc.AddRecord().set;
                    recordSetter("OCR", "1");

                    return CRRes.Avail;
                }
            }
            return CRRes.Fail;
        }

        private bool TestPattern(string pattern, string input)
        {
            if (!string.IsNullOrEmpty(pattern))
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    return true;
                }
            }
            return false;
        }

        public static void TrySQLServerLookup(
            DCR.BlkRow row,
            string inputArg,
            Action<string, string> setter
        )
        {
            if (row.UseSQLServerLookup)
            {
                using (var db = new SqlConnection(row.SQLConnStr))
                {
                    db.Open();

                    var command = new SqlCommand(row.SQLQuery, db);
                    command.Parameters.AddWithValue("@input", inputArg);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (var outputColumn in row.SQLOutputColumns.Replace("\r\n", "\n").Split('\n'))
                            {
                                if (string.IsNullOrEmpty(outputColumn))
                                {
                                    continue;
                                }
                                try
                                {
                                    setter(outputColumn, "" + reader[outputColumn]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    // 列名無効
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
