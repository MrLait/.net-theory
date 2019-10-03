using System;

internal struct Point
{
    public Int32 m_x, m_y;
    public Point()
    {
        m_x = m_y = 5;
    }
}
internal sealed class Rectangle
{
    public Point m_topLeft, m_bottonRight;
    public Rectangle()
    {
    }
}