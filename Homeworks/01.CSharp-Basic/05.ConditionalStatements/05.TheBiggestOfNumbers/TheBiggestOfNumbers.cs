using System;
using System.Globalization;
using System.Linq;

/* The Biggest of 3 Numbers
 *  Write a program that finds the biggest of three numbers.
 */

class TheBiggestOfNumbers
{
    static void Main()
    {
        #region User Input
        var numbers = new float[3];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number #{0}: ", i + 1);
            numbers[i] = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        #endregion

        // using Max(); method in Linq namespace
        Console.WriteLine(numbers.Max());
    }
}