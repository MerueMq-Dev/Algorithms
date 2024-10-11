using AlgorithmsDataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class PowerSetTest
    {
        [Fact]
        public void Put_ShouldPutElementAndReturnTrue_WhenElementIsExists()
        {
            var powerSet = new PowerSet<string>();
            powerSet.Put("value");

            var exists = powerSet.Get("value");

            exists.Should().BeTrue();
        }

        [Fact]
        public void Get_ShouldReturnFalse_WhenElementNotPresent()
        {
            var powerSet = new PowerSet<string>();

            var value = powerSet.Get("test-value");

            value.Should().BeFalse();
        }

        [Fact]
        public void Get_ShouldReturnTrue_WhenElementExists()
        {
            var powerSet = new PowerSet<string>();
            powerSet.Put("test-value");

            var value = powerSet.Get("test-value");

            value.Should().BeTrue();
        }

        [Fact]
        public void Remove_ShouldReturnTrue_WhenElementIsRemoved()
        {
            var powerSet = new PowerSet<string>();
            powerSet.Put("test-value");

            var value = powerSet.Remove("test-value");

            value.Should().BeTrue();
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenElementIsNotRemoved()
        {
            var powerSet = new PowerSet<string>();

            var value = powerSet.Remove("test-value");

            value.Should().BeFalse();
        }

        [Fact]
        public void Intersection_ShouldReturnSetWithCommonElements_WhenBothSetsHaveCommonValues()
        {
            var expectedSet = new PowerSet<string>();
            expectedSet.Put("1");
            expectedSet.Put("3");
            var firstSet = new PowerSet<string>();
            firstSet.Put("1");
            firstSet.Put("2");
            firstSet.Put("3");
            firstSet.Put("4");
            var secondSet = new PowerSet<string>();
            secondSet.Put("1");
            secondSet.Put("3");
            secondSet.Put("8");
            secondSet.Put("9");

            var result = firstSet.Intersection(secondSet);

            result.Should().BeEquivalentTo(expectedSet);
        }

        [Fact]
        public void Intersection_ShouldReturnEmptySet_WhenBothSetsHaveNoCommonValues()
        {
            var expectedSet = new PowerSet<string>();
            var firstSet = new PowerSet<string>();
            firstSet.Put("12");
            firstSet.Put("2");
            firstSet.Put("15");
            firstSet.Put("4");
            var secondSet = new PowerSet<string>();
            secondSet.Put("1");
            secondSet.Put("3");
            secondSet.Put("8");
            secondSet.Put("9");

            var result = firstSet.Intersection(secondSet);

            result.Should().BeEquivalentTo(expectedSet);
        }

        [Fact]
        public void Union_ShouldReturnCombinedSet_WhenBothSetsAreNotEmpty()
        {
            var expectedSet = new PowerSet<string>();
            expectedSet.Put("12");
            expectedSet.Put("2");
            expectedSet.Put("1");
            expectedSet.Put("3");
            var firstSet = new PowerSet<string>();
            firstSet.Put("12");
            firstSet.Put("2");
            var secondSet = new PowerSet<string>();
            secondSet.Put("1");
            secondSet.Put("3");

            var result = firstSet.Union(secondSet);

            result.Should().BeEquivalentTo(expectedSet);
        }

        [Fact]
        public void Difference_ShouldReturnOnlyUniqueElements_WhenSomeElementsAreCommon()
        {
            var expectedSet = new PowerSet<string>();
            expectedSet.Put("7");
            expectedSet.Put("5");

            var firstSet = new PowerSet<string>();
            firstSet.Put("12");
            firstSet.Put("5");
            firstSet.Put("3");
            var secondSet = new PowerSet<string>();
            secondSet.Put("12");
            firstSet.Put("7");
            secondSet.Put("3");

            var result = firstSet.Difference(secondSet);

            result.Should().BeEquivalentTo(expectedSet);
        }

        [Fact]
        public void Difference_ShouldReturnEmptySet_WhenBothSetsHaveCommonValues()
        {
            var expectedSet = new PowerSet<string>();
            var firstSet = new PowerSet<string>();
            firstSet.Put("12");
            firstSet.Put("3");
            var secondSet = new PowerSet<string>();
            secondSet.Put("12");
            secondSet.Put("3");

            var result = firstSet.Difference(secondSet);

            result.Should().BeEquivalentTo(expectedSet);
        }

        [Fact]
        public void IsSubset_ShouldReturnTrue_WhenParameterIsSubset()
        {
            var mainSet = new PowerSet<string>();
            mainSet.Put("22");
            mainSet.Put("12");
            mainSet.Put("3");
            var secondSet = new PowerSet<string>();
            secondSet.Put("12");
            secondSet.Put("3");

            var result = mainSet.IsSubset(secondSet);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsSubset_ShouldReturnTrue_WhenAllInParameterSet()
        {
            var mainSet = new PowerSet<string>();
            mainSet.Put("22");
            mainSet.Put("12");
            var secondSet = new PowerSet<string>();
            secondSet.Put("22");
            secondSet.Put("12");

            var result = mainSet.IsSubset(secondSet);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsSubset_ShouldReturnFalse_WhenSomeParameterNotInCurrent()
        {
            var mainSet = new PowerSet<string>();
            mainSet.Put("22");
            mainSet.Put("12");
            var secondSet = new PowerSet<string>();
            secondSet.Put("32");
            secondSet.Put("45");
            secondSet.Put("12");

            var result = mainSet.IsSubset(secondSet);

            result.Should().BeFalse();
        }


        [Fact]
        public void Equals_ShouldReturnFalse_WhenSomeParameterNotInCurrent()
        {
            PowerSet<string> mainSet = new PowerSet<string>();
            PowerSet<string> parameterSet = new PowerSet<string>();
            for (int i = 0; i < 20000; i++)
            {
                mainSet.Put("String" + i);
                parameterSet.Put("String2" + i);
            }

            var result = mainSet.Equals(parameterSet);
            
            result.Should().BeFalse();
        }
        
        [Fact]
        public void Equals_ShouldReturnTrue_WhenBothSetsHaveCommonValues()
        {
            PowerSet<string> mainSet = new PowerSet<string>();
            PowerSet<string> parameterSet = new PowerSet<string>();
            for (int i = 0; i < 20000; i++)
            {
                mainSet.Put("String" + i);
                parameterSet.Put("String" + i);
            }

            var result = mainSet.Equals(parameterSet);
            
            result.Should().BeTrue();
        }
    }
}