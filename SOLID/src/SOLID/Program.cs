using SOLID.SingleResponsibilityPrinciple.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Services;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibilityOne();
            SingleResponsibilityTwo();
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
                new ConsolePhoneReader(), new GeneralPhoneBinder(),
                new GeneralPhoneValidator(), new TextPhoneSaver());
            store.Process();
        }
    }
}
