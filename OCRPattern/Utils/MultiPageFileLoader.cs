using OCRPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal class MultiPageFileLoader
    {
        internal static IMultiPageFileLoader LoadFromFile(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);
            if (StringComparer.InvariantCultureIgnoreCase.Compare(fileExtension, ".pdf") == 0)
            {
                return new PdfFileLoader(filePath);
            }
            else
            {
                return new TiffFileLoader(filePath);
            }
        }
    }
}
