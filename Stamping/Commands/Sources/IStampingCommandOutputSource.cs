namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    interface IStampingCommandOutputSource
    {
        void Accept(StampingCommandOutput commandOutput);
        void Reject(InOutStampingCommandException commandException);
    }
}
