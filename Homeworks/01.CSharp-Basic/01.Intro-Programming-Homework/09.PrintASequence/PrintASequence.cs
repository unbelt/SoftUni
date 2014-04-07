using System;

/* Print a Sequence
 *  Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
*/

class PrintASequence
{
    static void Main()
    {
        // Using 'for' loop
        for (int i = 2; i < 12; i++)
        {
            // Check if the number is even
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            else // if number is odd
            {
                Console.WriteLine(-i);
            }
        }
    }
}