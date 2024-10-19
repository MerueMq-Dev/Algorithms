using System.Collections.Generic;
using System;
using System.Collections;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;

        public int bitArray;

        public BloomFilter(int f_len = 32,int countValuesForFilter = 10)
        {
            filter_len = f_len;
            bitArray = 0;
        }
        
        public int Hash1(string str1)
        {
            var hash = 0;
            var randomValue = 17;
            for (int i = 0; i < str1.Length; i++)
            {
                hash = (hash * randomValue + str1[i]) % filter_len;
            }
            
            return hash;
        }

        public int Hash2(string str1)
        {
            var hash = 0;
            var randomValue = 223;
            for (int i = 0; i < str1.Length; i++)
            {
                hash = (hash * randomValue + str1[i]) % filter_len;
            }
            
            return hash;
        }

        public void Add(string str1)
        {
            var fistIndex = Hash1(str1);
            var secondIndex = Hash2(str1);

            ReplaceBit(fistIndex);
            ReplaceBit(secondIndex);
        }

        public bool IsValue(string str1)
        {
            var fistIndex = Hash1(str1);
            var secondIndex = Hash2(str1);

            return GetBitAt(fistIndex) == 1 && GetBitAt(secondIndex) == 1;
        }

        private int GetBitAt( int bitIndex)
        {
            return  (bitArray >> bitIndex) & 1;;
        }
        
        private void ReplaceBit(int bitIndex)
        {
            int mask = 1 << bitIndex;
            bitArray |= mask;
        }
    }
}