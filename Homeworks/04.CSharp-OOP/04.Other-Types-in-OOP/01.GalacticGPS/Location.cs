namespace GalacticGPS
{
    using System;
    using System.Text;

    public struct Location
    {
        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        #region Properties

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Planet Planet { get; set; }

        #endregion

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);

            return print.ToString();
        }
    }
}