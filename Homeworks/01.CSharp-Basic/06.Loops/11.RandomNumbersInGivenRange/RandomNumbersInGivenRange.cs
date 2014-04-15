using System;

/* Random Numbers in Given Range
 *  Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers in the range [min...max].
 */

class RandomNumbersInGivenRange
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number n: ");
        int numberN = int.Parse(Console.ReadLine());

        Console.Write("Enter min number: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Enter max number: ");
        int max = int.Parse(Console.ReadLine());
        #endregion

        Random randomNumber = new Random();

        for (int i = 0; i < numberN; i++)
        {
            Console.Write(randomNumber.Next(min, max + 1) + " ");
        }

        Console.WriteLine();
    }
}