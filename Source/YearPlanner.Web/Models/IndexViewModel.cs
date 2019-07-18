using YearPlanner.Web.Controllers;

namespace YearPlanner.Web.Models
{
    public class IndexViewModel
    {
        public int YearValue { get; set; }

        public Year Year { get; set; }

        public DayOffsets DayOffsets { get; internal set; }
    }
}