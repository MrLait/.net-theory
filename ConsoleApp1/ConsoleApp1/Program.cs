using System;

internal sealed class SomeRefType
{
    static SomeRefType()
    {
        // Исполняется при первом обращении к ссылочному типу SomeRefType}
    }
}
internal struct SomeValType
{
    // C# на самом деле допускает определять для значимых типов
    // конструкторы без параметров
    static SomeValType()
    {
        // Исполняется при первом обращении к значимому типу SomeValType}
        Console.WriteLine("This never gets displayed");
    }
    public Int32 m_x;
}

public sealed class Programm
{
    public static void Main()
    {
        SomeValType p = new SomeValType();
        Console.WriteLine(p.m_x);
        p.m_x = 100;
        Console.WriteLine(p.m_x);

        Console.ReadKey();
    }
}
