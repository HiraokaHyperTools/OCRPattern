using Microsoft.VisualBasic.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OCRPattern.Utils
{
    public class FilePostProcessor
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        internal RecogCore.Next Apply(
            CRRes resp,
            Func<ReservedFilePair> reserveOut,
            Action<string> saveEntireTo,
            Action<string> savePartTo,
            Action<String> saveCsvFileTo,
            bool useRecyc,
            bool doNotSplit,
            Func<string> reserveRecyc,
            Action closeSourceFile,
            Action recycSourceFile,
            RunOutCmdDelegate runOutCmd
        )
        {
            RecogCore.Next ApplyFailure()
            {
                // 認識：失敗、保存有り
                if (doNotSplit)
                {
                    var reservedFile1 = reserveRecyc();
                    saveEntireTo(reservedFile1);
                    closeSourceFile();
                    recycSourceFile();
                    return RecogCore.Next.BreakLoop;
                }
                else
                {
                    var reservedFile1 = reserveRecyc();
                    savePartTo(reservedFile1);
                    return RecogCore.Next.Continue;
                }
            }

            if (resp == CRRes.SaveAll)
            {
                // 認識：成功
                var reserved = reserveOut();
                saveEntireTo(reserved.File1);
                saveCsvFileTo(reserved.File2);
                if (runOutCmd(reserved.File1, reserved.File2))
                {
                    return RecogCore.Next.BreakLoop;
                }
                else
                {
                    TryToDelete(reserved.File1);
                    TryToDelete(reserved.File2);
                    return ApplyFailure();
                }
            }
            else if (resp == CRRes.Avail)
            {
                // 認識：成功
                var reserved = reserveOut();
                savePartTo(reserved.File1);
                saveCsvFileTo(reserved.File2);
                if (runOutCmd(reserved.File1, reserved.File2))
                {
                    return RecogCore.Next.BreakLoop;
                }
                else
                {
                    TryToDelete(reserved.File1);
                    TryToDelete(reserved.File2);
                    return ApplyFailure();
                }
            }
            else if (resp == CRRes.TemplatePage)
            {
                return RecogCore.Next.Continue;
            }
            else if (useRecyc)
            {
                return ApplyFailure();
            }
            else
            {
                return RecogCore.Next.BreakLoop;
            }
        }

        private void TryToDelete(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                _log.Warn(ex, "認識失敗ファイルの削除に失敗: {0}", file);
            }
        }
    }
}
