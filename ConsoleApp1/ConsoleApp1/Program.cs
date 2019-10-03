﻿using System;
using System.Text;

public static class StringBuilderExtensions
{
    public static Int32 IndexOf(StringBuilder sb,Char value)
    {
        for (int index = 0; index < sb.Length; index++)
        if (sb[index] == value) return index;
        return -1;

    }
}
public sealed class Programm
{
    public static void Main()
    {
        // Инициализирующая строка
        StringBuilder sb = new StringBuilder("Hi.");
        // Замена точки восклицательным знаком
        // и получение номера символа в первом предложении
        Int32 index = StringBuilderExtensions.IndexOf(sb.Replace('.', '!'), '!');

    }
}
