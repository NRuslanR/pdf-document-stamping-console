using System;

namespace PdfDocumentStampingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PdfDocumentStampingApp
                .Builder
                .WithConsoleErrorHandling()
                .WithCommandLineArgsStampingOptions(args)
                .WithStandardPdfDocumentQRCodeStamper()
                .Build()
                    .Run();
        }
    }
}
