using System;

/* Matrix of Numbers
 *  Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix.
 *  Use two nested loops. 
 */

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        long numberN = long.Parse(Console.ReadLine());

        for (int row = 0; row < numberN; row++)
        {
            for (int col = row + 1; col <= numberN + row; col++)
            {
                Console.Write(" " + col);
            }

            Console.WriteLine();
        }
    }
}