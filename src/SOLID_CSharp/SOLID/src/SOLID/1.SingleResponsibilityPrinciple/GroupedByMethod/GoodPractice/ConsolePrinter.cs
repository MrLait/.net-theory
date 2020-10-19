using System;

namespace SOLID._1.SingleResponsibilityPrinciple.GroupedByMethod.GoodPractice
{
    class ConsolePrinter : IPrinter
    {
        public void Print(string text) => Console.WriteLine(text);
    }
}
