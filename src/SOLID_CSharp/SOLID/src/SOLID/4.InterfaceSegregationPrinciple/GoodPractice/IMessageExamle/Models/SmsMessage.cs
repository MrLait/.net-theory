using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Models
{
    class SmsMessage : ITextMessage
    {
        public string Text { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public void Send()
        {
            Console.WriteLine("Отправляем по Sms сообщение: {0}", Text);
        }
    }
}
