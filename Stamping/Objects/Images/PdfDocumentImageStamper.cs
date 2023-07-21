using PdfDocumentStamperInterfaces;
using System.Drawing;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Images
{
    interface IPdfDocumentImageStamper
    {
        void StampImageInPdfDocument(string sourceFilePath, string imagePath, string destFilePath, IPdfDocumentStamper.StampingOptions stampingOptions = null);
        void StampImageInPdfDocument(string sourceFilePath, Image image, string destFilePath, IPdfDocumentStamper.StampingOptions stampingOptions = null);
    }

    abstract class PdfDocumentImageStamper : IPdfDocumentImageStamper
    {
        public void StampImageInPdfDocument(string sourceFilePath, string imagePath, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null)
        {
            var image = Image.FromFile(imagePath);

            StampImageInPdfDocument(sourceFilePath, image, destFilePath, stampingOptions);
        }

        public abstract void StampImageInPdfDocument(string sourceFilePath, Image image, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null);
    }
}
