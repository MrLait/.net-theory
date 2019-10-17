using System;
using System.Text;
using System.Globalization;
using System.Threading;

public static class Program
{
    public static void Main()
    {
        String s1 = "Hello";
        String s2 = "Hello";
       //true т.к стоит флаг по умолчанию интернировать
        Console.WriteLine(Object.ReferenceEquals(s1,s2));

        s1 = String.Intern(s1); //явное интернирование
        s2 = String.Intern(s2); //явное интернирование
        Console.WriteLine(Object.ReferenceEquals(s1,s2));
    }
    private static Int32 NumTimesWordAppearsIntern(String word, String[]
 wordlist)
    {
        // В этом методе предполагается, что все элементы в wordlist
        // ссылаются на интернированные строки
        word = String.Intern(word);
        Int32 count = 0;
        for (Int32 wordnum = 0; wordnum < wordlist.Length; wordnum++)
        {
            if (Object.ReferenceEquals(word, wordlist[wordnum]))
                count++;
        }
        return count;
    }
}

