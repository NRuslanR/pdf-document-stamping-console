using System;
using System.IO;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.ErrorHandling;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.InputSources.Console;
using PdfDocumentStampingConsoleApp.Stamping.Commands.Sources;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating;
using PdfDocumentStampingConsoleApp.Stamping.Objects.Images;
using PdfSharpPdfDocumentStamping;
using ILinearBarcodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._1D.Generating.ILinearBarcodeGenerator;
using IQRCodeGenerator = PdfDocumentStampingConsoleApp.Stamping.Objects.Barcodes._2D.QRCodes.Generating.IQRCodeGenerator;

namespace PdfDocumentStampingConsoleApp
{
    internal partial class PdfDocumentStampingApp
    {
        public class PdfDocumentStampingAppBuilder
        {
            private ContainerBuilder containerBuilder = new ContainerBuilder();

            public PdfDocumentStampingAppBuilder WithConsoleErrorHandling()
            {
                containerBuilder.Register(r => new ApplicationErrorHandler(Console.Out));

                return this;
            }

            public PdfDocumentStampingAppBuilder WithCommandLineArgsStampingOptions(string[] args)
            {
                containerBuilder
                    .RegisterType<PdfDocumentStampingOptionsCommandLineArgs>()
                    .As<IPdfDocumentStampingOptionsInputSource>()
                    .WithParameter(new TypedParameter(typeof(string[]), args));

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardStampers()
            {
                WithStandardPdfDocumentBarcodeStampers();
                WithStandardPdfDocumentImageStamper();
                
                return this;
            }

            private PdfDocumentStampingAppBuilder WithStandardPdfDocumentBarcodeStampers()
            {
                WithStandardPdfDocumentLinearBarcodeStamper();
                WithStandardPdfDocumentQRCodeStamper();

                return this;
            }

            private PdfDocumentStampingAppBuilder WithStandardPdfDocumentLinearBarcodeStamper()
            {
                WithStandardLinearBarcodeGenerator();
                WithStandardPdfDocumentStamper();

                containerBuilder.RegisterType<StandardPdfDocumentLinearBarcodeStamper>().As<IPdfDocumentLinearBarcodeStamper>();

                return this;
            }

            private PdfDocumentStampingAppBuilder WithStandardLinearBarcodeGenerator()
            {
                containerBuilder.RegisterType<StandardLinearBarcodeGenerator>().As<ILinearBarcodeGenerator>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardPdfDocumentQRCodeStamper()
            {
                WithStandardQRCodeGenerator();
                WithStandardPdfDocumentStamper();

                containerBuilder.RegisterType<StandardPdfDocumentQRCodeStamper>().As<IPdfDocumentQRCodeStamper>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardQRCodeGenerator()
            {
                containerBuilder.RegisterType<StandardQRCodeGenerator>().As<IQRCodeGenerator>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardPdfDocumentImageStamper()
            {
                WithStandardPdfDocumentStamper();

                containerBuilder.RegisterType<StandardPdfDocumentImageStamper>().As<IPdfDocumentImageStamper>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardPdfDocumentStamper()
            {
                containerBuilder.RegisterType<PdfSharpPdfDocumentStamper>().As<IPdfDocumentStamper>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardStampingCommandSource()
            {
                WithStandardStampingCommandInputSource();
                WithNoOpStampingCommandOutputSource();

                containerBuilder.RegisterType<StandardStampingCommandSource>().As<IStampingCommandSource>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardStampingCommandInputSource()
            {
                containerBuilder.RegisterType<StandardStampingCommandInputSource>().As<IStampingCommandInputSource>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithNoOpStampingCommandOutputSource()
            {
                containerBuilder.RegisterType<NoOpStampingCommandOutputSource>().As<IStampingCommandOutputSource>();

                return this;
            }
            public PdfDocumentStampingApp Build()
            {
                var app = InternalBuildApp();

                ResetAllDependencies();

                return app;
            }

            private PdfDocumentStampingApp InternalBuildApp()
            {
                RegisterApp();

                return ResolveApp();
            }

            private void RegisterApp()
            {
                containerBuilder
                    .RegisterType<PdfDocumentStampingApp>()
                    .EnableClassInterceptors()
                    .InterceptedBy(typeof(ApplicationErrorHandler));
            }

            private PdfDocumentStampingApp ResolveApp() => containerBuilder.Build().Resolve<PdfDocumentStampingApp>();

            private void ResetAllDependencies()
            {
                containerBuilder = new ContainerBuilder();
            }
        }

        public static readonly PdfDocumentStampingAppBuilder Builder = new PdfDocumentStampingAppBuilder();
    }
}
