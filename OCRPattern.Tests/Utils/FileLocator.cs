using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCRPattern.Tests.Utils
{
    internal static class FileLocator
    {
        public static string Resolve(string relPath)
        {
            return Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "../../..", // @"bin\x86\Debug"
                relPath
            );
        }
    }
}
