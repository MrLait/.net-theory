using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        SomeValueType v = new SomeValueType();
        Object o = new Object();
        Int32 n = v.CompareTo(v);
        n = v.CompareTo(o);
    }
    public interface IComparable
    {
        Int32 CompareTo(Object other);
    }
    internal struct SomeValueType : IComparable
    {
        private Int32 m_x;
        public SomeValueType(Int32 x)
        {
            m_x = x;
        }

        public Int32 CompareTo(Object other)
        {
            return (m_x - ((SomeValueType)other).m_x);
        }
    }
}

