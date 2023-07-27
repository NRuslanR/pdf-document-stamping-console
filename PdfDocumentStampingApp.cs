using System;
using Castle.DynamicProxy;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;

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
