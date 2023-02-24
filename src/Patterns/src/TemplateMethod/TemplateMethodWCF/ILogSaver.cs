using OpenQA.Selenium;
using System.Collections.Generic;

namespace TemplateMethod.TemplateMethodWCF
{
    // Интерфейс сервиса сохранения записей
    interface ILogSaver
    {
        void UploadLogEntries(IEnumerable<LogEntry> logEntries);
        void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions);

    }
}
