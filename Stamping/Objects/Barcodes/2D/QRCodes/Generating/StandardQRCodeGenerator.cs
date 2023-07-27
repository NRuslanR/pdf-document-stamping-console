using System.Drawing;
using QRCoder;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating
{
    class StandardQRCodeGenerator : IQRCodeGenerator
    {
        public StandardQRCodeGenerator() : this(new IQRCodeGenerator.GeneratingOptions())
        {
        }

        public StandardQRCodeGenerator(IQRCodeGenerator.GeneratingOptions options)
        {
            Options = options;
        }

        public Image GenerateBarcode(string plainText)
        {
            using (var qrCodeGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrCodeGenerator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.H, true,
                           false, QRCodeGenerator.EciMode.Default))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        return qrCode.GetGraphic(Options.PixelsInModule, Options.DarkColor, Options.LightColor, Options.DrawQuietZone);
                    }
                }
            }
        }

        public IQRCodeGenerator.GeneratingOptions Options { get; set; }
    }
}
