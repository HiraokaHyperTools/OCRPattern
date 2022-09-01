using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal sealed class TempFiles : IDisposable
    {
        private readonly List<string> files = new List<string>();

        public string NewOne(string suffix)
        {
            var file = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + suffix);
            files.Add(file);
            return file;
        }

        public void Dispose()
        {
            foreach (var file in files)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
                catch
                {
                    // ignore
                }
            }

            files.Clear();
        }
    }
}
