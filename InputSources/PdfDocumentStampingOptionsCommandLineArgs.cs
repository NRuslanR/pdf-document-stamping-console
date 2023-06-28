using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using PdfDocumentStamperInterfaces;

namespace PdfDocumentStampingConsoleApp.InputSources
{
    class PdfDocumentStampingOptionsCommandLineArgs : IPdfDocumentStampingOptionsInputSource
    {
        private IEnumerable<string> args;

        public PdfDocumentStampingOptionsCommandLineArgs(string[] args)
        {
            this.args = args;
        }

        public PdfDocumentStampingOptions GetPdfDocumentStampingOptions()
        {
            var parsingResult = Parser.Default.ParseArguments<PdfDocumentStampingConsoleOptions>(args);

            if (parsingResult.Tag == ParserResultType.NotParsed)
                throw new ArgumentException("Parsing the command line args has failed. Check rightness of the args specification");

            return MapPdfDocumentStampingOptions(parsingResult.Value);
        }

        private PdfDocumentStampingOptions MapPdfDocumentStampingOptions(
            PdfDocumentStampingConsoleOptions consoleOptions)
        {
            var standardPositionNumbers = ZipStandardPositionNumbers(consoleOptions.StandardStampPositionNumbers,
                consoleOptions.StandardStampPositionNumber);

            return new PdfDocumentStampingOptions
            {
                QRCodeDarkColor = consoleOptions.QRCodeDarkColor,
                QRCodeLightColor = consoleOptions.QRCodeLightColor,
                StampPositions = MapStampPositions(standardPositionNumbers),
                SourcePdfDocumentPath = consoleOptions.SourcePdfDocumentPath,
                TextToEncode = consoleOptions.TextToEncode,
                OutputPdfDocumentPath = consoleOptions.OutputPdfDocumentPath
            };
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
