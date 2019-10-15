using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        // Переменная s ссылается на объект String
        String s = "Jeffrey";
        // Используя переменную s, можно вызывать любой метод,
        // определенный в String, Object, IComparable, ICloneable,
        // IConvertible, IEnumerable, IComparable<String>,
        //IEnumerable<Char> и IEquatable<String>

        // Переменная cloneable ссылается на тот же объект String
        ICloneable cloneable = s;
        // Используя переменную cloneable, я могу вызвать любой метод,
        // объявленный только в интерфейсе ICloneable (или любой метод,
        // определенный в типе Object)

        // Переменная comparable ссылается на тот же объект String
        IComparable comparable = s;
        // Используя переменную comparable, я могу вызвать любой метод,
        // объявленный только в интерфейсе IComparable (или любой метод,
        // определенный в типе Object)

        // Переменная enumerable ссылается на тот же объект String
        // Во время выполнения можно приводить интерфейсную переменную
        // к интерфейсу другого типа, если тип объекта реализует оба интерфейса
        IEnumerable enumerable = (IEnumerable)comparable;
        // Используя переменную enumerable, я могу вызывать любой метод,
        // объявленный только в интерфейсе IEnumerable (или любой метод,
        // определенный только в типе Object)

    }
}

