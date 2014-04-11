using System;
using System.Globalization;

/* Formatting Numbers
 *  Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500),
 *  a floating-point b and a floating-point c and prints them in 4 virtual columns on the console.
 *  Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left aligned;
 *  then the number a should be printed in binary form, padded with zeroes,
 *  then the number b should be printed with 2 digits after the decimal point, right aligned;
 *  the number c should be printed with 3 digits after the decimal point, left aligned.
 */

class FormattingNumbers
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        ushort number = ushort.Parse(Console.ReadLine());

        Console.Write("Enter number b: ");
        string firstFloatInput = Console.ReadLine().Replace(',', '.');
        float firstFloatNumber = float.Parse(firstFloatInput, CultureInfo.InvariantCulture);

        Console.Write("Enter number c: ");
        string secondFloatInput = Console.ReadLine().Replace(',', '.');
        float secondFloatNumber = float.Parse(secondFloatInput, CultureInfo.InvariantCulture);
        #endregion

        Console.WriteLine("|{0,-10}|{1}|{2,10:0.00}|{3,-10:0.000}|",
            number.ToString("X"), Convert.ToString(number, 2).PadLeft(10, '0'), firstFloatNumber, secondFloatNumber);
    }
}