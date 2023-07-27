using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using ILinearBarcodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating.ILinearBarcodeGenerator;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D
{
    class StandardPdfDocumentLinearBarcodeStamper : StandardPdfDocumentBarcodeStamper, IPdfDocumentLinearBarcodeStamper
    {
        public StandardPdfDocumentLinearBarcodeStamper(IPdfDocumentImageStamper pdfDocumentImageStamper, ILinearBarcodeGenerator barcodeGenerator) : 
            base(pdfDocumentImageStamper, barcodeGenerator)
        {
        }

        public new ILinearBarcodeGenerator BarcodeGenerator { get; set; }
    }
}
