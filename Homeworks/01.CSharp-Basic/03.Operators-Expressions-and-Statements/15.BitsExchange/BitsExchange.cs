using System;

/* Bits Exchange
 *  Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
 */

class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint number = uint.Parse(Console.ReadLine());

        // Convert to binary string
        string binary = Convert.ToString(number, 2).PadLeft(32, '0');

        // Get numbers for exchanging
        string fromPosition = binary.Substring(26, 3);
        string toPosition = binary.Substring(5, 3);

        char[] binaryArray = binary.ToCharArray();

        // Exchange numbers
        for (int i = 0; i < fromPosition.Length; i++)
        {
            binaryArray[i + 5] = fromPosition[i];
        }
        for (int i = 0; i < toPosition.Length; i++)
        {
            binaryArray[i + 26] = toPosition[i];
        }

        // Output
        Console.Write(" n = {0} \r\n Binary representation of n: {1} \r\n Binary result: {2}", number, binary, new String(' ', 13));

        #region Styling
        for (int i = 0; i < binaryArray.Length; i++)
        {
            // Some styling
            if ((i >= 5 && i <= 7) || (i >= 26 && i <= 28))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
            }

            // Print changed array
            Console.Write(binaryArray[i]);
        }
        #endregion

        Console.WriteLine("\r\n Result: {0}", Convert.ToUInt32(new string(binaryArray), 2));
    }
}