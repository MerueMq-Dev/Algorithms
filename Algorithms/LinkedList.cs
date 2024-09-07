using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
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
                }
                return true;
            }

            Node node = head;
            Node previousNode = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    previousNode.next = node.next;

                    if (node == tail)
                    {
                        tail = previousNode;
                    }
                    return true;
                }
                previousNode = node;
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

            Node node = head;
            Node previousNode = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    previousNode.next = node.next;

                    if (node == tail)
                    {
                        tail = previousNode;
                    }
                }
                else
                {
                    previousNode = node;
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
            Node node = head;
            while (node != null)
            {
                nodesCount++;
                node = node.next;
            }
            return nodesCount;
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

            Node node = head;
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