using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes;
using IQRCodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes.Generating.IQRCodeGenerator;

namespace PdfDocumentStampingConsoleApp.Stamping.QRCodes
{
    internal class StandardPdfDocumentQRCodeStamper : IPdfDocumentQRCodeStamper
    {
        public StandardPdfDocumentQRCodeStamper(IQRCodeGenerator qrCodeGenerator, IPdfDocumentImageStamper pdfDocumentImageStamper)
        {
            PdfDocumentImageStamper = pdfDocumentImageStamper;
            QRCodeGenerator = qrCodeGenerator;
        }

        public IPdfDocumentImageStamper PdfDocumentImageStamper { get; set; }

        public IQRCodeGenerator QRCodeGenerator { get; set; }

        public void StampQRCodeInPdfDocument(string sourceFilePath, string textToEncode, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null)
        {
            var qrCodeImage = CreateQRCode(textToEncode);

            StampPdfDocument(sourceFilePath, qrCodeImage, destFilePath, stampingOptions);
        }

        private Image CreateQRCode(string textToEncode) => QRCodeGenerator.GenerateQRCode(textToEncode);

        private void StampPdfDocument(string sourcePdfDocumentPath, Image qrCodeImage, string outputPdfDocumentPath, IPdfDocumentStamper.StampingOptions options)
        {
            PdfDocumentImageStamper.StampImageInPdfDocument(sourcePdfDocumentPath, qrCodeImage, outputPdfDocumentPath, options);
        }
    }
}
