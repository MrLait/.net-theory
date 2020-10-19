using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Models
{
    class VoiceMessage : IVoiceMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }

        public byte[] Voice { get; set; }
        public void Send()
        {
            Console.WriteLine("Передача голосовой почты");
        }
    }
}
