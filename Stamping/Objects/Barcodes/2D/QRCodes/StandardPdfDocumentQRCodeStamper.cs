using System.Drawing;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using IQRCodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating.IQRCodeGenerator;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes
{
    class StandardPdfDocumentQRCodeStamper : StandardPdfDocumentBarcodeStamper, IPdfDocumentQRCodeStamper
    {
        public StandardPdfDocumentQRCodeStamper(IPdfDocumentImageStamper pdfDocumentImageStamper, IQRCodeGenerator qrCodeGenerator) : 
            base(pdfDocumentImageStamper, qrCodeGenerator) 
        {
        }

        public new IQRCodeGenerator BarcodeGenerator { get; set; }
    }
}