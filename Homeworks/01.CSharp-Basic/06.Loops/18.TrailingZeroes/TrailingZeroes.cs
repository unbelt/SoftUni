using System;
using System.Numerics;

/* Trailing Zeroes in N!
 *  Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
 *  Your program should work well for very big numbers, e.g. n=100000.
 */

class TrailingZeroes
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());

        BigInteger number = 1;
        BigInteger nFact = 1;
        int counter = 0;

        // Calculate number's factorial
        for (int i = 1; i <= numberN; i++)
        {
            number = number *= i;
            nFact = number;
        }

        // Loop for checking is there a zero at the end
        while (nFact % 5 == 0)
        {
            counter++;
            nFact /= 10; // Remove the last zero
        }

        Console.WriteLine(" N = {0} \r\n N! = {1} \r\n trailing zeroes of n! - {2}", numberN, number, counter);
    }
}