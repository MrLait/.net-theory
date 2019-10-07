using System;
public sealed class Programm
{
    public sealed class DisplayTypes : Object
    {

        public static void Display(object? arg0, object? arg1, object? arg2, object? arg3)
        {
            Object[] args = { arg0, arg1, arg2, arg3 };

            if (args != null)
            {
                foreach (var o in args)
                {
                    Console.WriteLine(o.GetType());
                }
            }
        }
        public static void Display(object? arg0, object? arg1, object? arg2)
        {
            Object[] args = { arg0, arg1, arg2 };
            if (args != null)
            {
                foreach (var o in args)
                {
                    Console.WriteLine(o.GetType());
                }
            }
        }
        public static void Display(object? arg0, object? arg1)
        {
            Object[] args = { arg0, arg1};
            if (args != null)
            {
                foreach (var o in args)
                {
                    Console.WriteLine(o.GetType());
                }
            }
        }
        public static void Display(object? arg0)
        {
            Console.WriteLine(arg0.GetType());
        }
        public static void Display(params object?[] args)
        {
            if (args != null)
            {
                foreach (var o in args)
                {
                    Console.WriteLine(o.GetType());
                }
            }
        }
    }
    public static void Main()
    {
        Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4, 5 }));
        //Благодаря ключевому слову params такой вызов доступен
        Console.WriteLine(Add(1, 2, 3, 4, 5));
        // Обе строчки выводят "0" 
        // передает новый элемент Int32[0] методу Add 
        Console.WriteLine(Add());
        // передает методу Add значение null, 
        // что более эффективно (не выделяется } 
        // память под массив)
        Console.WriteLine(Add(null));
        DisplayTypes.Display(new Object(), new Random(), "Jeff", 5);
    }

    //private static void DisplayTypes(object v1, Random random, string v2, int v3)
    //{
    //    throw new NotImplementedException();
    //}

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

