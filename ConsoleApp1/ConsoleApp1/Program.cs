using System;

public sealed class Programm
{
    public static void Main()
    {
        Int32 x; // Инициализация х
        GetVal(out x); // Инициализация х не обязательна
        Console.WriteLine(x); 
    }
    private static void GetVal(out Int32 x)
    {
        x = 10;
    }
}

