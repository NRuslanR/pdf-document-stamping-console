using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    [Verb("barcode", HelpText = "Barcodes stamping command")]
    class BarcodeStampingConsoleOptions : PdfDocumentStampingConsoleOptions
    {
        [Option(
            "write_text", 
            Default = false, 
            HelpText = "Must or not write encoded text under barcode. If flag is not presented then encoded text isn't written", 
            Required = false)
        ]
        public bool WriteText { get; set; }

        [Value(1, HelpText = "Text to barcode encoding")]
        public string TextToEncode { get; set; }
    }
}
