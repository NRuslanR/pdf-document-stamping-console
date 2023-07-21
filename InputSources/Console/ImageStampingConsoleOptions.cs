using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    [Verb("img", HelpText = "Image stamping command")]
    class ImageStampingConsoleOptions : PdfDocumentStampingConsoleOptions
    {
        [Value(1, Required = true, HelpText = "Image's path to stamping")]
        public string ImagePath { get; set; }
    }
}
