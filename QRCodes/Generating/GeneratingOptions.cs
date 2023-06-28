using System.Drawing;

namespace PdfDocumentStampingConsoleApp.QRCodes.Generating
{
    partial interface IQRCodeGenerator
    {
        public class GeneratingOptions
        {
            public const int DefaultPixelsInModule = 2;

            private Color lightColor;
            private Color darkColor;
            private int pixelsInModule;

            public GeneratingOptions()
            {
                DarkColor = default(Color);
                LightColor = default(Color);
                PixelsInModule = default(int);
            }

            public Color DarkColor
            {
                get => darkColor;
                set => darkColor = ResolveColor(value, Color.Black);
            }

            public Color LightColor
            {
                get => lightColor;
                set => lightColor = ResolveColor(value, Color.White);
            }

            public int PixelsInModule
            {
                get => pixelsInModule;
                set => pixelsInModule = ResolvePixelsInModule(value, DefaultPixelsInModule);
            }

            private Color ResolveColor(Color targetColor, Color defaultColor) => targetColor == default(Color) ? defaultColor : targetColor;
            private int ResolvePixelsInModule(int targetPixelsInModule, int defaultPixelsInModule) => targetPixelsInModule == default(int) ? defaultPixelsInModule : targetPixelsInModule;
        }
    }
}
