using System;
public sealed class Employee
{
    // Это свойство является автоматически реализуемым
    public String Name { get; set; }
    private Int32 age; // Поле стало закрытым

    // идентифицирует новое значение
    public Int32 Age
    {
        get { return age; }
        set
        {
            if (value < 0) // Ключевое слово value всегда
                           // идентифицирует новое значение
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
            Age = 1
        };
        Console.WriteLine(employee.Name + " " + employee.Age);
    }
}

