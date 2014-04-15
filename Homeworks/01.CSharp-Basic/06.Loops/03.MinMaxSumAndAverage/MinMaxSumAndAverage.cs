using System;
using System.Linq;

/* Min, Max, Sum and Average of N Numbers
 *  Write a program that reads from the console a sequence of n integer numbers and returns
 *  the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
 *  The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
 */

class MinMaxSumAndAverage
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter count of numbers: ");
        int numCount = int.Parse(Console.ReadLine());

        var numbers = new int[numCount];

        for (int i = 0; i < numCount; i++)
        {
            Console.Write("Enter number #{0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        #endregion

        // using methods in Linq namespace for the task
        Console.WriteLine(" min = {0} \r\n max = {1} \r\n sum = {2} \r\n avg = {3:0.00}", 
            numbers.Min(), numbers.Max(), numbers.Sum(), numbers.Average());
    }
}