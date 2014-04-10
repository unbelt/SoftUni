using System;
using System.Collections.Generic;

/* Four-Digit Number
 *  Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
     • Calculates the sum of the digits (in our example 2+0+1+1 = 4).
     • Prints on the console the number in reversed order: dcba (in our example 1102).
     • Puts the last digit in the first position: dabc (in our example 1201).
     • Exchanges the second and the third digits: acbd (in our example 2101).
*/

class FourDigitNumber
{
    static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 9999);

        // Convert to char array
        char[] digits = randomNumber.ToString().ToCharArray();

        // Sum of all digits
        int sumOfDigits = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            sumOfDigits += int.Parse(digits[i].ToString());
        }

        // Reverse digits
        var reversed = new char[digits.Length];
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            reversed[digits.Length - i - 1] = digits[i];
        }

        // Last digit in the first position
        var lastDigitInFront = new char[digits.Length];
        lastDigitInFront[0] = digits[digits.Length - 1];

        for (int i = 0; i < digits.Length - 1; i++)
        {
            lastDigitInFront[i + 1] = digits[i];

        }

        // Swapping second and the third digits
        char[] swappedDigits = randomNumber.ToString().ToCharArray();
        char secondDigit = digits[1];
        swappedDigits[1] = swappedDigits[2];
        swappedDigits[2] = secondDigit;

        Console.WriteLine("n = {0} \r\n Sum of digits: {1} \r\n Reversed: {2} \r\n Last Digit in Front: {3} \r\n Second and Third Digits Exchanged: {4}",
                            randomNumber, sumOfDigits, new string(reversed), new string(lastDigitInFront), new string(swappedDigits));

    }
}