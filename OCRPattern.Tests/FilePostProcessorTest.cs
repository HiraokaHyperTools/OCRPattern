using NUnit.Framework;
using OCRPattern.Tests.Utils;
using OCRPattern.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OCRPattern.Utils.RecogCore;

namespace OCRPattern.Tests
{
    public class FilePostProcessorTest
    {
        private readonly FilePostProcessor _filePostProcessor;

        public FilePostProcessorTest()
        {
            _filePostProcessor = new FilePostProcessor();
        }

        [Test]
        [TestCase(false, false, false, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|savePartTo recyc", Next.Continue)]
        [TestCase(false, false, true, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|saveEntireTo recyc|recycSourceFile", Next.BreakLoop)]
        [TestCase(false, true, false, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|savePartTo recyc", Next.Continue)]
        [TestCase(false, true, true, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|saveEntireTo recyc|recycSourceFile", Next.BreakLoop)]
        [TestCase(true, false, false, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, false, true, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, true, false, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, true, true, "|saveEntireTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        public void SaveAllCmd(
            bool successful,
            bool useRecyc,
            bool doNotSplit,
            string expectedFootprints,
            Next expectedNext)
        {
            string footprints = "";
            var next = _filePostProcessor.Apply(
                resp: CRRes.SaveAll,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    footprints += $"|saveEntireTo {copyTo}";
                },
                savePartTo: saveTo =>
                {
                    footprints += $"|savePartTo {saveTo}";
                },
                saveCsvFileTo: saveTo =>
                {
                    footprints += $"|saveCsvFileTo {saveTo}";
                },
                saveAllWithoutFirstPageTo: saveTo =>
                {
                    footprints += $"|saveAllWithoutFirstPageTo {saveTo}";
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    footprints += $"|recycSourceFile";
                },
                runOutCmd: (a, b) =>
                {
                    footprints += $"|runOutCmd {a} {b}";
                    return successful;
                }
            );
            Assert.That(next, Is.EqualTo(expectedNext));
            Assert.That(footprints, Is.EqualTo(expectedFootprints));
        }

        [Test]
        [TestCase(false, false, false, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|savePartTo recyc", Next.Continue)]
        [TestCase(false, false, true, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|saveEntireTo recyc|recycSourceFile", Next.BreakLoop)]
        [TestCase(false, true, false, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|savePartTo recyc", Next.Continue)]
        [TestCase(false, true, true, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv|saveEntireTo recyc|recycSourceFile", Next.BreakLoop)]
        [TestCase(true, false, false, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, false, true, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, true, false, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        [TestCase(true, true, true, "|saveAllWithoutFirstPageTo pdf|saveCsvFileTo csv|runOutCmd pdf csv", Next.BreakLoop)]
        public void SaveAllWithoutFirstPageCmd(
            bool successful,
            bool useRecyc,
            bool doNotSplit,
            string expectedFootprints,
            Next expectedNext)
        {
            string footprints = "";
            var next = _filePostProcessor.Apply(
                resp: CRRes.SaveAllWithoutFirstPage,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    footprints += $"|saveEntireTo {copyTo}";
                },
                savePartTo: saveTo =>
                {
                    footprints += $"|savePartTo {saveTo}";
                },
                saveCsvFileTo: saveTo =>
                {
                    footprints += $"|saveCsvFileTo {saveTo}";
                },
                saveAllWithoutFirstPageTo: saveTo =>
                {
                    footprints += $"|saveAllWithoutFirstPageTo {saveTo}";
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    footprints += $"|recycSourceFile";
                },
                runOutCmd: (a, b) =>
                {
                    footprints += $"|runOutCmd {a} {b}";
                    return successful;
                }
            );
            Assert.That(next, Is.EqualTo(expectedNext));
            Assert.That(footprints, Is.EqualTo(expectedFootprints));
        }

        [Test]
        [TestCase(false, false, "|savePartTo pdf|saveCsvFileTo csv|runOutCmd pdf csv")]
        [TestCase(false, true, "|savePartTo pdf|saveCsvFileTo csv|runOutCmd pdf csv")]
        [TestCase(true, false, "|savePartTo pdf|saveCsvFileTo csv|runOutCmd pdf csv")]
        [TestCase(true, true, "|savePartTo pdf|saveCsvFileTo csv|runOutCmd pdf csv")]
        public void SaveAvailCmdSuccessful(
            bool useRecyc,
            bool doNotSplit,
            string expectedFootprints
            )
        {
            string footprints = "";
            var next = _filePostProcessor.Apply(
                resp: CRRes.Avail,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    footprints += $"|saveEntireTo {copyTo}";
                },
                savePartTo: saveTo =>
                {
                    footprints += $"|savePartTo {saveTo}";
                },
                saveCsvFileTo: saveTo =>
                {
                    footprints += $"|saveCsvFileTo {saveTo}";
                },
                saveAllWithoutFirstPageTo: saveTo =>
                {
                    footprints += $"|saveAllWithoutFirstPageTo {saveTo}";
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    footprints += $"|recycSourceFile";
                },
                runOutCmd: (a, b) =>
                {
                    footprints += $"|runOutCmd {a} {b}";
                    return true;
                }
            );
            Assert.That(next, Is.EqualTo(Next.BreakLoop));
            Assert.That(footprints, Is.EqualTo(expectedFootprints));
        }

        [Test]
        [TestCase(false, false, "")]
        [TestCase(false, true, "")]
        [TestCase(true, false, "")]
        [TestCase(true, true, "")]
        public void TemplatePageCmdContinue(
            bool useRecyc,
            bool doNotSplit,
            string expectedFootprints
            )
        {
            string footprints = "";
            var next = _filePostProcessor.Apply(
                resp: CRRes.TemplatePage,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    footprints += $"|saveEntireTo {copyTo}";
                },
                savePartTo: saveTo =>
                {
                    footprints += $"|savePartTo {saveTo}";
                },
                saveCsvFileTo: saveTo =>
                {
                    footprints += $"|saveCsvFileTo {saveTo}";
                },
                saveAllWithoutFirstPageTo: saveTo =>
                {
                    footprints += $"|saveAllWithoutFirstPageTo {saveTo}";
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    footprints += $"|recycSourceFile";
                },
                runOutCmd: (a, b) =>
                {
                    footprints += $"|runOutCmd {a} {b}";
                    return true;
                }
            );
            Assert.That(next, Is.EqualTo(Next.Continue));
            Assert.That(footprints, Is.EqualTo(expectedFootprints));

        }
    }
}
