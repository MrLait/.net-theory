using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ch_12_Generics
{
    internal sealed class Triangle : IEnumerator<Point>
    {
        private Point[] m_vertices;

        // Тип свойства Current в IEnumerator<Point> - это Point
        public Point Current { get; }

        object IEnumerator.Current => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public bool MoveNext() => throw new NotImplementedException();
        public void Reset() => throw new NotImplementedException();
    }

    internal sealed class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] m_array;
        // Тип свойства Current в IEnumerator<T> — T
        public T Current { get; }

        object IEnumerator.Current => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public bool MoveNext() => throw new NotImplementedException();
        public void Reset() => throw new NotImplementedException();
    }
}
