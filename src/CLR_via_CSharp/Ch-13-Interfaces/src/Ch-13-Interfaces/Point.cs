using System;

namespace Ch_13_Interfaces
{
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
        public Int32 CompareTo(Point other)
        {
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
            - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", m_x, m_y);
        }
    }

}