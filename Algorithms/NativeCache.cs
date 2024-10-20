using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public int step = 1;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            var keyHash = key.GetHashCode();
            var slotIndex = Math.Abs(keyHash % size);
            return slotIndex;
        }

        public bool IsKey(string key)
        {
            var index = HashFun(key);
            return slots[index] != null && slots[index] == key;
        }

        public void Put(string key, T value)
        {
            if (!HasEmptySlot() && Find(key) < 0)
            {
                var mostUnusedSlotIndex = FindMostUnusedSlot();
                values[mostUnusedSlotIndex] = value;
                slots[mostUnusedSlotIndex] = key;
                hits[mostUnusedSlotIndex] = 0;
                return;
            }

            var index = SeekSlot(key);
            if (index < 0)
                return;
            
            slots[index] = key;
            values[index] = value;
            hits[index] = 0;
        }

        protected int SeekSlot(string value)
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

            for (var startIndex = 0; startIndex != slotIndex && startIndex < slotIndex; startIndex += step)
            {
                if (slots[startIndex] == null)
                {
                    return startIndex;
                }
            }

            return -1;
        }

        public T Get(string key)
        {
            var index = Find(key);
            if (index < 0)
                return default(T);

            hits[index] = +1;
            return values[index];
        }

        protected int Find(string value)
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

            for (var startIndex = 0; startIndex != slotIndex && startIndex < slotIndex; startIndex += step)
            {
                if (slots[startIndex] != null && slots[startIndex] == value)
                {
                    return startIndex;
                }

                // if (startIndex > slotIndex || startIndex + step > slots.Length)
                // {
                //     startIndex = 0;
                // }
            }

            return -1;
        }

        private int FindMostUnusedSlot()
        {
            var currentElement = hits[0];

            for (int i = 1; i < hits.Length; i++)
            {
                if (currentElement > hits[i])
                    currentElement = hits[i];
            }

            return currentElement;
        }

        public bool HasEmptySlot()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] is null)
                    return true;
            }

            return false;
        }
    }
}