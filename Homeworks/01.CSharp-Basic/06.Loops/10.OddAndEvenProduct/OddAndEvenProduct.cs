using System;

/* Odd and Even Product
 *  You are given n integers (given in a single line, separated by a space).
 *  Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
 *  Elements are counted from 1 to n, so the first element is odd, the second is even, etc. 
 */

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Write("Enter numbers [space separated]: ");
        string readNumbers = Console.ReadLine();

        int even = 1;
        int odd = 1;
        
        string[] numbers = readNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbers.Length; i++)
        {
            int number = int.Parse(numbers[i]);

            if (i % 2 == 0)
            {
                even *= number;
            }
            else
            {
                odd *= number;
            }
        }

        if (even == odd)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = " + even);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = " + odd);
            Console.WriteLine("even_product = " + even);
        }
    }
}