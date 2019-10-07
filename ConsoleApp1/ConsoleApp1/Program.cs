using System;
public sealed class Programm
{
    public static void Main()
    {
        Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4, 5 }));
        //Благодаря ключевому слову params такой вызов доступен
        Console.WriteLine(Add(1,2,3,4,5));
        // Обе строчки выводят "0" 
        // передает новый элемент Int32[0] методу Add 
        Console.WriteLine(Add());
        // передает методу Add значение null, 
        // что более эффективно (не выделяется } 
        // память под массив)
        Console.WriteLine(Add(null));
        DisplayTypes(new Object(), new Random(), "Jeff", 5);
        }

    private static void DisplayTypes(params Object[] objects)
    {
        if (objects != null)
        {
            foreach (var o in objects)
            {
                Console.WriteLine(o.GetType());
            }
        }
    }
    static Int32 Add(params Int32[] values)
    {
        // ПРИМЕЧАНИЕ: при необходимости этот массив
        // можно передать другим методам
        Int32 sum = 0;
        if (values != null)
        {
            for (Int32 i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
        }
        return sum;
    }
}

