using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class OrderedListTest
    {
        [Fact]
        public void Add_ShouldAddElementToFrontOfOrderedList_WhenOrderedListInAscMode()
        {
            var orderedList = new OrderedList<string>(true, "5");
            var expectedOrderedList = new OrderedList<string>(true, "4", "5");

            orderedList.Add("4");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Add_ShouldAddElementToMiddleOfOrderedList_WhenOrderedListInAscMode()
        {
            var orderedList = new OrderedList<string>(true, "5", "7");
            var expectedOrderedList = new OrderedList<string>(true, "5", "6", "7");

            orderedList.Add("6");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Add_ShouldAddElementToEndOfOrderedList_WhenOrderedListInAscMode()
        {
            var orderedList = new OrderedList<string>(true, "5");
            var expectedOrderedList = new OrderedList<string>(true, "5", "6");

            orderedList.Add("6");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Add_ShouldAddElementToFrontOfOrderedList_WhenOrderedListInDescMode()
        {
            var orderedList = new OrderedList<string>(false, "4");
            var expectedOrderedList = new OrderedList<string>(false, "5", "4");

            orderedList.Add("5");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Add_ShouldAddElementToMiddleOfOrderedList_WhenOrderedListInDescMode()
        {
            var orderedList = new OrderedList<string>(false, "5", "7");
            var expectedOrderedList = new OrderedList<string>(false, "7", "6", "5");

            orderedList.Add("6");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Add_ShouldAddElementToEndOfOrderedList_WhenOrderedListInDescMode()
        {
            var expectedOrderedList = new OrderedList<string>(true, "6", "5");
            var orderedList = new OrderedList<string>(true, "6");
            orderedList.Add("5");
            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Find_ShouldShouldReturnNull_WhenElementNotPresentAndOrderedListInAscMode()
        {
            var orderedList = new OrderedList<string>(true, "6", "5", "9", "2");

            var result = orderedList.Find("1");

            result.Should().BeNull();
        }

        [Fact]
        public void Find_ShouldReturnMatchingElement_WhenElementExistAndOrderedListInAscMode()
        {
            var expectedValue = "9";
            var orderedList = new OrderedList<string>(true, "6", "5", "9", "2");

            var result = orderedList.Find("9");

            result.value.Should().Be(expectedValue);
        }

        [Fact]
        public void Find_ShouldShouldReturnNull_WhenElementNotPresentAndOrderedListInDescMode()
        {
            var orderedList = new OrderedList<string>(false, "8", "3", "6", "9", "2");

            var result = orderedList.Find("1");

            result.Should().BeNull();
        }

        [Fact]
        public void Find_ShouldReturnMatchingElement_WhenElementExistAndOrderedListInDescMode()
        {
            var expectedValue = "4";
            var orderedList = new OrderedList<string>(false, "1", "9", "4", "2");

            var result = orderedList.Find("4");

            result.value.Should().Be(expectedValue);
        }


        [Fact]
        public void Delete_ShouldDeleteMatchingNode_WhenElementExistsAndOrderedListInAscMode()
        {
            var expectedOrderedList = new OrderedList<string>(true, "1", "6");
            var orderedList = new OrderedList<string>(true, "1", "6", "5");

            orderedList.Delete("5");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Delete_ShouldNotChangeOrderedList_WhenElementNotFoundAndOrderedListInAscMode()
        {
            var expectedOrderedList = new OrderedList<string>(true, "6", "5");
            var orderedList = new OrderedList<string>(true, "5", "6");

            orderedList.Delete("2");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }


        [Fact]
        public void Delete_ShouldDeleteMatchingNode_WhenElementExistsAndOrderedListInDescMode()
        {
            var expectedOrderedList = new OrderedList<string>(false, "1", "6", "2", "5");
            var orderedList = new OrderedList<string>(false, "1", "6", "2", "8", "5");

            orderedList.Delete("8");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }

        [Fact]
        public void Delete_ShouldNotChangeOrderedList_WhenElementNotFoundAndOrderedListInDescMode()
        {
            var expectedOrderedList = new OrderedList<string>(false, "1", "6", "2", "8", "5");
            var orderedList = new OrderedList<string>(false, "1", "6", "2", "8", "5");
            
            orderedList.Delete("3");

            orderedList.Should().BeEquivalentTo(expectedOrderedList,
                options => options.IgnoringCyclicReferences());
        }
    }
}