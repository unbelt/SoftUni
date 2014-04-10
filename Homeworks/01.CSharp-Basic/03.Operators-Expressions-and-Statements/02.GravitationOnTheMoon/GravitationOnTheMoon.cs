using System;

/* Gravitation on the Moon
 *  The gravitational field of the Moon is approximately 17% of that on the Earth.
 *  Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
 */

class GravitationOnTheMoon
{
    static void Main()
    {
        Random random = new Random();
        float randomNumber = random.Next(50, 100);

        // Formula for calculating percentage of a number
        double moonWeight = randomNumber * 17 / 100;

        Console.WriteLine("{0:0.00#} kg.", moonWeight);
    }
}