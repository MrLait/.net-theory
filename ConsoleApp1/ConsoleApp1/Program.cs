using System;
// Сгенерированный код в некотором файле с исходным кодом: 
internal sealed partial class Base
{
    private String m_name;
    // Это объявление с определением частичного метода вызывается
    // перед изменением поля m_name
    partial void OnNameChanging(String value);

    public String Name
    {
        get { return m_name; }
        set
        {
            //Информирование класса о потенциальном изменении
            OnNameChanging(value.ToUpper());
            m_name = value; // Изменение поля
        }
    }
}
// Написанный программистом код из другого файла 
internal sealed partial class Base
{
    // Это объявление с реализацией частичного метода вызывается перед тем,
    // как будет изменено поле m_name
    partial void OnNameChanging(String value)
    {
        if (String.IsNullOrEmpty(value))
        throw new ArgumentNullException("value");
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
