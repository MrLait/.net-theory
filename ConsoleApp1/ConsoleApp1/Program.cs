using System;
using System.Collections;
using System.Collections.Generic;

public interface IDisposable
{
    void Dispose();
}

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

public interface IEnumerable<T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}

public interface ICollection<T> : IEnumerable<T>, IEnumerable
{
    void CopyTo(T[] array, Int32 arrayIndex);
    Boolean Remove(T item);
    Int32 Count { get; } // Свойство только для чтения
    Boolean IsReadOnly { get; } // Свойство только для чтения

}