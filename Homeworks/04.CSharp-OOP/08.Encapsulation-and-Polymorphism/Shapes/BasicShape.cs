namespace Shapes
{
    using System;

    public abstract class BasicShape : IShape
    {
        private double width;

        private double height;

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        #region Properties

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(this.GetType().Name + " width cannot be negative number!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(this.GetType().Name + " height cannot be negative number!");
                }

                this.height = value;
            }
        }
        #endregion

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public override string ToString()
        {
            return string.Format("{0} - Width: {1}; Height: {2}", this.GetType().Name, this.width, this.height);
        }
    }
}