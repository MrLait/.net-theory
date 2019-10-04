using System;
using System.Collections.Generic;

public static class Programm
{
    public static void Main()
    {
        ImplicitlyTypedLocalVariables();
    }
    private static void ImplicitlyTypedLocalVariables()
    {
        var name = "Jeff";
        ShowVariableType(name); // Вывод: System.String
        //Не удается присвоить<NULL> неявно типизированной переменной.
        //var test = null; 
        var x = (String)null; // Допустимо, хотя и бесполезно
        ShowVariableType(x); // Вывод: System.String
        var number = new Int32[] { 1, 2, 3 };
        ShowVariableType(number); // Вывод: System.Int32[]
        // Меньше символов при вводе сложных типов
        var collection = new Dictionary<String, Single>() { { "Grand", 4.0F } };
        // Вывод: System.Collections.Generic.Dictionary`2[System.String,System.Single]
        ShowVariableType(collection);
        foreach (var item in collection)
        {
            // Вывод: System.Collections.Generic.KeyValuePair`2
            //[System.String, System.Single]
            ShowVariableType(item);
        }
    }
    private static void ShowVariableType<T>(T t)
    {
        Console.WriteLine(typeof(T));
    }
}

