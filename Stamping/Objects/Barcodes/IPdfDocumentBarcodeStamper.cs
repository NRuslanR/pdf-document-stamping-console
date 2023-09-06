using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes.Generating;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes
{
    interface IPdfDocumentBarcodeStamper
    {
        IPdfDocumentImageStamper PdfDocumentImageStamper { get; set; }

        IBarcodeGenerator BarcodeGenerator { get; set; }

        void StampBarcodeInPdfDocument(string sourceFilePath, string textToEncode, string destFilePath,
            IPdfDocumentStamper.StampingOptions stampingOptions = null);
    }
}
