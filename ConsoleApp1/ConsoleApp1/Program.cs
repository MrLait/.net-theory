using System;
using System.IO;

internal static class FileAttributesExtensionMethods
{
    public static Boolean IsSet(this FileAttributes flags, FileAttributes flagToTest)
    {
        if (flagToTest == 0)
            throw new ArgumentOutOfRangeException("flagToTest", "Value must not be 0");
        return (flags & flagToTest) == flagToTest;
    }
    public static Boolean IsClear(this FileAttributes flags, FileAttributes flagToTest)
    {
        if (flagToTest == 0)
            throw new ArgumentOutOfRangeException("flagToTest", "Value must not be 0");
        return !IsSet(flags, flagToTest);
    }
    public static Boolean AnyFlagsSet(this FileAttributes flags, FileAttributes testFlags)
    {
        return ((flags & testFlags) != 0);
    }
    public static FileAttributes Set(this FileAttributes flags, FileAttributes setFlags)
    {
        return flags | setFlags;
    }
    public static FileAttributes Clear(this FileAttributes flags, FileAttributes clearFlags)
    {
        return flags & ~clearFlags;
    }
    public static void ForEach(this FileAttributes flags, Action<FileAttributes> processFlag)
    {
        if (processFlag == null) 
            throw new ArgumentNullException("processFlag");
        for (UInt32 bit = 1; bit != 0; bit <<= 1)
        {
            UInt32 temp = ((UInt32)flags) & bit;
            if (temp != 0) processFlag((FileAttributes)temp);
        }
    }
}
public static class Program
{
    
    public static void Main()
    {
        FileAttributes fa = FileAttributes.System;
        fa = fa.Set(FileAttributes.ReadOnly);
        fa = fa.Clear(FileAttributes.System);
        fa.ForEach(f => Console.WriteLine(f));
    }

}