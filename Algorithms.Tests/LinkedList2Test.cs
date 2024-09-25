using System.Collections.Generic;
using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class LinkedList2Test
    {
        [Fact]
        public void Remove_ShouldRemoveNodeAndReturnTrue_WhenElementExists()
        {
            var list = new LinkedList2(new Node(1),
                new Node(2),
                new Node(3),
                new Node(4),
                new Node(5));

            var expectedList = new LinkedList2(new Node(1),
                new Node(2),
                new Node(4),
                new Node(5));
            var result = list.Remove(3);

            result.Should().BeTrue();
            
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Remove_ShouldNotChangeListAndReturnFalse_WhenElementNotFound()
        {
            var list = new LinkedList2(new Node(1), new Node(2));
            var expectedList = new LinkedList2(new Node(1), new Node(2));

            var result = list.Remove(12);

            result.Should().BeFalse();
            
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void RemoveAll_ShouldRemoveNodes_WhenElementExists()
        {
            var list = new LinkedList2(new Node(3),
                new Node(1), new Node(2),
                new Node(3), new Node(4),
                new Node(5), new Node(3));

            var expectedList = new LinkedList2(
                new Node(1), new Node(2),
                new Node(4), new Node(5)
            );

            list.RemoveAll(3);
            
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void RemoveAll_ShouldNotChangeList_WhenElementNotFound()
        {
            var list = new LinkedList2(
                new Node(1), new Node(2),
                new Node(4), new Node(5));

            var expectedList = new LinkedList2(
                new Node(1), new Node(2),
                new Node(4), new Node(5)
            );

            list.RemoveAll(16);
            
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Clear_ShouldClearList_WhenListIsNotEmpty()
        {
            var list = new LinkedList2(new Node(3), new Node(1),
                new Node(2));
            var expectedList = new LinkedList2();
            
            list.Clear();
            
            list.Should().BeEquivalentTo(expectedList);
        }
        
        [Fact]
        public void Find_ShouldShouldReturnMatchingElement_WhenElementExist()
        {
            var desiredNode = new Node(5);
            var list = new LinkedList2(
                new Node(3), new Node(1),
                new Node(2), new Node(3),
                new Node(4), desiredNode,
                new Node(3)
            );
            
            var foundNode = list.Find(5);
            
            foundNode.Should().Be(desiredNode);
        }

        [Fact]
        public void Find_ShouldShouldReturnNull_WhenElementNotPresent()
        {
            var list = new LinkedList2(
                new Node(3), new Node(1),
                new Node(2), new Node(3),
                new Node(4),
                new Node(3)
            );
            
            var foundNode = list.Find(5);
            
            foundNode.Should().BeNull();
        }

        [Fact]
        public void FindAll_ShouldReturnAllMatchingElements_WhenTheyExist()
        {
            var list = new LinkedList2(
                new Node(3), new Node(1),
                new Node(2), new Node(3),
                new Node(4), new Node(5),
                new Node(3));
            var expectedNodesCount = 3;
            
            var foundNodesCount = list.FindAll(3).Count;
            
            foundNodesCount.Should().Be(expectedNodesCount);
        }
        
        [Fact]
        public void FindAll_ShouldReturnEmptyList_WhenElementsNotPresent()
        {
            var list = new LinkedList2(new Node(3), new Node(1),
                new Node(2), new Node(3),
                new Node(4), new Node(5),
                new Node(3));
            var expectedNodesCount = 0;
            
            var foundNodesCount = list.FindAll(152).Count;
            
            foundNodesCount.Should().Be(expectedNodesCount);
        }
        
        [Fact]
        public void Count_ShouldReturnZero_WhenElementsNotPresent()
        {
            var list = new LinkedList2();
            var expectedNodesCount = 0;
            
            var nodesCount = list.Count();
            
            nodesCount.Should().Be(expectedNodesCount);
        }
        
        [Fact]
        public void Count_ShouldReturnFive_WhenFiveElementsExist()
        {
            var list = new LinkedList2(
                new Node(1), new Node(2),
                new Node(3), new Node(4),
                new Node(5)
            );
            var expectedNodesCount = 5;
            
            var nodesCount = list.Count();
            
            nodesCount.Should().Be(expectedNodesCount);
        }
        
        [Fact]
        public void InsertAfter_ShouldInsertElement_WhenTargetElementFound()
        {
            var nodeAfter = new Node(2);
            var list = new LinkedList2( 
                new Node(1), nodeAfter,
                new Node(3), new Node(4),
                new Node(5) );
            var nodeToInsert = new Node(12);
            var expectedList = new LinkedList2(
                new Node(1), new Node(2),
                nodeToInsert, new Node(3),
                new Node(4), new Node(5)
            );
            
            list.InsertAfter(nodeAfter,nodeToInsert);
            
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }
        
        [Fact]
        public void InsertAfter_ShouldNotChangeList_WhenElementNotFound()
        {
            var list = new LinkedList2(new Node(1), new Node(2),
                new Node(3), new Node(4),
                new Node(5)
            );
            
            var expectedList = new LinkedList2( 
                new Node(1), new Node(2),
                new Node(3), new Node(4),
                new Node(5) );
            var nodeAfter = new Node(16);
            var nodeToInsert = new Node(12);
            
            list.InsertAfter(nodeAfter, nodeToInsert);
            list.Should().BeEquivalentTo(expectedList, options => options.IgnoringCyclicReferences());
        }
    }
}