using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using System;

namespace SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Services
{
    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(string[] data)
        {
            if (data.Length >= 2)
            {
                int price = 0;
                if (Int32.TryParse(data[1], out price))
                    return new Phone { Model = data[0], Price = price };
                else
                    throw new Exception("Ошибка привязчика модели Phone. Некорректные данные для свойства Price");
            }
            else
                throw new Exception("Ошибка привязчика модели Phone. Недостаточно данных для создания модели");
        }
    }
}
