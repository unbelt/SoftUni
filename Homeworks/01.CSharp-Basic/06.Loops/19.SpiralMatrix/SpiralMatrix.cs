using System;

/* Spiral Matrix
 *  Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20)
 *  and prints a matrix holding the numbers from 1 to n*n in the form of square spiral. 
 */

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter number n:");
        int numberN = int.Parse(Console.ReadLine());

        // 2D array for the spiral
        int[,] spiral = new int[numberN, numberN];

        // String direction
        string direction = "right";

        int currentRow = 0;
        int currentCol = 0;

        // Main loop
        for (int i = 1; i <= numberN * numberN; i++)
        {
            if (direction == "right" && (currentCol >= numberN || spiral[currentRow, currentCol] != 0))
            {
                currentCol--;
                currentRow++;
                direction = "down";
            }
            else if (direction == "down" && (currentRow >= numberN || spiral[currentRow, currentCol] != 0))
            {
                currentRow--;
                currentCol--;
                direction = "left";
            }
            else if (direction == "left" && (currentCol < 0 || spiral[currentRow, currentCol] != 0))
            {
                currentCol++;
                currentRow--;
                direction = "up";
            }
            else if (direction == "up" && (currentRow < 0 || spiral[currentRow, currentCol] != 0))
            {
                currentRow++;
                currentCol++;
                direction = "right";
            }

            spiral[currentRow, currentCol] = i;

            if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "left")
            {
                currentCol--;
            }
            else if (direction == "up")
            {
                currentRow--;
            }
        }

        // Loop for printing
        for (int i = 0; i < numberN; i++)
        {
            for (int j = 0; j < numberN; j++)
            {
                // Styling
                if (spiral[i, j] < 10)
                {
                    Console.Write("".PadRight(3) + spiral[i, j]);
                }
                else if (spiral[i, j] >= 10 && spiral[i, j] < 100)
                {
                    Console.Write("".PadRight(2) + spiral[i, j]);
                }
                else
                {
                    Console.Write("".PadRight(1) + spiral[i, j]);
                }
            }

            Console.WriteLine();
        }
    }
}