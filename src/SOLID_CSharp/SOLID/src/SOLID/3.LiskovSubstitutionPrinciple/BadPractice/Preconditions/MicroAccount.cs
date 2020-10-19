using System;

namespace SOLID._3.LiskovSubstitutionPrinciple.BadPractice.Preconditions
{
    class MicroAccount : Account
    {
        public override void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0");

            //В этом случае подкласс MicroAccount добавляет дополнительное предусловие, 
            //то есть усиливает его, что недопустимо. Поэтому в реальной задаче мы можем столкнуться с проблемой
            if (money > 100)
                throw new Exception("Нельзя положить на счет больше 100");

            Capital = money;
        }
    }
}
