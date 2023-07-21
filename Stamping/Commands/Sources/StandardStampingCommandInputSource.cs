using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    class StandardStampingCommandInputSource : IStampingCommandInputSource
    {
        private readonly IPdfDocumentStampingOptionsInputSource stampingOptionsInputSource;

        public StandardStampingCommandInputSource(IPdfDocumentStampingOptionsInputSource stampingOptionsInputSource)
        {
            this.stampingOptionsInputSource = stampingOptionsInputSource;
        }

        public IEnumerator<StampingCommandInput> GetEnumerator()
        {
            foreach (var stampingOptions in stampingOptionsInputSource)
                yield return MapStampingCommandInput(stampingOptions);
        }

        private StampingCommandInput MapStampingCommandInput(PdfDocumentStampingOptions stampingOptions)
        {
            if (stampingOptions is QRCodeStampingOptions qrCodeStampingOptions)
                return MapQRCodeStampingCommandInput(qrCodeStampingOptions);

            if (stampingOptions is ImageStampingOptions imageStampingOptions)
                return MapImageStampingCommandInput(imageStampingOptions);

            throw new ArgumentException(
                $"\"{stampingOptions.GetType().Name}\" is unknown type for the mapping of the command input");
        }

        private StampingCommandInput MapQRCodeStampingCommandInput(QRCodeStampingOptions qrCodeStampingOptions)
        {
            var commandInput = new QRCodeStampingCommandInput
            {
                QRCodeDarkColor = qrCodeStampingOptions.QRCodeDarkColor,
                QRCodeLightColor = qrCodeStampingOptions.QRCodeLightColor,
                TextToEncode = qrCodeStampingOptions.TextToEncode,
                DrawQuietZone = qrCodeStampingOptions.DrawQuietZone,
            };

            SetStampingCommandInput(commandInput, qrCodeStampingOptions);

            return commandInput;
        }

        private StampingCommandInput MapImageStampingCommandInput(ImageStampingOptions imageStampingOptions)
        {
            var commandInput = new ImageStampingCommandInput
            {
                ImagePath = imageStampingOptions.ImagePath,
            };

            SetStampingCommandInput(commandInput, imageStampingOptions);

            return commandInput;
        }

        private void SetStampingCommandInput(StampingCommandInput commandInput, PdfDocumentStampingOptions stampingOptions)
        {
            commandInput.SourcePdfDocumentPath = stampingOptions.SourcePdfDocumentPath;
            commandInput.OutputPdfDocumentPath = stampingOptions.OutputPdfDocumentPath;
            commandInput.StampPositions = stampingOptions.StampPositions;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
