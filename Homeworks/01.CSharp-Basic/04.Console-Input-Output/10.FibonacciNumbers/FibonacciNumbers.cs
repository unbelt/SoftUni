using System;
using System.Numerics;

/* Fibonacci Numbers
 *  Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by spaces):
 *  0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops.
 */

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int number = int.Parse(Console.ReadLine());

        // using 'BigInteger' in 'Numerics' namespace for large numbers
        BigInteger first = 0, second = 1;

        while (number-- != 0)
        {
            Console.WriteLine(first);

            second = first + second;
            first = second - first;
        }
    }
}