using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value) { 
            value = _value; 
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public LinkedList2(params Node[] nodes)
        {
            head = null;
            tail = null;
            foreach (var node in nodes)
            {
                AddInTail(node);
            }
        }
        
        public void AddInTail(Node _item)
        {
            if (head == null) {
                head = _item;
                head.next = null;
                head.prev = null;
            } else {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null)
                return false;

            if (head.value == _value)
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
                return true;
            }

            if (tail.value == _value)
            {
                tail = tail.prev;
                tail.next = null;
                return true;
            }
            
            
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;    
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            if (head == null)
                return;

            while (head != null && head.value == _value)
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
            }

            
            while (tail != null && tail.value == _value)
            {
                if (head == tail)
                {
                    Clear();
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
            }
         
            
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    node.next.prev = node?.prev;
                    node.prev.next = node?.next;
                }
                node = node.next;
            }     
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeToInsert == null)
            {
                return;
            }

            if (head == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
                return;
            }

            if (_nodeAfter == null && head != null)
            {
                _nodeToInsert.next = head;
                _nodeToInsert.prev = null;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
                return;
            }
            
            if (head == tail)
            {
                head.next = _nodeToInsert;
                _nodeToInsert.prev = head;
                tail = _nodeToInsert;
                return;
            }

            if (_nodeAfter == tail)
            {
                tail.next = _nodeToInsert;
                _nodeToInsert.prev = tail;
                _nodeToInsert.next = null;
                tail = tail.next;
                return;
            }

            Node node = head;
            while (node != null)
            {
                if (_nodeAfter == node)
                {
                    _nodeToInsert.prev = node;
                    _nodeToInsert.next = node.next;
                    _nodeToInsert.next.prev = _nodeToInsert;
                    node.next = _nodeToInsert;
                    return;
                }
                node = node.next;
            }
        }
    }
}