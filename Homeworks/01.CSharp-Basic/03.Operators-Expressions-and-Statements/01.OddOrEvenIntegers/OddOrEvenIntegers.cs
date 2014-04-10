using System;

/* Odd or Even Integers
 *  Write an expression that checks if given integer is odd or even.
 */

public class OddOrEvenIntegers
{
    public static void Main()
    {
        // Using Random class
        Random random = new Random();

        // Generate random numbers in range from 1 to 99
        int randomNumber = random.Next(1, 100);

        Console.WriteLine("The number {0} is {1}. ", randomNumber, randomNumber % 2 == 0 ? "even" : "odd");
    }
}