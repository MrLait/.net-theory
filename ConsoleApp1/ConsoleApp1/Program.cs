using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        SomeValueType v = new SomeValueType(0);
        IComparable c = v; // Упаковка!
        Object o = new Object();
        Int32 n = c.CompareTo(v); // Нежелательная упаковка
        n = c.CompareTo(o); // Исключение InvalidCastException
    }

    internal struct SomeValueType : IComparable
    {
        private Int32 m_x;
        public SomeValueType(Int32 x) { m_x = x; }
        public Int32 CompareTo(SomeValueType other)
        {
            return (m_x - other.m_x);
        }
        // ПРИМЕЧАНИЕ: в следующей строке не используется public/private
        Int32 IComparable.CompareTo(Object other)
        {
            return CompareTo((SomeValueType)other);
        }
    }
}

