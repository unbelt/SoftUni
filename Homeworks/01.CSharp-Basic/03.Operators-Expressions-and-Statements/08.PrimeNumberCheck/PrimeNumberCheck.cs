using System;

/* Prime Number Check
 *  Write an expression that checks if given positive integer number n (n ≤ 100) is prime
 *  (i.e. it is divisible without remainder only to itself and 1). 
 */

class PrimeNumberCheck
{
    static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);

        int tempNumber = 0;

        for (int i = 1; i <= randomNumber; i++)
        {
            if (randomNumber % i == 0)
            {
                tempNumber++; // if more than 2 != prime
            }
        }

        Console.WriteLine("n = {0} \r\n Prime? {1}", randomNumber, tempNumber == 2);
    }
}