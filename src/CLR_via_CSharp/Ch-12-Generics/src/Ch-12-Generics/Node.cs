using System;

namespace Ch_12_Generics
{
    internal sealed class Node<T>
    {
        public T m_data;
        public Node<T> m_next;

        public Node(T data) : this(data, null) { }

        public Node(T data, Node<T> next)
        {
            m_data = data;
            m_next = next;
        }

        public override String ToString()
        {
            return m_data.ToString() + ((m_next != null) ? m_next.ToString() : null);
        }
    }

    internal class Node
    {
        protected Node m_next;

        public Node(Node next)
        {
            m_next = next;
        }
    }
    internal sealed class TypedNode<T> : Node
    {
        public T m_data;
        public TypedNode(T data) : this(data, null) { }

        public TypedNode(T data, Node next) : base(next)
        {
            m_data = data;
        }
        public override String ToString()
        {
            return m_data.ToString() + ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }

}
