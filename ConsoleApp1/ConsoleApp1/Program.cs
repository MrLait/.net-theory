using System;

internal struct SomeValType
{
    public Int32 m_x, m_y;
    // C# позволяет значимым типам иметь конструкторы с параметрами
    public SomeValType(Int32 x)
    {
        // Выглядит необычно, но компилируется прекрасно,
        // и все поля инициализируются значениями 0 или null
        this = new SomeValType();
        m_x = x; // Присваивает m_x значение x
    // Обратите внимание, что поле m_y было инициализировано нулем
    }
}
