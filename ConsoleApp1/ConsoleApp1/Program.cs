using System;
using System.Diagnostics;

public static class Program
{
    private const Int32 c_numElements = 10000;
    public static void Main()
    {
        Array a;
        // Создание одномерного массива с нулевым
        // начальным индексом и без элементов
        a = new String[0];
        Console.WriteLine(a.GetType());// "System.String[]"

        // Создание одномерного массива с нулевым
        // начальным индексом и без элементов
        a = Array.CreateInstance(typeof(String), new Int32[] { 0 }, new Int32[] { 0 });
        Console.WriteLine(a.GetType()); // "System.String[]"
        // Создание одномерного массива с начальным индексом 1 и без элементов
        a = Array.CreateInstance(typeof(String), new Int32[] { 0 }, new Int32[] { 1 });
        Console.WriteLine(a.GetType()); // "System.String[*]" <-- ВНИМАНИЕ!
        Console.WriteLine();

        // Создание двухмерного массива с нулевым
        // начальным индексом и без элементов
        a = new String[0,0];
        Console.WriteLine(a.GetType()); // "System.String[,]"
        // Создание двухмерного массива с нулевым
        // начальным индексом и без элементов
        a = Array.CreateInstance(typeof(String), new Int32[] { 0,0 }, new Int32[] { 0,0 });
        Console.WriteLine(a.GetType()); // "System.String[,]"
        // Создание двухмерного массива с начальным индексом 1 и без элементов
        a = Array.CreateInstance(typeof(String), new Int32[] { 0, 0 }, new Int32[] { 1, 1 });
        Console.WriteLine(a.GetType()); // "System.String[,]"

        Int32[] b = new Int32[5];
        for (Int32 index = 0; index < b.Length; index++)
        {
            // Какие-то действия с элементом b[index]
        }


        // Объявление двухмерного массива
        Int32[,] a2Dim = new Int32[c_numElements, c_numElements];
        // Объявление нерегулярного двухмерного массива (вектор векторов)
        Int32[][] aJagged = new Int32[c_numElements][];
        for (int i = 0; i < c_numElements; i++)
        {
            aJagged[i] = new Int32[c_numElements];
        }
        // 1: Обращение к элементам стандартным, безопасным способом
        Safe2DimArrayAccess(a2Dim);
        // 2: Обращение к элементам с использованием нерегулярного массива
        SafeJaggedArrayAccess(aJagged);
        // 3: Обращение к элементам небезопасным методом
        Unsafe2DimArrayAccess(a2Dim);

    }
    private static Int32 Safe2DimArrayAccess(Int32[,] a)
    {
        Int32 sum = 0;
        for (int x = 0; x <c_numElements; x++)
        {
            for (int y = 0; y < c_numElements; y++)
            {
                sum += a[x, y];
            }
        }
        return sum;
    }
    private static Int32 SafeJaggedArrayAccess(Int32[][] aJagged)
    {
        int sum = 0;
        for (int x = 0; x < c_numElements; x++)
        {
            for (int y = 0; y < c_numElements; y++)
            {
                sum += aJagged[x][y];
            }
        }
        return sum;
    }
    private static unsafe Int32 Unsafe2DimArrayAccess(Int32[,] a)
    {
        Int32 sum = 0;
        fixed (Int32* pi = a)
        {
            for (Int32 x = 0; x < c_numElements; x++)
            {
                Int32 baseOfDim = x * c_numElements;
                for (Int32 y = 0; y < c_numElements; y++)
                {
                    sum += pi[baseOfDim + y];
                }
            }
        }
        return sum;
    }
}