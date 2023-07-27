using System.Drawing;
using PdfDocumentStampingConsoleApp.Stamping.Commands;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes
{
    class QRCodeStampingCommandInput : BarcodeStampingCommandInput
    {
        public Color QRCodeDarkColor { get; set; }

        public Color QRCodeLightColor { get; set; }

        public bool DrawQuietZone { get; set; }
    }
}
