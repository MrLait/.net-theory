using System;
public sealed class Employee
{
    private String name; // Поле стало закрытым
    private Int32 age; // Поле стало закрытым

    public String GetName() { return name; } 
    public void SetName(String value) { name = value; }
    public Int32 GetAge() { return age; }
    public void SetAge(Int32 value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("value", value.ToString(), 
                "The value must be greater than or equal to 0");
        }
            age = value;
    }
}
public sealed class Programm
{
    public static void Main()
    {
        Employee employee = new Employee();
        employee.SetName("Ame");
        employee.SetAge(-1);
       Console.WriteLine(employee.GetName() + " " + employee.GetAge());
    }
}

