using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OCRPattern.Utils
{
    public class UtKwt
    {
        [Obsolete("Use PartMatch instead.", true)]
        public static bool Match(String input, String test)
        {
            input = Regex.Replace(input, "\\s+", "");
            test = Regex.Replace(test, "\\s+", "");
            return String.Compare(input, test) == 0;
        }

        public static bool PartMatch(String input, String test)
        {
            input = Regex.Replace(input, "\\s+", " ");
            test = Regex.Replace(test, "\\s+", " ").Trim();
            return input.Contains(test);
        }

        public static bool PartMatch2(String input, String test, bool skipws)
        {
            input = Regex.Replace(input, "\\s+", skipws ? "" : " ");
            test = Regex.Replace(test, "\\s+", skipws ? "" : " ").Trim();
            return input.Contains(test);
        }
    }
}
