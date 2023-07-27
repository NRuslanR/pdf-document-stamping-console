using System;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.OneD;
using ZXing.Rendering;

namespace PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating
{
    class StandardLinearBarcodeGenerator : ILinearBarcodeGenerator
    {
        private const int MinBarcodeImageHeight = 15;
        private const int DefaultTextTop = 5;

        public StandardLinearBarcodeGenerator() : this(new ILinearBarcodeGenerator.GeneratingOptions())
        {

        }

        public StandardLinearBarcodeGenerator(ILinearBarcodeGenerator.GeneratingOptions options)
        {
            Options = options;
        }

        public Image GenerateBarcode(string text)
        {
            var barcodeMatrix = CreateBarcodeMatrix(text);

            return CreateBarcodeImage(barcodeMatrix, text);
        }

        private BitMatrix CreateBarcodeMatrix(string text)
        {
            return CreateDefaultBarcodeWriter().Encode(text);
        }

        private Image CreateBarcodeImage(BitMatrix barcodeMatrix, string text)
        {
            var barcodeGenerator = CreateDefaultBarcodeWriter();

            barcodeGenerator.Options.PureBarcode = Options.PureBarcode;
            barcodeGenerator.Options.Height = CalculateBarcodeImageHeight(barcodeMatrix.Width, Options.PureBarcode ? string.Empty : text);

            return barcodeGenerator.Write(text);
        }

        private BarcodeWriter CreateDefaultBarcodeWriter() => new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new Code128EncodingOptions
            {
                Margin = 0,
            },

        };

        private int CalculateBarcodeImageHeight(int barcodeImageWidth, string text)
        {
            var barcodeImageHeight = Math.Max((float)barcodeImageWidth / MinBarcodeImageHeight, MinBarcodeImageHeight);

            if (!string.IsNullOrWhiteSpace(text))
            {
                var textFont = new BitmapRenderer().TextFont;

                SizeF textSize;

                using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
                {
                    textSize = graphics.MeasureString(text, textFont);
                }

                barcodeImageHeight += textSize.Height;
            }

            return (int)Math.Ceiling(barcodeImageHeight);
        }

        public ILinearBarcodeGenerator.GeneratingOptions Options { get; set; }
    }
}
