using System.Collections.Generic;
using System.Drawing;
using CommandLine;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    abstract class PdfDocumentStampingConsoleOptions
    {
        [Option("std_poss", HelpText = "Standard position numbers to stamping within PDF document", Separator = ',', Required = false)]
        public IEnumerable<int> StandardStampPositionNumbers { get; set; }

        [Option("std_pos", HelpText = "Standard position number to stamping within PDF document", Required = false)]
        public int StandardStampPositionNumber { get; set; }

        [Option("std_h_off", Default = 0, HelpText = "Standard position horizontal offset to stamping. Measure units are millimeters by default", Required = false)]
        public float StandardStampPositionHorizontalOffset { get; set; }

        [Option("std_v_off", Default = 0, HelpText = "Standard position vertical offset to stamping. Measure units are millimeters by default", Required = false)]
        public float StandardStampPositionVerticalOffset { get; set; }

        [Option("std_off_unit", Default = "mm", HelpText = "Measure units of a standard position offset to stamping (millimeters by default).", Required = false)]
        public string StandardStampPositionOffsetUnit { get; set; }

        [Value(0, Required = true, HelpText = "Source PDF Document path")]
        public string SourcePdfDocumentPath { get; set; }

        [Value(2, Required = true, HelpText = "Output PDF Document path")]
        public string OutputPdfDocumentPath { get; set; }
    }
}
