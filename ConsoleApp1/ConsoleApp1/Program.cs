using System;

public sealed class Program
{
    public static void Main()
    {
        //Упаковка null-совместимых значимых типов
        Int32? n1 = null;
        Object o1 = n1;
        Console.WriteLine(o1==null);
        n1 = 5;
        o1 = n1; // o ссылается на упакованный тип Int32
        Console.WriteLine("o's type={0}", o1.GetType()); // "System.Int32"

        //Распаковка null-совместимых значимых типов
        // Создание упакованного типа Int32
        Object o = 5;
        // Распаковка этого типа в Nullable<Int32> и в Int32
        Int32? a = (Int32?)o; // a = 5
        Int32 b = (Int32)o; // b = 5
                            // Создание ссылки, инициализированной значением null
        o = null;
        // "Распаковка" ее в Nullable<Int32> и в Int32
        a = (Int32?)o; // a = null
        //b = (Int32)o; // NullReferenceException

        //Вызов метода GetType через null - совместимый значимый тип
        Int32? x = 5;
        // Эта строка выводит "System.Int32", а не "System.Nullable<Int32>"
        Console.WriteLine(x.GetType());

        //Вызов интерфейсных методов через null - совместимый значимый тип
        Int32? x1 = 5;
        Int32 result = ((IComparable)x1).CompareTo(5);
        Console.WriteLine(result);
        Int32 result2 = ((IComparable)(Int32)x1).CompareTo(5); // Громоздкий код
    }
}