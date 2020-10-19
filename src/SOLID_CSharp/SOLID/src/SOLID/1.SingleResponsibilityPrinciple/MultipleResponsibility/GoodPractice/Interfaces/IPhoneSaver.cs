using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;

namespace SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces
{
    interface IPhoneSaver
    {
        void Save(Phone phone, string fileName);
    }
}
