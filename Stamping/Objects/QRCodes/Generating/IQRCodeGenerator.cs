using System.Drawing;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes.Generating
{
    partial interface IQRCodeGenerator
    {
        Image GenerateQRCode(string plainText);

        GeneratingOptions Options { get; set; }
    }
}