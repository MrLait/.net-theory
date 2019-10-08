using System;
public sealed class Employee
{
    public String Name;
    public Int32 Age;
}
public sealed class Programm
{
    public static void Main()
    {
        Employee employee = new Employee()
        {
            Name = "Ame",
            Age = 21
        };
        Console.WriteLine(employee.Name + " " + employee.Age);
    }
}

