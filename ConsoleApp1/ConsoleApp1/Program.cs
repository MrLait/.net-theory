using System;
public sealed class Program
{
    public sealed class Point
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        public override string ToString()
        {
            return String.Format("{0},{1}", m_x, m_y);
        }
    }
    public static void Main()
    {
        Point p = new Point(3, 4);
        // Компилятор C# вставит здесь инструкцию callvirt,
        // но JIT-компилятор оптимизирует этот вызов и сгенерирует код
        // для невиртуального вызова ToString,
        // поскольку p имеет тип Point, являющийся запечатанным
        Console.WriteLine(p);
    }
}
