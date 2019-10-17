using System;
using System.Text;
using System.Threading;

public static class Program
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat(new BoldInt32s(), "{0} {1} {2:M}", "Jeff", 123,
 DateTime.Now);
        Console.WriteLine(sb);
    }
}
internal sealed class BoldInt32s : IFormatProvider, ICustomFormatter
{
    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter)) return this;
        return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
    }
    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
        string s;
        IFormattable formattable = arg as IFormattable;
        if (formattable == null) return arg.ToString();
        else s = formattable.ToString(format, formatProvider);
        if (arg.GetType() == typeof(Int32))
            return "<B>" + s + "</B>";
        return s;
    }
}