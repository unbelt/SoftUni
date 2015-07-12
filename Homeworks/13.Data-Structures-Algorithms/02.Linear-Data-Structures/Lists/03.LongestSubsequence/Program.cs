using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter numbers [space separated]:");

        var input = Console.ReadLine();
        var output = GetLongestSubsequence(input);

        Console.WriteLine(string.Join(" ", output));
    }

    public static List<int> GetLongestSubsequence(string input)
    {
    	if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input is empty!");
        }
        
        var inputArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var length = 1;
        var bestLen = 1;
        var index = 0;

        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            if (inputArray[i] == inputArray[i + 1])
            {
                length++;
            }
            else
            {
                length = 1;
            }

            if (length > bestLen)
            {
                bestLen = length;
                index = i;
            }
        }

        int number;

        if (!int.TryParse(inputArray[index], out number))
        {
            throw new ArgumentException("Longest Subsequence in not a number!");    
        }

        var outputList = Enumerable.Repeat(int.Parse(inputArray[index]), bestLen).ToList();

        return outputList;
    }
}