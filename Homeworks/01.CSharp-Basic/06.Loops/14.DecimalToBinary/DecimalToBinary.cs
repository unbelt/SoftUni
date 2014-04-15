using System;

/* Decimal to Binary Number
 *  Using loops write a program that converts an integer number to its binary representation.
 *  The input is entered as long. The output should be a variable of type string.
 *  Do not use the built-in .NET functionality.
 */

class DecimalToBinary
{
    static string Base10ToBase2(int d)
    {
        string b = String.Empty;

        for (; d != 0; d /= 2) b = d % 2 + b;

        return b;
    }

    static string RecursionBase10ToBase2(int d, string b = "")
    {
        return d == 0 ? b : RecursionBase10ToBase2(d / 2, d % 2 + b);
    }

    static void Main()
    {
        Console.WriteLine(Base10ToBase2(43691));
        Console.WriteLine(RecursionBase10ToBase2(43691));
    }
}