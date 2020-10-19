using System.Collections;
using System.Collections.Generic;

namespace DataStructures.CircularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public bool IsEmpty { get { return count == 0; } }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (IsEmpty) 
                return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null) // Если узел в середине или в конце
                    {
                        //Убираем узел current, теперь previous ссылается не на current,
                        //а на current.Next
                        previous.Next = current.Next;

                        // Если узел последний,
                        // изменяем переменную tail
                        if (current == tail)
                            tail = previous;
                    }
                    else // если удаляется первый элемент
                    {
                        if (count == 1) // если в списке всего один элемент
                            head = tail = null;
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }

                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != head);

            return false;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;

            if (current == null) 
                return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

    }
}
