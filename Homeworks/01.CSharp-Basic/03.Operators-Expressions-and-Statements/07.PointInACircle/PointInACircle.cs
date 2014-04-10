using System;

/* Point in a Circle
 *  Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2). 
*/

class PointInACircle
{
    static void Main()
    {
        // Method for generating random floating-point numbers
        Random random = new Random();
        double mantissaX = (random.NextDouble() * 2.0) - 1.0;
        double exponentX = Math.Pow(2.0, random.Next(-5, 5));

        double mantissaY = (random.NextDouble() * 2.0) - 1.0;
        double exponentY = Math.Pow(2.0, random.Next(-5, 5));

        float pointX = (float)(mantissaY * exponentY);
        float pointY = (float)(mantissaX * exponentX);

        // Formula for calculationg is given point is in the circle
        bool isInCirle = Math.Pow(pointX, 2) + Math.Pow(pointY, 2) <= Math.Pow(2, 2);

        Console.WriteLine(" x = {0:0.0##} \r\n y = {1:0.0##} \r\nInside: {2}", pointX, pointY, isInCirle);
    }
}