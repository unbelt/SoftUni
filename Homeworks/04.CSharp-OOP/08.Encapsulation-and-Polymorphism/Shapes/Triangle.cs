namespace Shapes
{
    using System;

    public class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return 0.5 * (this.Width * this.Height);
        }

        public override double CalculatePerimeter()
        {
            return this.Width + (this.Height * 2);
        }
    }
}