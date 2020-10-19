﻿using System;

namespace Ch_7_ConstantsFields
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Max entries supported in list: " + SomeLibraryType.MaxEntriesInList);
        }
    }

    public sealed class SomeTypeNull
    {
        // Некоторые типы не являются элементарными, но С# допускает существование
        // константных переменных этих типов после присваивания значения null
        public const SomeTypeNull Empty = null;
    }

    public sealed class SomeLibraryType
    {
        // ПРИМЕЧАНИЕ: C# не позволяет использовать для констант модификатор
        // static, поскольку всегда подразумевается, что константы являются
        // статическими
        public const Int32 MaxEntriesInList = 50;

    }
    public sealed class SomeLibraryTypeReadonly
    {
        // Модификатор static необходим, чтобы поле
        // ассоциировалось с типом, а не экземпляром
        public static readonly Int32 MaxEntriesInList = 50;
    }

    public sealed class SomeType
    {
        // Статическое неизменяемое поле. Его значение рассчитывается
        // и сохраняется в памяти при инициализации класса во время выполнения
        public static readonly Random s_random = new Random();

        // Статическое изменяемое поле
        private static Int32 s_numberOfWrites = 0;

        // Неизменяемое экземплярное поле
        public readonly String Pathname = "Untitled";

        // Изменяемое экземплярное поле
        private System.IO.FileStream m_fs;

        public SomeType(String pathname)
        {
            // Эта строка изменяет значение неизменяемого поля
            // В данном случае это возможно, так как показанный далее код
            // расположен в конструкторе
            this.Pathname = pathname;
        }

        public String DoSomething()
        {
            // Эта строка читает и записывает значение статического изменяемого поля
            s_numberOfWrites = s_numberOfWrites + 1;
            // Эта строка читает значение неизменяемого экземплярного поля
            return Pathname;
        }
    }

    /*Внимание
    Неизменность поля ссылочного типа означает неизменность ссылки, которую этот
    тип содержит, а вовсе не объекта, на которую указывает ссылка, например:*/
    public sealed class АТуре
    {
        // InvalidChars всегда ссылается на один объект массива
        public static readonly Char[] InvalidChars = new Char[] { 'А', 'В', 'C' };
    }

    public sealed class AnotherType
    {
        public static void M()
        {
            // Следующие строки кода вполне корректны, компилируются
            // и успешно изменяют символы в массиве InvalidChars
            АТуре.InvalidChars[0] = 'X';
            АТуре.InvalidChars[1] = 'Y';
            АТуре.InvalidChars[2] = 'Z';
            // Следующая строка некорректна и не скомпилируется,
            // так как ссылка InvalidChars изменяться не может
            //АТуре.InvalidChars = new Char[] { 'X', 'Y', 'Z' };
        }
    }

}