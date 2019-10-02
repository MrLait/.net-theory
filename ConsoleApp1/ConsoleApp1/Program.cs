using System;

public sealed class Programm
{
    public sealed class SomeType
    {
        // Некоторые типы не являются элементарными, но С# допускает существование
        // константных переменных этих типов после присваивания значения null
        public const SomeType Empty = null;
    }
        public static void Main()
        {
            Console.ReadKey();
        }
    }