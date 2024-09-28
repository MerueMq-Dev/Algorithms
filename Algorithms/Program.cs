using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nodeAfter = new DummyNode(12);
            var nodeToInsert = new DummyNode(13);

            var list = new DummyLinkedList(
                new DummyNode(1),
                new DummyNode(3),
                new DummyNode(2),
                nodeAfter,
                new DummyNode(3),
                new DummyNode(3)
            );

            Console.WriteLine("BEFORE");
            Console.WriteLine();
            if (list.Head.next == null)
            {
                Console.WriteLine("The list is empty.");
            }

            for (var currentNode = list.Head; currentNode.next != null; currentNode = currentNode.next)
            {
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }
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
            var foundNodes = list.FindAll(3);

            foreach (var currentNode in foundNodes)
            {
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }
            Console.WriteLine();
            if (list.Head.next == null)
            {
                Console.WriteLine("The list is empty.");
            }
            //
            // for (var currentNode = list.Head; currentNode.next != null; currentNode = currentNode.next)
            // {
            //     Console.WriteLine($"Previous value {currentNode.prev?.value}");
            //     Console.WriteLine($"Current value {currentNode.value}");
            //     Console.WriteLine($"Next value {currentNode.next?.value}");
            //     Console.WriteLine("--------------------------------------------------------------");
            // }


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