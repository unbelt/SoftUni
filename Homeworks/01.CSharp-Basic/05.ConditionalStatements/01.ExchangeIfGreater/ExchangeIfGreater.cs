using System;
using System.Globalization;

/* Exchange If Greater
 *  Write an if-statement that takes two integer variables a and b and exchanges their values if the first one is greater than the second one.
 *  As a result print the values a and b, separated by a space.
 */

class ExchangeIfGreater
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        float numberA = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

        Console.Write("Enter number b: ");
        float numberB = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        #endregion

        // Simple if{...} else{...} statement
        if (numberA > numberB)
        {
            Console.WriteLine("{0} {1}", numberB, numberA);
        }
        else
        {
            Console.WriteLine("{0} {1}", numberA, numberB);
        }
    }
}