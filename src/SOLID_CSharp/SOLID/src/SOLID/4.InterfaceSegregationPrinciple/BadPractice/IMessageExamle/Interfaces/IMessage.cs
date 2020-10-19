namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Interfaces
{
    interface IMessage
    {
        void Send();
        string Text { get; set; }
        string Subject { get; set; }
        string ToAddress { get; set; }
        string FromAddress { get; set; }

        /*Класс голосовой почты также имеет отправителя и получателя, 
         * только само сообщение передается в виде звука, что на уровне C# можно выразить в виде массива байтов. 
         * И в этом случае было бы неплохо, если бы интерфейс IMessage 
         * включал бы в себя дополнительные свойства и методы для этого*/
        /*
         * И здесь опять же мы сталкиваемся с ненужными свойствами. 
         * Плюс нам надо добавить новое свойство в предыдущие классы SmsMessage и EmailMessage*/
        byte[] Voice { get; set; }
    }
}
