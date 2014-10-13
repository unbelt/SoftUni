namespace Shapes
{
    using System;

    public class Circle : IShape
    {
        private double diameter;

        public Circle(double diameter)
        {
            this.Diameter = diameter;
        }

        public double Diameter
        {
            get
            {
                return this.diameter;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(this.GetType().Name + " cannot be negative number!");
                }

                this.diameter = value;
            }
        }

        public double CalculateArea()
        {
            return (Math.PI * Math.Pow(this.diameter, 2)) / 4;
        }

        public double CalculatePerimeter()
        {
            return Math.PI * this.diameter;
        }

        public override string ToString()
        {
            return string.Format("{0} - diameter: {1}", this.GetType().Name, this.diameter);
        }
    }
}