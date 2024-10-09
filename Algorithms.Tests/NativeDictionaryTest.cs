using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class NativeDictionaryTest
    {
        [Fact]
        public void HashFun_ShouldGenerateElementIndexAndReturnIt()
        {
            var expectedValue = 10;
            var hashTable = new NativeDictionary<string>(17);
            
            var result = hashTable.HashFun("value");
            
            result.Should().Be(expectedValue);
        }
        
        [Fact]
        public void Put_ShouldPutElement()
        {
            var expectedValue = "value";
            var nativeDictionary = new NativeDictionary<string>(17);
            nativeDictionary.Put("key", "value");
            
            var value = nativeDictionary.Get("key");
            
            value.Should().Be(expectedValue);
        }
        
        [Fact]
        public void Get_ShouldReturnNull_WhenElementNotPresent()
        {
            var nativeDictionary = new NativeDictionary<string>(17);
            
            var value = nativeDictionary.Get("test-key");
            
            value.Should().BeNull();
        }
        
        [Fact]
        public void Get_ShouldReturnElement_WhenElementExists()
        {
            var expectedValue = "test-value";
            var nativeDictionary = new NativeDictionary<string>(17);
            nativeDictionary.Put("test-key", "test-value");
            
            var value = nativeDictionary.Get("test-key");
            
            value.Should().Be(expectedValue);
        }
        
        [Fact]
        public void IsKey_ShouldReturnTrue_WhenKeyExists()
        {
            var nativeDictionary = new NativeDictionary<string>(17);
            nativeDictionary.Put("test-key", "test-value");
            
            var value = nativeDictionary.IsKey("test-key");
            
            value.Should().BeTrue();
        }
        
        [Fact]
        public void IsKey_ShouldReturnFalse_WhenKeyNotPresent()
        {
            var nativeDictionary = new NativeDictionary<string>(17);
            
            var value = nativeDictionary.IsKey("test-key");
            
            value.Should().BeFalse();
        }
    }
}