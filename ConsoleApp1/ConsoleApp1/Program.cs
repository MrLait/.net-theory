using System;
using System.Drawing;

public static class Program
{
    public static void Main()
    {
        String[] names = new String[] {"Aidan", "Grant" };
        // Использование локальной переменной неявного типа:
        var names1 = new String[] { "Aidan", "Grant" };
        var names2 = new[] { "Aidan", "Grant", null };

        // Ошибочное задание типа массива с помощью локальной
        // переменной неявного типа
        //var names3 = new[] { "Aidan", "Grant", 123 };

        String[] names4 = { "Aidan", "Grant" };
        // Ошибочное использование локальной переменной
        //var names5 = { "Aidan", "Grant" };

        // Применение переменных и массивов неявно заданного типа,
        // а также анонимного типа:
        var kids = new[] { new { Name = "Aidan" }, new { Name = "Grant" } };
        // Пример применения (с другой локальной переменной неявно заданного типа):
        foreach (var kid in kids)
        {
            Console.WriteLine(kid.Name);
        }
    }
}