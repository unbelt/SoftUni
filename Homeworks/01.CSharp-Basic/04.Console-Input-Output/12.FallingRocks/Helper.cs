namespace FallingRocks
{
    using System;
    using System.Threading;

    public class Helper
    {
        internal static void DrawElement(int x, int y, string c, ConsoleColor color) // Draw an element
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        internal static void FancyText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(30);
            }
        } // Animation for info window
    }
}
