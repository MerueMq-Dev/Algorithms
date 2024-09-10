using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public static class LinkedListExtention
    {
        public static List<int> SumOfTwoLists(this LinkedList _firstList, LinkedList _secondList)
        {
            List<int> result = new List<int>();

            if (_firstList.head == null || _secondList.head == null)
                return result;

            if (_firstList.Count() != _secondList.Count())
                return result;

            Node2 firstListPointer = _firstList.head;
            Node2 secondListPointer = _secondList.head;

            while (firstListPointer != null && secondListPointer != null)
            {
                var sum = firstListPointer.value + secondListPointer.value;
                result.Add(sum);
                firstListPointer = firstListPointer.next;
                secondListPointer = secondListPointer.next;
            }
            return result;
        }
    }
}
