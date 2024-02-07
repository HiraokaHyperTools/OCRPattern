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
        [TestCase(false, false, false, "Idle", "Saved", "Saved", Next.Continue)]
        [TestCase(false, false, true, "Idle", "Saved", "Saved", Next.Continue)]
        [TestCase(false, true, false, "Idle", "Saved", "Saved", Next.Continue)]
        [TestCase(false, true, true, "Recycled", "Saved", "Saved", Next.Continue)]
        [TestCase(true, false, false, "Idle", "Saved", "Saved", Next.BreakLoop)]
        [TestCase(true, false, true, "Idle", "Saved", "Saved", Next.BreakLoop)]
        [TestCase(true, true, false, "Idle", "Saved", "Saved", Next.BreakLoop)]
        [TestCase(true, true, true, "Idle", "Saved", "Saved", Next.BreakLoop)]
        public void SaveAllCmd(
            bool successful,
            bool useRecyc,
            bool doNotSplit,
            string expectedSource,
            string expectedEntire,
            string expectedPart,
            Next expectedNext)
        {
            var entire = new OnStated("entire", "Idle");
            var part = new OnStated("part", "Idle");
            var csv = new OnStated("csv", "Idle");
            var source = new OnStated("source", "Idle");
            var cmd = new OnStated("cmd", "Idle");

            var next = _filePostProcessor.Apply(
                resp: CRRes.SaveAll,
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
                    return successful;
                }
            );
            Assert.That(next, Is.EqualTo(expectedNext));

            entire.Ensure(expectedEntire, "_");
            part.Ensure(expectedPart, "_");
            csv.Ensure("Saved", "_");
            source.Ensure(expectedSource, "_");
            cmd.Ensure("Done", "_");
        }

        [Test]
        public void SaveAvailCmdSuccessful()
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
                useRecyc: false,
                doNotSplit: false,
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
    }
}
