using System;

public sealed class Programm
{
    public static void Main()
    {
        Int32 x = 5; // Инициализация х
        AddVal(ref x); // x требуется инициализировать
        Console.WriteLine(x); 
    }
    private static void AddVal(ref Int32 x)
    {
        x += 10;
    }
}

