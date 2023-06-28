using System;
using System.IO;
using Castle.DynamicProxy;

namespace PdfDocumentStampingConsoleApp.ErrorHandling
{
    internal class ApplicationErrorHandler: IInterceptor
    {
        private readonly TextWriter errorWriter;

        public ApplicationErrorHandler(TextWriter errorWriter)
        {
            this.errorWriter = errorWriter;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }

            catch (Exception ex)
            {
                errorWriter.WriteLine(ex.Message);
            }
        }
    }
}
