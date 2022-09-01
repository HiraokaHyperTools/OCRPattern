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
    public class CRContext
    {
        private readonly Logger crcLog = LogManager.GetLogger("CRContext");
        private readonly Dictionary<string, string> templateDict = new Dictionary<string, string>();
        private readonly List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();

        public delegate string ValueTryGetter(string field);
        public delegate void ValueSetter(string field, string value);
        public delegate IEnumerable<KeyValuePair<string, string>> ValuePairs();

        public class ValueAccess
        {
            public ValueTryGetter tryGet;
            public ValueSetter set;
            public ValuePairs pairs;
        }

        public class Export
        {
            public IEnumerable<string> Headers { get; set; }
            public IEnumerable<IEnumerable<string>> Rows { get; set; }
        }

        public ValueSetter StartNewTemplate()
        {
            crcLog.Debug("StartNewTemplate");
            templateDict.Clear();
            TemplateAvailable = true;

            return (a, b) =>
            {
                crcLog.Debug("SetTemplateValue({0}, {1})", a, b);
                templateDict[a] = b ?? "";
            };
        }

        public bool TemplateAvailable { get; private set; }

        public ValueAccess AddRecord()
        {
            crcLog.Debug("AddRecord");

            var record = new Dictionary<string, string>();
            records.Add(record);

            return new ValueAccess
            {
                set = (a, b) =>
                {
                    crcLog.Debug("SetRecordValue({0}, {1})", a, b);
                    record[a] = b ?? "";
                },
                tryGet = (a) =>
                {
                    record.TryGetValue(a, out string b);
                    return b;
                },
                pairs = () => record,
            };
        }

        public Export GetExported()
        {
            var keys = templateDict.Keys
                .Concat(
                    records.SelectMany(record => record.Keys)
                )
                .Distinct()
                .ToArray();

            return new Export
            {
                Headers = keys,

                Rows = records
                    .Select(
                        record =>
                        {
                            var newRecord = new Dictionary<string, string>();
                            foreach (var pair in templateDict)
                            {
                                newRecord[pair.Key] = pair.Value;
                            }
                            foreach (var pair in record)
                            {
                                newRecord[pair.Key] = pair.Value;
                            }

                            return keys
                                .Select(
                                    key =>
                                    {
                                        newRecord.TryGetValue(key, out string value);
                                        return value ?? "";
                                    }
                                )
                                .ToArray();
                        }
                    )
                    .ToArray()
            };
        }

        public void ClearRecords()
        {
            records.Clear();
        }
    }
}
