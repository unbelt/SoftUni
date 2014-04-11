using System;
using System.Globalization;

/* Number Comparer
 *  Write a program that gets two numbers from the console and prints the greater of them.
 *  Try to implement this without if statements.
 */

class NumberComparer
{
    static void Main()
    {
        #region User Input
        Console.Write("Enter number a: ");
        string firstInput = Console.ReadLine().Replace(',', '.');
        float firstNumber = float.Parse(firstInput, CultureInfo.InvariantCulture);

        Console.Write("Enter number b: ");
        string secondInput = Console.ReadLine().Replace(',', '.');
        float secondNumber = float.Parse(secondInput, CultureInfo.InvariantCulture);
        #endregion

        // using Math.Max(); method
        Console.WriteLine(" a = {0} \r\n b = {1} \r\n greater: {2}", firstNumber, secondNumber,
            Math.Max(firstNumber, secondNumber));

        // using ternary operator '?'
        // Console.WriteLine("\r\n a = {0} \r\n b = {1} \r\n greater: {2}", firstNumber, secondNumber,
        //    firstNumber > secondNumber ? firstNumber : secondNumber);

       
    }
}