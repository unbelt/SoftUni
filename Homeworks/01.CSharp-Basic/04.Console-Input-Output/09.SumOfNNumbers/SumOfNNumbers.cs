using System;
using System.Globalization;

/* Sum of n Numbers
 *  Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.
 *  Note that you may need to use a for-loop.
 */

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("Enter numbers count: ");
        int numbersCount = int.Parse(Console.ReadLine());

        string input = string.Empty;
        float number = 0f, sum = 0f;

        for (int i = 1; i <= numbersCount; i++)
        {
            Console.Write("Enter number #{0}: ", i);
            input = Console.ReadLine().Replace(',', '.');
            number = float.Parse(input, CultureInfo.InvariantCulture);
            sum += number;
        }

        Console.WriteLine(Environment.NewLine + "sum = {0:0.#}", sum);
    }
}