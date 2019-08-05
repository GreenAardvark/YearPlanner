using System;
using System.Collections.Generic;

namespace YearPlanner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // For every year that DateTime can handle...
            for (var year = DateTime.MinValue.Year; year < DateTime.MaxValue.Year; year++)
            {
                // Left offsets are determined by the day of the week on which the 1st of the month falls upon...
                var leftOffsets = new Dictionary<int, int>();
                for (var month = 1; month <= 12 ; month++)
                {
                    var start = new DateTime(year, month, 1);
                    leftOffsets.Add(month, GetLeftOffset(start));
                }

                // Determine widest month of this year...
                var widestMonthOfTheYear = 0;
                for (var month = 1; month <= 12; month++)
                {
                    var leftOffset = leftOffsets[month];
                    var width = leftOffset + DateTime.DaysInMonth(year, month); // Raise a bug with Microsoft, 9999!
                    if (width > widestMonthOfTheYear)
                    {
                        widestMonthOfTheYear = width;
                    }
                }

                // Right offsets are determined by the widest month subtract the number of days in that month subtract the left offset for that month...
                var rightOffsets = new Dictionary<int, int>();
                for (var month = 1; month <= 12; month++)
                {
                    var leftOffset = leftOffsets[month];
                    var rightOffset = widestMonthOfTheYear - leftOffset - DateTime.DaysInMonth(year, month);
                    rightOffsets.Add(month, rightOffset);
                }

                var left = GetOffsetsForDisplay(leftOffsets);
                var right = GetOffsetsForDisplay(rightOffsets);
                System.Console.WriteLine($"Year: {year}, Left: {left}, Width: {widestMonthOfTheYear}, Right: {right}");
            }
        }

        private static string GetOffsetsForDisplay(IReadOnlyDictionary<int, int> offsets)
        {
            var display = string.Empty;
            for (var month = 1; month <= 12; month++)
            {
                var offset = offsets[month];
                display += $"{offset},";
            }
            return display.Substring(0, display.Length - 1);
        }

        private static int GetLeftOffset(in DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday: return 0;
                case DayOfWeek.Tuesday: return 1;
                case DayOfWeek.Wednesday: return 2;
                case DayOfWeek.Thursday: return 3;
                case DayOfWeek.Friday: return 4;
                case DayOfWeek.Saturday: return 5;
                case DayOfWeek.Sunday: return 6;
            }
            throw new InvalidOperationException("Unexpected value for DayOfWeek!");
        }
    }
}
