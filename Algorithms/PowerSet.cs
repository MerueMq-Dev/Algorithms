using System;
using System.Collections.Generic;

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
            for (int i = 0; i < size; i++) slots[i] = default;
        }

        protected int HashFun(string value)
        {
            var valueHash = value.GetHashCode();
            var slotIndex = Math.Abs(valueHash % size);
            return slotIndex;
        }

        protected int Put(string value)
        {
            var slotIndex = SeekSlot(value);

            if (slotIndex != -1)
            {
                slots[slotIndex] = value;
                return slotIndex;
            }

            return -1;
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
                if (slots[startIndex] != null && slots[slotIndex] == value)
                {
                    return startIndex;
                }
            }

            for (var startIndex = 0; startIndex != slotIndex; startIndex++)
            {
                if (slots[startIndex] != null && slots[startIndex] == value)
                {
                    return startIndex;
                }
            }

            return -1;
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

            for (var startIndex = 0; startIndex != slotIndex; startIndex++)
            {
                if (slots[startIndex] == null)
                {
                    return startIndex;
                }
            }
            
            return -1;
        }
    }

    public class PowerSet<T> : HashTable
    {
        public List<T> _sorcePowerSet;

        public PowerSet(int sz = 20, int stp = 3) : base(sz, stp)
        {
            step = stp;
            size = sz;
            slots = new string[size];
            _sorcePowerSet = new List<T>();
        }

        public int Size()
        {
            return _sorcePowerSet.Count;
        }

        public void Put(T value)
        {
            if (Get(value))
                return;

            if (0 > base.Put(value as string))
                return;

            _sorcePowerSet.Add(value);
        }

        public bool Get(T value)
        {
            return Find(value as string) >= 0;
        }

        public bool Remove(T value)
        {
            var slotIndex = Find(value as string);
            if (slotIndex < 0)
                return false;
            slots[slotIndex] = default;
            return _sorcePowerSet.Remove(value);
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (var item in _sorcePowerSet)
            {
                if (set2.Get(item))
                    result.Put(item);
            }

            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            foreach (var item in _sorcePowerSet)
            {
                set2.Put(item);
            }

            return set2;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (var item in _sorcePowerSet)
            {
                if (!set2.Get(item))
                    result.Put(item);
            }

            return result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            var count = 0;
            foreach (var item in _sorcePowerSet)
            {
                if (set2.Get(item))
                    count++;
            }

            return count == set2.Size();
        }

        public bool Equals(PowerSet<T> set2)
        {
            if (_sorcePowerSet.Count != set2.Size())
                return false;

            foreach (var item in _sorcePowerSet)
            {
                if (!set2.Get(item))
                    return false;
            }

            return true;
        }
    }
}