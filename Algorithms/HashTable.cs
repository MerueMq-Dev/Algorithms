using System;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            var valueHash = value.GetHashCode();
            var slotIndex = Math.Abs(valueHash % size);
            return slotIndex;
        }

        public int Put(string value)
        {
            var slotIndex = SeekSlot(value);

            if (slotIndex != -1)
            {
                slots[slotIndex] = value;
                return slotIndex;
            }

            return -1;
        }

        public int Find(string value)
        {
            var slotIndex = HashFun(value);
            if (slots[slotIndex] != null && slots[slotIndex] == value)
            {
                return slotIndex;
            }

            for (var startIndex = slotIndex; startIndex <= size - 1; startIndex += step)
            {
                if (slots[startIndex] != null && slots[startIndex] == value)
                {
                    return startIndex;
                }
            }

            return -1;
        }

        public int SeekSlot(string value)
        {
            var slotIndex = HashFun(value);
            if (slots[slotIndex] == null)
            {
                return slotIndex;
            }

            for (var startIndex = slotIndex; startIndex <= size - 1; startIndex += step)
            {
                if (slots[startIndex] == null)
                {
                    return startIndex;
                }
            }  
            
            return -1;
        }
    }
}