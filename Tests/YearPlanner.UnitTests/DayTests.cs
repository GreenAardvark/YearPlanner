using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace YearPlanner.UnitTests
{
    public class DayTests
    {
        private const int NonLeapYear = 2019;
        private const int LeapYear = 2020;

        [Fact]
        public void Should_Be_OK_When_Passed_Valid_Day()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,1);
            var day = new Day(month, 1);
            day.Should().NotBeNull();
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Day_Too_Low()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,1);
            Action action = () => new Day(month,0);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
        
        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Day_Too_High()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,1);
            Action action = () => new Day(month,32);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Be_Able_To_Retrieve_Value_For_Day_When_Given_Valid_Value()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,1);
            var day = new Day(month, 1);
            day.Value.Should().Be(1);
        }

        [Fact]
        public void Should_Be_OK_When_28_Passed_To_February()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year, 2);
            var day = new Day(month, 28);
            day.Value.Should().Be(28);

        }

        [Fact] // In a Non-leap year February should be 28
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_29_In_February_In_Non_Leap_Year()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,2);
            Action action = () => new Day(month,29);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Day_In_February_In_Leap_Year()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year,1);
            Action action = () => new Day(month,32);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Be_OK_When_Day_Of_Week_Is_Correct()
        {
            var year = new Year(NonLeapYear);
            var month = new Month(year, 7);
            var day = new Day(month, 14);
            Day.GetDayOfWeek(year.Value, month.Value, day.Value).Should().Be("Sunday");
        }
    }
}
