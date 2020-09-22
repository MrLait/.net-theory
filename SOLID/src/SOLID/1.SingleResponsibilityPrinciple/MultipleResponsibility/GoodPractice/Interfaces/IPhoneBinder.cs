using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;

namespace SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces
{
    interface IPhoneBinder
    {
        Phone CreatePhone(string[] data);
    }
}
