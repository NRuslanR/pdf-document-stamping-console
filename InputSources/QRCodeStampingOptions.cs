using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class QRCodeStampingOptions : BarcodeStampingOptions
    {
        public Color QRCodeDarkColor { get; set; }

        public Color QRCodeLightColor { get; set; }

        public bool DrawQuietZone { get; set; }
    }
}
