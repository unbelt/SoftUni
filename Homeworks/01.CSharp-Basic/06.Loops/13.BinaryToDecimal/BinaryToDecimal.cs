using System;

/* Binary to Decimal Number
 *  Using loops write a program that converts a binary integer number to its decimal form.
 *  The input is entered as string. The output should be a variable of type long.
 *  Do not use the built-in .NET functionality. 
 */

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Binary number: ");
        string binNum = Console.ReadLine();

        int decNum = 0;

        // Convert to decimal
        for (int i = 0; i < binNum.Length; i++)
        {
            if (binNum[binNum.Length - i - 1] == '0')
            {
                continue;
            }

            decNum += (int)(Math.Pow(2, i));
        }

        Console.WriteLine(decNum + Environment.NewLine);
    }
}