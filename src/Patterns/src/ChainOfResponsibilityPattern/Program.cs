using ChainOfResponsibilityPattern.Metanit;
using ChainOfResponsibilityPattern.RefactoringGuru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Receiver receiver = new Receiver(false, true, false);

            //PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            //PaymentHandler moneyPaymentHadler = new MoneyPaymentHandler();
            //PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            //bankPaymentHandler.Successor = paypalPaymentHandler;
            //paypalPaymentHandler.Successor = moneyPaymentHadler;
            //bankPaymentHandler.Handle(receiver);

            AbstractHandler monkeyHandler = new MonkeyHandler();
            monkeyHandler.SetNext(new SquirrelHandler());
            Client.ClientCode(monkeyHandler);

            Console.Read();
        }
    }
}
