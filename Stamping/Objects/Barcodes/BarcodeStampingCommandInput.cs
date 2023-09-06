using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStampingConsoleApp.Stamping.Commands;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes
{
    abstract class BarcodeStampingCommandInput : StampingCommandInput
    {
        public string TextToEncode { get; set; }
    }
}
