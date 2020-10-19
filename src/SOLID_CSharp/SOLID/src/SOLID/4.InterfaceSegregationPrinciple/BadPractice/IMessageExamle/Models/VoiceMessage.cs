using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IMessageExamle.Models
{
    class VoiceMessage : IMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public byte[] Voice { get; set; }

        public string Text
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Subject
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Send()
        {
            Console.WriteLine("Передача голосовой почты");
        }
    }
}
