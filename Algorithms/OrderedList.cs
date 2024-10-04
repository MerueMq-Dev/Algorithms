using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        
        public OrderedList(bool asc = true, params T[] values)
        {
            head = null;
            tail = null;
            _ascending = asc;
            foreach (var node in values)
            {
                Add(node);
            }
        }

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;

            if (typeof(T) == typeof(String))
            {
                var value1 = v1.ToString().Trim();
                var value2 = v2.ToString().Trim();
                var resultStringCompare = String.Compare(value1, value2, StringComparison.Ordinal);
                result = resultStringCompare < 0 ? -1 : resultStringCompare > 0 ? 1 : resultStringCompare;
            }
            else
            {
                var value1 = Convert.ToInt32(v1);
                var value2 = Convert.ToInt32(v2);
                result = value1 > value2 ? 1 : value1 < value2 ? -1 : 0;
            }

            return result;
        }

        public void Add(T value)
        {
            var item = new Node<T>(value);

            if (head == null)
            {
                head = item;
                head.next = null;
                head.prev = null;
                tail = item;
                return;
            }

            if (_ascending)
            {
                AddAsc(item);
            }
            else
            {
                AddDesc(item);
            }
        }

        public Node<T> Find(T val)
        {
            if (val == null)
                return null;
            
            if (_ascending && Compare(tail.value, val) == -1 || !_ascending && Compare(tail.value, val) == 1)
                return null;

            if (_ascending && Compare(head.value, val) == 1 || !_ascending && Compare(head.value, val) == -1)
                return null;

            if (Compare(tail.value, val) == 0)
                return tail;

            if (Compare(head.value, val) == 0)
                return head;

            for (var node = head; node != null; node = node.next)
            {
                if (Compare(val, node.value) == 0)
                    return node;
            }

            return null;
        }

        public void Delete(T val)
        {
            if (head == null)
                return;

            if (Compare(head.value, val) == 0)
            {
                if (head == tail)
                {
                    Clear();
                }
                else
                {
                    head = head.next;
                    head.prev = null;
                }

                return;
            }

            if (Compare(tail.value, val) == 0)
            {
                tail = tail.prev;
                tail.next = null;
                return;
            }


            var node = head;
            while (node != null)
            {
                if (Compare(node.value, val) == 0)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return;
                }

                node = node.next;
            }
        }

        public void Clear(bool asc = true)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            var node = head;

            if (node != null)
            {
                count++;
                node = node.next;
            }

            while (node != head && node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }

            return r;
        }

        private void AddAsc(Node<T> item)
        {
            var resultOfHeadCompare = Compare(item.value, head.value);
            if (head == tail)
            {
                if (resultOfHeadCompare <= 0)
                {
                    item.next = head;
                    head.prev = item;
                    item.prev = null;
                    head = item;
                    return;
                }

                tail.next = item;
                item.next = null;
                item.prev = tail;
                tail = item;
                return;
            }

            if (resultOfHeadCompare == -1)
            {
                head.prev = item;
                item.next = head;
                head = item;
                return;
            }

            var currentNode = head;
            while (currentNode != null)
            {
                var resultOfCurrentNodeCompare = Compare(item.value, currentNode.value);
                if (resultOfCurrentNodeCompare >= 0 && currentNode.next == null)
                {
                    item.prev = currentNode;
                    item.next = null;
                    currentNode.next = item;
                    tail = item;
                    return;
                }

                var resultOfNextNodeCompare = Compare(item.value, currentNode.next.value);
                if (resultOfCurrentNodeCompare <= 0 && resultOfNextNodeCompare >= 0 && currentNode.next != null)
                {
                    var next = currentNode.next;
                    next.prev = item;
                    currentNode.next = item;
                    item.prev = currentNode;
                    item.next = next;
                    return;
                }

                if (resultOfCurrentNodeCompare >= 0 && resultOfNextNodeCompare <= 0 && currentNode.next != null)
                {
                    var next = currentNode.next;
                    next.prev = item;
                    currentNode.next = item;
                    item.prev = currentNode;
                    item.next = next;
                    return;
                }

                currentNode = currentNode.next;
            }
        }

        private void AddDesc(Node<T> item)
        {
            var resultOfHeadCompare = Compare(item.value, head.value);
            var resultOfTailCompare = Compare(item.value, tail.value);

            if (head == tail)
            {
                if (resultOfHeadCompare >= 0)
                {
                    item.next = head;
                    head.prev = item;
                    item.prev = null;
                    head = item;
                    return;
                }

                tail.next = item;
                item.next = null;
                item.prev = tail;
                tail = item;
                return;
            }

            if (resultOfTailCompare <= 0)
            {
                item.prev = tail;
                tail.next = item;
                item.next = null;
                tail = item;
                return;
            }

            if (resultOfHeadCompare == 1)
            {
                head.prev = item;
                item.next = head;
                head = item;
                return;
            }

            var currentNode = head;
            while (currentNode != null)
            {
                var resultOfCurrentNodeCompare = Compare(item.value, currentNode.value);
                if (resultOfCurrentNodeCompare >= 0 && currentNode.next == null)
                {
                    item.prev = currentNode;
                    item.next = null;
                    currentNode.next = item;
                    tail = item;
                    return;
                }

                var resultOfNextNodeCompare = Compare(item.value, currentNode.next.value);
                if (resultOfCurrentNodeCompare >= 0 && resultOfNextNodeCompare <= 0 && currentNode.next != null)
                {
                    var next = currentNode.next;
                    next.prev = item;
                    currentNode.next = item;
                    item.prev = currentNode;
                    item.next = next;
                    return;
                }

                if (resultOfCurrentNodeCompare <= 0 && resultOfNextNodeCompare >= 0 && currentNode.next != null)
                {
                    var next = currentNode.next;
                    next.prev = item;
                    currentNode.next = item;
                    item.prev = currentNode;
                    item.next = next;
                    return;
                }

                currentNode = currentNode.next;
            }
        }
    }
}