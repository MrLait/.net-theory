using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using TemplateMethod.TemplateMethodWCF;

namespace TemplateMethod.TemplateMethodWCF
{
    // Прокси-класс инкапсулирует особенности работы
    // с WCF-инфраструктурой
    class LogSaverProxy : ILogSaver
    {
        class LogSaverClient : ClientBase<ILogSaver>
        {
            public ILogSaver LogSaver
            {
                get { return Channel; }
            }
        }

        public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
        {
            UseProxyClient(c => c.UploadLogEntries(logEntries));
        }

        public void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions)
        {
            UseProxyClient(c => c.UploadExceptions(exceptions));
        }

        private void UseProxyClient(Action<ILogSaver> accessor)
        {
            var client = new LogSaverClient();
            try
            {
                accessor(client.LogSaver);
                client.Close();
            }
            catch (CommunicationException e)
            {
                client.Abort();
                throw new OperationFailedException(e);
            }
        }
    }
}
