using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStampingConsoleApp.Stamping.Commands;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes
{
    class QRCodeStampingCommandInput : StampingCommandInput
    {
        public Color QRCodeDarkColor { get; set; }

        public Color QRCodeLightColor { get; set; }

        public string TextToEncode { get; set; }

        public bool DrawQuietZone { get; set; }
    }
}
