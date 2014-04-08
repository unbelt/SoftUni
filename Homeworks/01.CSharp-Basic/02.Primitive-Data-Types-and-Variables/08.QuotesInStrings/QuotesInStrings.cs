using System;

/* Quotes in Strings
 *  Declare two string variables and assign them with following value:
 *      The "use" of quotations causes difficulties.
 *  Do the above in two different ways: with and without using quoted strings.
 *  Print the variables to ensure that their value was correctly defined.
 */

public class QuotesInStrings
{
    public static void Main()
    {
        // Using '\' before quotation marks to escape them.
        string quotedString = "The \"use\" of quotations causes difficulties.";
        string justString = "The use of quotations causes difficulties.";

        Console.WriteLine(quotedString + Environment.NewLine + justString);
    }
}