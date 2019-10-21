using System;
using System.Drawing;
using System.IO;

public static class Program
{

    public static void Main()
    {
        // Требуется двухмерный массив [2005..2009][1..4]
        Int32[] lowerBounds ={ 2005, 1 };
        Int32[] lengths = { 5, 4 };
        Decimal[,] quarterlyRevenue = (Decimal[,])Array.CreateInstance(typeof(Decimal), lengths, lowerBounds);
        Console.WriteLine("{0,4} {1,5} {2,7} {3,7} {4,7}", "Year", "Q1", "Q2", "Q3", "Q4");
        Int32 firstYear = quarterlyRevenue.GetLowerBound(0);
        Int32 lastYear = quarterlyRevenue.GetUpperBound(0);
        Int32 firstQuarter = quarterlyRevenue.GetLowerBound(1);
        Int32 lastQuarter = quarterlyRevenue.GetUpperBound(1);
        for (int year = firstYear; year <= lastYear; year++)
        {
            Console.Write(year + " ");
            for (int quarter = firstQuarter; quarter <= lastQuarter; quarter++)
            {
                Console.Write("{0,7:C} ", quarterlyRevenue[year, quarter]);
            }
            Console.WriteLine();
        }

    }
}