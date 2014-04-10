using System;

/* Bitwise: Extract Bit #3
 *  Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
 *  The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0.
 */

class BitwiseExtractBit
{
    static void Main()
    {
        var random = new Random();
        int randomNumber = random.Next(0, ushort.MaxValue);

        // Converting to binary number
        string binary = Convert.ToString(randomNumber, 2).PadLeft(16, '0');

        Console.WriteLine(" n = {0} \r\n Binary representation: {1} \r\n Bit #3: {2}",
                            randomNumber, binary, binary[binary.Length - 4]);
    }
}