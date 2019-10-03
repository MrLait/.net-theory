using System;

internal sealed class SomeType
{
    private static Int32 m_x;
    static SomeType()
    {
        m_x = 5;
    }
}

public sealed class Programm
{
    public static void Main()
    {
        SomeType p = new SomeType();

        Console.ReadKey();
    }
}
