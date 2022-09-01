using NLog;
using OCRPattern.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Utils
{
    internal class SetteiLoader
    {
        private readonly SortedDictionary<string, OCRSettei> dictSet = new SortedDictionary<string, OCRSettei>();

        public SetteiLoader(string baseDir)
        {
            foreach (var setteiFile in Directory.GetFiles(baseDir, "*.OCR-Settei"))
            {
                using (var fs = File.OpenRead(setteiFile))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(OCRSettei));
                    OCRSettei ocrs = dictSet[setteiFile] = (OCRSettei)xs.Deserialize(fs);
                    DCR dcr = new DCR();
                    dcr.Merge(ocrs.DCR, true, MissingSchemaAction.Add);
                    ocrs.DCR = dcr;
                }
            }
        }

        public IEnumerable<KeyValuePair<string, OCRSettei>> GetAll()
        {
            return dictSet;
        }
    }
}
