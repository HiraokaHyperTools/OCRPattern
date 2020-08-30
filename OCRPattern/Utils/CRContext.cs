using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Utils
{
    public class CRContext
    {
        public DataTable dtCR = new DataTable();
        public SortedDictionary<string, OCRSettei> dictSet = new SortedDictionary<string, OCRSettei>();
        public SortedDictionary<string, string> dictTempl = new SortedDictionary<string, string>();

        public bool ReadSet(String baseDir)
        {
            dictSet.Clear();
            foreach (String fpSet in Directory.GetFiles(baseDir, "*.OCR-Settei"))
            {
                using (FileStream fs = File.OpenRead(fpSet))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(OCRSettei));
                    OCRSettei ocrs = dictSet[fpSet] = (OCRSettei)xs.Deserialize(fs);
                    DCR dcr = new DCR();
                    dcr.Merge(ocrs.DCR, true, MissingSchemaAction.Add);
                    ocrs.DCR = dcr;
                }
            }
            return dictSet.Count != 0;
        }

        Logger crcLog = LogManager.GetLogger("CRContext");

        public void AddTempl(String field, Object value)
        {
            crcLog.Debug("AddTempl({0}, {1})", field, value);
            dictTempl[field] = Convert.ToString(value);
        }

        internal void StartTemplPage()
        {
            crcLog.Debug("StartTemplPage");
            dictTempl.Clear();
        }

        internal DataRow drCR = null;

        bool templAvail = false;

        public bool TemplAvail { get { return templAvail; } set { templAvail = value; } }

        internal void NewRecord()
        {
            crcLog.Debug("NewRecord");
            drCR = dtCR.NewRow();
        }

        internal void SetValue(String field, Object val)
        {
            if (dtCR.Columns.IndexOf(field) < 0)
            {
                dtCR.Columns.Add(field, typeof(string));
            }
            drCR[field] = val;
        }

        internal void CommitRecord()
        {
            crcLog.Debug("CommitRecord");
            dtCR.Rows.Add(drCR);
        }

        internal void AddFrmTempl()
        {
            crcLog.Debug("AddFrmTempl");
            foreach (KeyValuePair<string, string> kv in dictTempl)
            {
                SetValue(kv.Key, kv.Value);
            }
        }

        internal void ClearTempl()
        {
            crcLog.Debug("ClearTempl");
            dictTempl.Clear();
            TemplAvail = false;
        }

        internal string TryGetValue(string field)
        {
            if (dtCR.Columns.IndexOf(field) < 0)
            {
                return null;
            }
            return "" + drCR[field];
        }
    }
}
