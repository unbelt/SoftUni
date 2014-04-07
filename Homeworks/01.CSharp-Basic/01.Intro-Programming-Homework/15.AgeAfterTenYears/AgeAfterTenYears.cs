using System;

/* Age after 10 Years
 *  Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.
*/

class AgeAfterTenYears
{
    static void Main()
    {
        int age;
        string message = "Enter your age: ";

        do
        {
            Console.Write(message);
            message = "The input is not valid! Try again: ";

            // Read a number from the console & validate the input
        } while (!int.TryParse(Console.ReadLine(), out age) || age > 110 || age < 1);
        

        // Print the number +10
        Console.WriteLine("Your age after 10 years will be: {0}", age + 10);
    }
}