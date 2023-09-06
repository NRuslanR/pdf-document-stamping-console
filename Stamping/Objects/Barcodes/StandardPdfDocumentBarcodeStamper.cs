using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes.Generating;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes
{
    class StandardPdfDocumentBarcodeStamper : IPdfDocumentBarcodeStamper
    {
        public StandardPdfDocumentBarcodeStamper(IPdfDocumentImageStamper pdfDocumentImageStamper, IBarcodeGenerator barcodeGenerator)
        {
            PdfDocumentImageStamper = pdfDocumentImageStamper;
            BarcodeGenerator = barcodeGenerator;
        }

        public IPdfDocumentImageStamper PdfDocumentImageStamper { get; set; }

        public IBarcodeGenerator BarcodeGenerator { get; set; }

        public void StampBarcodeInPdfDocument(string sourceFilePath, string textToEncode, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null)
        {
            var barcodeImage = BarcodeGenerator.GenerateBarcode(textToEncode);

            PdfDocumentImageStamper.StampImageInPdfDocument(sourceFilePath, barcodeImage, destFilePath, stampingOptions);
        }
    }
}
