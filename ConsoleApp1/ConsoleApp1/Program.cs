using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    internal sealed class SimpleType : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("public Dispose");
        }
        void IDisposable.Dispose()
        {
            Console.WriteLine("IDisposable Dispose");
        }

    }
    internal sealed class SimpleType1 : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
    public static void Main()
    {
        SimpleType st = new SimpleType();
        // Вызов реализации открытого метода Dispose
        st.Dispose();
        // Вызов реализации метода Dispose интерфейса IDisposable
        IDisposable disposable = st;
        disposable.Dispose();

        SimpleType1 st1 = new SimpleType1();
        // Вызов реализации открытого метода Dispose
        st1.Dispose();
        // Вызов реализации метода Dispose интерфейса IDisposable
        IDisposable disposable1 = st1;
        disposable1.Dispose();

    }
}

