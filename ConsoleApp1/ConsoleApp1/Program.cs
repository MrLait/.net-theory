using System;

namespace ConsoleApp1
{
    // Этот тип неявно наследует от типа System.Object
    internal class Employee : Object
    {
    }

    internal class Manager : Employee
    {

    }
    public sealed class Program
    {
        public static void Main()
        {
            //Создаем объект Manager и передаем его в PromoteEmployee
            // Manager ЯВЛЯЕТСЯ производным от Employee,
            // поэтому PromoteEmployee работает

            Manager m = new Manager();
            PromoteEmployee(m);

            // Создаем объект DateTime и передаем его в PromoteEmployee
            // DateTime НЕ ЯВЛЯЕТСЯ производным от Employee,
            // поэтому PromoteEmployee выбрасывает
            // исключение System.InvalidCastException
            DateTime newYears = new DateTime(2013, 1, 1);

            PromoteEmployee(newYears);

            Console.ReadKey();
        }

        private static void PromoteEmployee(object m)
        {
            // В этом месте компилятор не знает точно, на какой тип объекта
            // ссылается o, поэтому скомпилирует этот код
            // Однако в период выполнения CLR знает, на какой тип
            // ссылается объект o (приведение типа выполняется каждый раз),
            // и проверяет, соответствует ли тип объекта типу Employee
            // или другому типу, производному от Employee
            Employee e = (Manager)m;
        }
    }
}
