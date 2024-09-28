using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DummyNode
    {
        public int? value;
        public DummyNode next, prev;

        
        public DummyNode(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public DummyNode()
        {
            next = null;
            prev = null;
        }
    }


    public class DummyLinkedList
    {
        public DummyNode Head { get; private set; }
        public DummyNode Tail { get; private set; }

        public DummyLinkedList(params DummyNode[] nodes)
        {
            Head = new DummyNode();
            Tail = new DummyNode();

            foreach (var dummyNode in nodes)
            {
                AddInTail(dummyNode);
            }
        }

        public void AddInTail(DummyNode _item)
        {
            if (Head.next == null)
            {
                Head.next = _item;
                Head.next.next = Tail;
                Head.next.prev = null;
                Tail.prev = _item;
                return;
            }

            _item.prev = Tail.prev;
            Tail.prev.next = _item;
            Tail.prev = _item;
            _item.next = Tail;
        }

        public DummyNode Find(int _value)
        {
            var node = Head;
            while (node.next != null)
            {
                if (node.next.value == _value) return node;
                node = node.next;
            }

            return null;
        }

        public List<DummyNode> FindAll(int _value)
        {
            List<DummyNode> nodes = new List<DummyNode>();
            DummyNode node = Head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            DummyNode node = Head;
            while (node.next != null)
            {
                if (node.next.value == _value)
                {
                    node.next.next.prev = node;
                    node.next = node.next.next;
                    return true;
                }

                node = node.next;
            }

            return false;
        }


        public void RemoveAll(int _value)
        {
            DummyNode node = Head;
            while (node.next != null)
            {
                if (node.next.value == _value)
                {
                    node.next = node.next.next;
                    node.next.prev = node;
                    continue;
                }

                node = node.next;
            }
        }

        public void Clear()
        {
            Head = new DummyNode();
            Tail = new DummyNode();
        }

        public int Count()
        {
            int count = 0;
            DummyNode node = Head;
            while (node.next != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        public void InsertAfter(DummyNode _nodeAfter, DummyNode _nodeToInsert)
        {
            if (_nodeToInsert == null)
            {
                return;
            }

            DummyNode node = Head;
            while (node.next != null)
            {
                if (_nodeAfter == node.next)
                {
                    _nodeToInsert.prev = node.next;
                    _nodeToInsert.next = node.next.next;
                    _nodeToInsert.next.prev = _nodeToInsert;
                    node.next.next = _nodeToInsert;
                    return;
                }

                node = node.next;
            }
        }
    }
}
