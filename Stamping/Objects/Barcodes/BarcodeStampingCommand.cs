using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;
using PdfDocumentStampingConsoleApp.Stamping.Commands;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes
{
    abstract class BarcodeStampingCommand : InOutStampingCommand
    {
        private readonly IPdfDocumentBarcodeStamper pdfDocumentBarcodeStamper;

        public BarcodeStampingCommand(
            IPdfDocumentBarcodeStamper pdfDocumentBarcodeStamper,
            StampingCommandInput commandInput,
            IStampingCommandOutputSource commandOutputSource) : base(commandInput, commandOutputSource)
        {
            this.pdfDocumentBarcodeStamper = pdfDocumentBarcodeStamper;
        }

        private new BarcodeStampingCommandInput CommandInput => base.CommandInput as BarcodeStampingCommandInput;

        protected override StampingCommandOutput InternalRun()
        {
            CustomizePdfDocumentBarcodeStamper(pdfDocumentBarcodeStamper, CommandInput);

            pdfDocumentBarcodeStamper.StampBarcodeInPdfDocument(
                CommandInput.SourcePdfDocumentPath, CommandInput.TextToEncode, CommandInput.OutputPdfDocumentPath,
                IPdfDocumentStamper.StampingOptions.DefaultWithStampingPositions(CommandInput.StampPositions));

            return new StampingCommandOutput { OutputPdfDocumentPath = CommandInput.OutputPdfDocumentPath };
        }

        protected virtual void CustomizePdfDocumentBarcodeStamper(IPdfDocumentBarcodeStamper documentBarcodeStamper, BarcodeStampingCommandInput commandInput)
        {
        
        }
    }
}
