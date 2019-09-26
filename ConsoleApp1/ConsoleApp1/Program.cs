using System;

namespace ConsoleApp1
{
    // Этот тип неявно наследует от типа System.Object
    internal class Employee : Object
    {
    }

    public sealed class Program
    {
        public static void Main()
        {
            // Приведение типа не требуется, т. к. new возвращает объект Employee,
            // а Object — это базовый тип для Employee.
            Object o = new Employee();
            // Приведение типа обязательно, т. к. Employee — производный от Object
            // В других языках (таких как Visual Basic) компилятор не потребует
            // явного приведения
            Employee e = (Employee)o;
        }
    }
}
