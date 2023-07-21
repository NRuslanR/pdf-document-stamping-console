using PdfDocumentStamperInterfaces;
using System.Collections.Generic;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands
{
    abstract class StampingCommandInput
    {
        public IEnumerable<IPdfDocumentStamper.Position> StampPositions { get; set; }

        public string SourcePdfDocumentPath { get; set; }

        public string OutputPdfDocumentPath { get; set; }
    }
}
