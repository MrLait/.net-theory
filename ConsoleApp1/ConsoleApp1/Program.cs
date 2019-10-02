using System;
internal class Employee
{
    //Невиртуальный экземплярный метод
    public Int32 GetYearsEmployee(){ return 0; }
    //Виртуальный метод (виртуальный -значит, экземплярный)
    public virtual String GetProgressReport() { return null; }
    //Статический метод
    public static Employee Lookup(string name) { return null; }
}

public sealed class Program
{
    public static void Main()
    {
        Console.WriteLine(); //вызов сатического метода
        Object o = new Object();
        o.GetHashCode(); //Вызов виртуального экземплярного метода
        o.GetType(); // Вызов невиртуального экземплярного метода

        Program p = null;
        p.GetFive(); // В C# выдается NullReferenceException
    }
    //Невиртуального экземплярный метод
    public Int32 GetFive() { return 5; }
}

internal class SomeClass
{
    //ToString виртуальный метод базового класса Object
    public override String ToString()
    {
        // Компилятор использует команду call для невиртуального вызова
        // метода ToString класса Object

        // Если бы компилятор вместо call использовал callvirt, этот
        // метод продолжал бы рекурсивно вызывать сам себя до переполнения стека
        return base.ToString();
    }
}

public class Set
{
    private Int32 m_length = 0;
    // Этот перегруженный метод — невиртуальный
    public Int32 Find(Object value)
    {
        return Find(value, 0, m_length);
    }
    // Этот перегруженный метод — невиртуальный
    public Int32 Find(Object value, Int32 startIndex)
    {
        return Find(value, startIndex, m_length);
    }
    // Наиболее функциональный метод сделан виртуальным
    // и может быть переопределен
    public virtual Int32 Find(Object value, Int32 startIndex, Int32 endIndex)
    {
        // Здесь находится настоящая реализация, которую можно переопределить...
        return 0;
    }
    // Другие методы
}

