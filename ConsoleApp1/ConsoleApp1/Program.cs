using System;
using System.Drawing;
using System.IO;

public static class Program
{
    internal sealed class MyValueType : IComparable
    {
        public Int32 CompareTo(Object o)
        {
            return -1;
        }
    }

    public static void Main()
    {
        // Создание двухмерного массива FileStream
        FileStream[,] fs2dim = new FileStream[3,5];
        // Неявное приведение к массиву типа Object
        Object[,] o2dim = fs2dim;
        // Невозможно приведение двухмерного массива к одномерному
        // Ошибка компиляции CS0030: невозможно преобразовать тип 'object[*,*]'
        // в 'System.IO.Stream[]'
        
        //Stream[] s1dim = (Stream[])o2dim;

        // Явное приведение к двухмерному массиву Stream
        Stream[,] s2dim = (Stream[,])o2dim;

        // Явное приведение к двухмерному массиву String
        // Компилируется, но во время выполнения
        // возникает исключение InvalidCastException
        
        //String[,] st2dim = (String[,])o2dim;

        // Создание одномерного массива Int32 (значимый тип)
        Int32[] i1dim = new Int32[5];
        // Невозможно приведение массива значимого типа
        // Ошибка компиляции CS0030: невозможно преобразовать
        // тип 'int[]' в 'object[]'
        //Object[] o1dim = (Object[])i1dim;

        // Создание нового массива и приведение элементов к нужному типу
        // при помощи метода Array.Copy
        // Создаем массив ссылок на упакованные элементы типа Int32
        Object[] ob1dim = new Object[i1dim.Length];
        Array.Copy(i1dim, ob1dim, i1dim.Length);

        // Создание массива из 100 элементов значимого типа
        MyValueType[] src = new MyValueType[100];
        // Создание массива ссылок IComparable
        IComparable[] dest = new IComparable[src.Length];
        // Присваивание элементам массива IComparable ссылок на упакованные
        // версии элементов исходного массива
        Array.Copy(src,dest,src.Length);

        String[] sa = new String[100];
        Object[] oa = sa;
        oa[5] = "Jeff"; // CLR проверяет принадлежность oa к типу String;
                        // Проверка проходит успешно
        oa[3] = 5; // CLR проверяет принадлежность oa к типу Int32;
                   // Генерируется исключение ArrayTypeMismatchException
    }
}