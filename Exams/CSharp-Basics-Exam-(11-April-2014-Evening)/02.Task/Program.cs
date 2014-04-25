using System;
using System.Numerics;

class Illuminati
{
    static void Main()
    {
        string input = Console.ReadLine();

        BigInteger sum = 0;
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i].ToString().ToLowerInvariant())
            {
                case "a": sum += 65;
                    count++;
                    break;
                case "e": sum += 69;
                    count++;
                    break;
                case "i": sum += 73;
                    count++;
                    break;
                case "o": sum += 79;
                    count++;
                    break;
                case "u": sum += 85;
                    count++;
                    break;
            }
        }

        Console.WriteLine(count);
        Console.WriteLine(sum);
    }
}