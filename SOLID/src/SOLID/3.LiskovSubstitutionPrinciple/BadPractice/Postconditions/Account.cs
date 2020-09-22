using System;

namespace SOLID._3.LiskovSubstitutionPrinciple.BadPractice.Postconditions
{
    class Account
    {
        public virtual decimal GetInterest(decimal sum, int month, int rate)
        {
            // предусловие
            if (sum < 0 || month > 12 || month < 1 || rate < 0)
                throw new Exception("Некорректные данные");

            decimal result = sum;
            for (int i = 0; i < month; i++)
                result += result * rate / 100;

            // постусловие
            if (sum >= 1000)
                result += 100; // добавляем бонус

            return result;
        }
    }
}
