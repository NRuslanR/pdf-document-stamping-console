using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class QRCodeStampingOptions : PdfDocumentStampingOptions
    {
        public Color QRCodeDarkColor { get; set; }

        public Color QRCodeLightColor { get; set; }

        public string TextToEncode { get; set; }

        public bool DrawQuietZone { get; set; }
    }
}
