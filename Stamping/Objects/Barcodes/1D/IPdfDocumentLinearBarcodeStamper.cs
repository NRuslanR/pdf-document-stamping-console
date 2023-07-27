using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D
{
    interface IPdfDocumentLinearBarcodeStamper : IPdfDocumentBarcodeStamper
    {
        new ILinearBarcodeGenerator BarcodeGenerator { get; set; }
    }
}
