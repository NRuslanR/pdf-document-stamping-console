using System;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Commands;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes
{
    class QRCodeStampingCommand : BarcodeStampingCommand
    {
        private readonly IPdfDocumentQRCodeStamper pdfDocumentQrCodeStamper;

        public QRCodeStampingCommand(
            IPdfDocumentQRCodeStamper pdfDocumentQRCodeStamper,
            StampingCommandInput commandInput, 
            IStampingCommandOutputSource commandOutputSource) : 
            base(pdfDocumentQRCodeStamper, commandInput, commandOutputSource)
        {
            this.pdfDocumentQrCodeStamper = pdfDocumentQRCodeStamper;
        }

        protected override Type CommandInputType => typeof(QRCodeStampingCommandInput);

        private new QRCodeStampingCommandInput CommandInput => base.CommandInput as QRCodeStampingCommandInput;

        protected override void CustomizePdfDocumentBarcodeStamper(IPdfDocumentBarcodeStamper documentBarcodeStamper,
            BarcodeStampingCommandInput commandInput)
        {
            base.CustomizePdfDocumentBarcodeStamper(documentBarcodeStamper, commandInput);

            var qrCodeGenerator = (IQRCodeGenerator)documentBarcodeStamper.BarcodeGenerator;

            qrCodeGenerator.Options.DrawQuietZone = CommandInput.DrawQuietZone;
            qrCodeGenerator.Options.DarkColor = CommandInput.QRCodeDarkColor;
            qrCodeGenerator.Options.LightColor = CommandInput.QRCodeLightColor;
        }
    }
}
