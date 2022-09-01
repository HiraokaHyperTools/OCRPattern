using NUnit.Framework;
using OCRPattern.Tests.Utils;
using OCRPattern.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCRPattern.Tests
{
    public class BitmapRotateUtilTest
    {
        [Test]
        public void Test()
        {
            using (var pages = MultiPageFileLoader.LoadFromFile(
                FileLocator.Resolve("Samples/balloon.tif")
            ))
            {
                Assert.That(pages.NumPages, Is.EqualTo(1));

                using (var bitmap = pages.Rasterize(0))
                {
                    using (var op = new BitmapRotateUtil())
                    {
                        Assert.That(op.Rotate(bitmap, 0), Is.EqualTo(bitmap));
                        Assert.That(op.Rotate(bitmap, 1), Is.Not.Null.And.Not.EqualTo(bitmap));
                        Assert.That(op.Rotate(bitmap, 2), Is.Not.Null.And.Not.EqualTo(bitmap));
                        Assert.That(op.Rotate(bitmap, 3), Is.Not.Null.And.Not.EqualTo(bitmap));
                    }
                }
            }
        }
    }
}
