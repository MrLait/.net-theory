using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        Int32 x = 5;
        //   Single s = x.ToSingle(null); // Попытка вызвать метод
        // интерфейса IConvertible

        Single s = ((IConvertible)x).ToSingle(null);

    }
    internal class Base : IComparable
    {
        // Явная реализация интерфейсного метода (EIMI)
        Int32 IComparable.CompareTo(object obj)
        {
            Console.WriteLine(("Base's CompareTo"));
            return 0;
        }
    }
    internal sealed class Derived : Base, IComparable
    {
        // Открытый метод, также являющийся реализацией интерфейса
        public Int32 CompareTo(object obj)
        {
            Console.WriteLine("Derived's CompareTo");

            // Эта попытка вызова EIMI базового класса приводит
            // к бесконечной рекурсии
            IComparable c = this;
            c.CompareTo(obj);
            return 0;
        }
    }
}

