using System;
using System.Globalization;

/* Sum of 5 Numbers
 *  Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum. 
 */

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Enter five numbers [space separated]: ");

        // using Split() method to isolate each number in the array
        string[] numbers = Console.ReadLine().Replace(',', '.').Split(' ');
        
        float sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += float.Parse(numbers[i], CultureInfo.InvariantCulture);
        }

        // using 'string.Join()' method to avoid space at the end
        Console.WriteLine(" numbers: {0} \r\n sum = {1}", string.Join(" ", numbers), sum);
    }
}