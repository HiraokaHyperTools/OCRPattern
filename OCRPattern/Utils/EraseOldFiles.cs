using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OCRPattern.Utils
{
    class EraseOldFiles
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        internal static void Run(string dir, string pattern, TimeSpan period)
        {
            int nFilesDeleted = 0;
            try
            {
                var re = new Regex(pattern, RegexOptions.IgnoreCase);
                var limit = DateTime.UtcNow.Subtract(period);
                foreach (var filePath in Directory.GetFiles(dir))
                {
                    var fileName = Path.GetFileName(filePath);
                    if (re.IsMatch(fileName))
                    {
                        if (File.GetLastWriteTimeUtc(filePath) < limit)
                        {
                            File.Delete(filePath);
                            ++nFilesDeleted;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex, "古いファイルの削除中にエラー発生");
            }
            log.Info("{0:#,##0} 個の古いファイルを削除: {1}", nFilesDeleted, dir);
        }
    }
}
