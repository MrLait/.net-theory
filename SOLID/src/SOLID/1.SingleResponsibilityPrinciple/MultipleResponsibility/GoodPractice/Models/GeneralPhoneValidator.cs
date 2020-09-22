using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;
using System;

class GeneralPhoneValidator : IPhoneValidator
{
    public bool IsValid(Phone phone)
    {
        if (String.IsNullOrEmpty(phone.Model) || phone.Price <= 0)
            return false;

        return true;
    }
}
