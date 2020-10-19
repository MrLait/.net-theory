using System;

namespace SOLID._3.LiskovSubstitutionPrinciple.BadPractice.Postconditions
{
    class MicroAccount : Account
    {
        /*В качестве постусловия в классе Account используется начисление бонусов в 100 единиц
         * к финальной сумме, если начальная сумма от 1000 и более. 
         * В классе MicroAccount это условие не используется.*/
        public override decimal GetInterest(decimal sum, int month, int rate)
        {
            // предусловие соблюдено
            if (sum < 0 || month > 12 || month < 1 || rate < 0)
                throw new Exception("Некорректные данные");

            decimal result = sum;
            for (int i = 0; i < month; i++)
                result += result * rate / 100;

            // постусловие не соблюдено

            return result;
        }
    }
}