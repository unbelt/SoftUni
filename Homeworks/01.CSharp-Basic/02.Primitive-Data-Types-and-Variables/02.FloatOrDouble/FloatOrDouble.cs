using System;

/* Float or Double?
 *  Which of the following values can be assigned to a variable of type float and which to a variable of type double:
 *  34.567839023, 12.345, 8923.1234857, 3456.091?
 *  Write a program to assign the numbers in variables and print them to ensure no precision is lost.
 */

public class FloatOrDouble
{
    public static void Main()
    {
        double firstDoubleNumber = 34.567839023d; // Precision of 15-16 digits
        float firstFloatNumber = 12.345f;         // Precision of 7 digits

        double secondDoubleNumber = 8923.1234857d;
        float secondFloatNumber = 3456.091f;

        Console.WriteLine("First double number: {0} \n\r Second double number: {1} \n\r", firstDoubleNumber, secondDoubleNumber);
        Console.WriteLine("First float number: {0} \n\r Second float number: {1}", firstFloatNumber, secondFloatNumber);
    }
}