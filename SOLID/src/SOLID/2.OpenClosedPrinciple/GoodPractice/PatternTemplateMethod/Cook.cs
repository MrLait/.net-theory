using SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod.Models;

namespace SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod
{
    /*В данном случае расширение класса опять же производится за счет наследования классов, которые определяют требуемый функционал.*/
    class Cook
    {
        public string Name { get; set; }

        public Cook(string name)
        {
            Name = name;
        }

        public void MakeDinner(AbstractMealBase[] menu)
        {
            foreach (AbstractMealBase meal in menu)
                meal.Make();
        }
    }
}
