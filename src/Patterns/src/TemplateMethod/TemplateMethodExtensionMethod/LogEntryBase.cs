using System;

namespace TemplateMethod.TemplateMethodExtensionMethod
{
    public abstract class LogEntryBase
    {
        public DateTime EntryDateTime { get; internal set; }

        //public Severity Severity { get; internal set; }
        public string Message { get; internal set; }
        // ExceptionLogEntry будет возвращать информацию об исключении
        public string AdditionalInformation { get; internal set; }
    }
}
