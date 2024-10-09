using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
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
            var index = HashFun(key);
            slots[index] = key;
            values[index] = value;
        }

        public T Get(string key)
        {
            var isKey = IsKey(key);
            if (!isKey)
                return default(T);
            
            var index = HashFun(key);
            return values[index];
        }
    }
}