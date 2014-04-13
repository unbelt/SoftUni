using System;
using System.Text;

/* Number as Words
 *  Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
 */

class NumberAsWords
{
    static void Main()
    {
        Console.Write("Enter a number [0-999]: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(NumberToWords(number));
    }

    public static string NumberToWords(int number)
    {
        // Special case for more than one zeroes
        if (number == 0)
        {
            return "Zero";
        }

        // using StringBuilder(); for faster performance
        var words = new StringBuilder();

        if ((number / 100) > 0)
        {
            // Recursive call for large numbers
            words.AppendFormat("{0} hundred ", NumberToWords(number / 100));
            number %= 100;
        }

        if (number > 0)
        {
            // Apply only to numbers above 100
            if (words.Length != 0)
            {
                words.Append("and ");
            }

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20) // unit numbers
            {
                words.Append(unitsMap[number]);
            }
            else
            {
                words.Append(tensMap[number / 10]);

                if ((number % 10) > 0)
                {
                    words.AppendFormat(" {0}", unitsMap[number % 10]);
                }
            }
        }

        words.Replace(words[0].ToString(), words[0].ToString().ToUpper(), 0, 1);
        return words.ToString();
    }
}