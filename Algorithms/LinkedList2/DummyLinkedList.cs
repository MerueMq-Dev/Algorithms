using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DummyNode : Node
    {
        public DummyNode()
        {
        }
        
        public DummyNode(int _value) : base(_value)
        {
        }
    }


    public class DummyLinkedList
    {
        public DummyNode Head { get; private set; }
        public DummyNode Tail { get; private set; }

        public DummyLinkedList(params Node[] nodes)
        {
            Head = new DummyNode();
            Tail = new DummyNode();

            Head.next = Tail;
            Tail.prev = Head;

            foreach (var node in nodes)
            {
                AddInTail(node);
            }
        }

        public void AddInTail(Node _item)
        {
            var last = Tail.prev;
            last.next = _item;
            _item.prev = last;
            Tail.prev = _item;
            _item.next = Tail;
        }

        public Node Find(int _value)
        {
            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode) && node.value == _value)
                {
                    return node;
                }

                node = node.next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            var nodes = new List<Node>();
            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode) && node.value == _value)
                    nodes.Add(node);

                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode) && node.value == _value)
                {
                    node.next.prev = node.prev;
                    node.prev.next = node.next;
                    return true;
                }

                node = node.next;
            }

            return false;
        }


        public void RemoveAll(int _value)
        {
            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode) && node.value == _value)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                }
                node = node.next;
            }
        }

        public void Clear()
        {
            Head = new DummyNode();
            Tail = new DummyNode();

            Head.next = Tail;
            Tail.prev = Head;
        }

        public int Count()
        {
            int count = 0;
            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode))
                {
                    count++;
                }

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

            Node node = Head;
            while (node != Tail)
            {
                if (!(node is DummyNode) && _nodeAfter == node)
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