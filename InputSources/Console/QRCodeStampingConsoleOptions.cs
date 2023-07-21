using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    [Verb("qrcode", HelpText = "QR-codes stamping command")]
    class QRCodeStampingConsoleOptions : PdfDocumentStampingConsoleOptions
    {
        [Option("qr_dark_color", Default = null, HelpText = "Dark color of QR-code stamp", Required = false)]
        public Color QRCodeDarkColor { get; set; }

        [Option("qr_light_color", Default = null, HelpText = "Light color of QR-code to stamp", Required = false)]
        public Color QRCodeLightColor { get; set; }

        [Option('q', "quiet_zone", Default = default(bool), HelpText = "Use qr-code's quiet zone", Required = false)]
        public bool DrawQuietZone { get; set; }

        [Value(1, Required = true, HelpText = "Text to QR-code encoding")]
        public string TextToEncode { get; set; }
    }
}
