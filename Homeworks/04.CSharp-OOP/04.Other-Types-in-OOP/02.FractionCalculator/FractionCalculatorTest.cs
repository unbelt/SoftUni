namespace FractionCalculator
{
    using System;
    using System.Collections.Generic;

    /* Create a struct Fraction that holds the numerator and denominator of a fraction as fields.
     * A fraction is the division of two rational numbers (e.g. 22 / 7, where 22 is the numerator and 7 is the denominator).
        • The struct constructor takes the numerator and denominator as arguments. They are integer numbers in the range [-9223372036854775808…9223372036854775807]. 
        • Validate the input through properties. The denominator cannot be 0. Throw proper exceptions with descriptive messages.
        • Overload the + and - operators to perform addition and subtraction on objects of type Fraction. The result should be a new Fraction.
        • Override ToString() to print the fraction in floating-point format.
     */

    public class FractionCalculatorTest
    {
        public static void Main()
        {
            var fraction1 = new Fraction(22, 7);
            var fraction2 = new Fraction(40, 4);

            Console.WriteLine("Fraction 1: {0}/{1} \r\nFraction 2: {2}/{3}\r\n--------------------\r\n",
                fraction1.Numerator, fraction1.Denominator, fraction2.Numerator, fraction2.Denominator);

            var oprations = new[] { "Add", "Subtract", "Multiply", "Divide", "Power" };
            int index = 0;

            var fractionOperations = new List<Fraction>
            {
                fraction1 + fraction2,
                fraction1 - fraction2,
                fraction1 * fraction2,
                fraction1 / fraction2,
                fraction1 ^ 2
            };

            foreach (var opetarion in fractionOperations)
            {
                Console.WriteLine("{0}\r\nFraction: {1} \r\nResult: {2}",
                    oprations[index++], opetarion, (double)opetarion + Environment.NewLine);
            }

            try
            {
                new Fraction(22, 0);
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}