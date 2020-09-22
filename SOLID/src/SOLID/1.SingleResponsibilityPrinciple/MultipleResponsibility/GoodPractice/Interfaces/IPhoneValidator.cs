using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;

namespace SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces
{
    interface IPhoneValidator
    {
        bool IsValid(Phone phone);
    }
}
