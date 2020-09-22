namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces
{
    interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }
}
