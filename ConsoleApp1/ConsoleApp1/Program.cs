using System;
using System.Text;
using System.Globalization;

public static class Program
{
    public static void Main()
    {
        // Следующая строка содержит комбинированные символы
        String s = "a\u0304\u0308bc\u0327";
        SubstringByTextElements(s);
        EnumTextElements(s);
        EnumTextElementIndexes(s);
    }

    private static void EnumTextElementIndexes(string s)
    {
        String output = String.Empty;
        Int32[] textElementIndex = StringInfo.ParseCombiningCharacters(s);
        for (Int32 i = 0; i < textElementIndex.Length; i++)
        {
            output += String.Format(
            "Character {0} starts at index {1}{2}",
            i, textElementIndex[i], Environment.NewLine);
        }
        Console.WriteLine(output);
    }

    private static void EnumTextElements(string s)
    {
        String output = String.Empty;
        TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);
        while (charEnum.MoveNext())
        {
            output += String.Format(
                "Character at index {0} is '{1}'{2}",
                charEnum.ElementIndex, charEnum.GetTextElement(),
                Environment.NewLine);
        }
        Console.WriteLine(output);
    }

    private static void SubstringByTextElements(string s)
    {
        String output = String.Empty;

        StringInfo si = new StringInfo(s);
        for (Int32 element = 0; element < si.LengthInTextElements; element++)
        {
            output += String.Format("Text element {0} is '{1}'{2}", element, si.SubstringByTextElements(element, 1), Environment.NewLine);
        }
        Console.WriteLine(output);
    }
}

