using System;
using System.Numerics;

/* Catalan Numbers
 *  In combinatorics, the Catalan numbers are calculated by the following formula:
 *      Cn = (2n)! / (n + 1)! * n! for n >= 0.
 *  Write a program to calculate the nth Catalan number by given n (1 < n < 100). 
 */

class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        long numberN = long.Parse(Console.ReadLine());

        if (numberN == 0)
        {
            Console.WriteLine(1);
        }

        if (numberN > 0)
        {
            BigInteger nFactoriel = 1;
            BigInteger multipliedNFact = 1;
            BigInteger nPlusOneFact = 1;

            for (long i = 1; i <= 2 * numberN; i++)
            {
                if (i <= numberN)
                {
                    nFactoriel = nFactoriel * i;
                    multipliedNFact = nFactoriel;
                }

                if (i == numberN + 1)
                {
                    nPlusOneFact = nFactoriel * i;
                    multipliedNFact = nPlusOneFact;
                }

                if (i > numberN + 1)
                {
                    multipliedNFact = multipliedNFact * i;
                }
            }

            BigInteger result = multipliedNFact / (nPlusOneFact * nFactoriel);

            Console.WriteLine(result);
        }
    }
}