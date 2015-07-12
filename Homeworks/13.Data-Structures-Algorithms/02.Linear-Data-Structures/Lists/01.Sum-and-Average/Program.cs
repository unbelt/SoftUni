using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter numbers [space separated]: ");

        var input = Console.ReadLine();
        var output = CalculateSumAndAverage(input);

        Console.WriteLine(output);
    }

    private static string CalculateSumAndAverage(string input = "")
    {
        const string outputString = "Sum={0}; Average={1}";
        var inputArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int numbers;
        var isNotValid = inputArray.Any(s => !int.TryParse(s, out numbers));

        if (isNotValid || !inputArray.Any())
        {
            return string.Format(outputString, 0, 0);
        }

        List<int> numbersList = inputArray.Select(int.Parse).ToList();

        return string.Format(outputString, numbersList.Sum(), numbersList.Average());
    }
}