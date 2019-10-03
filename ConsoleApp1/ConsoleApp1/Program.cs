using System;

public sealed class Rational
{
    private Int32 num1;
    private Single num2;
    // Создает Rational из Int32
    public Rational(Int32 num) 
    { 
        num1 = num; 
    }
    // Создает Rational из Single
    public Rational(Single num) { num2 = num; }
    // Преобразует Rational в Int32
    public Int32 ToInt32(){ return num1; }
    // Преобразует Rational в Single
    public Single ToSingle(){ return num2; }
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
        Rational r1 = 5; // Неявное приведение Int32 к Rational
        Rational r2 = 2.5F; // Неявное приведение Single к Rational
        Int32 x = (Int32)r1; // Явное приведение Rational к Int32
        Single y = (Single)r2; // Явное приведение Rational к Single
    }
}
