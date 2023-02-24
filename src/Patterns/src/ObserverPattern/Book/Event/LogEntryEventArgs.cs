using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Book.Event
{
    public class LogEntryEventArgs : EventArgs
    {
        public LogEntryEventArgs(string logEntry)
        {
            LogEntry = logEntry;
        }

        public string LogEntry { get; internal set; }
    }
    public class LogFileReader : IDisposable
    {
        private readonly string _logFileName;
        public LogFileReader(string logFileName)
        {
            //...
        }
        public event EventHandler<LogEntryEventArgs> OnNewLogEntry;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void CheckFile()
        {
            foreach (var logEntry in ReadNewLogEntries())
            {
                RaiseNewLogEntry(logEntry);
            }
        }
        private void RaiseNewLogEntry(string logEntry)
        {
            var handler = OnNewLogEntry;
            if (handler != null)
                handler(this, new LogEntryEventArgs(logEntry));
        }

        private IEnumerable<string> ReadNewLogEntries()
        {
            // ...
            // Читаем новые записи из файла,
            // которые появились с момента последнего чтения
            return default;
        }

    }
}
