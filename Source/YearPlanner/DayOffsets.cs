using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YearPlanner
{
    public class DayOffsets
    {
        private Year _year;

        private Dictionary<int, int> _leftOffsets;
        private Dictionary<int, int> _rightOffsets;

        public Dictionary<int, int> LeftOffsets => _leftOffsets;
        public Dictionary<int, int> RightOffsets => _rightOffsets;

        public void CalculateDayOffsets()
        {
            var highestSundays = new Dictionary<int, int>();

            var highestSunday = 0;
            foreach (var month in _year.Months)
            {
                foreach (var day in month.Days)
                {
                    var dt = new DateTime(_year.Value, month.Value, day.Value);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        highestSundays.Add(month.Value, day.Value);

                        if (dt.Day > highestSunday)
                        {
                            highestSunday = dt.Day;
                        }

                        break;
                    }
                }
            }

            foreach (var kvp in highestSundays)
            {
                var month = kvp.Key;
                var day = kvp.Value;

                _leftOffsets.Add(month, highestSunday - day);
            }

        }

        public DayOffsets(Year year)
        {
            // Is year object valid? If not, throw error. null checking.

            _year = year;

            _leftOffsets = new Dictionary<int, int>();
            _rightOffsets = new Dictionary<int, int>();

            CalculateDayOffsets();
        }
    }
}