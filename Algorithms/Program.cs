using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nodeAfter = new Node(12);
            var nodeToInsert = new Node(13);

            var list = new DummyLinkedList(
                new Node(1),
                new Node(3),
                new Node(2),
                nodeAfter,
                new Node(3),
                new Node(3)
            );


            Console.WriteLine("BEFORE");
            Console.WriteLine();
            if (list.Head.next == null)
            {
                Console.WriteLine("The list is empty.");
            }

            // for (var currentNode = list.Head; currentNode.next != null; currentNode = currentNode.next)
            // {
            //     Console.WriteLine($"Previous value {currentNode.prev?.value}");
            //     Console.WriteLine($"Current value {currentNode.value}");
            //     Console.WriteLine($"Next value {currentNode.next?.value}");
            //     Console.WriteLine("--------------------------------------------------------------");
            // }
            // var elements = list.FindAll(1);
            // if (elements.Count == 0)
            // {
            //     Console.WriteLine("The list is empty.");
            // }
            //
            // Console.WriteLine($"Count Before: {elements.Count}");

            // foreach (var currentNode in elements)
            // {
            //     Console.WriteLine($"Previous value {currentNode.prev?.value}");
            //     Console.WriteLine($"Current value {currentNode.value}");
            //     Console.WriteLine($"Next value {currentNode.next?.value}");
            //     Console.WriteLine("--------------------------------------------------------------");
            // }


            Console.WriteLine("AFTER");
            Console.WriteLine();
            list.InsertAfter(nodeAfter, nodeToInsert);


            Console.WriteLine();
            if (list.Head == list.Tail)
            {
                Console.WriteLine("The list is empty.");
            }

            Console.WriteLine($"list count {list.Count()}");
            for (Node currentNode = list.Head; currentNode != null; currentNode = currentNode?.next)
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