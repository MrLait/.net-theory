namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IMessageExamle.Interfaces
{
    interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }
}
