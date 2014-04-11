using System;
using System.Globalization;

/* Sum of 3 Numbers
 *  Write a program that reads 3 real numbers from the console and prints their sum.
 */

class SumOfThreeNumbers
{
    static void Main()
    {
        #region User input
        Console.Write("Enter number a: ");
        string firstNumString = Console.ReadLine().Replace(',', '.');

        Console.Write("Enter number b: ");
        string secondNumString = Console.ReadLine().Replace(',', '.');

        Console.Write("Enter number c: ");
        string thirdNumString = Console.ReadLine().Replace(',', '.');
        #endregion

        // using 'InvariantCulture' for ensuring correct format
        float firstNumber = float.Parse(firstNumString, CultureInfo.InvariantCulture);
        float secondNumber = float.Parse(secondNumString, CultureInfo.InvariantCulture);
        float thirdNumber = float.Parse(thirdNumString, CultureInfo.InvariantCulture);

        float sum = firstNumber + secondNumber + thirdNumber;

        Console.WriteLine("{0} + {1} + {2} = {3:0.#}", firstNumber, secondNumber, thirdNumber, sum);
    }
}