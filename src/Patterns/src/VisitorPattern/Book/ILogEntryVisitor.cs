namespace VisitorPattern.Book
{
    public interface ILogEntryVisitor //определяет интерфейс посетителя
    {
        void Visit(ExceptionLogEntry exceptionLogEntry);
        //void Visit(SimpleLogEntry simpleLogEntry);
    }
    public abstract class LogEntry // базовый класс иерархии, для которой нужно добавить новую операцию;
    {
        public abstract void Accept(ILogEntryVisitor logEntryVisitor);
        // Остальные члены остались без изменения
    }

    public class ExceptionLogEntry : LogEntry
    {
        public override void Accept(ILogEntryVisitor logEntryVisitor)
        {
            // Благодаря перегрузке методов выбирается метод
            // Visit(ExceptionLogEntry)
            logEntryVisitor.Visit(this);
        }
    }

    public class DatabaseLogSaver : ILogEntryVisitor // использует посетитель для обработки иерархии элементов.
    {
        public void SaveLogEntry(LogEntry logEntry)
        {
            logEntry.Accept(this);
        }
        void ILogEntryVisitor.Visit(ExceptionLogEntry exceptionLogEntry)
        {
            SaveException(exceptionLogEntry);
        }

        //void ILogEntryVisitor.Visit(SimpleLogEntry simpleLogEntry)
        //{
        //    SaveSimpleLogEntry(simpleLogEntry);
        //}

        private void SaveException(ExceptionLogEntry logEntry) 
        { 
            //...
        }
        //private void SaveSimpleLogEntry(SimpleLogEntry logEntry) { ...}
    }
}
