namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating
{
    partial interface ILinearBarcodeGenerator
    {
        class GeneratingOptions
        {
            private bool pureBarcode;

            public GeneratingOptions()
            {
                PureBarcode = true;
            }

            public bool PureBarcode
            {
                get => pureBarcode;
                set => pureBarcode = value;
            }
        }
    }
}
