namespace Shapes
{
    using System;
    using System.Collections.Generic;

    /* • Define an interface IShape with two abstract methods: CalculateArea() and CalculatePerimeter().
       • Define an abstract class BasicShape implementing IShape and holding width and height.
         Leave the methods CalculateArea() and CalculatePerimeter() abstract.
       • Define two new BasicShape subclasses: Triangle and Rectangle that
         implement the abstract methods CalculateArea() and CalculatePerimeter().
       • Define a class Circle with a suitable constructor and IShape.
       • Create an array of different shapes (Circle, Rectangle, Triangle)
         and test the behavior of the CalculateSurface() and CalculatePerimeter() methods. */

    public class ShapesTest
    {
        public static void Main()
        {
            var shapes = new List<IShape>()
            {
                new Rectangle(10, 20),
                new Triangle(5, 10.5),
                new Circle(10)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}\r\nArea: {1:0.##} \r\nPerimeter: {2:0.##}\r\n",
                    shape, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
