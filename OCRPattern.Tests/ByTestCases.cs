using NUnit.Framework;
using OCRPattern.Tests.Models;
using OCRPattern.Tests.Utils;
using OCRPattern.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OCRPattern.Tests
{
    public class ByTestCases
    {
        private readonly TextRecogEngines engines = new TextRecogEngines();

        [TestCaseSource(nameof(LoadTestCases))]
        public void Run(string fileName, string expected, string engineName)
        {
            var filePath = FileLocator.Resolve("Samples/" + fileName);
            using (var bitmap = new Bitmap(filePath))
            {
                var engine = engines.SearchInstalled()
                    .First(it => it.Name == engineName);
                var result = RecogUtil.Recognize3(
                    bitmap,
                    new RecogOption
                    {
                        X = 0,
                        Y = 0,
                        Width = bitmap.Width / bitmap.HorizontalResolution * 25.4f,
                        Height = bitmap.Height / bitmap.VerticalResolution * 25.4f,
                        CutSpaces = true,
                    },
                    (inputBitmap, opt) => inputBitmap,
                    engine,
                    out Bitmap used
                )
                    ?.Trim();
                used?.Dispose();
                Assert.That(result, Is.EqualTo(expected));
            }
        }

        public static IEnumerable<object> LoadTestCases()
        {
            var some = (TestCases)new XmlSerializer(typeof(TestCases)).Deserialize(
                new MemoryStream(
                    File.ReadAllBytes(FileLocator.Resolve("Samples/TestCases.xml"))
                )
            );

            return some.TestCase
                .Select(it => new object[] { it.File, it.Expected, it.Engine, })
                .ToArray();
        }
    }
}
