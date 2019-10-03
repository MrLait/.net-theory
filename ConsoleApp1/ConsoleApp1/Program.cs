using System;
// Сгенерированный код в некотором файле с исходным кодом: 
internal class Base
{
    private String m_name;
    // Вызывается перед изменением поля m_name 
    protected virtual void OnNameChanging(String value) 
    { }
    public String Name
    {
        get { return m_name; }
        set
        {
            // Информирует класс о возможных изменениях 
            OnNameChanging(value.ToUpper());
            m_name = value; // Изменение поля 
        }
    }
}
// Написанный программистом код из другого файла 
internal class Derived : Base
{
    protected override void OnNameChanging(string value)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentNullException("value");
    }
}

