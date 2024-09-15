using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var list = new LinkedList2();
            // var node1 = new Node(1);
            // // var node2 = new Node(2);
            // var node11 = new Node(11);
            // var node3 = new Node(1);
            // var node4 = new Node(1);
            // var node12 = new Node(12);
            // // var node5 = new Node(5);
            // var node13 = new Node(13);
            //
            // list.AddInTail(node1);
            // // list.AddInTail(node2);
            // list.AddInTail(node11);
            // list.AddInTail(node3);
            // list.AddInTail(node12);
            // list.AddInTail(node4);
            // // list.AddInTail(node5);
            // list.AddInTail(node13);
            //
            // var currentNode = list.head;
            // Console.WriteLine("BEFORE");
            // if(currentNode == null) 
            //     Console.WriteLine("List is empty");
            // while (currentNode != null)
            // {
            //     Console.WriteLine($"----------------------------------------------------------------------");
            //     Console.WriteLine($"previous  value: {currentNode?.prev?.value}");
            //     Console.WriteLine($"current value: {currentNode?.value}");
            //     Console.WriteLine($"next value: {currentNode?.next?.value}");
            //     Console.WriteLine($"----------------------------------------------------------------------");
            //     currentNode = currentNode.next;
            // }
            //
            // var elementsCount =  list.Count();
            // Console.WriteLine($"elementsCount {elementsCount}");
            //
            // var newNode = new Node(22);
            // list.RemoveAll(13);
            //
            // Console.WriteLine("AFTER");
            // currentNode = list.head;
            // if(currentNode == null) 
            //     Console.WriteLine("List is Empty");
            // while (currentNode != null)
            // {
            //     Console.WriteLine($"----------------------------------------------------------------------");
            //     Console.WriteLine($"previous  value: {currentNode?.prev?.value}");
            //     Console.WriteLine($"current value: {currentNode?.value}");
            //     Console.WriteLine($"next value: {currentNode?.next?.value}");
            //     Console.WriteLine($"----------------------------------------------------------------------");
            //     currentNode = currentNode.next;
            // }
            
            // var secondList = new LinkedList2();
            // var fourthNode = new Node(4);
            // var sixthNode = new Node(6);
            // var seventhNode = new Node(7);
            // secondList.AddInTail(thiedNode);
            // secondList.AddInTail(fourthNode);
            // secondList.AddInTail(sixthNode);
            // secondList.AddInTail(seventhNode);

            var dynArr = new DynArray<int>();
            for (int i = 1; i <= 16; i++)
            {
                dynArr.Append(i);
            }

            Console.WriteLine("BEFORE: ");
            Console.WriteLine($"Count: {dynArr.count}");
            Console.WriteLine($"Capacity: {dynArr.capacity}");
            for (int i = 0; i < dynArr.count; i++)
            {
                Console.WriteLine($"Dynamic arr element: {dynArr.GetItem(i)}");
            }
            
            dynArr.Insert(550,0);
            dynArr.Remove(4);
            dynArr.Remove(100);
            Console.WriteLine("AFTER: ");
            Console.WriteLine($"Count: {dynArr.count}");
            Console.WriteLine($"Capacity: {dynArr.capacity}");
            for (int i = 0; i < dynArr.count; i++)
            {
                Console.WriteLine($"Dynamic arr element: {dynArr.GetItem(i)}");
            }
            // Console.ReadLine();
        }
    }
}
