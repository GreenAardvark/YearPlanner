using System;
using FluentAssertions;
using Xunit;

namespace YearPlanner.UnitTests
{
    public class MonthTests
    {
        private const int LeapYear = 2020;
        private const int NonLeapYear = 2019;
        private const int NumberOfDaysInJanuary = 31;
        private const int NumberOfDaysInFebruaryNonLeapYear = 28;
        private const int NumberOfDaysInFebruaryLeapYear = 29;
        private const int NumberOfDaysInMarch = 31;
        private const int NumberOfDaysInApril = 30;
        private const int NumberOfDaysInMay = 31;
        private const int NumberOfDaysInJune = 30;
        private const int NumberOfDaysInJuly = 31;
        private const int NumberOfDaysInAugust = 31;
        private const int NumberOfDaysInSeptember = 30;
        private const int NumberOfDaysInOctober = 31;
        private const int NumberOfDaysInNovember = 30;
        private const int NumberOfDaysInDecember = 31;

        [Fact]
        public void Should_Be_OK_When_Passed_Valid_Month()
        {
            var month = new Month(new Year(NonLeapYear), 3);
            month.Should().NotBeNull();
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Month_Too_Low()
        {
            Action action = () => new Month(new Year(NonLeapYear),0);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
        
        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Passed_Month_Too_High()
        {
            Action action = () => new Month(new Year(NonLeapYear),13);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Be_Able_To_Retrieve_Value_For_Month_When_Given_Valid_Value()
        {
            var month = new Month(new Year(NonLeapYear),3);
            month.Value.Should().Be(3);
        }

        [Fact] //January
        public void Should_Contain_31_Days_When_Month_Is_January()
        {
            var month = new Month(new Year(NonLeapYear),1);
            month.Days.Should().HaveCount(NumberOfDaysInJanuary);
        }

        [Fact] //February
        public void Should_Contain_28_Days_When_Month_Is_February_And_Is_Not_Leap_Year()
        {
            var month = new Month(new Year(NonLeapYear),2);
            month.Days.Should().HaveCount(NumberOfDaysInFebruaryNonLeapYear);
        }

        [Fact] //February
        public void Should_Contain_29_Days_When_Month_Is_February_And_Is_Leap_Year()
        {
            var month = new Month(new Year(LeapYear),2);
            month.Days.Should().HaveCount(NumberOfDaysInFebruaryLeapYear);
        }

        [Fact] //March
        public void Should_Contain_31_Days_When_Month_Is_March()
        {
            var month = new Month(new Year(NonLeapYear),3);
            month.Days.Should().HaveCount(NumberOfDaysInMarch);
        }

        [Fact] //April
        public void Should_Contain_30_Days_When_Month_Is_April()
        {
            var month = new Month(new Year(NonLeapYear),4);
            month.Days.Should().HaveCount(NumberOfDaysInApril);
        }

        [Fact] //May    
        public void Should_Contain_31_Days_When_Month_Is_May()
        {
            var month = new Month(new Year(NonLeapYear),5);
            month.Days.Should().HaveCount(NumberOfDaysInMay);
        }

        [Fact] //June
        public void Should_Contain_30_Days_When_Month_Is_June()
        {
            var month = new Month(new Year(NonLeapYear),6);
            month.Days.Should().HaveCount(NumberOfDaysInJune);
        }

        [Fact] //July
        public void Should_Contain_31_Days_When_Month_Is_July()
        {
            var month = new Month(new Year(NonLeapYear),7);
            month.Days.Should().HaveCount(NumberOfDaysInJuly);
        }

        [Fact] //August
        public void Should_Contain_31_Days_When_Month_Is_August()
        {
            var month = new Month(new Year(NonLeapYear),8);
            month.Days.Should().HaveCount(NumberOfDaysInAugust);
        }

        [Fact] //September
        public void Should_Contain_30_Days_When_Month_Is_September()
        {
            var month = new Month(new Year(NonLeapYear),9);
            month.Days.Should().HaveCount(NumberOfDaysInSeptember);
        }

        [Fact] //October
        public void Should_Contain_31_Days__When_Month_Is_October()
        {
            var month = new Month(new Year(NonLeapYear),10);
            month.Days.Should().HaveCount(NumberOfDaysInOctober);
        }

        [Fact] //November
        public void Should_Contain_30_Days__When_Month_Is_November()
        {
            var month = new Month(new Year(NonLeapYear),11);
            month.Days.Should().HaveCount(NumberOfDaysInNovember);
        }

        [Fact] //December
        public void Should_Contain_31_Days__When_Month_Is_December()
        {
            var month = new Month(new Year(NonLeapYear),12);
            month.Days.Should().HaveCount(NumberOfDaysInDecember);
        }
    }
}
