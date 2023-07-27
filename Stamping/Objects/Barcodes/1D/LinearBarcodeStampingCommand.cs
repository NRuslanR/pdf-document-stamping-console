using System;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Commands;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D
{
    class LinearBarcodeStampingCommand : BarcodeStampingCommand
    {
        public LinearBarcodeStampingCommand(
            IPdfDocumentLinearBarcodeStamper pdfDocumentBarcodeStamper, 
            StampingCommandInput commandInput, 
            IStampingCommandOutputSource commandOutputSource
            ) : base(pdfDocumentBarcodeStamper, commandInput, commandOutputSource)
        {
        }

        protected override Type CommandInputType => typeof(LinearBarcodeStampingCommandInput);

        public new LinearBarcodeStampingCommandInput CommandInput => base.CommandInput as LinearBarcodeStampingCommandInput;

        protected override void CustomizePdfDocumentBarcodeStamper(IPdfDocumentBarcodeStamper documentBarcodeStamper,
            BarcodeStampingCommandInput commandInput)
        {
            base.CustomizePdfDocumentBarcodeStamper(documentBarcodeStamper, commandInput);

            var barcodeGenerator = (ILinearBarcodeGenerator)documentBarcodeStamper.BarcodeGenerator;

            barcodeGenerator.Options.PureBarcode = CommandInput.PureBarcode;
        }
    }
}
