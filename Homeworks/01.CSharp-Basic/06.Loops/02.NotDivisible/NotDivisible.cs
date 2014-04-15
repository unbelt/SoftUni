using System;

/* Numbers Not Divisible by 3 and 7
 *  Write a program that enters from the console a positive integer n
 *  and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space.
 */

class NotDivisible
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i <= number; i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                continue; // this will skip the iteration
            }

            Console.Write("{0} ", i);
        }

        Console.WriteLine();
    }
}