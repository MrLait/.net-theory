using System;
public sealed class Program
{
    public static void Main()
    {
        Nullable<Int32> x = 5;
        Nullable<Int32> y = null;
        Console.WriteLine("x: HasValue={0}, Value={1}", x.HasValue, x.Value);
        Console.WriteLine("y: HasValue={0}, Value={1}", y.HasValue, y.GetValueOrDefault());
        //Exception
        Console.WriteLine("y: HasValue={0}, Value={1}", y.HasValue, y.Value);
    }
}