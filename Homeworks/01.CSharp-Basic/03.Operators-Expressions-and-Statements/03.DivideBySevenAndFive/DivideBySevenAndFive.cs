using System;

/* Divide by 7 and 5
 *  Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
*/

class DivideBySevenAndFive
{
    static void Main()
    {
        var random = new Random();
        int randomNumber = random.Next(1, 1000);

        Console.WriteLine("n = {0} \r\n Divided by 7 and 5? {1}",
                           randomNumber, randomNumber % 35 == 0);
    }
}