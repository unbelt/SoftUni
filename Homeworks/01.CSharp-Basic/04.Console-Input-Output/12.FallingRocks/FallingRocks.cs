namespace FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Media;
    using System.Text;
    using System.Threading;

    /* Falling Rocks
     *  Implement the "Falling Rocks" game in the text console.
     *  A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
     *  A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
     *  Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
     *  Ensure a constant game speed by Thread.Sleep(150).
     *  Implement collision detection and scoring system.
     */

    public class FallingRocks
    {
        // Initial settings
        private const int gameSpeed = 150;

        private static string gameTitle = "Falling Rocks";
        private static int gameWidth = 50;
        private static int gameHeight = 25;

        private static int lives = 3;
        internal static int score = 0;

        private static List<Rocks> rocks = new List<Rocks>();

        private static void GameSettings()
        {
            Dwarf dwarf = new Dwarf('\u2588', gameWidth / 4, gameHeight - 2, ConsoleColor.White);

            Engine(rocks, dwarf); // Start the game
            Info.GameOver(score);
            GameSettings();
        }

        internal static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 6, (Console.WindowHeight / 2) - 11);
            Console.WriteLine("╔═════════════╗");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, (Console.WindowHeight / 2) - 10);
            Console.WriteLine("Falling Rocks");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 6, (Console.WindowHeight / 2) - 9);
            Console.WriteLine("╚═════════════╝");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, (Console.WindowHeight / 2) - 7);
            Console.WriteLine("-= MENU =-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, (Console.WindowHeight / 2) - 5);
            Console.WriteLine("Play·······Enter");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, (Console.WindowHeight / 2));
            Console.WriteLine("Game Info····I");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, (Console.WindowHeight / 2) + 5);
            Console.WriteLine("Exit········Esc");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 6, (Console.WindowHeight / 2) + 7);
            Console.Write("Press Key:");

            // Menu switcher
            bool commandCorrect = false;

            while (!commandCorrect)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((Console.WindowWidth / 2) + 5, (Console.WindowHeight / 2) + 7);
                var command = Console.ReadKey();

                switch (command.Key)
                {
                    case ConsoleKey.Enter: Console.Clear();
                        commandCorrect = true;
                        break;
                    case ConsoleKey.Spacebar: Console.Clear();
                        commandCorrect = true;
                        Menu();
                        break;
                    case ConsoleKey.I: Console.Clear();
                        Info.GameInfo();
                        UI.DrawControlInfo();
                        break;
                    case ConsoleKey.Escape: Console.WriteLine("GOOD BYE!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default: Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" is incorrect!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        }

        private static void Engine(List<Rocks> rocks, Dwarf dwarf) // V6 Supercharged
        {
            while (lives > 0)
            {
                // Control the asteroid creation
                Rocks newRock = new Rocks(UI.PickUpChar(), ConsoleColor.Cyan);
                rocks.Add(newRock);

                // Move the asteroids
                for (int index = 0; index < rocks.Count; index++)
                {
                    rocks[index].Clear();
                    rocks[index].Move();
                }

                Collisions(rocks, dwarf);
                Control(dwarf);
                dwarf.Draw();

                UI.DrawInterface(lives, score); // draw score and lives in separated cells

                // Slow down the game
                Thread.Sleep(gameSpeed);
            }
        }

        private static void Control(Dwarf dwarf)
        {
            // Left / Right movement
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.XPos > 1)
                    {
                        dwarf.XPos--;
                    }

                    Console.SetCursorPosition(dwarf.XPos + 1, dwarf.YPos);
                    Console.Write(' ');
                }

                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.XPos <= gameWidth / 2 - 1)
                    {
                        dwarf.XPos++;
                    }

                    Console.SetCursorPosition(dwarf.XPos - 1, dwarf.YPos);
                    Console.Write(' ');
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    // Pause game
                    Console.SetCursorPosition(Console.WindowWidth - 47, (Console.WindowHeight / 2) - 6);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" -= GAME PUSED =- ");
                    Console.SetCursorPosition(Console.WindowWidth - 48, (Console.WindowHeight / 2) - 4);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Press Space to resume");
                    Console.ReadKey();

                    // Return to game
                    if (userInput.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Control(dwarf);
                    }
                }

                // Exit game / Main menu /
                if (userInput.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu();
                }
            }
        }

        private static void Collisions(List<Rocks> rocks, Dwarf dwarf)
        {
            // Collisions with Dwarf
            for (int i = 0; i < rocks.Count; i++)
            {
                if (dwarf.IsHittedBy(rocks[i]))
                {
                    Helper.DrawElement((Console.BufferWidth / 2) + 13 + lives - 1, 4, '\u2665'.ToString(), ConsoleColor.Black);
                    lives--; // loses lives only if hitted by rock

                    rocks.Remove(rocks[i]);

                    if (lives == 0) // You are dead
                    {
                        break;
                    }
                }

                rocks[i].Print();

                // When rock hit the ground
                if (rocks[i].YPos == gameHeight - 1)
                {
                    score += 1;
                    rocks[i].Clear();
                    rocks.RemoveAt(i);
                }

                if (score > 1000) // Winning score
                {
                    Info.YouWin(score);
                }
            }
        }

        static void Main()
        {
            // Set environment
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            // Game settings
            Console.Title = gameTitle;
            Console.BufferWidth = Console.WindowWidth = gameWidth;
            Console.BufferHeight = Console.WindowHeight = gameHeight;

            Menu();
            GameSettings();
        }
    }
}
