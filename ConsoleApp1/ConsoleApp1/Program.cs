using System;
using System.Text;
using System.Threading;

public static class Program
{
    public static void Main()
    {
        //System.FormatException
        //Int32 x = Int32.Parse(" 123", System.Globalization.NumberStyles.None, null);

        Int32 x = Int32.Parse(" 123", System.Globalization.NumberStyles.AllowLeadingWhite, null);
        Console.WriteLine(x);
        //Вот пример синтаксического разбора строки шестнадцатеричного числа:
        Int32 x1 = Int32.Parse("1A", System.Globalization.NumberStyles.HexNumber, null);
        Console.WriteLine(x1); // Отображает "26".
    }
}