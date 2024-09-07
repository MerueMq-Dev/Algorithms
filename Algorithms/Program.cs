using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            var firstNode = new Node(1);
            var secondNode = new Node(2);
            var thiedNode = new Node(3);
            var ninethNode = new Node(9);
            var ninethNode2 = new Node(9);
            
            list.AddInTail(firstNode);
            list.AddInTail(ninethNode);
            list.AddInTail(ninethNode2);
            list.AddInTail(secondNode);

            var secondList = new LinkedList();
            var fourthNode = new Node(4);
            var sixthNode = new Node(6);
            var seventhNode = new Node(7);
            secondList.AddInTail(thiedNode);
            secondList.AddInTail(fourthNode);
            secondList.AddInTail(sixthNode);
            secondList.AddInTail(seventhNode);

            Console.ReadLine();
        }
    }
}
