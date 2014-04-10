using System;

/* Bit Exchange (Advanced)
 *  Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
 *  The first and the second sequence of bits may not overlap.
 */

class BitExchange
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter n (number): ");
        string inputNumber = Console.ReadLine();
        uint number = 0;

        if (!uint.TryParse(inputNumber, out number))
        {
            Console.WriteLine("out of range");
            return;
        }

        number = uint.Parse(inputNumber);

        Console.Write("Enter p (position): ");
        sbyte position = sbyte.Parse(Console.ReadLine());

        Console.Write("Enter q (position to move): ");
        sbyte toPosition = sbyte.Parse(Console.ReadLine());

        Console.Write("Enter k (number of bytes from p): ");
        sbyte numberOfBytes = sbyte.Parse(Console.ReadLine());
        #endregion

        string binary = Convert.ToString(number, 2).PadLeft(32, '0');

        #region Validation
        if (position + numberOfBytes > binary.Length || number > uint.MaxValue ||
            position < 0 || toPosition < 0 || numberOfBytes < 0)
        {
            Console.WriteLine("out of range");
            return;
        }
        if (position + toPosition < numberOfBytes)
        {
            Console.WriteLine("overlapping");
            return;
        }
        #endregion

        string firstGroup = binary.Substring(binary.Length - toPosition - numberOfBytes, numberOfBytes);
        string secondGroup = binary.Substring(binary.Length - position - numberOfBytes, numberOfBytes);

        char[] binaryArray = binary.ToCharArray();

        for (int i = 0; i < firstGroup.Length; i++)
        {
            binaryArray[binary.Length - position - numberOfBytes + i] = firstGroup[i];
        }
        for (int i = 0; i < secondGroup.Length; i++)
        {
            binaryArray[binary.Length - toPosition - numberOfBytes + i] = secondGroup[i];
        }

        Console.WriteLine(" n = {0} \r\n p = {1} \r\n q = {2} \r\n k = {3} \r\n Binary representation of n: {4} \r\n Binary result:{5} {6} \r\n Result: {7}",
                            number, position, toPosition, numberOfBytes, binary, new string(' ', 13), new string(binaryArray), Convert.ToUInt32(new string(binaryArray), 2));
    }
}