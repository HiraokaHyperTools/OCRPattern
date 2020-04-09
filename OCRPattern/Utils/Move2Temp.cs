using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class Move2Temp : IDisposable
    {
        List<string> fileList = new List<string>();

        internal void Add(string fp)
        {
            fileList.Add(fp);
        }

        Logger log = LogManager.GetCurrentClassLogger();

        #region IDisposable メンバ

        public void Dispose()
        {
            foreach (String fp in fileList)
            {
                try
                {
                    MFUt.MoveTo(fp, Path.GetTempPath());
                }
                catch (Exception ex)
                {
                    log.Warn(ex, "一時ファイルの削除に失敗: {0}", fp);
                }
            }
        }

        #endregion
    }

}
