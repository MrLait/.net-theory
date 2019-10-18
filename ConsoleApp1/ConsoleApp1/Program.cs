using System;
using System.Security;
using System.Runtime.InteropServices;
public static class Program
{
    internal enum Color
    {
        White, // Присваивается значение 0
        Red,   // Присваивается значение 1
        Green, // Присваивается значение 2
        Blue,  // Присваивается значение 3
        Orange // Присваивается значение 4
    }
    //internal struct Color : System.Enum
    //{
    //    // Далее перечислены открытые константы,
    //    // определяющие символьные имена и значения
    //    public const Color White = (Color)0;
    //    public const Color Red = (Color)1;
    //    public const Color Green = (Color)2;
    //    public const Color Blue = (Color)3;
    //    public const Color Orange = (Color)4;
    //    // Далее находится открытое поле экземпляра со значением переменной Color
    //    // Код с прямой ссылкой на этот экземпляр невозможен
    //    public Int32 value__;
    //}

    internal enum Color1 : byte
    {
        White,
        Red,
        Green,
        Blue,
        Orange
    }

    public static void Main()
    {
        Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));
        Console.WriteLine(Enum.GetUnderlyingType(typeof(Color1)));
        Color1 color = Color1.Blue;
        Console.WriteLine(color);            // "Blue" (Общий формат)
        Console.WriteLine(color.ToString()); // "Blue" (Общий формат)
        Console.WriteLine(color.ToString("G")); // "Blue" (Общий формат)
        Console.WriteLine(color.ToString("D")); // "3" (Десятичный формат)
        Console.WriteLine(color.ToString("X")); // "03" (Шестнадцатеричный формат)
        Console.WriteLine(Enum.Format(typeof(Color), 3, "G"));

        Color[] colors = (Color[])Enum.GetValues(typeof(Color));
        Console.WriteLine("Number of symbols defined: " + colors.Length);
        Console.WriteLine("Value\tSymbol\n-----\t------");
        foreach (Color c in colors)
        {
            Console.WriteLine("{0,5:D}\t{0:G}", c);
        }

        Color[] colors1 = GetEnumValues<Color>();
        Console.WriteLine("Number of symbols defined: " + colors1.Length);
        Console.WriteLine("Value\tSymbol\n-----\t------");
        foreach (Color c in colors1)
        {
            Console.WriteLine("{0,5:D}\t{0:G}", c);
        }

        Color color1 = (Color)Enum.Parse(typeof(Color), "White", false);
        Console.WriteLine(color1.ToString());
        // Так как White2 не определен, генерируется исключение ArgumentException
        // color1 = (Color)Enum.Parse(typeof(Color), "White2", false);
        Console.WriteLine(color1.ToString());

        // Создается экземпляр перечисления Color со значением 1
        Enum.TryParse<Color>("1", false, out Color color2);
        // Создается экземпляр перечисления Color со значение 23
        Enum.TryParse<Color>("23", false, out Color color3);

        // Выводит "True", так как в перечислении Color
        // идентификатор Red определен как 1
        Console.WriteLine(Enum.IsDefined(typeof(Color), 1));
        // Выводит "True", так как в перечислении Color
        // идентификатор White определен как 0
        Console.WriteLine(Enum.IsDefined(typeof(Color), "White"));
        // Выводит "False", так как выполняется проверка с учетом регистра
        Console.WriteLine(Enum.IsDefined(typeof(Color), "white"));
        // Выводит "False", так как в перечислении Color
        // отсутствует идентификатор со значением 10
        Console.WriteLine(Enum.IsDefined(typeof(Color), 10));

        SetColor((Color)547);

        void SetColor(Color c)
        {
            if (!Enum.IsDefined(typeof(Color), c))
            {

                throw (new ArgumentOutOfRangeException("c", c, "Invalid Color value."));
            }
            // Задать цвет, как White, Red, Green, Blue или Orange
        }

    }

        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
    {
        return (TEnum[])Enum.GetValues(typeof(TEnum));
    }


}