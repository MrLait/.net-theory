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
            return CompareTo(obj); // Теперь здесь вызывается виртуальный метод
        }
        // Виртуальный метод для производных классов
        // (этот метод может иметь любое имя)
        public virtual Int32 CompareTo(Object obj)
        {
            Console.WriteLine("Base's virtual CompareTo");
            return 0;
        }
    }
    internal sealed class Derived : Base, IComparable
    {
        // Открытый метод, также являющийся реализацией интерфейса
        public override Int32 CompareTo(object obj)
        {
            Console.WriteLine("Derived's CompareTo");
            // Эта попытка вызова EIMI базового класса приводит
            // к бесконечной рекурсии
            return base.CompareTo(obj);
        }
    }
}

