using System;
using Castle.DynamicProxy;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.QRCodes;
using PdfDocumentStampingConsoleApp.Stamping.QRCodes;

namespace PdfDocumentStampingConsoleApp
{
    partial class PdfDocumentStampingApp
    {
        private readonly IStampingCommandSource stampingCommandSource;

        public PdfDocumentStampingApp(IStampingCommandSource stampingCommandSource)
        {
            this.stampingCommandSource = stampingCommandSource;
        }

        public virtual void Run()
        {
            foreach (var stampingCommand in stampingCommandSource)
                stampingCommand.Run();
        }
    }
}
