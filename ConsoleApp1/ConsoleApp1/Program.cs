using System;

public sealed class Complex
{
    public static Complex operator+(Complex c1,Complex c2)
    {
        return (c1 + c2);
    }
    //или так
    public static Complex Add(Complex c1, Complex c2)
    {
        return (c1 + c2);
    }
}

public sealed class Programm
{
    public static void Main()
    {
        Complex c = new Complex();
        //SomeType p = new SomeType();
        //Console.WriteLine(p);
        Console.ReadKey();
    }
}
