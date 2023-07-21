using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Commands;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes
{
    class QRCodeStampingCommand : InOutStampingCommand
    {
        private readonly IPdfDocumentQRCodeStamper pdfDocumentQrCodeStamper;

        public QRCodeStampingCommand(
            IPdfDocumentQRCodeStamper pdfDocumentQRCodeStamper,
            StampingCommandInput commandInput, 
            IStampingCommandOutputSource commandOutputSource) : base(commandInput, commandOutputSource)
        {
            this.pdfDocumentQrCodeStamper = pdfDocumentQRCodeStamper;
        }

        protected override Type CommandInputType => typeof(QRCodeStampingCommandInput);

        private new QRCodeStampingCommandInput CommandInput => base.CommandInput as QRCodeStampingCommandInput;

        protected override StampingCommandOutput InternalRun()
        {
            pdfDocumentQrCodeStamper.QRCodeGenerator.Options.DarkColor = CommandInput.QRCodeDarkColor;
            pdfDocumentQrCodeStamper.QRCodeGenerator.Options.LightColor = CommandInput.QRCodeLightColor;
            pdfDocumentQrCodeStamper.QRCodeGenerator.Options.DrawQuietZone = CommandInput.DrawQuietZone;

            pdfDocumentQrCodeStamper.StampQRCodeInPdfDocument(
                CommandInput.SourcePdfDocumentPath,
                CommandInput.TextToEncode,
                CommandInput.OutputPdfDocumentPath,
                IPdfDocumentStamper.StampingOptions.DefaultWithStampingPositions(CommandInput.StampPositions));

            return new StampingCommandOutput { OutputPdfDocumentPath = CommandInput.OutputPdfDocumentPath };
        }
    }
}
