using System;
using System.Collections.Generic;
using System.Linq;

/* Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
 * If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100.
 * If the user enters an invalid number, let the user to enter again.
 */

public class EnterNumbers
{
    public static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(null, "The number must be in rage [" + start + "..." + end + "]");
        }

        return number;
    }

    public static void Main()
    {
        int min = 1;
        int max = 100;
        int count = 10;

        var numbers = new List<int>();

        do
        {
            Console.Write("Enter a number #{0}: ", numbers.Count() + 1);

            try
            {
                int number = ReadNumber(min, max);

                if (numbers.Count != 0 && numbers.Max() >= number)
                {
                    throw new ArgumentOutOfRangeException(null, "The number must be bigger than the rest.");
                }

                numbers.Add(number);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (numbers.Count() < count);

        Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));
    }
}