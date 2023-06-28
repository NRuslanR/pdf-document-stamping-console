using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.QRCodes.Generating;
using PdfDocumentStampingConsoleApp.QRCodes.Stamping;

namespace PdfDocumentStampingConsoleApp
{
    internal partial class PdfDocumentStampingApp 
    {
        private readonly IPdfDocumentStampingOptionsInputSource optionsInputSource;
        private readonly IPdfDocumentQRCodeStamper pdfDocumentQRCodeStamper;

        public PdfDocumentStampingApp(
            IPdfDocumentStampingOptionsInputSource optionsInputSource, 
            IPdfDocumentQRCodeStamper pdfDocumentQRCodeStamper)
        {
            this.optionsInputSource = optionsInputSource;
            this.pdfDocumentQRCodeStamper = pdfDocumentQRCodeStamper;
        }

        public virtual void Run()
        {
            var stampingOptions = GetPdfDocumentStampingOptions();

            DoStampingByOptions(stampingOptions);
        }

        private PdfDocumentStampingOptions GetPdfDocumentStampingOptions() => optionsInputSource.GetPdfDocumentStampingOptions();

        private void DoStampingByOptions(PdfDocumentStampingOptions options)
        {
            pdfDocumentQRCodeStamper.QRCodeGenerator.Options.DarkColor = options.QRCodeDarkColor;
            pdfDocumentQRCodeStamper.QRCodeGenerator.Options.LightColor = options.QRCodeLightColor;

            pdfDocumentQRCodeStamper.StampQRCodeInPdfDocument(
                options.SourcePdfDocumentPath, options.TextToEncode, options.OutputPdfDocumentPath,
                IPdfDocumentStamper.StampingOptions.DefaultWithStampingPositions(options.StampPositions));
        }
    }
}
