using System;
using System.IO;
using System.Reflection;

namespace Ch_15_EnumeratedTypesAndBitFlags
{
    public class Program
    {
        public static void Main()
        {

            // Эта строка выводит "System.Byte"
            Console.WriteLine(Enum.GetUnderlyingType(typeof(ColorTwo)));
            ColorOne colorOne = ColorOne.Green;
            var test = colorOne - colorOne;


            ColorOne c = ColorOne.Blue;
            Console.WriteLine(c); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString()); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString("G")); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString("D")); // "3" (Десятичный формат)
            Console.WriteLine(c.ToString("X")); // "03" (Шестнадцатеричный формат)

            ColorOne[] colors = (ColorOne[])Enum.GetValues(typeof(ColorOne));
            Console.WriteLine("Number of symbols defined: " + colors.Length);
            Console.WriteLine("Value\tSymbol\n-----\t------");
            foreach (ColorOne cTwo in colors)
            {
                // Выводим каждый идентификатор в десятичном и общем форматах
                Console.WriteLine("{0,5:D}\t{0:G}", cTwo);
            }


            Actions actions = Actions.Read | Actions.Delete; // 0x0005
            Console.WriteLine(actions.ToString()); // "Read, Delete"

                //Следующий фрагмент проверяет, является ли файл скрытым:
            String file = Assembly.GetEntryAssembly().Location;
            FileAttributes attributes = (FileAttributes)File.GetAttributes(file);
            Console.WriteLine("Is {0} hidden? {1}", file, (
             attributes & FileAttributes.Hidden) != 0);

        }

        internal enum ColorOne
        {
            White, // Присваивается значение 0
            Red, // Присваивается значение 1
            Green, // Присваивается значение 2
            Blue, // Присваивается значение 3
            Orange // Присваивается значение 4
        }

        /*
            При компиляции перечислимого типа компилятор C# превращает каждый
        идентификатор в константное поле типа. Например, предыдущее перечисление
        Color компилятор видит примерно так:
        internal struct Color : System.Enum
        {
            // Далее перечислены открытые константы,
            // определяющие символьные имена и значения
            public const Color White = (Color)0;
            public const Color Red = (Color)1;
            public const Color Green = (Color)2;
            public const Color Blue = (Color)3;
            public const Color Orange = (Color)4;
            // Далее находится открытое поле экземпляра со значением переменной Color
            // Код с прямой ссылкой на этот экземпляр невозможен
            public Int32 value__;
        }
        */

        internal enum ColorTwo : byte
        {
            White,
            Red,
            Green,
            Blue,
            Orange
        }

        [Flags, Serializable]
        public enum FileAttributes
        {
            ReadOnly = 0x0001,
            Hidden = 0x0002,
            System = 0x0004,
            Directory = 0x0010,
            Archive = 0x0020,
            Device = 0x0040,
            Normal = 0x0080,
            Temporary = 0x0100,
            SparseFile = 0x0200,
            ReparsePoint = 0x0400,
            Compressed = 0x0800,
            Offline = 0x1000,
            NotContentIndexed = 0x2000,
            Encrypted = 0x4000
        }


        [Flags] // Компилятор C# допускает значение "Flags" или "FlagsAttribute"
        internal enum Actions
        {
            None = 0,
            Read = 0x0001,
            Write = 0x0002,
            ReadWrite = Actions.Read | Actions.Write,
            Delete = 0x0004,
            Query = 0x0008,
            Sync = 0x0010
        }
    }
}