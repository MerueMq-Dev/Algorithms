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
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToInt32(hashBytes, 0);
                var slotIndex = Math.Abs(hash % size); 
                return slotIndex;
            }
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