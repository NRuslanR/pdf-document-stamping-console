using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.QRCodes.Generating;
using QRCoder;
using QRCoderQRCodeGenerator = QRCoder.QRCodeGenerator;

namespace PdfDocumentStampingConsoleApp.QRCodes.Stamping
{
    internal class StandardPdfDocumentQRCodeStamper : IPdfDocumentQRCodeStamper
    {
        public StandardPdfDocumentQRCodeStamper(IQRCodeGenerator qrCodeGenerator, IPdfDocumentStamper pdfDocumentStamper)
        {
            PdfDocumentStamper = pdfDocumentStamper;
            QRCodeGenerator = qrCodeGenerator;
        }

        public IPdfDocumentStamper PdfDocumentStamper { get; set; }
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
            using (var qrCodeStream = new MemoryStream())
            {
                qrCodeImage.Save(qrCodeStream, ImageFormat.Png);

                qrCodeStream.Seek(0, SeekOrigin.Begin);

                PdfDocumentStamper.StampPdfDocument(sourcePdfDocumentPath, qrCodeStream, outputPdfDocumentPath, options);
            }
        }
    }
}
