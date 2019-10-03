using System;

internal sealed class SomeType
{
    public Int32 m_x = 5;
}

public sealed class Programm
{
    public static void Main()
    {
        SomeType p = new SomeType();
        Console.WriteLine(p.m_x);
        p.m_x = 100;
        Console.WriteLine(p.m_x);

        Console.ReadKey();
    }
}
