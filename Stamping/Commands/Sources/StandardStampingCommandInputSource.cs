using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;

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
            if (stampingOptions is BarcodeStampingOptions barcodeStampingOptions)
                return MapBarcodeStampingCommandInput(barcodeStampingOptions);

            if (stampingOptions is ImageStampingOptions imageStampingOptions)
                return MapImageStampingCommandInput(imageStampingOptions);

            throw new ArgumentException(
                $"\"{stampingOptions.GetType().Name}\" is unknown type for the mapping of the command input");
        }

        private StampingCommandInput MapBarcodeStampingCommandInput(BarcodeStampingOptions barcodeStampingOptions)
        {
            if (barcodeStampingOptions is LinearBarcodeStampingOptions linearBarcodeStampingOptions)
                return MapLinearBarcodeStampingCommandInput(linearBarcodeStampingOptions);

            if (barcodeStampingOptions is QRCodeStampingOptions qrCodeStampingOptions) 
                return MapQRCodeStampingCommandInput(qrCodeStampingOptions);

            throw new ArgumentException($"{barcodeStampingOptions.GetType().Name} is not accounted stamping options type");
        }

        private BarcodeStampingCommandInput MapLinearBarcodeStampingCommandInput(LinearBarcodeStampingOptions options)
        {
            var commandInput = new LinearBarcodeStampingCommandInput
            {
                PureBarcode = !options.WriteText
            };

            SetBarcodeStampingCommandInput(commandInput, options);

            return commandInput;
        }

        private StampingCommandInput MapQRCodeStampingCommandInput(QRCodeStampingOptions qrCodeStampingOptions)
        {
            var commandInput = new QRCodeStampingCommandInput
            {
                QRCodeDarkColor = qrCodeStampingOptions.QRCodeDarkColor,
                QRCodeLightColor = qrCodeStampingOptions.QRCodeLightColor,
                DrawQuietZone = qrCodeStampingOptions.DrawQuietZone,
            };

            SetBarcodeStampingCommandInput(commandInput, qrCodeStampingOptions);

            return commandInput;
        }

        private void SetBarcodeStampingCommandInput(BarcodeStampingCommandInput commandInput, BarcodeStampingOptions options)
        {
            commandInput.TextToEncode = options.TextToEncode;

            SetStampingCommandInput(commandInput, options);
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
