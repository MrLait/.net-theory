using System;
public interface IComparable<T>
{
    Int32 CompareTo(T others);
}
// Объект Point является производным от System.Object
// и реализует IComparable<T> в Point
public sealed class Point : IComparable<Point>
{
    private Int32 m_x, m_y;
    public Point(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }
    // Этот метод реализует IComparable<T> в Point
    public Int32 CompareTo(Point others)
    {
        return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
            - Math.Sqrt(others.m_x * others.m_x + others.m_y * others.m_y));
    }
    public override string ToString()
    {
        return String.Format("{0}, {1}", m_x, m_y);
    }
}
public static class Program
{
    public static void Main()
    {
        Point[] points = new Point[]
        {
            new Point(1,3),
            new Point(2,5),
        };
        // Вызов метода CompareTo интерфейса IComparable<T> объекта Point
        if (points[0].CompareTo(points[1]) < 0)
        {
            Point tempPoint = points[0];
            points[0] = points[1];
            points[1] = tempPoint;
            Console.WriteLine("Swap point");
        }
        Console.WriteLine("Points from closest to (0, 0) to farthest: ");
        foreach (Point item in points)
        {
            Console.WriteLine(item);
        }
    }
}