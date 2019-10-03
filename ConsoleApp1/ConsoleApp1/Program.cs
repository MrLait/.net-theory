using System;
// Логический эквивалент сгенерированного инструментом кода в случае,
// когда нет объявления выполняемого частичного метода
internal sealed class Base
{
    private String m_name;
    public String Name
    {
        get { return m_name; }
        set
        {
            m_name = value; // Изменение поля
        }
    }
}

public sealed class Programm
{
    public static void Main()
    {
        Base d = new Base { Name = "s" };
        d.Name = "ss";
    }
}