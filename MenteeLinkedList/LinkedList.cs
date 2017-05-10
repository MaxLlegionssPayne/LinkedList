using System;
using System.Collections;
using System.Collections.Generic;

namespace MenteeLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private int _length = 0;
        private ListNode<T> _head;
        private ListNode<T> _tail;
        private class ListNode<T>
        {
            public T Value;
            public ListNode<T> Next { get; set; }
        }

        public int Length => _length;

        private ListNode<T> NodeAt(int index)
        {
            if (index == 0)
                return _head;
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException(string.Format("Incorrect index: {0}", index));

            var node = _head.Next;
            for (int i = 1; i < index; i++)
                node = node.Next;
            return node;
        }

        public T ElementAt(int position)
        {
            return NodeAt(position).Value;
        }

        public LinkedList<T> Add(T value)
        {
            var newNode = new ListNode<T>() { Value = value };
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }
            _length++;
            return this;
        }

        public LinkedList<T> Remove(T value)
        {
            if (_head == null)
                return this;

            if (_head.Value.Equals(value))
            {
                _head = _head.Next;
                _length--;
                return this.Remove(value);
            }

            var currNode = _head;
            while (currNode.Next != null)
            {
                if (currNode.Next.Value.Equals(value))
                { 
                    currNode.Next = currNode.Next.Next;
                    _length--;
                    continue;
                }

                currNode = currNode.Next;
            }
            
            return this;
        }

        public LinkedList<T> RemoveAt(int position)
        {
            if (_head == null)
                return this;

            if (position == 0)
            {
                _head = _head.Next;
                _length--;
                return this;
            }

            var prevNode = NodeAt(position - 1);
            prevNode.Next = prevNode.Next.Next;
            _length--;
            return this;
        }

        public LinkedList<T> AddAt(T value, int position)
        {
            if (position == 0)
            {
                _head = new ListNode<T>() { Value = value, Next = _head };
                _length++;
                return this;
            }

            var prevNode = NodeAt(position - 1);
            prevNode.Next = new ListNode<T>() { Value = value, Next = prevNode.Next };
            _length++;
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }
}
