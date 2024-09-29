using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Deque<T>
    {
        public readonly List<T> _dequeSource;
        
        public Deque()
        {
            _dequeSource = new List<T>();
        }
        
        public Deque(params T[] items)
        {
            _dequeSource = new List<T>();

            foreach (var item in items)
            {
                AddTail(item);
            }
        }
        
        public void AddFront(T item)
        {
            _dequeSource.Insert(0, item);
        }

        public void AddTail(T item)
        {
            _dequeSource.Add(item);
        }

        public T RemoveTail()
        {
            var elementsCount = Size();
            if (elementsCount == 0)
                return default;
            var elementToRemove = _dequeSource[elementsCount - 1];
            _dequeSource.Remove(elementToRemove);
            return elementToRemove;
        }
        
        public T RemoveFront()
        {
            if (Size() == 0)
                return default;
            var elementToRemove = _dequeSource[0];
            _dequeSource.Remove(elementToRemove);
            return elementToRemove;
        }
        
        public int Size()
        {
            return _dequeSource.Count;
        }
    }
}