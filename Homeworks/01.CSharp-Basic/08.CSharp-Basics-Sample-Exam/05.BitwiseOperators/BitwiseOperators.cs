using System;
using System.Collections.Generic;

class BitwiseOperators
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var binary = new char[n];
        var newNumber = string.Empty;

        var result = new List<string>();

        for (int i = 0; i < n; i++)
        {
            binary = Convert.ToString(int.Parse(Console.ReadLine()), 2).ToCharArray();

            for (int j = 0; j < binary.Length; j++)
            {
                newNumber += (binary[i] ^ Modify(binary[i])) & binary[binary.Length - 1 - j];
            }

            result.Add(newNumber);
            newNumber = string.Empty;
        }

        foreach (var number in result)
        {
            Console.WriteLine(Convert.ToUInt32(number, 2));
        }
    }

    public static char Modify(char num)
    {
        if (num == '1')
        {
            return '0';
        }

        return '1';
    }
}