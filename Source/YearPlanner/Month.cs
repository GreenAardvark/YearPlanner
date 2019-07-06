using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YearPlanner
{
    public class Month
    {
        public Year Parent { get; }

        public int Value { get;}

        private Dictionary<int, Day> _days ;
        
        public IEnumerable<Day> Days
        {
            get
            {
                if (_days == null)
                {
                    _days = new Dictionary<int, Day>();
                    for (var i = 1; i <= GetNumberOfDaysInMonth(Parent.Value, Value); i++)
                    {
                        var day = new Day(this, i);
                        _days.Add(i, day);
                    }
                }
                return _days.Values.ToList();
            }
        }

        public Month(Year parent, int value)
        {
            if (parent == null) throw new ArgumentNullException(nameof(Year), "Cannot be null.");
            if (value < 1) throw new ArgumentOutOfRangeException(nameof(value),"Value must be higher than 0.");
            if (value > 12) throw new ArgumentOutOfRangeException(nameof(value),"Value must be lower than or equal to 12.");

            Parent = parent;
            Value = value;
        }
        
        public static int GetNumberOfDaysInMonth(int year, int month)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }
    }
}
