using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    class FPUt
    {
        String outDir;
        int num = 1;
        DateTime dt = DateTime.Now;

        public FPUt(String outDir)
        {
            this.outDir = outDir;
        }

        public void Prepare(String fext1, String fext2)
        {
            while (true)
            {
                String id = String.Format("{0:yyyyMMdd}_{1:0000}", dt, num);
                ++num;
                if (File.Exists(fp1 = Path.Combine(outDir, id + fext1))) continue;
                if (File.Exists(fp2 = Path.Combine(outDir, id + fext2))) continue;
                break;
            }
        }

        public String fp1 = String.Empty;
        public String fp2 = String.Empty;

        internal void Flush()
        {
            fp1 = String.Empty;
            fp2 = String.Empty;
        }
    }
}
