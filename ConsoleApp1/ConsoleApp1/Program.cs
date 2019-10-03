using System;

public sealed class Rational
{
    // Создает Rational из Int32
    public Rational(Int32 num) { }
    // Создает Rational из Single
    public Rational(Single num) { }
    // Преобразует Rational в Int32
    public Int32 ToInt32() { }
    // Преобразует Rational в Single
    public Single ToSingle(){}
}

public sealed class Programm
{
    public static void Main()
    {
        //SomeType p = new SomeType();
        //Console.WriteLine(p);
        Console.ReadKey();
    }
}
