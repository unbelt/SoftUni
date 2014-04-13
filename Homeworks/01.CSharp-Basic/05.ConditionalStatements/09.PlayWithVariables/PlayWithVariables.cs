using System;
using System.Globalization;

/* Play with Int, Double and String
 *  Write a program that, depending on the user’s choice, inputs an int, double or string variable.
 *  If the variable is int or double, the program increases it by one.
 *  If the variable is a string, the program appends "*" at the end.
 *  Print the result at the console. Use switch statement. 
 */

class PlayWithVariables
{
    static void Main()
    {
        Console.Write("Please choose a type: \r\n 1 --> int \r\n 2 --> double \r\n 3 --> string \r\n Input: ");
        ConsoleKeyInfo input = Console.ReadKey();

        int inputInt = 0;
        double inputDouble = 0.0d;
        string inputStr = string.Empty;

        switch (input.Key)
        {
            case ConsoleKey.D1: Console.Write("\r\nEnter int number: ");
                inputInt = int.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                Console.WriteLine(inputInt + 1);
                break;
            case ConsoleKey.D2: Console.Write("\r\nEnter double number: ");
                inputDouble = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                Console.WriteLine(inputDouble + 1);
                break;
            case ConsoleKey.D3: Console.Write("\r\nEnter a string: ");
                inputStr = Console.ReadLine();
                Console.WriteLine(inputStr + "*");
                break;
            default: Console.WriteLine(" is wrong Input! Try again." + Environment.NewLine);
                Main();
                break;
        }
    }
}