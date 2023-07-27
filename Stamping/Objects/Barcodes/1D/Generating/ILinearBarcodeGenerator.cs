using System.Drawing;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating
{
    partial interface ILinearBarcodeGenerator : IBarcodeGenerator
    {
        GeneratingOptions Options { get; set; }
    }
}
