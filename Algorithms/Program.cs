using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderedList = new OrderedList<int>(false, 3, 1, 4, 8, 5, -1, 8, 8, 5);

            Console.WriteLine("BEFORE");

            for (Node<int> currentNode = orderedList.head;
                 currentNode != null;
                 currentNode = currentNode.next)
            {
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }

            Console.WriteLine("AFTER");
            
             orderedList.Delete(1);
            
            
            for (Node<int> currentNode = orderedList.head;
                 currentNode != null;
                 currentNode = currentNode.next)
            {
                Console.WriteLine($"Previous value {currentNode.prev?.value}");
                Console.WriteLine($"Current value {currentNode.value}");
                Console.WriteLine($"Next value {currentNode.next?.value}");
                Console.WriteLine("--------------------------------------------------------------");
            }

            // var res = orderedList.Compare("33", "32");
            // Console.WriteLine($"res {res}");

            Console.ReadLine();
        }
    }
}