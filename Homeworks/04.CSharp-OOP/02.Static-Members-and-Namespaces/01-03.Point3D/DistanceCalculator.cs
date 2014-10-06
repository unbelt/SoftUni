namespace Point3D
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point pointA, Point pointB)
        {
            // 3D distance formula: http://en.wikipedia.org/wiki/Euclidean_distance
            double distance = Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) +
                                 Math.Pow(pointA.Y - pointB.Y, 2) +
                                 Math.Pow(pointA.Z - pointB.Z, 2));

            return distance;
        }
    }
}