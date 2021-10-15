using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Modules.Locations.Classes
{
    public class Week
    {
        private List<Day> days { get; set; }
        public List<Day> Days { get { return days; } }

        public Week()
        {
            days = new List<Day>();
            for (int i = 0; i < 7; i++)
                days.Add(new Day(i));
        }

        public void SetTimeFor(DayOfWeek dayOfWeek, DateTime open, DateTime close)
        {
            Day day = days.Where(h => h.Name == dayOfWeek).FirstOrDefault();
            day.SetOpen(open);
            day.SetClose(close);
        }
    }
}