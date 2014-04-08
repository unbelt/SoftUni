using System;
using System.Text;

/* Isosceles Triangle
 *  Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
        ©
       © ©
      ©   ©
     © © © ©
 *  Note that the © symbol may be displayed incorrectly at the console
 *  so you may need to change the console character encoding to UTF-8 and the console font.
 */

public class IsoscelesTriangle
{
    public static void Main()
    {
        // Set encoding to UTF8: System.Text needed
        Console.OutputEncoding = Encoding.UTF8;

        int numberOfRows = 4;
        int spaceing = numberOfRows;

        string symbol = "©";

        for (int rows = 0; rows < numberOfRows - 1; rows++)
        {
            if (spaceing == numberOfRows)
            {
                // Draw top side
                Console.WriteLine(symbol.PadLeft(spaceing--));
            }
            else
            {
                // Draw left and right side
                Console.WriteLine("{0}{1}", symbol.PadLeft(spaceing--), symbol.PadLeft(rows + rows));
            }
            
            if (spaceing == 1)
            {
                for (int bottom = 0; bottom < numberOfRows; bottom++)
                {
                    // Draw bottom side
                    Console.Write(symbol + " ");
                }

                Console.WriteLine();
            }
        }
    }
}