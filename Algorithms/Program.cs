using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nodeAfter = new Node(2);
            var nodeToInsert = new Node(3);
            var list = new OneDummyNodeLinkedList(
                new Node(1),
                nodeAfter,
                new Node(3),
                new Node(4),
                new Node(4)
            );

            Console.WriteLine("BEFORE");
            Console.WriteLine();
            if (list.Head.next == list.Head)
            {
                Console.WriteLine("The list is empty.");
            }


            for (Node currentNode = list.Head.next == list.Head ? list.Head : list.Head.next;
                 currentNode != list.Head;
                 currentNode = currentNode.next)
            {
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }


            Console.WriteLine("AFTER");
            list.InsertAfter(nodeAfter, nodeToInsert);
            // if (elements.Count == 0)
            // {
            //     Console.WriteLine("The list is empty.");
            // }
            // foreach (var currentNode in elements)
            // {
            //     Console.WriteLine($"Previous value {currentNode.prev?.value}");
            //     Console.WriteLine($"Current value {currentNode.value}");
            //     Console.WriteLine($"Next value {currentNode.next?.value}");
            //     Console.WriteLine("--------------------------------------------------------------");
            // }


            Console.WriteLine();
            if (list.Head.next == list.Head)
            {
                Console.WriteLine("The list is empty.");
            }

            // Console.WriteLine($"list count {list.Count()}");
            for (Node currentNode = list.Head.next == list.Head ? list.Head : list.Head.next;
                 currentNode != list.Head;
                 currentNode = currentNode.next)
            {
                if ((currentNode is DummyNode)) continue;
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }


            // foreach (var currentNode in elements)
            // {
            //     Console.WriteLine($"Previous value {currentNode.prev?.value}");
            //     Console.WriteLine($"Current value {currentNode.value}");
            //     Console.WriteLine($"Next value {currentNode.next?.value}");
            //     Console.WriteLine("--------------------------------------------------------------");
            // }

            Console.ReadLine();
        }
    }
}