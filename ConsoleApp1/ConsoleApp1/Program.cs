using System;
using System.Collections.Generic;
using System.IO;

public sealed class Programm
{
    public static void Main()
    {
    }
    // Рекомендуется в этом методе использовать параметр слабого типа
    public void ManipulateItems<T>(IEnumerable<T> collection) { }
    // Не рекомендуется в этом методе использовать параметр сильного типа
    public void ManipulateItems<T>(List<T> collection) { }
    // Рекомендуется в этом методе использовать параметр мягкого типа
    public void ProcessBytes(Stream someStream){}
    // Не рекомендуется в этом методе использовать параметр сильного типа
    public void ProcessBytes(FileStream someStream) {}

    // Рекомендуется в этом методе использовать
    // сильный тип возвращаемого объекта
    public FileStream openFile() { return new FileStream("path", FileMode.Open); }
    // Не рекомендуется в этом методе использовать
    // слабый тип возвращаемого объекта
    public Stream OpenFile() { return Stream.Null; }
    // Гибкий вариант: в этом методе используется
    // мягкий тип возвращаемого объекта
    public IList<Stream> GetStringCollection() { return null; }
    // Негибкий вариант: в этом методе используется
    // сильный тип возвращаемого объекта
    public List<Stream> GetStringCollection() { return null; }
}

