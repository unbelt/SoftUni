using System;
using System.Numerics;

/* Calculate N! / (K! * (N-K)!)
 *  In combinatorics, the number of ways to choose k different members out of a group of n different elements
 *  (also known as the number of combinations) is calculated by the following formula:
 *      (n/k) = n!/(k!(n-k))
 *  For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
 *  Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100).
 *  Try to use only two loops. 
 */

class CalculateComplexFactorial
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());
        Console.Write("nter number k: ");
        int numberK = int.Parse(Console.ReadLine());
        #endregion

        if (numberN > 1 && numberK > 1 && numberN < 100 && numberK < 100)
        {
            BigInteger factN = 1;
            BigInteger factK = 1;
            BigInteger factNAndK = 1;
            BigInteger result = 0;

            for (int i = 1; i <= numberN; i++)
            {
                factN *= i;
            }

            for (int j = 1; j <= numberK; j++)
            {
                factK *= j;
            }

            for (int z = 1; z <= numberN - numberK; z++)
            {
                factNAndK *= z;
            }

            result = factN / (factK * factNAndK);

            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}