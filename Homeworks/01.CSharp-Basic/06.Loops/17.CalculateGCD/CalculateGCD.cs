using System;

/* Calculate GCD
 *  Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
 *  Use the Euclidean algorithm (find it in Internet). 
 */

class CalculateGCD
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        int numberA = int.Parse(Console.ReadLine());

        Console.Write("Enter number b: ");
        int numberB = int.Parse(Console.ReadLine());
        #endregion

        // Endless loop!
        while (true)
        {
            if (numberA < numberB)
            {
                int temp = numberA;
                numberA = numberB;
                numberB = temp;
            }
            else
            {
                int temp2 = numberB;
                numberB = numberA % numberB;
                numberA = temp2;
            }

            if (numberA % numberB == 0)
            {
                Console.WriteLine(numberB);
                break;
            }
        }
    }
}