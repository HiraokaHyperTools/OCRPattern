using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OCRPattern.Utils
{
    internal class SemVerComparer : IComparer<string>
    {
        public int Compare(string left, string right)
        {
            return PadNum(left ?? "").CompareTo(PadNum(right ?? ""));
        }

        public static readonly SemVerComparer Instance = new SemVerComparer();

        private static string PadNum(string text) => Regex.Replace(text, "\\d+", match => match.Value.PadLeft(10, '0'));
    }
}
