using SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy.Interfaces;

namespace SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy
{
    /*Теперь приготовление еды абстрагировано в интерфейсе IMeal, 
     * а конкретные способы приготовления определены в реализациях этого интерфейса. 
     * А класс Cook делегирует приготовление еды методу Make объекта IMeal.*/
    class Cook
    {
        public string Name { get; set; }

        public Cook(string name) => Name = name;

        public void MakeDinner(IMeal meal) => meal.Make();
    }
}
