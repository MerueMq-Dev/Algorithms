using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  
    public class LinkedList
    {
        public Node2 head;
        public Node2 tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node2 _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node2 Find(int _value)
        {
            Node2 node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node2> FindAll(int _value)
        {
            List<Node2> nodes = new List<Node2>();
            Node2 node = head;
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
                }
                return true;
            }

            Node2 node = head;
            Node2 previousNode2 = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    previousNode2.next = node.next;

                    if (node == tail)
                    {
                        tail = previousNode2;
                    }
                    return true;
                }
                previousNode2 = node;
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
                }
            }

            Node2 node = head;
            Node2 previousNode2 = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    previousNode2.next = node.next;

                    if (node == tail)
                    {
                        tail = previousNode2;
                    }
                }
                else
                {
                    previousNode2 = node;
                }
                node = node.next;
            }       
        }

        public void Clear()
        {
            tail = null;
            head = null;
        }

        public int Count()
        {
            int nodesCount = 0;
            Node2 node = head;
            while (node != null)
            {
                nodesCount++;
                node = node.next;
            }
            return nodesCount;
        }

        public void InsertAfter(Node2 _nodeAfter, Node2 _nodeToInsert)
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
                head = _nodeToInsert;
                return;
            }

            if (head == tail)
            {
                head.next = _nodeToInsert;
                tail = _nodeToInsert;
                return;
            }

            if (_nodeAfter == tail)
            {
                tail.next = _nodeToInsert;
                tail = tail.next;
                return;
            }

            Node2 node = head;
            while (node != null)
            {
                if (_nodeAfter == node)
                {
                    var temp = node.next;
                    node.next = _nodeToInsert;
                    node.next.next = temp;
                    return;
                }
                node = node.next;
            }
        }
    }
}