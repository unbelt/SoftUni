﻿namespace Methods
{
    using System;

    public static class Methods
    {
        private static readonly string[] DigitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException("Sides must be positive!");
            }

            if (a > b + c && b > c + a && c > a + b)
            {
                throw new ArgumentException("These sides don't form a triangle!");
            }

            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static string DigitToString(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException("The number must be in the range [0, 9].");
            }

            return DigitNames[digit];
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Elements must not be null!");
            }

            if (elements.Length <= 0)
            {
                throw new ArgumentException("Call with at least one argument!");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsFixedPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintRightAligned(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool AreVertical(Point point1, Point point2)
        {
            return point1.X == point2.X;
        }

        public static bool AreHorizontal(Point point1, Point point2)
        {
            return point1.Y == point2.Y;
        }

        public static double CalculateDistance(Point point1, Point point2)
        {
            double x = Math.Pow(point2.X - point1.X, 2);
            double y = Math.Pow(point2.Y - point1.Y, 2);

            return Math.Sqrt(x + y);
        }

        /// <summary>
        /// Test Methods here
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFixedPoint(1.3);
            PrintAsPercent(0.75);
            PrintRightAligned(2.30);

            {
                Point p1 = new Point(3, -1);
                Point p2 = new Point(3, 2.5);

                Console.WriteLine("Distance: " + CalculateDistance(p1, p2));
                Console.WriteLine("Horizontal? " + AreHorizontal(p1, p2));
                Console.WriteLine("Vertical? " + AreVertical(p1, p2));
            }

            {
                Student peter = new Student() { FirstName = "Pesho", LastName = "Ivanov", };
                peter.BirthDate = new DateTime(1992, 03, 17);
                peter.OtherInfo = "From Sofia";

                Student stella = new Student() { FirstName = "Nina", LastName = "Markova" };
                stella.BirthDate = new DateTime(1993, 11, 03);
                stella.OtherInfo = "From Vidin";

                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
        }

        public struct Point
        {
            public Point(double x, double y)
                : this()
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; private set; }

            public double Y { get; private set; }
        }
    }
}