using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter numbers [space separated]:");

        var input = Console.ReadLine();
        var output = RemoveOddOccurences(input);

        Console.WriteLine(string.Join(" ", output));
    }

    private static List<string> RemoveOddOccurences(string input)
    {
        var inputArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var outputList = inputArray.ToList();

        var elementsToRemove = inputArray
            .GroupBy(x => x)
            .Where(x => x.Count() % 2 != 0)
            .Select(x => x)
            .SelectMany(x => x);

        foreach (var element in elementsToRemove)
        {
            outputList.Remove(element);
        }

        return outputList;
    }
}