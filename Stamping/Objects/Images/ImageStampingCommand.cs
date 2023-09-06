using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.Stamping.Commands;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Images
{
    class ImageStampingCommand : InOutStampingCommand
    
    {
        private readonly IPdfDocumentImageStamper pdfDocumentImageStamper;

        public ImageStampingCommand(
            IPdfDocumentImageStamper pdfDocumentImageStamper,
            StampingCommandInput commandInput, 
            IStampingCommandOutputSource commandOutputSource) : base(commandInput, commandOutputSource)
        {
            this.pdfDocumentImageStamper = pdfDocumentImageStamper;
        }

        protected override Type CommandInputType => typeof(ImageStampingCommandInput);

        private new ImageStampingCommandInput CommandInput => base.CommandInput as ImageStampingCommandInput;

        protected override StampingCommandOutput InternalRun()
        {
            pdfDocumentImageStamper.StampImageInPdfDocument(
                CommandInput.SourcePdfDocumentPath,
                CommandInput.ImagePath,
                CommandInput.OutputPdfDocumentPath,
                IPdfDocumentStamper.StampingOptions.DefaultWithStampingPositions(CommandInput.StampPositions));

            return new StampingCommandOutput { OutputPdfDocumentPath = CommandInput.OutputPdfDocumentPath };
        }
    }
}
