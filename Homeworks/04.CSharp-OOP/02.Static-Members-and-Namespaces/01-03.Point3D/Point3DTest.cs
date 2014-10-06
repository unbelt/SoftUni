namespace Point3D
{
    using System;
    using System.Collections.Generic;

    public class Point3DTest
    {
        public static void Main()
        {
            // Make two points
            var pointA = new Point(5, 6, 2);
            var pointB = new Point(-7, 11, -13);

            // Print the points
            Console.WriteLine("Point a: {0}", pointA);
            Console.WriteLine("Point b: {0}", pointB);
            Console.WriteLine();

            // Calculate the distance
            double distance = DistanceCalculator.CalculateDistance(pointA, pointB);
            Console.WriteLine("Distance [a -> b] = {0:0.00}", distance);

            // Add a points to the List<>
            var path = new Path3D();

            //path.AddPoint(pointA);
            path.AddPoint(pointB);

            // Save the points from the List<> to .txt
            Storage.SavePoint(path);
            Console.WriteLine();

            // Load the points from the file
            Console.WriteLine("Loaded points:");
            Storage.LoadPoint();
            Console.WriteLine();
        }
    }
}
