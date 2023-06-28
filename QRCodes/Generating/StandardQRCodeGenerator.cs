using QRCoder;
using System.Drawing;

namespace PdfDocumentStampingConsoleApp.QRCodes.Generating
{
    class StandardQRCodeGenerator : IQRCodeGenerator
    {
        public StandardQRCodeGenerator() : this(new IQRCodeGenerator.GeneratingOptions())
        {
        }

        public StandardQRCodeGenerator(IQRCodeGenerator.GeneratingOptions options)
        {
            this.Options = options;
        }

        public Image GenerateQRCode(string plainText)
        {
            using (var qrCodeGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrCodeGenerator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.H, true,
                           false, QRCodeGenerator.EciMode.Default))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        return qrCode.GetGraphic(Options.PixelsInModule, Options.DarkColor, Options.LightColor, false);
                    }
                }
            }
        }

        public IQRCodeGenerator.GeneratingOptions Options { get; set; }
    }
}
