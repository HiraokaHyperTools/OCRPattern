using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal static class NoiseReducers
    {
        internal static IEnumerable<Magick> DetectMagicks() =>
            Magick
                .GetAll()
                .Where(it => it.Spec.Contains("Q:8"))
                .OrderByDescending(it => it.Version, SemVerComparer.Instance);

        internal static Func<Bitmap, string, Bitmap> UseMagick()
        {
            var magick = DetectMagicks()
                .FirstOrDefault();

            if (magick != null)
            {
                return (pic, parms) =>
                {
                    return magick.Run(pic, parms);
                };
            }
            return null;
        }
    }
}
