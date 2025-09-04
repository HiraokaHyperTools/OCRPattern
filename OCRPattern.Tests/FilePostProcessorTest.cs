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
        [TestCase(false, false, false, "Idle", "Saved", "Idle", "Saved", Next.Continue)]
        [TestCase(false, false, true, "Recycled", "Saved", "Saved", "Idle", Next.BreakLoop)]
        [TestCase(false, true, false, "Idle", "Saved", "Idle", "Saved", Next.Continue)]
        [TestCase(false, true, true, "Recycled", "Saved", "Saved", "Idle", Next.BreakLoop)]
        [TestCase(true, false, false, "Idle", "Saved", "Idle", "Idle", Next.BreakLoop)]
        [TestCase(true, false, true, "Idle", "Saved", "Idle", "Idle", Next.BreakLoop)]
        [TestCase(true, true, false, "Idle", "Saved", "Idle", "Idle", Next.BreakLoop)]
        [TestCase(true, true, true, "Idle", "Saved", "Idle", "Idle", Next.BreakLoop)]
        public void SaveAllCmd(
            bool successful,
            bool useRecyc,
            bool doNotSplit,
            string expectedSource,
            string expectedEntirePdf,
            string expectedEntireRecyc,
            string expectedPart,
            Next expectedNext)
        {
            var entirePdf = new OnStated("entirePdf", "Idle");
            var entireRecyc = new OnStated("entireRecyc", "Idle");
            var part = new OnStated("part", "Idle");
            var csv = new OnStated("csv", "Idle");
            var source = new OnStated("source", "Idle");
            var cmd = new OnStated("cmd", "Idle");

            var next = _filePostProcessor.Apply(
                resp: CRRes.SaveAll,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    if (copyTo == "pdf")
                    {
                        entirePdf.Ensure("Idle", "Saved");
                    }
                    else if (copyTo == "recyc")
                    {
                        entireRecyc.Ensure("Idle", "Saved");
                    }
                    else
                    {
                        throw new Exception($"Unexpected copyTo: {copyTo}");
                    }
                },
                savePartTo: saveTo =>
                {
                    part.Ensure("Idle", "Saved");
                },
                saveCsvFileTo: saveTo =>
                {
                    csv.Ensure("Idle", "Saved");
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    source.Ensure("Idle", "Recycled");
                },
                runOutCmd: (a, b) =>
                {
                    cmd.Ensure("Idle", "Done");
                    return successful;
                }
            );
            Assert.That(next, Is.EqualTo(expectedNext));

            entirePdf.Ensure(expectedEntirePdf, "_");
            entireRecyc.Ensure(expectedEntireRecyc, "_");
            part.Ensure(expectedPart, "_");
            csv.Ensure("Saved", "_");
            source.Ensure(expectedSource, "_");
            cmd.Ensure("Done", "_");
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void SaveAvailCmdSuccessful(
            bool useRecyc,
            bool doNotSplit
            )
        {
            var entire = new OnStated("entire", "Idle");
            var part = new OnStated("part", "Idle");
            var csv = new OnStated("csv", "Idle");
            var source = new OnStated("source", "Idle");
            var cmd = new OnStated("cmd", "Idle");

            var next = _filePostProcessor.Apply(
                resp: CRRes.Avail,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    entire.Ensure("Idle", "Saved");
                },
                savePartTo: saveTo =>
                {
                    part.Ensure("Idle", "Saved");
                },
                saveCsvFileTo: saveTo =>
                {
                    csv.Ensure("Idle", "Saved");
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    source.Ensure("Idle", "Recycled");
                },
                runOutCmd: (a, b) =>
                {
                    cmd.Ensure("Idle", "Done");
                    return true;
                }
            );
            Assert.That(next, Is.EqualTo(Next.BreakLoop));

            entire.Ensure("Idle", "_");
            part.Ensure("Saved", "_");
            csv.Ensure("Saved", "_");
            source.Ensure("Idle", "_");
            cmd.Ensure("Done", "_");
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void TemplatePageCmdContinue(
            bool useRecyc,
            bool doNotSplit
            )
        {
            var entire = new OnStated("entire", "Idle");
            var part = new OnStated("part", "Idle");
            var csv = new OnStated("csv", "Idle");
            var source = new OnStated("source", "Idle");
            var cmd = new OnStated("cmd", "Idle");

            var next = _filePostProcessor.Apply(
                resp: CRRes.TemplatePage,
                reserveOut: () => new ReservedFilePair("pdf", "csv"),
                saveEntireTo: copyTo =>
                {
                    entire.Ensure("Idle", "Saved");
                },
                savePartTo: saveTo =>
                {
                    part.Ensure("Idle", "Saved");
                },
                saveCsvFileTo: saveTo =>
                {
                    csv.Ensure("Idle", "Saved");
                },
                useRecyc: useRecyc,
                doNotSplit: doNotSplit,
                reserveRecyc: () => "recyc",
                closeSourceFile: () =>
                {

                },
                recycSourceFile: () =>
                {
                    source.Ensure("Idle", "Recycled");
                },
                runOutCmd: (a, b) =>
                {
                    cmd.Ensure("Idle", "Done");
                    return true;
                }
            );
            Assert.That(next, Is.EqualTo(Next.Continue));

            entire.Ensure("Idle", "_");
            part.Ensure("Idle", "_");
            csv.Ensure("Idle", "_");
            source.Ensure("Idle", "_");
            cmd.Ensure("Idle", "_");
        }
    }
}
