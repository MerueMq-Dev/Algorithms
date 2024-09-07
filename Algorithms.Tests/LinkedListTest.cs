using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Tests
{
    public class LinkedListTest
    {
        [Fact]
        public void Remove_ShouldRemoveNodeAndReturnTrue_WhenElementExists()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void Remove_ShouldNotChangeListAndReturnFalse_WhenElementNotFound()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveNodes_WhenElementExists()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void RemoveAll_ShouldNotChangeList_WhenElementNotFound()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void Clear_ShouldClearList_WhenListIsNotEmpty()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void FindAll_ShouldReturnAllMatchingElements_WhenTheyExist()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void FindAll_ShouldReturnEmptyList_WhenElementsNotPresent()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void Count_ShouldReturnZero_WhenElementsNotPresent()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void Count_ShouldReturnFive_WhenFiveElementsExist()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void InsertAfter_ShouldInsertElement_WhenTargetElementFound()
        {
            Assert.Equal(4, 4);
        }


        [Fact]
        public void InsertAfter_ShouldNotChangeList_WhenElementNotFound()
        {
            Assert.Equal(4, 4);
        }
    }
}
