using System;
public sealed class Employee
{
    private String name; // Поле стало закрытым
    private Int32 age; // Поле стало закрытым

    public String Name
    {
        get { return name; }
        set { name = value; } // Ключевое слово value
    }                         // идентифицирует новое значение
    public Int32 Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", value.ToString(),
                    "The value must be greater than or equal to 0");
            }
            age = value;
        }
    }
}
public sealed class Programm
{
    public static void Main()
    {
        Employee employee = new Employee
        {
            Name = "Ame",
            Age = -1
        };
        Console.WriteLine(employee.Name + " " + employee.Age);
    }
}

