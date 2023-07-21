using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using PdfDocumentStamperInterfaces;

namespace PdfDocumentStampingConsoleApp.InputSources.Console
{
    class PdfDocumentStampingOptionsCommandLineArgs : IPdfDocumentStampingOptionsInputSource
    {
        private IEnumerable<string> args;

        public PdfDocumentStampingOptionsCommandLineArgs(string[] args)
        {
            this.args = args;
        }

        public IEnumerator<PdfDocumentStampingOptions> GetEnumerator()
        {
            yield return GetPdfDocumentStampingOptions();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private PdfDocumentStampingOptions GetPdfDocumentStampingOptions()
        {
            var parsingResult = ParseCommandLineArgs(args);

            return ExtractPdfDocumentStampingOptions(parsingResult);
            
        }

        private ParserResult<object> ParseCommandLineArgs(IEnumerable<string> args)
        {
            var accessibleOptionTypes = GetAccessibleOptionTypes();

            var parsingResult = Parser.Default.ParseArguments(args, accessibleOptionTypes);

            if (parsingResult.Tag == ParserResultType.NotParsed)
                throw new ArgumentException("Parsing the command line args has failed. Check rightness of the args specification");

            return parsingResult;
        }

        private Type[] GetAccessibleOptionTypes()
        {
            return new Type[] { typeof(QRCodeStampingConsoleOptions), typeof(ImageStampingConsoleOptions) };
        }

        private PdfDocumentStampingOptions ExtractPdfDocumentStampingOptions(ParserResult<object> parsingResult)
        {
            return parsingResult.MapResult(MapPdfDocumentStampingOptions, errors => null);
        }

        private PdfDocumentStampingOptions MapPdfDocumentStampingOptions(object consoleOptions)
        {
            if (consoleOptions is QRCodeStampingConsoleOptions qrCodeStampingConsoleOptions)
                return MapQRCodeStampingOptions(qrCodeStampingConsoleOptions);

            if (consoleOptions is ImageStampingConsoleOptions imageStampingConsoleOptions)
                return MapImageStampingOptions(imageStampingConsoleOptions);

            throw new ArgumentException($"\"{consoleOptions.GetType().Name}\" is not accounted for the mapping of the pdf document stamping options");
        }

        private QRCodeStampingOptions MapQRCodeStampingOptions(QRCodeStampingConsoleOptions consoleOptions)
        {
            var options = new QRCodeStampingOptions
            {
                QRCodeDarkColor = consoleOptions.QRCodeDarkColor,
                QRCodeLightColor = consoleOptions.QRCodeLightColor,
                TextToEncode = consoleOptions.TextToEncode,
                DrawQuietZone = consoleOptions.DrawQuietZone
            };

            SetPdfDocumentStampingOptions(options, consoleOptions);

            return options;
        }

        private ImageStampingOptions MapImageStampingOptions(ImageStampingConsoleOptions consoleOptions)
        {
            var options = new ImageStampingOptions
            {
                ImagePath = consoleOptions.ImagePath
            };

            SetPdfDocumentStampingOptions(options, consoleOptions);

            return options;
        }

        private void SetPdfDocumentStampingOptions(
            PdfDocumentStampingOptions options,
            PdfDocumentStampingConsoleOptions consoleOptions)
        {
            var standardPositionNumbers = ZipStandardPositionNumbers(consoleOptions.StandardStampPositionNumbers,
                consoleOptions.StandardStampPositionNumber);

            options.StampPositions = MapStampPositions(standardPositionNumbers);
            options.SourcePdfDocumentPath = consoleOptions.SourcePdfDocumentPath;
            options.OutputPdfDocumentPath = consoleOptions.OutputPdfDocumentPath;
        }

        private IEnumerable<int> ZipStandardPositionNumbers(IEnumerable<int> positionNumbers, int positionNumber)
        {
            bool positionNumberSpecified = positionNumber != default(int),
                positionNumbersSpecified = positionNumbers.Any() || positionNumberSpecified;

            if (positionNumbersSpecified)
            {
                var resultPositionNumbers = positionNumbers.ToList();

                if (positionNumberSpecified)
                    resultPositionNumbers.Add(positionNumber);

                return resultPositionNumbers;
            }

            return new List<int> { 1 };
        }

        private IEnumerable<IPdfDocumentStamper.Position> MapStampPositions(IEnumerable<int> positionNumbers)
        {
            return positionNumbers.Distinct().Select(pn =>

                pn == 1 ? IPdfDocumentStamper.Position.LeftTopCorner :
                pn == 2 ? IPdfDocumentStamper.Position.RightTopCorner :
                pn == 3 ? IPdfDocumentStamper.Position.RightBottomCorner :
                pn == 4 ? IPdfDocumentStamper.Position.LeftBottomCorner :
                throw new ArgumentException("Incorrect QR-code's position number")

            ).ToList();
        }
    }
}
