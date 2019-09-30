using System;

// Интерфейс, определяющий метод Change
internal interface IChangeBoxedPoint
{
    void Change(Int32 x, Int32 y);
}
internal struct Point : IChangeBoxedPoint
{
    private Int32 m_x, m_y;
      
    public Point (Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }

    public void Change(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }
    public override String ToString()
    {
        return String.Format("{0}, {1}", m_x.ToString(), m_y.ToString());
    }
}

public sealed class Program
{
    public static void Main()
    {
        Point p = new Point(1, 1);
        Console.WriteLine(p);
        p.Change(2, 2);
        Console.WriteLine(p);
        Object o = p;
        Console.WriteLine(o);
        ((Point)o).Change(3, 3);
        Console.WriteLine(o);
        // p упаковывается, упакованный объект изменяется и освобождается
        ((IChangeBoxedPoint)p).Change(5, 5);
        Console.WriteLine(p);
        // Упакованный объект изменяется и выводится
        ((IChangeBoxedPoint)o).Change(6, 6);
        Console.WriteLine(o);
        Console.ReadKey();
    }
}