using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    class NoOpStampingCommandOutputSource : IStampingCommandOutputSource
    {
        public void Accept(StampingCommandOutput commandOutput)
        {
            
        }

        public void Reject(InOutStampingCommandException commandException)
        {
            throw commandException.InnerException;
        }
    }
}
