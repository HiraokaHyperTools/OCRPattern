using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    internal static class NoiseReducers
    {
        internal static Func<Bitmap, string, Bitmap> UseMagick()
        {
            var magick = Magick
                .GetAll()
                .Where(it => it.Spec.Contains("Q:8"))
                .OrderByDescending(it => it.Version, SemVerComparer.Instance)
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
