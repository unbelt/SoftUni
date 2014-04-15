using System;

/* Calculate N! / K!
 *  Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
 *  Use only one loop.
 */

class CalculateFactorial
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());

        Console.Write("Enter number k: ");
        int numberK = int.Parse(Console.ReadLine());
        #endregion

        int result = 1;

        for (int i = 0; i < (numberN - numberK); i++)
        {
            result = result * (numberN - i);
        }

        Console.WriteLine(result);
    }
}