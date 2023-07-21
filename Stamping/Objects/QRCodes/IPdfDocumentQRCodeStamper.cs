using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes
{
    partial interface IPdfDocumentQRCodeStamper
    {
        IPdfDocumentImageStamper PdfDocumentImageStamper { get; set; }

        IQRCodeGenerator QRCodeGenerator { get; set; }

        void StampQRCodeInPdfDocument(string sourceFilePath, string textToEncode, string destFilePath, IPdfDocumentStamper.StampingOptions stampingOptions = null);
    }
}