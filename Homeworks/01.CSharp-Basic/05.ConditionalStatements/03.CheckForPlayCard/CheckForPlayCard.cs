using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/* Check for a Play Card
 *  Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
 *  Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise.
 */

class CheckForPlayCard
{
    static void Main()
    {
        Console.Write("Enter character: ");
        string input = Console.ReadLine();

        char[] validSymbos = "23456789JQKA".ToCharArray();
        int valid = input.IndexOfAny(validSymbos);

        // Nested if{} else{} statement
        if (input.Length <= 2)
        {
            if (valid != -1 || input == "10")
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else
        {
            Console.WriteLine("no");
        }

        // using Regex
        //bool isValid = Regex.IsMatch(input, @"^([2-9]|10)?$|^[JQKA]?$");
        //Console.WriteLine(isValid ? "yes" : "no");
    }
}