using System;

internal struct Point
{
    public Int32 m_x, m_y;
    public Point(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }
}
internal sealed class Rectangle
{
    public Point m_topLeft, m_bottonRight;
    public Rectangle(Point topLeft, Point buttonRight)
    {
        m_topLeft = topLeft;
        m_bottonRight = buttonRight;
    }
}