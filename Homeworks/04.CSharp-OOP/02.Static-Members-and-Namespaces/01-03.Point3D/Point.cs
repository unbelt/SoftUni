namespace Point3D
{
    using System;
    using System.Text;

    public struct Point
    {
        private static readonly Point StartingPoint = new Point(0, 0, 0);

        public Point(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);

            return print.ToString();
        }
    }
}