using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class HashTableTest
    {
        [Fact]
        public void HashFun_ShouldGenerateElementIndexInHashTableAndReturnIt()
        {
            var expectedValue = 10;
            var hashTable = new HashTable(17, 3);
            var result = hashTable.HashFun("value");

            result.Should().Be(expectedValue);
        }
        
        [Fact]
        public void Put_ShouldPutElementInHashTableAndReturnElementIndex()
        {
            var expectedValue = 10;
            var hashTable = new HashTable(17, 3);
            var result = hashTable.Put("value");

            result.Should().Be(expectedValue);
            hashTable.slots[result].Should().Be("value");
        }
        
        [Fact]
        public void Find_ShouldReturnMinusOne_WhenElementNotPresent()
        {
            var expectedValue = -1;
            var hashTable = new HashTable(17, 3);
            hashTable.Put("value");

            var result = hashTable.Find("Not found");

            result.Should().Be(expectedValue);
        }
        
        [Fact]
        public void Find_ShouldReturnElementIndex_WhenElementExists()
        {
            var expectedValue = 10;
            var hashTable = new HashTable(17, 3);
            hashTable.Put("value");
            var result = hashTable.Find("value");
            
            result.Should().Be(expectedValue);
            hashTable.slots[result].Should().Be("value");
        }
        
        [Fact]
        public void SeekSlot_ShouldReturnEmptySlotIndex_WhenEmptySlotExists()
        {
            var expectedValue = 13;
            var hashTable = new HashTable(17, 3);
            hashTable.Put("value");
            var result = hashTable.SeekSlot("value");
            
            result.Should().Be(expectedValue);
        }
        
        [Fact]
        public void SeekSlot_ShouldReturnMinusOne_WhenEmptySlotNotPresent()
        {
            var expectedValue = -1;
            var hashTable = new HashTable(17, 3);
            hashTable.Put("value");
            hashTable.Put("value");
            hashTable.Put("value");
            var result = hashTable.SeekSlot("value");
            
            result.Should().Be(expectedValue);
        }
    }
}