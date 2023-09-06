using System;
using System.Diagnostics;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands
{
    abstract class InOutStampingCommand : IStampingCommand
    {
        private readonly IStampingCommandOutputSource commandOutputSource;

        protected InOutStampingCommand(StampingCommandInput commandInput, IStampingCommandOutputSource commandOutputSource)
        {
            ThrowIfCommandInputTypeNotValid(commandInput);

            this.commandOutputSource = commandOutputSource;

            CommandInput = commandInput;
        }

        private void ThrowIfCommandInputTypeNotValid(StampingCommandInput commandInput)
        {
            if (CommandInputType != commandInput.GetType())
            {
                throw new ArgumentException($"\"{commandInput.GetType().Name}\" is not equals \"{CommandInputType.Name}\"");
            }
        }

        public StampingCommandInput CommandInput { get; set; }

        protected abstract Type CommandInputType { get; }

        public void Run()
        {
            try
            {
                StampingCommandOutput commandOutput = InternalRun();

                commandOutputSource.Accept(commandOutput);
            }

            catch (Exception exception)
            {
                var commandException = new InOutStampingCommandException(GetType(), CommandInput, exception);

                commandOutputSource.Reject(commandException);
            }
        }

        protected abstract StampingCommandOutput InternalRun();
    }
}
