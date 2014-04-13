using System;
using System.Globalization;

/* The Biggest of Five Numbers
 *  Write a program that finds the biggest of five numbers by using only five if statements.
 */

class TheBiggestNumber
{
    static void Main()
    {
        #region User Input
        var numbers = new float[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number #{0}: ", i + 1);
            numbers[i] = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        #endregion

        float biggestNumber = float.MinValue;

        // using for{} loop to cover more than 5 numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            if (biggestNumber < numbers[i])
            {
                biggestNumber = numbers[i];
            }
        }

        Console.WriteLine(biggestNumber);
    }
}