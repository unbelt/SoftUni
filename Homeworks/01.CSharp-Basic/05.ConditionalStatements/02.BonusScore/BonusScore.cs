using System;

/* Bonus Score
 *  Write a program that applies bonus score to given score in the range [1…9] by the following rules:
     • If the score is between 1 and 3, the program multiplies it by 10.
     • If the score is between 4 and 6, the program multiplies it by 100.
     • If the score is between 7 and 9, the program multiplies it by 1000.
     • If the score is 0 or more than 9, the program prints “invalid score”.
 */

class BonusScore
{
    static void Main()
    {
        Console.Write("Enter a number [1-9]: ");
        int number = int.Parse(Console.ReadLine());

        // Chained if{} else{} statement
        if (number <= 3 && number > 0)
        {
            Console.WriteLine(number * 10);
        }
        else if (number > 3 && number <= 6)
        {
            Console.WriteLine(number * 100);
        }
        else if (number > 6 && number <= 9)
        {
            Console.WriteLine(number * 1000);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}