using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class StackTest
    {
        [Fact]
        public void Size_ShouldBeFive_WhenFiveElementsPushed()
        {
            var stack = new Stack<int>(1, 2, 3, 4, 5);
            var expectedSize = 5;
            
            var size = stack.Size();
            
            size.Should().Be(expectedSize);
        }
        
        [Fact]
        public void Size_ShouldBeZero_WhenNoElementsPushed()
        {
            var stack = new Stack<int>();
            var expectedSize = 0;

            var size = stack.Size();
            
            size.Should().Be(expectedSize);
        }
        
        [Fact]
        public void Pop_ShouldRemoveAndReturnTopElement_WhenStackIsNotEmpty()
        {
            var stack = new Stack<int>(1,2,3,4,5);
            var expectedStack = new Stack<int>(1,2,3,4);
            var expectedElement = 5;

            var result = stack.Pop();
            
            result.Should().Be(expectedElement);
            stack.Should().BeEquivalentTo(expectedStack);
        }
        
        [Fact]
        public void Pop_ShouldReturnNull_WhenStackIsEmpty()
        {
            var stack = new Stack<string>();

            var result = stack.Pop();
            
            result.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public void Push_ShouldAddElementToStack()
        {
            var stack = new Stack<string>("1","2","3");
            var expectedStack = new Stack<string>("1","2","3","4");

            stack.Push("4");
            
            stack.Should().BeEquivalentTo(expectedStack);
        }
        
        [Fact]
        public void Peek_ShouldReturnTopElement_WhenStackIsNotEmpty()
        {
            var stack = new Stack<string>("1","2","3");
            var expectedElement = "3";
            
            var result = stack.Peek();
            
            result.Should().Be(expectedElement);
        }
        
        [Fact]
        public void Peek_ShouldReturnNull_WhenStackIsEmpty()
        {
            var stack = new Stack<string>();

            var result = stack.Peek();
            
            result.Should().BeNullOrEmpty();
        }
    }
}