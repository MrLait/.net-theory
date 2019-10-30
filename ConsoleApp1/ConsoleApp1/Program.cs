using System;
internal struct Point
{
    private Int32 m_x, m_y;
    public Point(Int32 x, Int32 y) { m_x = x; m_y = y; }
    public static Boolean operator ==(Point p1, Point p2)
    {
        return (p1.m_x == p2.m_x) && (p1.m_y == p2.m_y);
    }
    public static Boolean operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }
}

public sealed class Program
{
    public static void Main()
    {
        Point? p1 = new Point(1, 1);
        Point? p2 = new Point(2, 2);
        Console.WriteLine("Are points equal? " + (p1 == p2).ToString());
        Console.WriteLine("Are points not equal? " + (p1 != p2).ToString());
        Console.ReadKey();

        Int32? x = 5;
        Int32? y = null;
        Console.WriteLine("x: HasValue={0}, Value={1}", x.HasValue, x.Value);
        Console.WriteLine("y: HasValue={0}, Value={1}", y.HasValue, y.GetValueOrDefault());
        //Exception
        Console.WriteLine("y: HasValue={0}, Value={1}", y.HasValue, y.Value);
    }
    private static void ConversionsAndCasting()
    {
        // Неявное преобразование из типа Int32 в Nullable<Int32>
        Int32? x = 5;
        // Неявное преобразование из 'null' в Nullable<Int32>
        Int32? b = null;
        // Явное преобразование Nullable<Int32> в Int32
        Int32 c = (Int32)b;
        // Прямое и обратное приведение примитивного типа
        // в null-совместимый тип
        Double? d = 5; // Int32->Double? (d содержит 5.0 в виде double)
        Double? e = b; // Int32?->Double? (e содержит null)
    }
    private static void Operators()
    {
        Int32? a = 5;
        Int32? b = null;
        // Унарные операторы (+ ++ - -- ! ~)
        a++; // a = 6
        b = -b; // b = null
                // Бинарные операторы (+ - * / % & | ^ << >>)
        a = a + 3; // a = 9
        b = b * 3; // b = null;
        // Операторы равенства (== !=)
        if (a == null) { /* нет */ } else { /* да */ }
        if (b == null) { /* да */ } else { /* нет */ }
        if (a != b) { /* да */ } else { /* нет */ }
        // Операторы сравнения (<> <= >=)
        if (a < b) { /* нет */ } else { /* да */ }

    }
}