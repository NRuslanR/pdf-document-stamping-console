using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Autofac;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;

namespace PdfDocumentStampingConsoleApp.Stamping.Commands.Sources
{
    partial class StandardStampingCommandSource
    {
        private IDictionary<Type, StampingCommandFactory> stampingCommandFactories;

        private void SetStampingCommandFactories()
        {
            stampingCommandFactories = new Dictionary<Type, StampingCommandFactory>();

            stampingCommandFactories[typeof(QRCodeStampingCommandInput)] =
                new QRCodeStampingCommandFactory(stampingCommandOutputSource, objectRegistry);

            stampingCommandFactories[typeof(ImageStampingCommandInput)] =
                new ImageStampingCommandFactory(stampingCommandOutputSource, objectRegistry);

            stampingCommandFactories[typeof(LinearBarcodeStampingCommandInput)] =
                new LinearBarcodeStampingCommandFactory(stampingCommandOutputSource, objectRegistry);
        }

        private StampingCommandFactory GetStampingCommandFactory(StampingCommandInput stampingCommandInput)
        {
            var commandInputType = stampingCommandInput.GetType();

            if (!stampingCommandFactories.ContainsKey(commandInputType))
                throw new ArgumentException(
                    $"Factory has not found for an command input of type \"{commandInputType.Name}\"");

            return stampingCommandFactories[commandInputType];
        }

        private abstract class StampingCommandFactory
        {
            protected IStampingCommandOutputSource CommandOutputSource { get; }

            protected ILifetimeScope ObjectRegistry { get; }

            protected StampingCommandFactory(IStampingCommandOutputSource commandOutputSource, ILifetimeScope objectRegistry)
            {
                CommandOutputSource = commandOutputSource;
                ObjectRegistry = objectRegistry;
            }

            public abstract IStampingCommand CreateStampingCommand(StampingCommandInput commandInput);
        }

        private class LinearBarcodeStampingCommandFactory : StampingCommandFactory
        {
            public LinearBarcodeStampingCommandFactory(IStampingCommandOutputSource commandOutputSource, ILifetimeScope objectRegistry) : base(commandOutputSource, objectRegistry)
            {
            }

            public override IStampingCommand CreateStampingCommand(StampingCommandInput commandInput)
            {
                var pdfDocumentBarcodeStamper = ObjectRegistry.Resolve<IPdfDocumentLinearBarcodeStamper>();

                return new LinearBarcodeStampingCommand(pdfDocumentBarcodeStamper, commandInput, CommandOutputSource);
            }
        }

        private class QRCodeStampingCommandFactory : StampingCommandFactory
        {
            public QRCodeStampingCommandFactory(IStampingCommandOutputSource commandOutputSource, ILifetimeScope objectRegistry) : base(commandOutputSource, objectRegistry)
            {
            }

            public override IStampingCommand CreateStampingCommand(StampingCommandInput commandInput)
            {
                var pdfDocumentQrCodeStamper = ObjectRegistry.Resolve<IPdfDocumentQRCodeStamper>();

                return new QRCodeStampingCommand(pdfDocumentQrCodeStamper, commandInput, CommandOutputSource);
            }
        }

        private class ImageStampingCommandFactory : StampingCommandFactory
        {
            public ImageStampingCommandFactory(IStampingCommandOutputSource commandOutputSource, ILifetimeScope objectRegistry) : base(commandOutputSource, objectRegistry)
            {
            }

            public override IStampingCommand CreateStampingCommand(StampingCommandInput commandInput)
            {
                var pdfDocumentImageStamper = ObjectRegistry.Resolve<IPdfDocumentImageStamper>();

                return new ImageStampingCommand(pdfDocumentImageStamper, commandInput, CommandOutputSource);
            }
        }
    }
}
