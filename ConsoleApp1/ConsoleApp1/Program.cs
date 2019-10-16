using System;
using System.Globalization;

public static class Program
{
    public static void Main()
    {
        String s1 = "Strasse";
        String s2 = "Straße";
        Boolean eq;
        // CompareOrdinal возвращает ненулевое значение
        eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
        Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

        // Сортировка строк для немецкого языка (de) в Германии (DE)
        CultureInfo ci = new CultureInfo("de-DE");
        // Compare возвращает нуль
        eq = String.Compare(s1, s2, true, ci) == 0;
        Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

    }
}

