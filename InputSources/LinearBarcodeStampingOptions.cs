using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class LinearBarcodeStampingOptions : BarcodeStampingOptions
    {
        public bool WriteText { get; set; }
    }
}
