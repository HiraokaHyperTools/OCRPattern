using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class ReserveNewFilePair
    {
        private readonly string _outDir;
        private int _lastNum = 1;
        private DateTime _then = DateTime.Now;

        public ReserveNewFilePair(String outDir)
        {
            _outDir = outDir;
        }

        public ReservedFilePair Reserve(String extension1, String extension2)
        {
            while (true)
            {
                var id = String.Format(CultureInfo.InvariantCulture, "{0:yyyyMMdd}_{1:0000}", _then, _lastNum);
                ++_lastNum;
                var file1 = Path.Combine(_outDir, id + extension1);
                if (File.Exists(file1)) continue;
                var file2 = Path.Combine(_outDir, id + extension2);
                if (File.Exists(file2)) continue;
                return new ReservedFilePair(file1, file2);
            }
        }
    }
}
