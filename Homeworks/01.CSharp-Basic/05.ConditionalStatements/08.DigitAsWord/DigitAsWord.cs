using System;

/* Digit as Word
 *  Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
 *  Print “not a digit” in case of invalid inut. Use a switch statement. 
 */

class DigitAsWord
{
    static void Main()
    {
        Console.Write("Enter a digit [0-9]: ");
        ConsoleKeyInfo input = Console.ReadKey();
        Console.WriteLine();

        switch (input.Key)
        {
            case ConsoleKey.D0: Console.WriteLine("zero");
                break;
            case ConsoleKey.D1: Console.WriteLine("one");
                break;
            case ConsoleKey.D2: Console.WriteLine("two");
                break;
            case ConsoleKey.D3: Console.WriteLine("three");
                break;
            case ConsoleKey.D4: Console.WriteLine("four");
                break;
            case ConsoleKey.D5: Console.WriteLine("five");
                break;
            case ConsoleKey.D6: Console.WriteLine("six");
                break;
            case ConsoleKey.D7: Console.WriteLine("seven");
                break;
            case ConsoleKey.D8: Console.WriteLine("eight");
                break;
            case ConsoleKey.D9: Console.WriteLine("nine");
                break;
            default: Console.WriteLine("not a digit");
                break;
        }
    }
}