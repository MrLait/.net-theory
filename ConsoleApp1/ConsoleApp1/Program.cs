using System;
public sealed class Programm
{
    public static void Main()
    {
        Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4, 5 }));
        Console.WriteLine(Add(1,2,3,4,5));
    }
    static Int32 Add(params Int32[] values)
    {
        // ПРИМЕЧАНИЕ: при необходимости этот массив
        // можно передать другим методам
        Int32 sum = 0;
        if (values != null)
        {
            for (Int32 i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
        }
        return sum;
    }
}

