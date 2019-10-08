using System;
using System.Collections.Generic;
using System.IO;

public sealed class Programm
{


    public static void Main()
    {
        var minmax = MinMax(6, 2);
        Console.WriteLine("Min={0}, Max={1}", 
            minmax.Item1, minmax.Item2); // Min=2, Max=6
    }

    // Возвращает минимум в Item1 и максимум в Item2
    private static Tuple<Int32, Int32> MinMax(Int32 a, Int32 b)
    {
        return new Tuple<Int32, Int32>(Math.Min(a, b), Math.Max(a, b));
    }
}

