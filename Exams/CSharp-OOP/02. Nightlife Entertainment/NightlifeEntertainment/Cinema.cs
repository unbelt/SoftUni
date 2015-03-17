namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cinema : Venue
    {
        public Cinema(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Movie, PerformanceType.Concert })
        {
        }

        public override string ToString()
        {
            var printCinema = new StringBuilder(base.ToString());

            return printCinema.ToString();
        }
    }
}
