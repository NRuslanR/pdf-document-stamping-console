using System;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands
{
    class InOutStampingCommandException : Exception
    {
        public Type CommandType { get; }

        public StampingCommandInput CommandInput { get; }

        public InOutStampingCommandException(Type commandType, StampingCommandInput commandInput,
            Exception innerException) :
            this($"During the \"{commandType.Name}\" command execution the errors were occurred", commandType,
                commandInput, innerException)
        {

        }

        public InOutStampingCommandException(string message, Type commandType, StampingCommandInput commandInput,
            Exception innerException) : base(message, innerException)
        {
            CommandType = commandType;
            CommandInput = commandInput;
        }
    }
}
