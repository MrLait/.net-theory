using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        Number n = new Number();
        // Значение n сравнивается со значением 5 типа Int32
        IComparable<Int32> c = n;
        Int32 result = c.CompareTo(5);
        Console.WriteLine(result);
        // Значение n сравнивается со значением "5" типа String
        IComparable<String> cString = n;
        result = cString.CompareTo("5");
        Console.WriteLine(result);
    }

    // Этот класс реализует обобщенный интерфейс IComparable<T> дважды
    public sealed class Number : IComparable<Int32>, IComparable<String>
    {
        private Int32 m_val = 5;
        // Этот метод реализует метод CompareTo интерфейса IComparable<Int32>
        public Int32 CompareTo(Int32 n)
        {
            return m_val.CompareTo(n);
        }
        // Этот метод реализует метод CompareTo интерфейса IComparable<String>
        public Int32 CompareTo(String s)
        {
            return m_val.CompareTo(Int32.Parse(s));
        }
    }

    public sealed class SomeType
    {
        private void SomeMethod1()
        {
            Int32 x = 1, y = 2;
            IComparable c = x;
            // CompareTo ожидает Object,
            // но вполне допустимо передать переменную y типа Int32
            c.CompareTo(y); // Выполняется упаковка
            // CompareTo ожидает Object,
            // при передаче "2" (тип String) компиляция выполняется нормально,
            // но во время выполнения генерируется исключение ArgumentException
            c.CompareTo("2");
        }
        private void SomeMethod2()
        {
            Int32 x = 1, y = 2;
            IComparable<Int32> c = x;
            // CompareTo ожидает Object,
            // но вполне допустимо передать переменную y типа Int32
            c.CompareTo(y); // Выполняется упаковка
            // CompareTo ожидает Int32,
            // передача "2" (тип String) приводит к ошибке компиляции
            // с сообщением о невозможности привести тип String к Int32
        //    c.CompareTo("2"); // Ошибка
        }
    }

}

