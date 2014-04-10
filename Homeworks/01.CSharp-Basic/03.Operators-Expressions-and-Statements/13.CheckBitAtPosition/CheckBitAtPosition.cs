using System;

/* Check a Bit at Given Position
 *  Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n has value of 1.
 */

class CheckBitAtPosition
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        ushort number = ushort.Parse(Console.ReadLine());

        // Converting to binary number
        string binary = Convert.ToString(number, 2).PadLeft(16, '0');

        Console.Write("Enter bit position [0-{0}]: ", binary.Length - 1);
        byte position = byte.Parse(Console.ReadLine());

        Console.WriteLine(" n = {0} \r\n Binary representation of n: {1} \r\n p = {2} \r\n bit @ p == 1: {3}",
                            number, binary, position, binary[binary.Length - position - 1].Equals('1'));

    }
}