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
        var t = Tuple.Create(0, 1, 2, 3, 4, 5, 6, Tuple.Create(7, 8, 9));
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
         t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7,
         t.Rest.Item1.Item1, t.Rest.Item1.Item2, t.Rest.Item1.Item3);

    }

    // Возвращает минимум в Item1 и максимум в Item2
    private static Tuple<Int32, Int32> MinMax(Int32 a, Int32 b)
    {
        return Tuple.Create(Math.Min(a, b), Math.Max(a, b));// Упрощенный
                                                            // синтаксис

    }
}

