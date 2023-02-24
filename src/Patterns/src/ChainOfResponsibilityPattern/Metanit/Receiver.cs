using System;

namespace ChainOfResponsibilityPattern.Metanit
{
    class Receiver
    {
        // банковские переводы
        public bool BankTransfer { get; set; }
        // денежные переводы - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // перевод через PayPal
        public bool PayPalTransfer { get; set; }

        public Receiver(bool bankTransfer, bool moneyTransfer, bool payPalTransfer)
        {
            BankTransfer = bankTransfer;
            MoneyTransfer = moneyTransfer;
            PayPalTransfer = payPalTransfer;
        }
    }
}
