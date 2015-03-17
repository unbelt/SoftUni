namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert })
        {
        }

        public override string ToString()
        {
            var printConcertHall = new StringBuilder(base.ToString());

            return printConcertHall.ToString();
        }
    }
}
