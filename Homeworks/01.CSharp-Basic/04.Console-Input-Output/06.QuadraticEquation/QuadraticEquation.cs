using System;
using System.Globalization;

/* Quadratic Equation
 *  Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
 */

class QuadraticEquation
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        string inputA = Console.ReadLine().Replace(',', '.');
        double a = double.Parse(inputA, CultureInfo.InvariantCulture);

        Console.Write("Enter number b: ");
        string inputB = Console.ReadLine().Replace(',', '.');
        double b = double.Parse(inputB, CultureInfo.InvariantCulture);

        Console.Write("Enter number c: ");
        string inputC = Console.ReadLine().Replace(',', '.');
        double c = double.Parse(inputC, CultureInfo.InvariantCulture);
        #endregion

        // Formula for calculating discriminant
        double discriminant = b * b - 4 * a * c;

        Console.Write("roots: ");

        if (discriminant > 0)
        {
            // Formula for calculating roots
            Console.WriteLine("x1={0}; x2={1}",(-b - Math.Sqrt(discriminant)) / (2 * a), (-b + Math.Sqrt(discriminant)) / (2 * a));
        }
        else if (discriminant == 0)
        {
            Console.WriteLine("x1=x2={0}", -b / (2 * a));
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}