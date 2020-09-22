using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using System;

namespace SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Services
{
    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone phone)
        {
            if (String.IsNullOrEmpty(phone.Model) || phone.Price <= 0)
                return false;

            return true;
        }
    }
}
