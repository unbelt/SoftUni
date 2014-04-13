using System;
using System.Globalization;

/* Sort 3 Numbers with Nested Ifs
 *  Write a program that enters 3 real numbers and prints them sorted in descending order.
 *  Use nested if statements.
 *  Don’t use arrays and the built-in sorting functionality.
 */

class SortNumbers
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        float numberA = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        Console.Write("Enter number b: ");
        float numberB = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        Console.Write("Enter number c: ");
        float numberC = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        #endregion


        if (numberA > numberB && numberA > numberC)
        {
            if (numberB > numberC)
            {
                Console.WriteLine("{0} {1} {2}", numberA, numberB, numberC);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberA, numberC, numberB);
            }
        }
        else if(numberB > numberC && numberB > numberA)
        {
            if (numberC > numberA)
            {
                Console.WriteLine("{0} {1} {2}", numberB, numberC, numberA);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberB, numberA, numberC);
            }
        }
        else if (numberC > numberA && numberC > numberB)
        {
            if (numberA > numberB)
            {
                Console.WriteLine("{0} {1} {2}", numberC, numberA, numberB);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberC, numberB, numberA);
            }
        }
        else // All numbers are equal
        {
            Console.WriteLine("{0} {1} {2}", numberA, numberB, numberC);
        }
    }
}