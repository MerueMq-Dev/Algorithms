using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Queue<T>
    {
        private readonly List<T> _queueSource;
        public Queue()
        {
            _queueSource = new List<T>();
        } 

        public void Enqueue(T item)
        {
            _queueSource.Add(item);
        }
        
        public T Dequeue()
        {
            if (Size() == 0)
                return default;
            var elementToRemove = _queueSource[0];
            _queueSource.Remove(elementToRemove);
            return elementToRemove;
        }
        public int Size()
        {
            return _queueSource.Count; 
        }
    }
}