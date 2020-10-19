using System;

namespace SOLID._5.DependencyInversionPrinciple.BadPractice.Models
{
    class ConsolePrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
