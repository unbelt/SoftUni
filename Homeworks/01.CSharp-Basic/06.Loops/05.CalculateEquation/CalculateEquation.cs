using System;

/* Calculate 1 + 1!/X + 2!/X2 + … + N!/XN
 *  Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn.
 *  Use only one loop. Print the result with 5 digits after the decimal point.
 */

class CalculateEquation
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());

        Console.Write("Enter number x: ");
        int numberX = int.Parse(Console.ReadLine());
        #endregion

        double sum = 1;
        double current = 1;

        for (double i = 1; i <= numberN; i++)
        {
            sum += current *= i / numberX;
        }

        Console.WriteLine("{0:0.00000}", sum);
    }
}