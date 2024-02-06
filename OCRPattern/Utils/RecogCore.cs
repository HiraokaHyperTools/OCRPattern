using OCRPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace OCRPattern.Utils
{
    internal class RecogCore
    {
        public enum Next
        {
            Continue,
            BreakLoop,
        }

        public delegate void OnRasterizeDelegate(int pageNum);
        public delegate Next TryTextRecognizeDelegate(int pageNum);

        public void Run(
            int numPages,
            bool doNotSplit,
            TryTextRecognizeDelegate tryCR
        )
        {
            for (int z = 0; z < numPages; z++)
            {
                if (doNotSplit && z != 0)
                {
                    continue;
                }
                var next = tryCR(1 + z);
                if (next == Next.BreakLoop)
                {
                    break;
                }
            }
        }
    }
}
