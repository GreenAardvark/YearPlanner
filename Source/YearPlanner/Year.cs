using System;
using System.Collections.Generic;
using System.Linq;

namespace YearPlanner
{
    public class Year
    {
        public int Value { get;}

        private Dictionary<int, Month> _months;

        public IEnumerable<Month> Months
        {
            get
            {
                if (_months == null)
                {
                    _months = new Dictionary<int, Month>();
                    for (var i = 1; i <= 12; i++)
                    {
                        var month = new Month(i);
                        _months.Add(i, month);
                    }
                }

                return _months.Values.ToList();
            }
        } 

        public Year(int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value),"Value must be higher than 0");
            if (value > 9999) throw new ArgumentOutOfRangeException(nameof(value),"Value must be lower than or equal to 9999");

            Value = value;
        }
    }
}
