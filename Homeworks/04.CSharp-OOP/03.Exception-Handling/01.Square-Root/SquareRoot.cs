using System;

/* Write a program that reads an integer number and calculates and prints its square root.
 * If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye".
 * Use try-catch-finally.
 */

public class SquareRoot
{
    public static void Main()
    {
        Console.Write("Enter a number: ");

        try
        {
            var number = double.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine("Math.Sqrt({0}) = {1}", number, Math.Sqrt(number));
        }

        // Same as general Exception below
        /*
        catch (FormatException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        */
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}