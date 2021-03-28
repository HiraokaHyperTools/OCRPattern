using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class FileEraser : IDisposable
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly List<string> files = new List<string>();

        public void Add(string fp)
        {
            files.Add(fp);
        }

        public void Dispose()
        {
            foreach (var fp in files)
            {
                try
                {
                    File.Delete(fp);
                }
                catch (Exception ex)
                {
                    log.Warn(ex, "ファイルの削除に失敗: {0}", fp);
                }
            }

            files.Clear();
        }
    }
}
