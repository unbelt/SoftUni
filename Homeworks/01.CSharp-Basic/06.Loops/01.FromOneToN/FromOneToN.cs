using System;

/* Numbers from 1 to N
 *  Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space.
 */

class Program
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            Console.Write("{0} ", i + 1);
        }
        Console.WriteLine();
    }
}