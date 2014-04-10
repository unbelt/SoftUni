using System;

/* Modify a Bit at Given Position
 *  We are given an integer number n, a bit value v (v=0 or 1) and a position p.
 *  Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p
 *  from the binary representation of n while preserving all other bits in n.
 */

class ModifyBitAtPosition
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter a number: ");
        ushort number = ushort.Parse(Console.ReadLine());

        Console.Write("Enter a value [0 or 1]: ");
        char value = char.Parse(Console.ReadLine());

        Console.Write("Enter a position [0-15]: ");
        byte position = byte.Parse(Console.ReadLine());
        #endregion

        // Convert to binary number in a char array
        char[] bitNumbers = Convert.ToString(number, 2).PadLeft(16, '0').ToCharArray();
        string binary = new string(bitNumbers);

        // Set the value at the given position
        bitNumbers[bitNumbers.Length - 1 - position] = value;
        string newBinary = new string(bitNumbers);

        // Converting back to integer
        long newNumber = Convert.ToInt64(newBinary, 2);

        Console.WriteLine(" n = {0} \r\n binary representation of n: {1} \r\n p = {2} \r\n v = {3}  \r\n Binary result: {4} \r\n Result: {5}",
                            number, binary, position, value, newBinary, newNumber);
    }
}