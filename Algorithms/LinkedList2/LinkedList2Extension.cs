using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public static class LinkedList2Extension
    {
        public static void ReverseList(this LinkedList2 source)
        {
            for (var currentNode = source.tail; currentNode != null; currentNode = currentNode.next)
            {
                (currentNode.next, currentNode.prev) = (currentNode.prev, currentNode.next);
            }

            (source.head, source.tail) = (source.tail, source.head);
        }

        public static bool IsCyclic(this LinkedList2 source)
        {
            
            var fstPointer = source.head;
            var sndPointer = source.head;

            while (fstPointer != null &&  sndPointer != null)
            {
                fstPointer = fstPointer.next;
                sndPointer = sndPointer.next.next;
                
                if (fstPointer == sndPointer)
                {
                    return true;
                }
            }
            
            return false;
        }

        public static void Sort(this LinkedList2 source)
        {
            if (source.head == null || source.head.next == null)
                return;

            for (var fstPointer = source.head; fstPointer != null; fstPointer = fstPointer.next)
            {
                for (var sndPointer = fstPointer.next; sndPointer != null; sndPointer = sndPointer.next)
                {
                    if (fstPointer.value > sndPointer.value)
                    {
                        (fstPointer.value, sndPointer.value) = (sndPointer.value, fstPointer.value);
                    }
                }
            }
        }

        public static LinkedList2 MergeTwoLists(this LinkedList2 source, LinkedList2 secondSource)
        {
            source.Sort();
            secondSource.Sort();

            var firstNode = source.head;
            var secondNode = secondSource.head;
            var mergedList = new LinkedList2();
            while (firstNode != null || secondNode != null)
            {
                if (firstNode?.value < secondNode.value)
                {
                    mergedList.AddInTail(new Node(firstNode.value));
                    firstNode = firstNode.next;
                }
                else
                {
                    mergedList.AddInTail(new Node(secondNode.value));
                    secondNode = secondNode.next;
                }
            }

            return mergedList;
        }

        
        
        
        // For testing purposes
        public static void CreateCyclic(this LinkedList2 source, int value)
        {   
            var node = source.Find(value);
            var newNode = new Node(value);
            newNode.next = node;
            source.tail.next = newNode;
            newNode.prev = source.tail;
            source.tail = newNode;
        }
    }
}