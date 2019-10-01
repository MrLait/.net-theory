using System;
public static class AStaticClass
{
    public static void AStaticMethodQ() { }
    public static String AStaticProperty
    {
        get { return s_AStaticField; }
        set { s_AStaticField = value; }
    }
    private static String s_AStaticField;
    public static event EventHandler AStaticEvent;
}