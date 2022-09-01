using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class SCUt
    {
        public static void SaveCsv(string fpcsv, CRContext.Export export, Encoding enc)
        {
            Csvw csv = new Csvw();

            foreach (var header in export.Headers)
            {
                csv.AddCol(header);
            }
            foreach (var row in export.Rows)
            {
                csv.NewRow();
                foreach (var cell in row)
                {
                    csv.AddCol(cell ?? "");
                }
            }
            File.WriteAllText(fpcsv, csv.ToString(), enc);
        }
    }
}
