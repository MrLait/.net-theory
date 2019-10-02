using System;

public sealed class Programm
{
    public sealed class AType
    {
        // InvalidChars всегда ссылается на один объект массива
        public static readonly Char[] InvalidChars = new Char[] { 'A', 'B', 'C' };
    }
    public sealed class AnotherType
    {
        public void M()
        {
            // Следующие строки кода вполне корректны, компилируются
            // и успешно изменяют символы в массиве InvalidChars
            AType.InvalidChars[0] = 'D';
            AType.InvalidChars[1] = 'E';
            AType.InvalidChars[2] = 'F';
            // Следующая строка некорректна и не скомпилируется,
            // так как ссылка InvalidChars изменяться не может
            AType.InvalidChars = new Char[] { 'X', 'Y', 'Z' };
        }
        
    public override string ToString()
        {
            return String.Format("{0},{1},{2}", AType.InvalidChars[0], AType.InvalidChars[1], AType.InvalidChars[2]);
        }
    }
    public static void Main()
    {
        AnotherType a = new AnotherType();
        Console.WriteLine(a);
        a.M();
        Console.WriteLine(a);
        Console.ReadKey();
    }
}