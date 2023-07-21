using System.Drawing;
using QRCoder;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes.Generating
{
    class StandardQRCodeGenerator : Objects.QRCodes.Generating.IQRCodeGenerator
    {
        public StandardQRCodeGenerator() : this(new Objects.QRCodes.Generating.IQRCodeGenerator.GeneratingOptions())
        {
        }

        public StandardQRCodeGenerator(Objects.QRCodes.Generating.IQRCodeGenerator.GeneratingOptions options)
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
                        return qrCode.GetGraphic(Options.PixelsInModule, Options.DarkColor, Options.LightColor, Options.DrawQuietZone);
                    }
                }
            }
        }

        public Objects.QRCodes.Generating.IQRCodeGenerator.GeneratingOptions Options { get; set; }
    }
}
