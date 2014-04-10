using System;

/* Point Inside a Circle & Outside of a Rectangle
 *  Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5)
 *  and out of the rectangle R(top=1, left=-1, width=6, height=2).
 */

class InsideCircleOutsideRectangle
{
    static void Main()
    {
        Random random = new Random();
        double mantissaX = (random.NextDouble() * 2.0) - 1.0;
        double exponentX = Math.Pow(2.0, random.Next(-1, 3));

        double mantissaY = (random.NextDouble() * 2.0) - 1.0;
        double exponentY = Math.Pow(2.0, random.Next(-1, 3));

        float pointY = (float)(mantissaX * exponentX);
        float pointX = (float)(mantissaY * exponentY);

        // Is in the circle K( (1,1), 1.5) ?
        bool isInCircle = Math.Pow(pointX - 1, 2) + Math.Pow(pointY - 1, 2) <= Math.Pow(1.5, 2);

        // Is out of the rectangle R(top=1, left=-1, width=6, height=2) ?
        bool outOfRectangle = (pointX > 4 || pointX < -1) || (pointY > 1 || pointY < -1);

        Console.WriteLine(" x = {0:0.0#} \r\n y = {1:0.0#} \r\ninside K & outside of R? {2}",
            pointX, pointY, isInCircle && outOfRectangle ? "yes" : "no");
    }
}