using OCRPattern.Interfaces;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OCRPattern.Utils
{
    public class PdfFileLoader : IMultiPageFileLoader, IDisposable
    {
        private readonly PdfDocument pdfDocument;
        private readonly string pdfOpen;

        public float DPI = 200;

        public int NumPages => pdfDocument.PageCount;

        public PdfFileLoader(String fp)
        {
            pdfDocument = PdfDocument.Load(fp);

            pdfOpen = fp;
        }

        public Bitmap Rasterize(int z)
        {
            return (Bitmap)pdfDocument.Render(z, DPI, DPI, false);
        }

        public void SavePageAs(string pdfSave, int index)
        {
            using (var newPdf = PdfDocument.Load(pdfOpen))
            {
                index -= 1;

                while (newPdf.PageCount >= 2)
                {
                    if (index >= 1)
                    {
                        newPdf.DeletePage(0);
                        index -= 1;
                    }
                    else
                    {
                        newPdf.DeletePage(1);
                    }
                }

                newPdf.Save(pdfSave);
            }
        }

        #region IDisposable メンバ

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            pdfDocument?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
