using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var tribInitOne = long.Parse(Console.ReadLine());
        var tribInitTwo = long.Parse(Console.ReadLine());
        var tribInitThree = long.Parse(Console.ReadLine());

        var spiralInit = long.Parse(Console.ReadLine());
        var spiralStep = long.Parse(Console.ReadLine());

        var step = spiralStep;

        long tribResult = 0;
        long spiralResult = spiralInit;

        const int maxValue = 1000000;
        bool isFound = false;

        var tribNumbers = new long[maxValue];
        var spiralNumbers = new long[maxValue];

        tribNumbers[0] = tribInitOne;
        tribNumbers[1] = tribInitTwo;
        tribNumbers[2] = tribInitThree;

        int counter = 0;

        for (long i = 3; i < maxValue; i++)
        {
            // tribunacci sequence
            tribResult = tribInitOne + tribInitTwo + tribInitThree;
            tribInitOne = tribInitTwo;
            tribInitTwo = tribInitThree;
            tribInitThree = tribResult;

            tribNumbers[i] = tribResult;

            // spiral sequence
            spiralNumbers[i - 3] = spiralResult;
            spiralResult += spiralStep;
            counter++;

            if (counter == 2)
            {
                spiralStep += step;
                counter = 0;
            }

            if (spiralNumbers[i - 3] > maxValue)
            {
                break;
            }
        }

        // compare every trib number from 0 with spiral all numbers
        for (long i = 0; i < spiralNumbers.Length; i++)
        {
            for (long j = 0; j < spiralNumbers.Length; j++)
            {
                if (tribNumbers[i] == spiralNumbers[j])
                {
                    Console.WriteLine(tribNumbers[i]);
                    isFound = true;
                    return;
                }

                if (tribNumbers[i] < spiralNumbers[j])
                {
                    break;
                }

                if (spiralNumbers[j] > maxValue || spiralNumbers[j] == 0)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            if (spiralNumbers[i] == 0)
            {
                break;
            }
        }

        if (!isFound)
        {
            Console.WriteLine("No");
        }
    }
}