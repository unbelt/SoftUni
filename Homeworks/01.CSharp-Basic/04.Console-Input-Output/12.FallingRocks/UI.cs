namespace FallingRocks
{
    using System;
    using System.Threading;

    public class UI
    {
        internal static void DrawInterface(int lives, int score) // Draw all interface
        {
            DrawBorders();
            DrawScore(score);
            DrawLives(lives);
            DrawControlInfo();
        }

        internal static char PickUpChar() // Ramdom generator for all symbols
        {
            Random charGenerator = new Random();

            int charX = charGenerator.Next(0, 4);
            int charY = charGenerator.Next(0, 4);

            char[,] allChars = new char[,]
            {
            {
                '^', '@', '*', '&', '%'
            },
                                          {
                                              '$', '#', '!', '.', ';'
                                          },
                                          {
                                              '^', '@', '*', '&', '%'
                                          },
                                          {
                                              '$', '#', '!', '.', ';'
                                          }
            };

            char rockChar = allChars[charX, charY];

            return rockChar;
        }
        
        private static void DrawBorders() // Draw dividing line for info board
        {
            for (int i = 0; i < Console.BufferHeight; i++)
            {
                Helper.DrawElement((Console.BufferWidth / 2) + 1, i, "|", ConsoleColor.White);
                Helper.DrawElement((Console.BufferWidth / 2) + 2, i, "|", ConsoleColor.White);
            }

            for (int i = (Console.BufferWidth / 2) + 3; i < Console.BufferWidth; i += 2)
            {
                // draw lines to divide information fields
                Helper.DrawElement(i, 2, "_", ConsoleColor.White); // lines displayed under lives
                Helper.DrawElement(i, 5, "_", ConsoleColor.White);
            }
        }

        internal static void DrawControlInfo() // Display the controls
        {
            Helper.DrawElement((Console.BufferWidth / 2) + 4, 12, "Controls :", ConsoleColor.DarkYellow);
            Helper.DrawElement((Console.BufferWidth / 2) + 4, 14, '\u2190' + '\u2192'.ToString() + " Move Left/Right", ConsoleColor.DarkYellow);
            Helper.DrawElement((Console.BufferWidth / 2) + 4, 16, "Space Pause/Resume", ConsoleColor.DarkYellow);
        }

        private static void DrawScore(int score) // Display the score
        {
            Helper.DrawElement((Console.BufferWidth / 2) + 4, 1, "score:" + score, ConsoleColor.Green);
        }

        private static void DrawLives(int lives) // Display the lives
        {
            Helper.DrawElement((Console.BufferWidth / 2) + 4, 4, "lives : ", ConsoleColor.Yellow);

            for (int i = 0; i < lives; i++)
            {
                // Draw heart symbols for lives
                Helper.DrawElement((Console.BufferWidth / 2) + 13 + i, 4, '\u2665'.ToString(), ConsoleColor.Red);
            }
        }
    }
}