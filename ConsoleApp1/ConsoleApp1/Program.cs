﻿using System;
using System.Collections;

struct Point
{
    public Int32 x, y;
}
public sealed class Program
{
    public static void Main()
    {
        ArrayList a = new ArrayList();
        Point p; //Выделяем память для поинт(не в куче)
        for (Int32 i = 0; i < 10; i++)
        {
            p.x = p.y = i; //Инициализация членов в нашей значимом типе
            a.Add(p); //Упаковка значимого типа и добавление ссылки в ArrayList
        }
        Point p1 = (Point)a[0];

        Int32 x = 5;
        Object o = x; // Упаковка x; o указывает на упакованный объект
        Int16 y = (Int16)(Int32)o; // Распаковка к Int32, а затем приведение типа к Int16

        Point p2;
        p2.x = p2.y = 1;
        Object o2 = p2; // Упаковка p2; o2 указывает на упакованный объект
        p2 = (Point)o2; // Распаковка o2 и копирование полей из экземпляра в стек

        Point p3;
        p3.x = p3.y = 1;
        Object o3 = p3; // Упаковка p3; o3 указывает на упакованный экземпляр
                        // Изменение поля x структуры Point (присвоение числа 1).
        p3 = (Point)o3; // Распаковка o и копирование полей из экземпляра
                        // в переменную в стеке
        p3.x = 2; // Изменение состояния переменной в стеке
        o3 = p3; // Упаковка p; o ссылается на новый упакованный экземпляр

        Int32 v = 5; // Создание неупакованной переменной значимого типа o
        Object o4 = v; // указывает на упакованное Int32, содержащее 5
        v = 123; // Изменяем неупакованное значение на 123
        Console.WriteLine(v + ", " + (Int32)o); // Отображается "123, 5"
        Console.WriteLine(v + ", " + o);
        //Предыдущий код можно улучшить, изменив вызов метода WriteLine:
        Console.WriteLine(v.ToString() + ", " + o); // Отображается "123, 5"

        Int32 v5 = 5; // Создаем неупакованную переменную значимого типа
        Object o5 = v5; // o указывает на упакованную версию v
        v5 = 123; // Изменяет неупакованный значимый тип на 123
        Console.WriteLine(v5); // Отображает "123"
        v5 = (Int32)o5; // Распаковывает и копирует o в v
        Console.WriteLine(v5); // Отображает "5"

        Int32 v6 = 10; // Создаем переменную упакованного значимого типа
                       // При компиляции следующей строки v6 упакуется
                       // три раза, расходуя и время, и память
        Console.WriteLine("{0}, {1}, {2}", v6, v6, v6);
        // Следующие строки дают тот же результат,
        // но выполняются намного быстрее и расходуют меньше памяти
        v6 = 6;
        Object o6 = v6; // Упакуем вручную v (только единожды)
                        // При компиляции следующей строки код упаковки не создается
        Console.WriteLine("{0}, {1}, {2}", o6, o6, o6);


        Console.ReadKey();
    }
}