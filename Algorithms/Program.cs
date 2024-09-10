using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList2();
            var node1 = new Node(1);
            // var node2 = new Node(2);
            var node11 = new Node(1);
            // var node3 = new Node(3);
            // var node4 = new Node(4);
            var node12 = new Node(1);
            // var node5 = new Node(5);
            var node13 = new Node(1);
            
            list.AddInTail(node1);
            // list.AddInTail(node2);
            // list.AddInTail(node11);
            // list.AddInTail(node3);
            // list.AddInTail(node4);
            // list.AddInTail(node12);
            // list.AddInTail(node5);
            // list.AddInTail(node13);
            
            var currentNode = list.head;
            Console.WriteLine("BEFORE");
            if(currentNode == null) 
                Console.WriteLine("List is empty");
            while (currentNode != null)
            {
                Console.WriteLine($"value: {currentNode.value}");
                currentNode = currentNode.next;
            }

            var elementsCount =  list.Count();
            Console.WriteLine($"elementsCount {elementsCount}");

            var newNode = new Node(22);
            list.InsertAfter(null,newNode);
            
            Console.WriteLine("AFTER");
            currentNode = list.head;
            if(currentNode == null) 
                Console.WriteLine("List is Empty");
            while (currentNode != null)
            {
                Console.WriteLine($"value: {currentNode.value}");
                currentNode = currentNode.next;
            }
            
            // var secondList = new LinkedList2();
            // var fourthNode = new Node(4);
            // var sixthNode = new Node(6);
            // var seventhNode = new Node(7);
            // secondList.AddInTail(thiedNode);
            // secondList.AddInTail(fourthNode);
            // secondList.AddInTail(sixthNode);
            // secondList.AddInTail(seventhNode);

            Console.ReadLine();
        }
    }
}
