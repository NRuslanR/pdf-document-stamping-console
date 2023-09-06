using System.Collections.Generic;
using System.Drawing;
using PdfDocumentStamperInterfaces;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class PdfDocumentStampingOptions
    {
        public IEnumerable<IPdfDocumentStamper.Position> StampPositions { get; set; }

        public string SourcePdfDocumentPath { get; set; }

        public string OutputPdfDocumentPath { get; set; }
    }
}
