using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

public sealed class Program
{
    public static void Main()
    {
        // Определение типа, создание сущности и инициализация свойств
        var o1 = new { Name = "Jeff", Year = 2019 };
        Console.WriteLine("Name {0}, Year {1}", o1.Name, o1.Year);

        String Name = "Jeff";
        DateTime dt = DateTime.Now;
        // Анонимный тип с двумя свойствами
        // 1. Строковому свойству Name назначено значение Grant
        // 2. Свойству Year типа Int32 Year назначен год из dt
        var o2 = new { Name, dt.Year };
        // Совпадение типов позволяет осуществлять операции сравнения и присваивания
        Console.WriteLine("Objects are equal: " + o1.Equals(o2));
        o1 = o2;
        Console.WriteLine(o1.Equals(o2));
        //Раз эти типы идентичны, то можно создать массив явных 
        //типов из анонимных типов
        // Это работает, так как все объекты имею один анонимный тип
        var people = new[]
        {
            o1,
            o2,
            new { Name = "xa", Year = 1992 },
            new { Name = "name2", Year = 1993 }
        };
        // Организация перебора массива анонимных типов
        // (ключевое слово var обязательно).
        foreach (var person in people)
        {
            Console.WriteLine("Person = {0}; Year = {1}", person.Name, person.Year);
        }

        String myDocuments =
 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var query =
         from pathname in Directory.GetFiles(myDocuments)
         let LastWriteTime = File.GetLastWriteTime(pathname)
         where LastWriteTime > (DateTime.Now - TimeSpan.FromDays(7))
         orderby LastWriteTime
         select new { Path = pathname, LastWriteTime };
        foreach (var file in query)
            Console.WriteLine("LastWriteTime={0}, Path={1}",
            file.LastWriteTime, file.Path);
    }

}

