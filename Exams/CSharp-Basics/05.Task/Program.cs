using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfBytes = int.Parse(Console.ReadLine());
        int steps = int.Parse(Console.ReadLine());

        var bytes = String.Empty;
        var newBytes = String.Empty;

        for (int i = 0; i < numberOfBytes; i++)
        {
            bytes += Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        int counter = 0;

        for (int i = 1; i < bytes.Length; i += steps)
        {
            newBytes += bytes[i];
            counter++;

            if (counter == 8)
            {
                newBytes += " ";
                counter = 0;
            }
        }

        var newBytesArray = newBytes.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < newBytesArray.Length; i++)
        {
            Console.WriteLine(Convert.ToUInt64(newBytesArray[i].PadRight(8, '0'), 2));
        }
    }
}