using System;
using System.Collections.Generic;
public sealed class Program
{
    public static void Main()
    {
        Employee e = new Employee() { Name = "Jeff", Age = 45 };
        //конструктор без параметров
        Employee e1 = new Employee();
        e1.Name = "Jeff";
        e1.Age = 45;

        String s = new Employee { Name = "Jeff", Age = 45 }.ToString().ToUpper();

        // код создает объект Classroom и инициализирует коллекцию Students
        Classroom classroom = new Classroom { Students = { "Jeff", "Kristin", "Aidan", "Grant" } };
        // Вывести имена 4 студентов, находящихся в классе
        foreach (var students in classroom.Students)
        {
            Console.WriteLine("Student name " + students);
        }
        Console.WriteLine();
        //это тоже самое т.к компилятор предпологает, что List<String> 
        //реализует интерфейс IEnumerable<String>.
        Classroom classroom1 = new Classroom();
        classroom1.Students.Add("Jeff1");
        classroom1.Students.Add("Kristin1");
        classroom1.Students.Add("Aidan1");
        classroom1.Students.Add("Grant1");

        foreach (var students in classroom1.Students)
        {
            Console.WriteLine("Student name " + students);
        }

        Dictionary<String, Int32> table = new Dictionary<String, Int32>
        {
            { "Jeffrey", 1 }, { "Kristin", 2 }, { "Aidan", 3 }, { "Grant", 4 }
        };
        foreach (var item in table)
        {
            Console.WriteLine("Name: " + item.Key + " Age: " + item.Value);
        }
        //Это равносильно следующему коду:
        Dictionary<String, Int32> table1 = new Dictionary<string, int>();
        table1.Add("Jeffrey", 1);
        table1.Add("Kristin", 2);
        table1.Add("Aidan", 3);
        table1.Add("Grant", 4);
        foreach (var item in table1)
        {
            Console.WriteLine("Name: " + item.Key + " Age: " + item.Value);
        }
    }


    public sealed class Classroom
    {
        private List<String> m_students = new List<string>();
        public List<String> Students { get { return m_students; } }
        public Classroom() { }
    }

    private class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

