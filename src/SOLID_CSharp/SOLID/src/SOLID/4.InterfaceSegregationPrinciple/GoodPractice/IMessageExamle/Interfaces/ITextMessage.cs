namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces
{
    interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }
}
