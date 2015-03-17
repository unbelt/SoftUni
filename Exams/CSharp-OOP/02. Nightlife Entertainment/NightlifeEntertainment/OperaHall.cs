namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class OperaHall : Venue
    {
        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre })
        {
        }

        public override string ToString()
        {
            var printOperaHall = new StringBuilder(base.ToString());


            return printOperaHall.ToString();
        }
    }
}
