using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter strings [space separated]: ");

        var input = Console.ReadLine();
        var output = SortStrings(input);

        Console.WriteLine(string.Join(" ", output));
    }

    public static List<string> SortStrings(string input = "")
    {
        var inputArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var outputList = inputArray.OrderBy(x => x).ToList();

        return outputList;
    }
}