using System;

/* Null Values Arithmetic
 *  Create a program that assigns null values to an integer and to a double variable.
 *  Try to print these variables at the console.
 *  Try to add some number or the null literal to these variables and print the result.
 */

public class NullValuesArithmetic
{
    public static void Main()
    {
        // You need '?' after value type to be nullable
        int? integer = null;
        double? number = null;

        Console.WriteLine(integer);
        Console.WriteLine(number);

        object addOne = integer + 1; 
        object addTwo = number + 2;

        Console.WriteLine(addOne);
        Console.WriteLine(addTwo);
    }
}