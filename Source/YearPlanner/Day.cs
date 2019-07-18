using System;

namespace YearPlanner
{

    public class Day
    {
        public Month Parent { get; }

        public int Value { get;}

        //public string DayOfWeek { get; }

        public Day(Month parent, int value)
        {
            if (parent == null) throw new ArgumentNullException(nameof(Year), "Cannot be null.");
            if (value < 1) throw new ArgumentOutOfRangeException(nameof(value),"Value must be higher than 0.");
            if (value > 31) throw new ArgumentOutOfRangeException(nameof(value),"Value must be lower than or equal to 31.");
            if (value > 28)
            {
                var numberOfDaysInMonth = Month.GetNumberOfDaysInMonth(parent.Parent.Value, parent.Value);

                if (value > numberOfDaysInMonth)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid number of days in month.");
                }
            }
            
            Parent = parent;
            Value = value;
        }
    }
}
