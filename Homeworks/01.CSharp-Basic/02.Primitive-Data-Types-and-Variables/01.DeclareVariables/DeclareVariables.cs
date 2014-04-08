using System;

/* Declare Variables
 *  Declare five variables choosing for each of them the most appropriate of the types
 *  byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values:
 *  52130, -115, 4825932, 97, -10000. Choose a large enough type for each number to ensure it will fit in it.
 *  Try to compile the code.
 */

public class DeclareVariables
{
    public static void Main()
    {
        ushort ushortNumber = 52130; // from  0     to 65 535
        sbyte sbyteNumber = -115;    // from -128   to 127
        uint uintNumber = 4825932;   // from  0     to 4 294 967 295
        byte byteNumber = 97;        // from  0     to 255
        short shortNumber = -10000;  // from -32768 to 32 767

        Console.WriteLine(" ushort: {0} \n\r sbyte: {1,4} \n\r uint: {2,9} \n\r byte: {3,4} \n\r short: {4}",
                            ushortNumber, sbyteNumber, uintNumber, byteNumber, shortNumber);
    }
}