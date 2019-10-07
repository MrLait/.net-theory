using System;
public sealed class Programm
{
    public static void Main()
    {
        String s1 = "Jeffrey";
        String s2 = "Richter";
        Swap(ref s1, ref s2);
        Console.WriteLine(s1); // Выводит "Richter"
        Console.WriteLine(s2); // Выводит "Jeffrey
    }
    public static void Swap<T>(ref T a, ref T b)
    {
        T t = b;
        b = a;
        a = t;
    }
}

