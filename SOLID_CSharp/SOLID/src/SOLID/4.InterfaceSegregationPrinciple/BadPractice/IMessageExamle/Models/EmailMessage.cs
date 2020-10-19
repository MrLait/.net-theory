using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Models
{
    /*Надо отметить, что класс EmailMessage выглядит целостно, 
     * вполне удовлетворяя принципу единственной ответственности. 
     * То есть с точки зрения связанности (cohesion) здесь проблем нет.*/
    class EmailMessage : IMessage
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        /*
         * И здесь опять же мы сталкиваемся с ненужными свойствами. 
         * Плюс нам надо добавить новое свойство в предыдущие классы SmsMessage и EmailMessage*/
        public byte[] Voice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Send()
        {
            Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
        }
    }
}
