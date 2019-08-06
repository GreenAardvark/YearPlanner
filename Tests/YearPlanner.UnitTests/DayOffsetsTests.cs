using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace YearPlanner.UnitTests
{
    public class DayOffsetsTests
    {
        private const int NonLeapYear = 2019;

        // This is actually an integration test as it tests 2 components working together (Year and DayOffsets).
        [Fact]
        public void Should_Be_OK_When_Passed_Valid_Year()
        {
            // Arrange...
            var year = new Year(NonLeapYear);

            // Act...
            var dayOffsets = new DayOffsets(year);

            // Assert...
            dayOffsets.LeftOffsets.Should().NotBeNull();
            dayOffsets.RightOffsets.Should().NotBeNull();
            // Requires more tests!
        }

        [Fact]
        public void LeftOffsets_Should_Contain_Certain_Values_When_Year_Is_2019()
        {
            var year = new Year(NonLeapYear);

            var dayOffsets = new DayOffsets(year);

            var validFor2019LeftOffsets = new Dictionary<int, int>();

            validFor2019LeftOffsets.Add(1, 1);
            validFor2019LeftOffsets.Add(2, 4);
            validFor2019LeftOffsets.Add(3, 4);
            validFor2019LeftOffsets.Add(4, 0);
            validFor2019LeftOffsets.Add(5, 2);
            validFor2019LeftOffsets.Add(6, 5);
            validFor2019LeftOffsets.Add(7, 0);
            validFor2019LeftOffsets.Add(8, 3);
            validFor2019LeftOffsets.Add(9, 6);
            validFor2019LeftOffsets.Add(10, 1);
            validFor2019LeftOffsets.Add(11, 4);
            validFor2019LeftOffsets.Add(12, 6);



            dayOffsets.LeftOffsets.Should().Equal(validFor2019LeftOffsets);
        }

        [Fact]
        public void RightOffsets_Should_Contain_Certain_Values_When_Year_Is_2019()
        {
            var year = new Year(NonLeapYear);

            var dayOffsets = new DayOffsets(year);

            var validFor2019RightOffsets = new Dictionary<int, int>();

            validFor2019RightOffsets.Add(1, 5);
            validFor2019RightOffsets.Add(2, 5);
            validFor2019RightOffsets.Add(3, 2);
            validFor2019RightOffsets.Add(4, 7);
            validFor2019RightOffsets.Add(5, 4);
            validFor2019RightOffsets.Add(6, 2);
            validFor2019RightOffsets.Add(7, 6);
            validFor2019RightOffsets.Add(8, 3);
            validFor2019RightOffsets.Add(9, 1);
            validFor2019RightOffsets.Add(10, 5);
            validFor2019RightOffsets.Add(11, 3);
            validFor2019RightOffsets.Add(12, 0);



            dayOffsets.RightOffsets.Should().Equal(validFor2019RightOffsets);
        }
    }
}
