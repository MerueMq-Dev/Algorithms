using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        private const int GrowthFactor = 2;
        private const double ShrinkFactor = 1.5;
        
        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public DynArray(params T[] elements)
        {
            count = 0;
            MakeArray(16);
            foreach (var element in elements)
            {
                Append(element);
            }
            
        }
        
        public void MakeArray(int new_capacity)
        {
            capacity = new_capacity < 16 ? 16 : new_capacity;

            if (array == null)
                array = new T[capacity];
                    
            var newArr = new T[capacity];
            Array.Copy(array, newArr, count);
            array = newArr;
        }

        public T GetItem(int index)
        {
            ValidateIndex(index);
            return array[index];
        }

        public void Append(T itm)
        {
            if (count == 0)
            {
                array[0] = itm;
                count++;
                return;
            }

            if (count == capacity)
                MakeArray(capacity * GrowthFactor);

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            ValidateIndex(index, true);

            if (count == capacity)
                MakeArray(capacity * GrowthFactor);

            for (int i = count; i > index; i--) 
                array[i] = array[i - 1];

            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            ValidateIndex(index);
            
            for (int i = index; i < count; i++) 
                array[i] = array[i + 1];
            count--;
            
            if (count >= capacity / 2)
                return;
            
            var newCapacity = (int)(capacity / ShrinkFactor);
            MakeArray(newCapacity);
        }

        private void ValidateIndex(int targetIndex, bool includeLastItem = false)
        {
            var itemsCount = includeLastItem ? count : count - 1;
            
            if (targetIndex > itemsCount || targetIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}