using System;

public class SomeType { }

//Это определение идентично определению:

public class SomeTyp2
{
    public SomeTyp2() : base() { }
}

internal sealed class SomeType3
{
    private Int32 m_x = 5;
}

internal sealed class SomeType4
{
    private Int32 m_x = 5;
    private String m_s = "Hi";
    private Double m_d = 3.14;
    private Byte m_b;
    //Это конструкторы
    public SomeType4() { }
    public SomeType4(Int32 x) { }
    public SomeType4(String s)
    {
        m_d = 10;
    }
}

internal sealed class SomeType5
{
    // Здесь нет кода, явно инициализирующего поля
    private Int32 m_x;
    private String m_s;
    private Double m_d;
    private Byte m_b;
    // Код этого конструктора инициализирует поля значениями по умолчанию
    // Этот конструктор должен вызываться всеми остальными конструкторами
    public SomeType5()
    {
        m_x = 5;
        m_s ="Hi";
        m_d = 3.14;
        m_b = 0xff;
    }
    // Этот конструктор инициализирует поля значениями по умолчанию,
    // а затем изменяет значение m_x
    public SomeType5(Int32 x) : this()
    {
        m_x = x;
    }
    // Этот конструктор инициализирует поля значениями по умолчанию,
    // а затем изменяет значение m_s
    public SomeType5(String s) : this()
    {
        m_s = s;
    }
    // Этот конструктор инициализирует поля значениями по умолчанию,
    // а затем изменяет значения m_x и m_s
    public SomeType5(Int32 x, String s) : this()
    {
        m_x = x;
        m_s = s;
    }
}