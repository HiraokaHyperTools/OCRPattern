using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class Csvw
    {
        StringWriter wr = new StringWriter();
        int x = 0;
        static char[] alcWeak = ",\"\r\n\t;|".ToCharArray();

        public void AddCol(string s)
        {
            if (x != 0)
                wr.Write(",");
            x++;

            if (s.IndexOfAny(alcWeak) >= 0)
            {
                wr.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            }
            else
            {
                wr.Write(s);
            }
        }
        public void NewRow()
        {
            wr.WriteLine();
            x = 0;
        }
        public override string ToString()
        {
            return wr.ToString();
        }
    }
}
