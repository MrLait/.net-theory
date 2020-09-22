using SOLID.SingleResponsibilityPrinciple.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using System;
using PatternStrategy = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy;
using PatternTemplateMethod = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod;
using BadPractice = SOLID._3.LiskovSubstitutionPrinciple.BadPractice;
using SOLID._5.DependencyInversionPrinciple.GoodPractice.Models;

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
            LiskovSubstitutionPrincipleBadPractice();
            //LiskovSubstitutionPrincipleBadPracticePrecoonditions();
            LiskovSubstitutionPrincipleBadPracticePostconditions();
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

        static void LiskovSubstitutionPrincipleBadPractice()
        {
            BadPractice.Rectangle rect = new BadPractice.Square();

            rect.Height = 5;
            rect.Width = 10;
            if (rect.GetArea() != 50)
                Console.WriteLine("Некорректная площадь!");
        }

        /*С точки зрения класса Account метод InitializeAccount() вполне является работоспособным. 
         * Однако при передаче в него объекта MicroAccount мы столкнемся с ошибкой. 
         * В итоге пинцип Лисков будет нарушен.*/
        static void LiskovSubstitutionPrincipleBadPracticePrecoonditions()
        {
            BadPractice.Preconditions.Account acc = new BadPractice.Preconditions.MicroAccount();
            acc.SetCapital(200);
            Console.WriteLine(acc.Capital);
        }

        /*Исходя из логики класса Account, в методе CalculateInterest мы ожидаем получить в качестве результата числа 1200. 
         * Однако логика класса MicroAccount показывает другой результат. 
         * В итоге мы приходим к нарушению принципа Лисков, 
         * хотя формально мы просто применили стандартные принципы ООП - полиморфизм и наследование.*/
        static void LiskovSubstitutionPrincipleBadPracticePostconditions()
        {
            BadPractice.Postconditions.Account acc = new BadPractice.Postconditions.MicroAccount();
            decimal sum = acc.GetInterest(1000, 1, 10); // 1000 + 1000 * 10 / 100 + 100 (бонус)
            if (sum != 1200) // ожидаем 1200
                Console.WriteLine("Неожиданная сумма при вычислениях");
        }

        static void DependencyInversionPrinciple()
        {
            Book book = new Book(new _5.DependencyInversionPrinciple.GoodPractice.Models.ConsolePrinter());
            book.Print();
            book.Printer = new HtmlPrinter();
            book.Print();
        }
    }
}
