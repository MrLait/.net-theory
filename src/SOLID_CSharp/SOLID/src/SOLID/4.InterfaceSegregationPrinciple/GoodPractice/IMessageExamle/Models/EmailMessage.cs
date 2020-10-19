using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Models
{
    class EmailMessage : IEmailMessage
    {
        public string Text { get; set; }
        public string Subject { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public void Send()
        {
            Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
        }
    }
}
