using System;

/* Comparing Floats
 *  Write a program that safely compares floating-point numbers with precision eps = 0.000001.
 *  Note that we cannot directly compare two floating-point numbers a and b by a==b
 *  because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal
 *  if they are more closely to each other than a fixed constant eps.
 */

public class ComparingFloats
{
    public static void Main()
    {
        double firstNumber = 5.00000001d;
        double secondNumber = 5.00000003d;

        // Using Math.Abs method to return the absolute value of a double-precision floating-point number.
        Console.WriteLine(Math.Abs(firstNumber - secondNumber) < 1E-6);
    }
}