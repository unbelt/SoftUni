using System;

/* Numbers from 1 to n
 *  Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.
 *  Note that you may need to use a for-loop.
 */

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int numberToCount = int.Parse(Console.ReadLine());

        Console.WriteLine("number: {0} \r\n result", numberToCount);

        for (int i = 1; i <= numberToCount; i++)
        {
            Console.WriteLine(i);
        }
    }
}