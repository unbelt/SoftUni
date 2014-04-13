using System;

/* Zero Subset
 *  We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
 *  Assume that repeating the same subset several times is not a problem.
 */

class ZeroSubset
{
    static string[] input = Console.ReadLine().Split(new[] {' '});
    static int[] numbers = Array.ConvertAll(input, int.Parse);

    static int[] m = new int[input.Length]; // Combination indeces of numbers
    static int k; // Combination (k + 1)

    static bool haveSubset = false;

    static void Check()
    {
        int sum = 0;

        for (int i = 0; i <= k; i++)
        {
            sum += numbers[m[i]];
        }

        if (sum == 0)
        {
            haveSubset = true;

            for (int i = 0; i <= k; i++)
            {
                Console.Write(input[m[i]] + (i == k ? " = 0 \r\n" : " + "));
            }
        }
    }

    static void Combination(int i, int next)
    {
        if (i > k)
        {
            return;
        }

        for (int j = next; j < input.Length; j++)
        {
            m[i] = j;

            if (i == k)
            {
                Check();
            }

            Combination(i + 1, j + 1);
        }
    }

    static void Main()
    {
        // Generate combinations of all sizes
        for (k = 0; k < input.Length; k++)
        {
            Combination(0, 0);
        }

        if (!haveSubset)
        {
            Console.WriteLine("no zero subset");
        }
    }
}