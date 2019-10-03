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
    // Неявно создает Rational из Int32 и возвращает полученный объект
    public static implicit operator Rational(Int32 num)
    {
        return new Rational(num);
    }
    // Неявно создает Rational из Single и возвращает полученный объект
    public static implicit operator Rational(Single num)
    {
        return new Rational(num);
    }
    // Явно возвращает объект типа Int32, полученный из Rational
    public static explicit operator Int32(Rational rational)
    {
        return rational.ToInt32();
    }
    // Явно возвращает объект типа Single, полученный из Rational
    public static explicit operator Single(Rational rational)
    {
        return rational.ToSingle();
    }
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
