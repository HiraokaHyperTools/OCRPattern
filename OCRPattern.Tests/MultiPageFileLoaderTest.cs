using NUnit.Framework;
using OCRPattern.Tests.Utils;
using OCRPattern.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCRPattern.Tests
{
    public class MultiPageFileLoaderTest
    {
        [Test]
        [TestCase("3p", 3)]
        [TestCase("a_b_c", 3)]
        [TestCase("t_a_t_b_t_c", 6)]
        public void TIFF(string name, int numPages)
        {
            using (var pages = MultiPageFileLoader.LoadFromFile(
                FileLocator.Resolve($"Samples/{name}.tif")
            ))
            {
                Assert.That(pages.NumPages, Is.EqualTo(numPages));

                for (int index = 0; index < numPages; index++)
                {
                    using (var bitmap = pages.Rasterize(index))
                    {
                        Assert.That(bitmap, Is.Not.Null);
                    }
                }
            }
        }

        [Test]
        [TestCase("3p", 3)]
        [TestCase("a_b_c", 3)]
        [TestCase("t_a_t_b_t_c", 6)]
        public void PDF(string name, int numPages)
        {
            using (var pages = MultiPageFileLoader.LoadFromFile(
                FileLocator.Resolve($"Samples/{name}.pdf")
            ))
            {
                Assert.That(pages.NumPages, Is.EqualTo(numPages));

                for (int index = 0; index < numPages; index++)
                {
                    using (var bitmap = pages.Rasterize(index))
                    {
                        Assert.That(bitmap, Is.Not.Null);
                    }
                }
            }
        }
    }
}
