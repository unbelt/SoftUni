using System;

class TrapezoidArea
{
    static void Main()
    {
        double sideA = 8.5d;
        double sideB = 4.3d;
        double height = 2.7d;

        // Formula for calculating trapezoid area
        double area = ((sideA + sideB) / 2) * height;

        Console.WriteLine("The trapezoid's area is: {0:0.0#}", area);
    }
}