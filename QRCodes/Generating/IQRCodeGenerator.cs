using System.Drawing;

namespace PdfDocumentStampingConsoleApp.QRCodes.Generating
{
    partial interface IQRCodeGenerator
    {
        Image GenerateQRCode(string plainText);

        GeneratingOptions Options { get; set; }
    }
}