using System;

internal struct SomeValType
{
    public Int32 m_x, m_y;
    // C# допускает наличие у значимых типов конструкторов с параметрами
    public SomeValType(Int32 x)
    {
        m_x = x;
    }
}
