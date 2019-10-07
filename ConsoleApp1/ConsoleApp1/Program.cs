using System;
public sealed class Programm
{
    public static void Main()
    {
        String s1 = "Jeffrey";
        String s2 = "Richter";
        Object o1 = (Object)s1, o2 = (Object)s2;
        Swap(ref o1, ref o2);
        s1 = (String)o1;
        s2 = (String)o2;
        Console.WriteLine(s1); // Выводит "Richter"
        Console.WriteLine(s2); // Выводит "Jeffrey
    }
    public static void Swap(ref Object a, ref Object b)
    {
        Object t = b;
        b = a;
        a = t;
    }
}

