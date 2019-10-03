using System;
using System.Collections.Generic;
public static class MyExtencion
{
    public static void InvokeAndCatch<TException>(this Action<Object> d, Object o)
        where TException : Exception
    {
        try
        {
            d(o);
        }
        catch (TException) { }
    }
}
    public sealed class Programm
    {
        public static void Main()
        {
            Action<Object> action = o => Console.WriteLine(o.GetType());
            // Выдает NullReferenceException
            action.InvokeAndCatch<NullReferenceException>(null);
            // Поглощает NullReferenceException
        }
}


