using System;

internal struct Point : IComparable
{
    private Int32 m_x, m_y;

    public Point(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }
    //Переопределяем метод ToString, унаследованный от System.ValueType
    public override string ToString()
    {
        //Возвразаем Point как строку (вызов ToString предотвращает упаковку)
        return String.Format("{0}, {1}", m_x.ToString(), m_y.ToString());
    }

    public Int32 CompareTo(Point other)
    {
        // Используем теорему Пифагора для определения точки,
        // наиболее удаленной от начала координат (0, 0)
        return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
            - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
    }
    //реализация метода CompareTo интерфейса ICompareble
    public Int32 CompareTo(Object o)
    {
        if (GetType() != o.GetType())
        {
            throw new ArgumentException("o is not a Point");
        }
        // Вызов безопасного в отношении типов метода CompareTo
        return CompareTo((Point)o);
    }
}

public sealed class Program
{
    public static void Main()
    {
        // Создаем в стеке два экземпляра Point
        Point p1 = new Point(10, 10);
        Point p2 = new Point(20, 20);
        // p1 НЕ пакуется для вызова ToString (виртуальный метод)
        Console.WriteLine(p1.ToString()); // "(10, 10)"
        // p1 ПАКУЕТСЯ для вызова GetType (невиртуальный метод)
        Console.WriteLine(p1.GetType()); // "Point"
        // p1 НЕ пакуется для вызова CompareTo
        // p2 НЕ пакуется, потому что вызван CompareTo(Point)
        Console.WriteLine(p1.CompareTo(p2)); // "-1" 
        // p1 пакуется, а ссылка размещается в c
        IComparable c = p1; 
        Console.WriteLine(c.GetType()); // "Point" 
        // p1 НЕ пакуется для вызова CompareTo
        // Поскольку в CompareTo не передается переменная Point,
        // вызывается CompareTo(Object), которому нужна ссылка
        // на упакованный Point
        // c НЕ пакуется, потому что уже ссылается на упакованный Point
        Console.WriteLine(p1.CompareTo(c)); // "0"
        // c НЕ пакуется, потому что уже ссылается на упакованный Point
        // p2 ПАКУЕТСЯ, потому что вызывается CompareTo(Object)
        Console.WriteLine(c.CompareTo(p2)); //"-1"
        // c пакуется, а поля копируются в p2
        p2 = (Point)c;
        // Убеждаемся, что поля скопированы в p2
        Console.WriteLine(p2.ToString());// "(10, 10)"
        Console.ReadKey();
    }
}