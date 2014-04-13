using System;
using System.Globalization;

/* Beer Time
 *  A beer time is after 1:00 PM and before 3:00 AM.
 *  Write a program that enters a time in format “hh:mm tt”
 *  (an hour in range [01...12], a minute in range [00…59] and AM / PM designator)
 *  and prints “beer time” or “non-beer time” according to the definition above or
 *  “invalid time” if the time cannot be parsed.
 *  Note that you may need to learn how to parse dates and times. 
 */

class BeerTime
{
    static void Main()
    {
        Console.Write("Enter time [hh:mm tt]: ");
        string input = Console.ReadLine();
        DateTime time;


        if (DateTime.TryParse(input, out time)) // validation
        {
            time = Convert.ToDateTime(input, CultureInfo.InvariantCulture);
        }
        else
        {
            Console.WriteLine(" invalid time");
            return;
        }

        // using DateTime class to store times
        DateTime beerTimeStart = Convert.ToDateTime("1:00 PM", CultureInfo.InvariantCulture);
        DateTime beerTimeEnd = Convert.ToDateTime("3:00 AM", CultureInfo.InvariantCulture);

        if (time >= beerTimeStart || time < beerTimeEnd)
        {
            Console.WriteLine("beer time");
            
        }
        else
        {
            Console.WriteLine("non-beer time");
        }
    }
}