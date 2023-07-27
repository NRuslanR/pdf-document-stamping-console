using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class BarcodeStampingOptions : PdfDocumentStampingOptions
    {
        public string TextToEncode { get; set; }
    }
}
