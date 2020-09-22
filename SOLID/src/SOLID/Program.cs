using SOLID.SingleResponsibilityPrinciple.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using System;
using PatternStrategy = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy;
using PatternTemplateMethod = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibilityOne();
            SingleResponsibilityTwo();
            OpenClosedPrinciplePatternStrategy();
            OpenClosedPrinciplePatternTemplatesMethod();
        }

        static void SingleResponsibilityOne()
        {
            IPrinter printer = new ConsolePrinter();
            Report report = new Report();
            report.Text = "Hello Wolrd";
            report.Print(printer);
        }

        static void SingleResponsibilityTwo()
        {
            MobileStore store = new MobileStore( 
                new ConsolePhoneReader(), 
                new GeneralPhoneBinder(),
                new GeneralPhoneValidator(), 
                new TextPhoneSaver());
            store.Process();
        }

        static void OpenClosedPrinciplePatternStrategy()
        {
            PatternStrategy.Cook bob = new PatternStrategy.Cook("Bob");
            bob.MakeDinner(new PatternStrategy.Models.PotatoMeal());
            Console.WriteLine();
            bob.MakeDinner(new PatternStrategy.Models.SaladMeal());
        }

        static void OpenClosedPrinciplePatternTemplatesMethod()
        {
            PatternTemplateMethod.Models.AbstractMealBase[] menu = new PatternTemplateMethod.Models.AbstractMealBase[] 
            { 
                new PatternTemplateMethod.Models.PotatoMeal(), 
                new PatternTemplateMethod.Models.SaladMeal() };

            PatternTemplateMethod.Cook bob = new PatternTemplateMethod.Cook("Bob");
            bob.MakeDinner(menu);
        }

    }
}
