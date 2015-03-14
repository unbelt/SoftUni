using System;

class Cinema
{
    static void Main()
    {
        string input = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        decimal price = 0m;

        switch (input.ToLowerInvariant())
        {
            case "premiere": price = 12m;
                break;
            case "normal": price = 7.50m;
                break;
            case "discount": price = 5m;
                break;
        }

        decimal output = price * rows * cols;

        Console.WriteLine("{0:0.00} leva", output);
    }
}