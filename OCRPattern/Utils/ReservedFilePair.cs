using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class ReservedFilePair
    {
        public ReservedFilePair(string file1, string file2)
        {
            File1 = file1;
            File2 = file2;
        }

        public string File1 { get; }
        public string File2 { get; }
    }
}
