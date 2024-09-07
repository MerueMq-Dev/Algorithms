using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AlgorithmsDataStructures;

namespace Algorithms.Tests
{
    public class LinkedListTest
    {
        [Fact]
        public void Remove_ShouldRemoveNodeAndReturnTrue_WhenElementExists()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach(var node in nodes)
            {
                list.AddInTail(node);
            }
            var expectedList = new LinkedList();
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }

            var result =  list.Remove(3);

            Assert.True(result);
            Assert.Equivalent(list, expectedList);
        }

        [Fact]
        public void Remove_ShouldNotChangeListAndReturnFalse_WhenElementNotFound()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            var expectedList = new LinkedList();
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }

            var result = list.Remove(12);
            Assert.False(result);
            Assert.Equivalent(list, expectedList);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveNodes_WhenElementExists()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(3), new Node(1), new Node(2), new Node(3), new Node(4), new Node(5), new Node(3) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            var expectedList = new LinkedList();
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }
           
            list.RemoveAll(3);
            Assert.Equivalent(list, expectedList);
        }

        [Fact]
        public void RemoveAll_ShouldNotChangeList_WhenElementNotFound()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(4), new Node(5) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }

            var expectedList = new LinkedList();
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }

            list.RemoveAll(16);

            Assert.Equivalent(list, expectedList);
            
        }

        [Fact]
        public void Clear_ShouldClearList_WhenListIsNotEmpty()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(3), new Node(1), new Node(2), new Node(3), new Node(4), new Node(5), new Node(3) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            list.Clear();
            var expectedList = new LinkedList();
            Assert.Equivalent(list, expectedList);
        }


        [Fact]
        public void FindAll_ShouldReturnAllMatchingElements_WhenTheyExist()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(3), new Node(1), new Node(2), new Node(3), new Node(4), new Node(5), new Node(3) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            var findedNodesCount = list.FindAll(3).Count;
            var expectedNodesCount =  3;
            Assert.Equal(expectedNodesCount, findedNodesCount);
        }


        [Fact]
        public void FindAll_ShouldReturnEmptyList_WhenElementsNotPresent()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(3), new Node(1), new Node(2), new Node(3), new Node(4), new Node(5), new Node(3) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            var findedNodesCount = list.FindAll(152).Count;
            var expectedNodesCount = 0;
            Assert.Equal(expectedNodesCount, findedNodesCount);
        }


        [Fact]
        public void Count_ShouldReturnZero_WhenElementsNotPresent()
        {
            var list = new LinkedList();

            var nodesCount = list.Count();
            Assert.Equal(0, nodesCount);            
        }


        [Fact]
        public void Count_ShouldReturnFive_WhenFiveElementsExist()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }

            var nodesCount = list.Count();

            Assert.Equal(5, nodesCount);
        }

        [Fact]
        public void InsertAfter_ShouldInsertElement_WhenTargetElementFound()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }
            
            var expectedList = new LinkedList();
            var nodeToInsert = new Node(12);
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), nodeToInsert, new Node(3), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }

            var nodeAfter = nodes[1];
            list.InsertAfter(nodeAfter,nodeToInsert);


            Assert.Equivalent(list, expectedList);
        }


        [Fact]
        public void InsertAfter_ShouldNotChangeList_WhenElementNotFound()
        {
            var list = new LinkedList();
            List<Node> nodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in nodes)
            {
                list.AddInTail(node);
            }

            var expectedList = new LinkedList();
            List<Node> expectedNodes = new List<Node>() { new Node(1), new Node(2), new Node(3), new Node(4), new Node(5) };
            foreach (var node in expectedNodes)
            {
                expectedList.AddInTail(node);
            }

            var nodeAfter = new Node(16);
            var nodeToInsert = new Node(12);

            list.InsertAfter(nodeAfter, nodeToInsert);

            Assert.Equivalent(list, expectedList);
        }
    }
}
