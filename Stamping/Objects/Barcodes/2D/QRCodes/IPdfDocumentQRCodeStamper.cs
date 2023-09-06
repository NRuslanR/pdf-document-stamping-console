using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using IQRCodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating.IQRCodeGenerator;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes
{
    interface IPdfDocumentQRCodeStamper : IPdfDocumentBarcodeStamper
    {
        new IQRCodeGenerator BarcodeGenerator { get; set; }
    }
}