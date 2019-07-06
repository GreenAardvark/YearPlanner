using System;
using FluentAssertions;
using Xunit;

namespace YearPlanner.UnitTests
{
    public class YearTests
    {
        [Fact]
        public void Should_Be_OK_When_Passed_Valid_Year()
        {
            var year = new Year(2019);
            year.Should().NotBeNull();
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Year_Too_Low()
        {
            Action action = () => new Year(-1);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Year_Too_High()
        {
            Action action = () => new Year(10000);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Be_Able_To_Retrieve_Value_For_Year_When_Given_Valid_Value()
        {
            var year = new Year(2019);
            year.Value.Should().Be(2019);
        }

        [Fact]
        public void Should_Contain_12_Months_When_Given_Valid_Year()
        {
            var year = new Year(2019);
            year.Months.Should().HaveCount(12);
        }
    }
}
