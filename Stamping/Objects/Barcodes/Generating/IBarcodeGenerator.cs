using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes.Generating
{
    interface IBarcodeGenerator
    {
        Image GenerateBarcode(string text);
    }
}
