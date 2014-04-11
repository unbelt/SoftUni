using System;
using System.Collections.Generic;

/* Numbers in Interval Dividable by Given Number
 *  Write a program that reads two positive integer numbers and prints how many
 *  numbers p exist between them such that the reminder of the division by 5 is 0.
 */

class DividableNumbers
{
    static void Main()
    {
        #region User Input
        Console.Write("Starting number: ");
        int startingNumber = int.Parse(Console.ReadLine());

        Console.Write("Ending number: ");
        int endingNumber = int.Parse(Console.ReadLine());
        #endregion

        // using List<int>(); in 'Collections.Generic' namespace
        // for numbers storage
        var numbers = new List<int>();

        int counter = 0;

        for (int i = startingNumber; i <= endingNumber; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
                numbers.Add(i);
            }
        }

        Console.WriteLine(" start: {0} \r\n end: {1} \r\n p: {2} \r\n comments: {3}",
                            startingNumber, endingNumber, counter, string.Join(", ", numbers));
    }
}