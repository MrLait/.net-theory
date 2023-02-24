using System;

namespace Mediator.Book
{
    class LogFileReader
    {
        public void ReadFile(string logFileName)
        {
            Console.WriteLine($"{logFileName}: прочитан");
        }
    }
}
