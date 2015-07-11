namespace DistanceCalculatorConsoleClient
{
    using System;

    using DistanceCalculatorService;

    public class Program
    {
        private static readonly DistanceCalculatorClient Calculator = new DistanceCalculatorClient();

        public static void Main()
        {
            var pointA = new Point() { X = 1, Y = 2 };
            var pointB = new Point() { X = 10, Y = 20 };

            var result = Calculator.CalculateDistance(pointA, pointB);

            Console.WriteLine("Point A: X = {0}; Y = {1} \r\nPoint B: X = {2}; Y = {3} \r\nDistance = {4}",
                pointA.X, pointA.Y, pointB.X, pointB.Y, result.ToString("F"));
        }
    }
}