using Xunit;
using AlgorithmsDataStructures;
using FluentAssertions;

namespace Algorithms.Tests
{
    public class DequeTest
    {
        [Fact]
        public void Size_ShouldBeFive_WhenFiveElementsPushed()
        {
            var deque = new Deque<int>(1, 2, 3, 4, 5);
            var expectedSize = 5;

            var size = deque.Size();

            size.Should().Be(expectedSize);
        }

        [Fact]
        public void Size_ShouldBeZero_WhenNoElementsPushed()
        {
            var deque = new Deque<int>();
            var expectedSize = 0;

            var size = deque.Size();

            size.Should().Be(expectedSize);
        }

        [Fact]
        public void AddFront_ShouldAddElementToFrontOfDeque()
        {
            var deque = new Deque<string>("5");
            var expectedDeque = new Deque<string>("4","5");
            deque.AddFront("4");

            deque.Should().BeEquivalentTo(expectedDeque);
        }
        
        [Fact] 
        public void RemoveFront_ShouldRemoveAndReturnElementFromFrontOfDeque_WhenDequeIsNotEmpty()
        {
            var frontElement = "4";
            var deque = new Deque<string>(frontElement, "5");
            var expectedDeque = new Deque<string>("5");
            
            var result = deque.RemoveFront();

            result.Should().Be(frontElement);
            deque.Should().BeEquivalentTo(expectedDeque);
        }
        
        [Fact]
        public void RemoveFront_ShouldReturnNull_WhenDequeIsNotEmpty()
        {
            var deque = new Deque<string>();

            var result = deque.RemoveFront();
            
            result.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public void AddTail_ShouldAddElementToTailOfDeque()
        {
            var deque = new Deque<string>("4");
            var expectedDeque = new Deque<string>("4","5");
            deque.AddTail("5");

            deque.Should().BeEquivalentTo(expectedDeque);
        }
        
        [Fact] 
        public void RemoveTail_ShouldRemoveAndReturnElementFromTailOfDeque_WhenDequeIsNotEmpty()
        {
            var frontElement = "6";
            var deque = new Deque<string>("5", frontElement);
            var expectedDeque = new Deque<string>("5");
            
            var result = deque.RemoveTail();

            result.Should().Be(frontElement);
            deque.Should().BeEquivalentTo(expectedDeque);
        }
        
        [Fact]
        public void RemoveTail_ShouldReturnNull_WhenDequeIsNotEmpty()
        {
            var deque = new Deque<string>();

            var result = deque.RemoveTail();
            
            result.Should().BeNullOrEmpty();
        }
        
    }
}