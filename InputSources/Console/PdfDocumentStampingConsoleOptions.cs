using System.Collections.Generic;
using System.Drawing;
using CommandLine;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    abstract class PdfDocumentStampingConsoleOptions
    {
        [Option("std_poss", HelpText = "Standard position numbers to stamping within PDF document", Separator = ',', Required = false)]
        public IEnumerable<int> StandardStampPositionNumbers { get; set; }

        [Option("std_pos", HelpText = "Standard position number to stamping within PDF document", Separator = ',', Required = false)]
        public int StandardStampPositionNumber { get; set; }

        [Value(0, Required = true, HelpText = "Source PDF Document path")]
        public string SourcePdfDocumentPath { get; set; }

        [Value(2, Required = true, HelpText = "Output PDF Document path")]
        public string OutputPdfDocumentPath { get; set; }
    }
}
