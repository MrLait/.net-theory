using System;
using TemplateMethod.MetanitExample;
using TemplateMethod.TemplateMethodExtensionMethod;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var logSaverProxy = new LogSaverProxy();
            //
            //logSaverProxy.UploadExceptions();
            LogEntryBase logEntryBase = new LogEntry
            {
                Message = "asdasd",
                AdditionalInformation = "ASDASD",
            };

            Console.WriteLine(logEntryBase.GetText());

            School school = new School();
            University university = new University();

            school.Learn();
            university.Learn();

            Console.Read();
        }
    }
}
