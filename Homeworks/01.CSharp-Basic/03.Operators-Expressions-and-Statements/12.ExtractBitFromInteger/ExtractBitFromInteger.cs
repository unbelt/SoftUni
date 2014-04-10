using System;

/* Extract Bit from Integer
 *  Write an expression that extracts from given integer n the value of given bit at index p.
 */

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        ushort number = ushort.Parse(Console.ReadLine());

        // Converting to binary number
        string binary = Convert.ToString(number, 2).PadLeft(16, '0');

        Console.Write("Enter position [0-{0}]: ", binary.Length - 1);
        byte position = byte.Parse(Console.ReadLine());

        Console.WriteLine(" n = {0} \r\n binary representation: {1} \r\n p = {2} \r\n bit @ p: {3}",
                            number, binary, position, binary[position]);
    }
}