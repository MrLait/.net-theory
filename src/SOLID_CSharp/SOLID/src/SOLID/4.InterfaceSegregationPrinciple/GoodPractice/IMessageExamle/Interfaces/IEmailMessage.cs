namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces
{
    interface IEmailMessage : ITextMessage
    {
        string Subject { get; set; }
    }
}
