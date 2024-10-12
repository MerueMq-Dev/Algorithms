using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T> : HashTable
    {
        private List<T> _sorcePowerSet;

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

            if (0 > Put(value as string))
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
            slots[slotIndex] = null;
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