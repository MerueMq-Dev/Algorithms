using System;
using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class DynArrayTest
    {
        [Fact]
        public void Remove_ShouldRemoveElementWithoutAffectingBuffer_WhenElementExists()
        {
            var array = new DynArray<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            var expectedArray = new DynArray<int>(1, 2, 3, 4, 6, 7, 8, 9);

            array.Remove(4);

            array.Should().BeEquivalentTo(expectedArray);
            array.array.Length.Should().Be(16);
        }

        [Fact]
        public void Remove_ShouldRemoveTwoElementsAndModifyBuffer_WhenElementExists()
        {
            var expectedBuffer = 21;
            var array = new DynArray<int>(1, 2, 3, 4, 5, 1, 2, 3,
                4, 5, 1, 2, 3, 4, 5, 1, 2);
            var expectedArray = new DynArray<int>(3, 4, 5, 1, 2, 3,
                4, 5, 1, 2, 3, 4, 5, 1, 2);
            expectedArray.MakeArray(expectedBuffer);

            array.Remove(0);
            array.Remove(0);

            array.Should().BeEquivalentTo(expectedArray);
            array.array.Length.Should().Be(expectedBuffer);
        }

        [Fact]
        public void Remove_ThrowIndexOutOfRangeException_WhenNoMatchingIndex()
        {
            var array = new DynArray<int>(1, 2, 3, 4);
  
            Action act = () => array.Remove(5);
            act.Should().ThrowExactly<IndexOutOfRangeException>();
        }
        
        [Fact]
        public void Insert_ShouldInsertElementWithoutAffectingBuffer()
        {
            var array = new DynArray<int>(1, 2, 3, 4, 5);
            var expectedArray = new DynArray<int>(1, 2, 6, 3, 4, 5);

            array.Insert(6, 2);

            array.Should().BeEquivalentTo(expectedArray);
            array.array.Length.Should().Be(16);
        }

        [Fact]
        public void Insert_ShouldInsertElementAndModifyBuffer()
        {
            var array = new DynArray<int>(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6,
                1, 2, 3, 4);
            var expectedArray = new DynArray<int>(1, 2, 3, 4, 5, 6, 123, 1, 2, 
                3, 4, 5, 6, 1, 2, 3, 4);

            array.Insert(123, 6);

            array.Should().BeEquivalentTo(expectedArray);
            array.array.Length.Should().Be(32);
        }
        
        [Fact]
        public void Insert_ThrowIndexOutOfRangeException_WhenNoMatchingIndex()
        {
            var array = new DynArray<int>(1, 2, 3, 4);
  
            Action act = () => array.Insert(4,5);

            act.Should().ThrowExactly<IndexOutOfRangeException>();
        }
    }
}