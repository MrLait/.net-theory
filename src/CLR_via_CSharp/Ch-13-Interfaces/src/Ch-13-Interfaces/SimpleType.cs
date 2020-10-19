using System;

namespace Ch_13_Interfaces
{
    internal sealed class SimpleTypeOne : IDisposable
    {
        public void Dispose() 
        { 
            Console.WriteLine("Dispose"); 
        }
    }

    internal class SimpleTypeTwo : IDisposable
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

    internal class D : SimpleTypeTwo, IDisposable
    {
        void IDisposable.Dispose()
        {
            Console.WriteLine("public D ");
        }
    }
}
