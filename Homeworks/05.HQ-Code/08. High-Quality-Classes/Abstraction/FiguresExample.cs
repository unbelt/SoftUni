namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. \r\nMy perimeter is {0:f2}. \r\nMy surface is {1:f2}.\r\n",
                circle.CalcPerimeter(), circle.CalcSurface());

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. \r\nMy perimeter is {0:f2}. \r\nMy surface is {1:f2}.",
                rect.CalcPerimeter(), rect.CalcSurface());
        }
    }
}