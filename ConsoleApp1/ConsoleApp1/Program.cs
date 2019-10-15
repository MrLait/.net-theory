using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
    }

    public static class SomeType
    {
        private static void Test()
        {
            Int32 x = 5;
            Guid g = new Guid();
            // Компиляция этого вызова M выполняется без проблем,
            // поскольку Int32 реализует и IComparable, и IConvertible
            M(x);
            // Компиляция этого вызова M приводит к ошибке, поскольку
            // Guid реализует IComparable, но не реализует IConvertible
            M(g);
        }
        // Параметр T типа M ограничивается только теми типами,
        // которые реализуют оба интерфейса: IComparable И IConvertible
        private static Int32 M<T>(T t) where T : IComparable, IConvertible
        {
            return 0;
        }
    }


}

