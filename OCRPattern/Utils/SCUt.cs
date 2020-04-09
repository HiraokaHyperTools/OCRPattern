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
        public static void SaveCsv(String fpcsv, DataTable dt, Encoding enc)
        {
            Csvw wr = new Csvw();
            foreach (DataColumn dc in dt.Columns)
                wr.AddCol(dc.ColumnName);
            wr.NewRow();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    wr.AddCol(Convert.ToString(dr[dc]));
                }
                wr.NewRow();
            }
            File.WriteAllText(fpcsv, wr.ToString(), enc);
        }
    }
}
