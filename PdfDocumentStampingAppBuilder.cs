using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using PdfDocumentStamperInterfaces;
using PdfDocumentStampingConsoleApp.ErrorHandling;
using PdfDocumentStampingConsoleApp.InputSources;
using PdfDocumentStampingConsoleApp.QRCodes.Generating;
using PdfDocumentStampingConsoleApp.QRCodes.Stamping;
using PdfSharpPdfDocumentStamping;

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

            public PdfDocumentStampingAppBuilder WithStandardQRCodeGenerator()
            {
                containerBuilder.RegisterType<StandardQRCodeGenerator>().As<IQRCodeGenerator>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardPdfDocumentStamper()
            {
                containerBuilder.RegisterType<PdfSharpPdfDocumentStamper>().As<IPdfDocumentStamper>();

                return this;
            }

            public PdfDocumentStampingAppBuilder WithStandardPdfDocumentQRCodeStamper()
            {
                WithStandardQRCodeGenerator();
                WithStandardPdfDocumentStamper();

                containerBuilder.RegisterType<StandardPdfDocumentQRCodeStamper>().As<IPdfDocumentQRCodeStamper>();

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
