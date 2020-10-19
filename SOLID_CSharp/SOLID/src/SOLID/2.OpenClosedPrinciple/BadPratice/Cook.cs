using System;

namespace SOLID._2.OpenClosedPrinciple.BadPratice
{
    /*Однако одного умения готовить картофельное пюре для повара вряд ли достаточно. 
    Хотелось бы, чтобы повар мог приготовить еще что-то. И в этом случае мы подходим 
    к необходимости изменения функционала класса, а именно метода MakeDinner. */
    class Cook
    {
        public string Name { get; set; }

        public Cook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }
}
