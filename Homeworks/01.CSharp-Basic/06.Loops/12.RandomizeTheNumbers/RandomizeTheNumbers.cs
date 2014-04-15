using System;

/* Randomize the Numbers 1…N
 *  Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
 */

class RandomizeTheNumbers
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());

        Random randomNumbers = new Random();

        for (int i = 1; i <= numberN; i++)
        {
            Console.Write(randomNumbers.Next(1, numberN + 1) + " ");
        }

        Console.WriteLine();
    }
}