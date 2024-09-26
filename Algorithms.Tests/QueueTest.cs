using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class QueueTest
    {
        [Fact]
        public void Size_ShouldBeThree_WhenThreeElementsPushed()
        {
            var queue = new Queue<int>(1, 2, 3);
            var expectedSize = 3;

            var size = queue.Size();

            size.Should().Be(expectedSize);
        }

        [Fact]
        public void Size_ShouldBeZero_WhenNoElementsPushed()
        {
            var queue = new Queue<int>();
            var expectedSize = 0;

            var size = queue.Size();

            size.Should().Be(expectedSize);
        }

        [Fact]
        public void Dequeue_ShouldRemoveAndReturnFirstElement_WhenQueueIsNotEmpty()
        {
            var queue = new Queue<int>(1, 2, 3, 4, 5);
            var expectedQueue = new Queue<int>(2, 3, 4, 5);
            var expectedElement = 1;

            var result = queue.Dequeue();

            result.Should().Be(expectedElement);
            queue.Should().BeEquivalentTo(expectedQueue);
        }

        [Fact]
        public void Dequeue_ShouldReturnNull_WhenQueueIsEmpty()
        {
            var queue = new Queue<string>();

            var result = queue.Dequeue();

            result.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public void Enqueue_ShouldAddElementToQueue()
        {
            var queue = new Queue<string>("1","2","3");
            var expectedQueue = new Queue<string>("1","2","3","4");
            
            queue.Enqueue("4");
            
            queue.Should().BeEquivalentTo(expectedQueue);
        }
    }
}