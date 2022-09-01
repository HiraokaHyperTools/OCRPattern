using NUnit.Framework;
using OCRPattern.Interfaces;
using OCRPattern.Models;
using OCRPattern.Tests.Utils;
using OCRPattern.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Tests
{
    public class RunCRTest
    {
        private string SetteiDir => FileLocator.Resolve("Samples");

        /// <summary>
        /// `Samples/a_b_c.pdf` を想定
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Every(bool forceSingleForm)
        {
            var recogCore = new RecogCore();
            var crc = new CRContext();

            var form = new SetteiLoader(SetteiDir).GetAll()
                .Single(pair => Path.GetFileNameWithoutExtension(pair.Key) == "every")
                .Value;

            var forms = new Dictionary<string, OCRSettei>();
            forms["every"] = form;

            var dataArray = "A1001,B2002,C3003".Split(',');

            var pagesChecked = new bool[3];

            recogCore.Run(
                numPages: 3,
                doNotSplit: false,
                pageNum =>
                {
                    crc.ClearRecords();

                    var runCR = new RunCR();

                    var data = dataArray[pageNum - 1];

                    var resp = runCR.TryCR(
                        new Bitmap(1, 1),
                        "a_b_c.pdf",
                        pageNum - 1,
                        () => forms,
                        crc,
                        new DummyProgress(),
                        false,
                        forceSingleForm,
                        (settei, thisPic, pairs, setter) =>
                        {
                            throw new Exception("won't verify");
                        },
                        (thisPic, row) =>
                        {
                            if (row.FieldName == "見積")
                            {
                                return "見積";
                            }
                            else if (row.FieldName == "DATA")
                            {
                                return data;
                            }
                            return null;
                        },
                        (row, inputArg, setter) =>
                        {
                            Assert.That(row.UseSQLServerLookup, Is.False);
                        }
                    );

                    Assert.That(resp, Is.EqualTo(CRRes.Avail));

                    var actual = ToSingleDict(crc.GetExported());

                    var expected = new Dictionary<string, string>();
                    expected["OCR"] = "1";
                    expected["FORM"] = "every";
                    expected["DATA"] = data;

                    CollectionAssert.AreEquivalent(
                        expected: expected,
                        actual: actual
                    );

                    pagesChecked[pageNum - 1] = true;

                    return RecogCore.Next.Continue;
                }
            );

            CollectionAssert.AreEqual(
                expected: new bool[] { true, true, true, },
                actual: pagesChecked
            );
        }

        /// <summary>
        /// `Samples/t_a_t_b_t_c.pdf` を想定
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void SingleSplit(bool forceSingleForm)
        {
            var recogCore = new RecogCore();
            var crc = new CRContext();

            var formKey = "single";

            var form = new SetteiLoader(SetteiDir).GetAll()
                .Single(pair => Path.GetFileNameWithoutExtension(pair.Key) == formKey)
                .Value;

            var forms = new Dictionary<string, OCRSettei>();
            forms[formKey] = form;

            var titleArray = "タイトル,図面,タイトル,図面,タイトル,図面".Split(',');
            var dataArray = "A1001,A1001,B2002,B2002,C3003,C3003".Split(',');

            var pagesChecked = new bool[6];

            recogCore.Run(
                numPages: 6,
                doNotSplit: false,
                pageNum =>
                {
                    crc.ClearRecords();

                    var runCR = new RunCR();

                    var data = dataArray[pageNum - 1];
                    var title = titleArray[pageNum - 1];

                    var resp = runCR.TryCR(
                        new Bitmap(1, 1),
                        "t_a_t_b_t_c.pdf",
                        pageNum - 1,
                        () => forms,
                        crc,
                        new DummyProgress(),
                        false,
                        forceSingleForm,
                        (settei, thisPic, pairs, setter) =>
                        {
                            throw new Exception("won't verify");
                        },
                        (thisPic, row) =>
                        {
                            if (row.FieldName == "タイトル")
                            {
                                return title;
                            }
                            else if (row.FieldName == "DATA")
                            {
                                return data;
                            }
                            return null;
                        },
                        (row, inputArg, setter) =>
                        {
                            Assert.That(row.UseSQLServerLookup, Is.False);
                        }
                    );

                    if (pageNum == 1)
                    {
                        Assert.That(resp, Is.EqualTo(CRRes.SaveAll));

                        var actual = ToSingleDict(crc.GetExported());

                        var expected = new Dictionary<string, string>();
                        expected["OCR"] = "1";
                        expected["TEMPLATE"] = formKey;
                        expected["DATA"] = data;

                        CollectionAssert.AreEquivalent(
                            expected: expected,
                            actual: actual
                        );
                    }
                    else
                    {
                        Assert.That(resp, Is.EqualTo(CRRes.Fail));
                    }

                    pagesChecked[pageNum - 1] = true;

                    return RecogCore.Next.Continue;
                }
            );

            CollectionAssert.AreEqual(
                expected: new bool[] { true, true, true, true, true, true, },
                actual: pagesChecked
            );
        }

        /// <summary>
        /// `Samples/t_a_t_b_t_c.pdf` を想定
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void SingleDoNotSplit(bool forceSingleForm)
        {
            var recogCore = new RecogCore();
            var crc = new CRContext();

            var formKey = "single";

            var form = new SetteiLoader(SetteiDir).GetAll()
                .Single(pair => Path.GetFileNameWithoutExtension(pair.Key) == formKey)
                .Value;

            var forms = new Dictionary<string, OCRSettei>();
            forms[formKey] = form;

            var titleArray = "タイトル,図面,タイトル,図面,タイトル,図面".Split(',');
            var dataArray = "A1001,A1001,B2002,B2002,C3003,C3003".Split(',');

            var pagesChecked = new bool[6];

            recogCore.Run(
                numPages: 6,
                doNotSplit: true,
                pageNum =>
                {
                    crc.ClearRecords();

                    var runCR = new RunCR();

                    var data = dataArray[pageNum - 1];
                    var title = titleArray[pageNum - 1];

                    var resp = runCR.TryCR(
                        new Bitmap(1, 1),
                        "t_a_t_b_t_c.pdf",
                        pageNum - 1,
                        () => forms,
                        crc,
                        new DummyProgress(),
                        false,
                        forceSingleForm,
                        (settei, thisPic, pairs, setter) =>
                        {
                            throw new Exception("won't verify");
                        },
                        (thisPic, row) =>
                        {
                            if (row.FieldName == "タイトル")
                            {
                                return title;
                            }
                            else if (row.FieldName == "DATA")
                            {
                                return data;
                            }
                            return null;
                        },
                        (row, inputArg, setter) =>
                        {
                            Assert.That(row.UseSQLServerLookup, Is.False);
                        }
                    );

                    {
                        Assert.That(resp, Is.EqualTo(CRRes.SaveAll));

                        var actual = ToSingleDict(crc.GetExported());

                        var expected = new Dictionary<string, string>();
                        expected["OCR"] = "1";
                        expected["TEMPLATE"] = formKey;
                        expected["DATA"] = data;

                        CollectionAssert.AreEquivalent(
                            expected: expected,
                            actual: actual
                        );
                    }

                    pagesChecked[pageNum - 1] = true;

                    return RecogCore.Next.Continue;
                }
            );

            CollectionAssert.AreEqual(
                expected: new bool[] { true, false, false, false, false, false, },
                actual: pagesChecked
            );
        }

        /// <summary>
        /// `Samples/t_a_t_b_t_c.pdf` を想定
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Multiple(bool forceSingleForm)
        {
            var recogCore = new RecogCore();
            var crc = new CRContext();

            var formKey = "multiple";

            var form = new SetteiLoader(SetteiDir).GetAll()
                .Single(pair => Path.GetFileNameWithoutExtension(pair.Key) == formKey)
                .Value;

            var forms = new Dictionary<string, OCRSettei>();
            forms[formKey] = form;

            var titleArray = "タイトル,図面,タイトル,図面,タイトル,図面".Split(',');
            var dataArray = "A1001,A1001,B2002,B2002,C3003,C3003".Split(',');

            var pagesChecked = new bool[6];

            recogCore.Run(
                numPages: 6,
                doNotSplit: false,
                pageNum =>
                {
                    crc.ClearRecords();

                    var runCR = new RunCR();

                    var data = dataArray[pageNum - 1];
                    var title = titleArray[pageNum - 1];

                    var resp = runCR.TryCR(
                        new Bitmap(1, 1),
                        "t_a_t_b_t_c.pdf",
                        pageNum - 1,
                        () => forms,
                        crc,
                        new DummyProgress(),
                        false,
                        forceSingleForm,
                        (settei, thisPic, pairs, setter) =>
                        {
                            throw new Exception("won't verify");
                        },
                        (thisPic, row) =>
                        {
                            if (row.FieldName == "タイトル")
                            {
                                return title;
                            }
                            else if (row.FieldName == "DATA")
                            {
                                return data;
                            }
                            return null;
                        },
                        (row, inputArg, setter) =>
                        {
                            Assert.That(row.UseSQLServerLookup, Is.False);
                        }
                    );

                    if (pageNum == 1 || pageNum == 3 || pageNum == 5)
                    {
                        Assert.That(resp, Is.EqualTo(CRRes.TemplatePage));
                    }
                    else
                    {
                        Assert.That(resp, Is.EqualTo(CRRes.Avail));

                        var actual = ToSingleDict(crc.GetExported());

                        var expected = new Dictionary<string, string>();
                        expected["OCR"] = "1";
                        expected["TEMPLATE"] = formKey;
                        expected["DATA"] = data;

                        CollectionAssert.AreEquivalent(
                            expected: expected,
                            actual: actual
                        );
                    }

                    pagesChecked[pageNum - 1] = true;

                    return RecogCore.Next.Continue;
                }
            );

            CollectionAssert.AreEqual(
                expected: new bool[] { true, true, true, true, true, true, },
                actual: pagesChecked
            );
        }

        private static IDictionary<string, string> ToSingleDict(CRContext.Export export)
        {
            var row = export.Rows.Single().ToArray();
            var dict = new Dictionary<string, string>();
            var headers = export.Headers.ToArray();
            for (int x = 0; x < row.Count(); x++)
            {
                dict[headers[x]] = row[x];
            }
            return dict;
        }

        private class DummyProgress : RunCR.IProgress
        {
            public void HintForm(int x, int cx)
            {
            }

            public void HintRot(int rot)
            {
            }

            public void HintTempl(string inputFile, bool import)
            {
            }
        }
    }
}
