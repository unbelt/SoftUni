using System;

/* Decimal to Hexadecimal Number
 *  Using loops write a program that converts an integer number to its hexadecimal representation.
 *  The input is entered as long. The output should be a variable of type string.
 *  Do not use the built-in .NET functionality.
 */

class DecimalToHexadecimal
{
    /// GetChar(15) -> 'F'
    static char GetChar(long i)
    {
        if (i >= 10) return (char)('A' + i - 10);
        else return (char)('0' + i);
    }

    static string Base10ToBase16(long d)
    {
        string h = String.Empty;

        for (; d != 0; d /= 16) h = GetChar(d % 16) + h;

        return h;
    }

    static void Main()
    {
        Console.WriteLine(Base10ToBase16(338583669684));
    }
}