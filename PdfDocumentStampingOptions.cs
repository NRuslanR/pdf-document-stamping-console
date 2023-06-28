using System.Collections.Generic;
using System.Drawing;
using PdfDocumentStamperInterfaces;

namespace PdfDocumentStampingConsoleApp
{
    class PdfDocumentStampingOptions
    {
        public Color QRCodeDarkColor { get; set; }

        public Color QRCodeLightColor { get; set; }

        public IEnumerable<IPdfDocumentStamper.Position> StampPositions { get; set; }

        public string SourcePdfDocumentPath { get; set; }

        public string TextToEncode { get; set; }

        public string OutputPdfDocumentPath { get; set; }
    }
}
