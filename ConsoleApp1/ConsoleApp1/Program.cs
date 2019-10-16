using System;
using System.Text;
using System.Globalization;
using System.Threading;

public static class Program
{
    public static void Main()
    {
        String output = String.Empty;
        String[] symbol = new String[] { "<", "=", ">" };
        Int32 x;
        CultureInfo ci;

        // Следующий код демонстрирует, насколько отличается результат
        // сравнения строк для различных региональных стандартов
        String s1 = "coté";
        String s2 = "côte";
        // Сортировка строк для французского языка (Франция)
        ci = new CultureInfo("fr-Fr");
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        // Сортировка строк для французского языка (Франция)
        ci = new CultureInfo("fr-FR");
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}",
        ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        // Сортировка строк для японского языка (Япония)
        ci = new CultureInfo("ja-JP");
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        // Сортировка строк по региональным стандартам потока
        ci = Thread.CurrentThread.CurrentCulture;
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}",
        ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine + Environment.NewLine;

        // Следующий код демонстрирует использование дополнительных возможностей
        // метода CompareInfo.Compare при работе с двумя строками
        // на японском языке
        // Эти строки представляют слово "shinkansen" (название
        // высокоскоростного поезда) в разных вариантах письма:
        // хирагане и катакане
        s1 = "\u3057\u3093\u304b\u3093\u305b\u3093"; // ("\u3057\u3093\u304b\u3093\u305b\u3093")
        s2 = "\u30b7\u30f3\u30ab\u30f3\u30bb\u30f3"; // ("\u30b7\u30f3\u30ab\u30f3\u30bb\u30f3")
                  // Результат сравнения по умолчанию
        ci = new CultureInfo("ja-JP");
        x = Math.Sign(String.Compare(s1, s2, true, ci));
        output += String.Format("Simple {0} Compare: {1} {3} {2}",
        ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        // Результат сравнения, который игнорирует тип каны
        CompareInfo compareInfo = CompareInfo.GetCompareInfo("ja-JP");
        x = Math.Sign(compareInfo.Compare(s1, s2,
        CompareOptions.IgnoreKanaType));
        output += String.Format("Advanced {0} Compare: {1} {3} {2}",
        ci.Name, s1, s2, symbol[x + 1]);

        Console.WriteLine(output, "Comparing Strings For Sorting");

    }
}

