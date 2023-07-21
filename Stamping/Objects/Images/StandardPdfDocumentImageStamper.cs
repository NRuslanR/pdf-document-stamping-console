using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStamperInterfaces;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Images
{
    class StandardPdfDocumentImageStamper : PdfDocumentImageStamper
    {
        private readonly IPdfDocumentStamper pdfDocumentStamper;

        public StandardPdfDocumentImageStamper(IPdfDocumentStamper pdfDocumentStamper)
        {
            this.pdfDocumentStamper = pdfDocumentStamper;
        }        
        
        public override void StampImageInPdfDocument(string sourceFilePath, Image image, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null)
        {
            using var stamp = new MemoryStream();

            var imageFormat = image.RawFormat.IsValid() ? image.RawFormat : ImageFormat.Png;
           
            image.Save(stamp, imageFormat);

            stamp.Seek(0, SeekOrigin.Begin);

            pdfDocumentStamper.StampPdfDocument(sourceFilePath, stamp, destFilePath, stampingOptions);
        }
    }

    public static class ImageFormatExtensions
    {
        public static bool IsValid(this ImageFormat imageFormat)
        {
            return new ImageFormat[]
            {
                ImageFormat.Bmp,
                ImageFormat.Gif,
                ImageFormat.Icon,
                ImageFormat.Jpeg,
                ImageFormat.Png,
                ImageFormat.Tiff,

            }.Contains(imageFormat);
        }
    }
}
