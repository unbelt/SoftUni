﻿using System;

/* Unicode Value
 *  Declare a character variable and assign it with the symbol that has Unicode code 72, and then print it.
 *  Hint: first, use the Windows Calculator to find the hexadecimal representation of 72. The output should be “H”.
 */

public class UnicodeValue
{
    public static void Main()
    {
        char symbol = '\u0048';
        Console.WriteLine(symbol);
    }
}