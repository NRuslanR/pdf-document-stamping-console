using System.Collections.Generic;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    interface IStampingCommandSource : IEnumerable<IStampingCommand>
    {
    }
}
