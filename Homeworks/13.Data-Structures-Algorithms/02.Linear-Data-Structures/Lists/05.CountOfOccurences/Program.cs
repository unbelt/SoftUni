using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter elements [space separated]: ");

        var input = Console.ReadLine();
        var output = CountOccurences(input);

        Console.WriteLine(string.Join("\r\n", output));
    }

    private static List<string> CountOccurences(string input)
    {
        const string outputString = "{0} -> {1} times";
        var inputArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var groupedElements = inputArray.GroupBy(x => x);
        var outputList = new List<string>();

        foreach (var group in groupedElements)
        {
            outputList.Add(string.Format(outputString, group.Key, group.Count()));
        }

        return outputList;
    }
}