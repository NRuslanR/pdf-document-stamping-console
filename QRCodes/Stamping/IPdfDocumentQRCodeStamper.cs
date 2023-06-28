using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.QRCodes.Generating;

namespace PdfDocumentStampingConsoleApp.QRCodes.Stamping
{
    partial interface IPdfDocumentQRCodeStamper
    {
        IPdfDocumentStamper PdfDocumentStamper { get; set; }
        IQRCodeGenerator QRCodeGenerator { get; set; }

        void StampQRCodeInPdfDocument(string sourceFilePath, string textToEncode, string destFilePath, IPdfDocumentStamper.StampingOptions stampingOptions = null);
    }
}