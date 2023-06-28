using System.Collections.Generic;
using System.Drawing;
using CommandLine;

namespace PdfDocumentStampingConsoleApp
{
    class PdfDocumentStampingConsoleOptions
    {
        [Option("qr_dark_color", Default = null, HelpText = "Dark color of QR-code stamp", Required = false)]
        public Color QRCodeDarkColor { get; set; }

        [Option("qr_light_color", Default = null, HelpText = "Light color of QR-code to stamp", Required = false)]
        public Color QRCodeLightColor { get; set; }

        [Option("std_poss", HelpText = "Standard position numbers to stamping within PDF document", Separator = ',', Required = false)]
        public IEnumerable<int> StandardStampPositionNumbers { get; set; }

        [Option("std_pos", HelpText = "Standard position number to stamping within PDF document", Separator = ',', Required = false)]
        public int StandardStampPositionNumber { get; set; }

        [Value(0, Required = true, HelpText = "Source PDF Document path")]
        public string SourcePdfDocumentPath { get; set; }

        [Value(1, Required = true, HelpText = "Text to QR-code encoding")]
        public string TextToEncode { get; set; }

        [Value(2, Required = true, HelpText = "Output PDF Document path")]
        public string OutputPdfDocumentPath { get; set; }
    }
}
