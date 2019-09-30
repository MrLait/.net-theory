using System;
using System.IO;

public sealed class Program
{
    //Reference types посколько class
    class SomeRef
    {
        public Int32 x;
    }
    //Values types посколько struct
    struct SomeVal
    {
        public Int32 x;
    }

    static void ValueTypeDemo()
    {
        SomeRef r1 = new SomeRef(); //Размещается в куче
        SomeVal v1 = new SomeVal(); //Размещается в стеке
        r1.x = 5; //разыменование указателя
        v1.x = 5; //Изменени в стеке
        Console.WriteLine(r1.x); // Отображается "5"
        Console.WriteLine(v1.x); ; // Также отображается "5"

        SomeRef r2 = r1; //Копируем только ссылку (указатель)
        SomeVal v2 = v1; //Помещаем в стек и копируем члены
        r1.x = 8; //изменяются r1.x и r2.x
        v1.x = 9; //изменяется тольк v1.x, но не v2.x
        Console.WriteLine();
        Console.WriteLine(r1.x);
        Console.WriteLine(r2.x);
        Console.WriteLine(v1.x);
        Console.WriteLine(v2.x);
    }

    public static void Main()
    {
        ValueTypeDemo();
        Console.ReadKey();

    }



}