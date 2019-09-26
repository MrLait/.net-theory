using System;

namespace ConsoleApp1
{
    // Этот тип неявно наследует от типа System.Object
    internal class Employee
    {
    }
    internal class Manager : Employee
    {
    }
    internal class B
    {
    }
    internal class D : B
    {
    }
    public sealed class Program
    {
        public static void Main()
        {
            Object o = new Object();
            Boolean b = (o is Object);
            Boolean b0 = (o is Employee);

            Console.WriteLine();
            Console.WriteLine(b + " " + b0);

            if (o is Employee)
            {
                Employee e1 = (Employee)o;
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            //В этом коде clr проверяет совместимость o с типом employee. если o и employee
            //совместимы, as возвращает ненулевой указатель на этот объект, а если нет — оператор as возвращает null.заметьте: оператор as заставляет clr верифицировать тип
            //объекта только один раз, а if лишь сравнивает e с null — такая проверка намного
            //эффективнее, чем определение типа объекта.
            Employee e2 = o as Employee;
            if (e2 != null)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("False");
            }

            Object o1 = new Object();
            Object o2 = new B();
            Object o3 = new D();
            Object o4 = o3;
            B b1 = new B();
            B b2 = new D();
            D d1 = new D();
            //B b3 = new Object(); CTE
            //D d2 = new Object(); CTE
            B b4 = d1;
            //D d3 = b2; CTE
            D d4 = (D)d1;
            D d5 = (D)b2;
            //D d6 = (D)b1; RTE
            //B b5 = (B)o1; RTE
            B b6 = (D)b2;

            Console.ReadKey();
        }

    }
}
