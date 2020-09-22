using System;

namespace SOLID._3.LiskovSubstitutionPrinciple.BadPractice.Preconditions
{
    class Account
    {
        public int Capital { get; protected set; }

        public virtual void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0");
            Capital = money;
        }
    }
}
