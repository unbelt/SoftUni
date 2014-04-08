using System;

/* Exchange Variable Values
 *  Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values.
 *  Print the variable values before and after the exchange.
 */

public class ExchangeVariableValues
{
    public static void Main()
    {
        int a = 5;
        int b = 10;

        int c = a; // Temp variable

        a = b;
        b = c;

        Console.WriteLine(" a = {0} \r\n b = {1}", a, b);
    }
}