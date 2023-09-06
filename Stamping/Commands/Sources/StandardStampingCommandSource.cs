using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    partial class StandardStampingCommandSource : IStampingCommandSource
    {
        private readonly IStampingCommandInputSource stampingCommandInputSource;
        private readonly IStampingCommandOutputSource stampingCommandOutputSource;
        private readonly ILifetimeScope objectRegistry;

        public StandardStampingCommandSource(
            IStampingCommandInputSource stampingCommandInputSource,
            IStampingCommandOutputSource stampingCommandOutputSource,
            ILifetimeScope objectRegistry)
        {
            this.stampingCommandInputSource = stampingCommandInputSource;
            this.stampingCommandOutputSource = stampingCommandOutputSource;
            this.objectRegistry = objectRegistry;

            SetStampingCommandFactories();
        }

        public IEnumerator<IStampingCommand> GetEnumerator()
        {
            foreach (var stampingCommandInput in stampingCommandInputSource)
                yield return CreateStampingCommand(stampingCommandInput);
        }

        private IStampingCommand CreateStampingCommand(StampingCommandInput stampingCommandInput)
        {
            var stampingCommandFactory = GetStampingCommandFactory(stampingCommandInput);

            return stampingCommandFactory.CreateStampingCommand(stampingCommandInput);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
