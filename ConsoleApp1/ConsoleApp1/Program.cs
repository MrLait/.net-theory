using System;
using System.Collections.Generic;
public static class MyExtencion
{
    public static void ShowItems<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
public sealed class Programm
{
    public static void Main()
    {
        // Показывает каждый символ в каждой строке консоли
        "Grant".ShowItems();
        // Показывает каждую строку в каждой строке консоли
        new[] { "asd", "asd2" }.ShowItems();
        // Показывает каждый Int32 в каждой строчке консоли.
        new List<Int32>() { 1, 2, 3 }.ShowItems(); 
        Console.ReadKey();
    }

}


