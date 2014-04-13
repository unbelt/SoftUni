using System;
using System.Globalization;

/* MultiplicationSign
 *  Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
 *  Use a sequence of if operators. 
 */

class MultiplicationSign
{
    static void Main()
    {
        var numbers = new float[3];
        int counter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number #{0}: ", i + 1);
            numbers[i] = float.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

            if (numbers[i] < 0)
            {
                counter++;
            }
        }

        // This will work for more than three numbers
        if (Array.IndexOf(numbers, 0) != -1)
        {
            Console.WriteLine("0");
        }
        else if (counter != numbers.Length && counter % 2 == 0)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("-");
        }
    }
}