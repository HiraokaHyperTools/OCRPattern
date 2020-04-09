using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OCRPattern.Utils
{
    class SemVerToVersion
    {
        internal static Version Parse(string ver)
        {
            var match = Regex.Match(ver, "(?<a>\\d+(\\.\\d+(\\.\\d+(\\.\\d+)?)?)?)");
            if (match.Success)
            {
                return Version.Parse(match.Value);
            }
            return null;
        }
    }
}
