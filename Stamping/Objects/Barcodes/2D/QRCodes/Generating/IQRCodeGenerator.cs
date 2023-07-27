using System.Drawing;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating
{
    partial interface IQRCodeGenerator : IBarcodeGenerator
    {
        GeneratingOptions Options { get; set; }
    }
}