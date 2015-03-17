namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SportsHall : Venue
    {
        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }

        public override string ToString()
        {
            var printSportsHall = new StringBuilder(base.ToString());

            return printSportsHall.ToString();
        }
    }
}
