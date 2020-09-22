using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Models
{
    /*Здесь мы уже сталкиваемся с небольшой проблемой: свойство Subject, 
     * которое определяет тему сообщения, при отправке смс не указывается, 
     * поэтому оно в данном классе не нужно. 
     * Таким образом, в классе SmsMessage появляется избыточная функциональность, 
     * от которой класс SmsMessage начинает зависеть.*/
    class SmsMessage : IMessage
    {
        public string Text { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public string Subject
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        /*
         * И здесь опять же мы сталкиваемся с ненужными свойствами. 
         * Плюс нам надо добавить новое свойство в предыдущие классы SmsMessage и EmailMessage*/
        public byte[] Voice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Send()
        {
            Console.WriteLine("Отправляем по Sms сообщение: {0}", Text);
        }
    }
}
