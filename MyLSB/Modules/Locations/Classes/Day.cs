using System;

namespace MyLSB.Modules.Locations.Classes
{
    public class Day
    {
        private DayOfWeek name;
        private DateTime open;
        private DateTime close;

        public Day(int day)
        {
            name = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day.ToString());
        }
        public DayOfWeek Name { get { return name; } }
        public DateTime Open { get { return open; } }
        public DateTime Close { get { return close; } }
        public bool Closed
        {
            get
            {
                if (open.TimeOfDay == close.TimeOfDay)
                    return true;
                return false;
            }
        }

        internal void SetOpen(DateTime open)
        {
            this.open = open;
        }

        internal void SetClose(DateTime close)
        {
            this.close = close;
        }
    }
}