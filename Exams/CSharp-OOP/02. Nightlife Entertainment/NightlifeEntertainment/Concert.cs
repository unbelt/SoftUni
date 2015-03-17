﻿namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Concert : Performance
    {
        public Concert(string name, decimal basePrice, IVenue venue, DateTime startTime)
            : base(name, basePrice, venue, startTime, PerformanceType.Concert)
        {

        }

        protected override void ValidateVenue()
        {
            if (!this.Venue.AllowedTypes.Contains(PerformanceType.Concert))
            {
                throw new InvalidOperationException(
                    string.Format("The venue {0} does not support the type of performance {1}", this.Venue.Name, this.Type));
            }
        }
    }
}
