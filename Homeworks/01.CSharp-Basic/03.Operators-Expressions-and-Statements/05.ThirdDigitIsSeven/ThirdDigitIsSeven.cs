using System;

/* Third Digit is 7
 *  Write an expression that checks for given integer if its third digit from right-to-left is 7.
*/

class ThirdDigitIsSeven
{
    static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(5, 9999799);

        // Using ToString() to get indexer
        string numberToCheck = randomNumber.ToString();

        Console.WriteLine("{0} → {1}", randomNumber, numberToCheck[numberToCheck.Length - 3] == '7');
    }
}