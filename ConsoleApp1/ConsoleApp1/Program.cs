using System;
using System.Text;
using System.Globalization;

public static class Program
{
    public static void Main()
    {
        Decimal price = 123.54M;
        String s = price.ToString("C", new CultureInfo("vi-VN"));
        Console.WriteLine(String.Format("{0:C}",s));
        String s1 = price.ToString("C", CultureInfo.InvariantCulture);
        Console.WriteLine(s1);

        String s2 = String.Format("On {0}, {1} is {2} years old.",
            new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
        Console.WriteLine(s2);

        String s3 = String.Format("On {0:D}, {1} is {2:E} years old.",
            new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
        Console.WriteLine(s3);
    }

}

