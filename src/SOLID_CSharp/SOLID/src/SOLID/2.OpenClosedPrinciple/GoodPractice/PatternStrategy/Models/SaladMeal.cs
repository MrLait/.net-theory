using SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy.Interfaces;
using System;

namespace SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy.Models
{
    class SaladMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }
    }
}
