namespace DistanceCalculator_SOAP
{
    using System;

    public class DistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Point pointA, Point pointB)
        {
            double deltaX = pointA.X - pointB.X;
            double deltaY = pointA.Y - pointB.Y;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }
    }
}