using System;
using System.Globalization;

/* Circle Perimeter and Area
 *  Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point
 */

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter number r: ");
        string input = Console.ReadLine().Replace(',', '.');

        double circleRadius = double.Parse(input, CultureInfo.InvariantCulture);

        double circlePerimeter = Math.PI * 2 * circleRadius,
               curcleArea      = Math.PI * Math.Pow(circleRadius, 2);

        Console.WriteLine(" r: {0} \r\n perimeter = {1:0.00} \r\n area = {2:0.00}", circleRadius, circlePerimeter, curcleArea);
    }
}