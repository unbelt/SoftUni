namespace FallingRocks
{
    using System;
    using System.Threading;

    public class Info
    {
        internal static void GameOver(int score) // Gave Over screen
        {
            Console.Clear();
            Console.Title = "ASTEROIDS!  -=-  You LOOSE!";
            Helper.DrawElement((Console.BufferWidth / 2) - 6, (Console.BufferHeight / 2) - 10, "GAME OVER", ConsoleColor.Red);
            Helper.DrawElement((Console.BufferWidth / 2) + 8, 2, "Your score:" + score, ConsoleColor.Yellow);

            string youDeadDude = @"



             _                   _
            ( )                 ( )_
           (_, |      __ __      | _)
             \'\    /  ^  \    /'/
              '\'\,/\      \,/'/'
                '\| []   [] |/'
                  (_  /^\  _)
                    \  ~  /
                    /HHHHH\
                  /'/{^^^}\'\
              _,/'/'  ^^^  '\'\,_
             (_, |           | ,_)
               (_)           (_)
";
            Console.WriteLine(youDeadDude); // game Over art

            Console.SetCursorPosition(Console.WindowWidth - 49, Console.WindowHeight - 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            FallingRocks.Menu();
        }

        internal static void YouWin(int score) // Win Game screen
        {
            Console.Clear();
            Console.Title = "ASTEROIDS!  -=-  You WIN!";
            Helper.DrawElement((Console.BufferWidth / 2) - 5, (Console.BufferHeight / 2) - 10, "YOU WIN\n", ConsoleColor.Green);
            Helper.DrawElement((Console.BufferWidth / 2) + 8, 2, "Your score:" + score, ConsoleColor.Yellow);

            string youWin = @"




             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗╔═╦╗╔═╗╔╦╗
             ╚╗╔╗╔╝║║║║║║║║║║║╩╣║╔╝
              ╚╝╚╝ ╚╝╚╩═╝╚╩═╝╚═╝╚╝
";

            Console.WriteLine(youWin); // You Win art

            Console.SetCursorPosition(Console.WindowWidth - 49, Console.WindowHeight - 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            FallingRocks.Menu();
        }

        public static void GameInfo() // Game info and credits
        {
            Console.Title = "Falling Rocks -=-  Game Credits";
            Console.CursorVisible = false;
            Console.SetCursorPosition(Console.WindowWidth - 48, Console.WindowHeight - 23);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Flyer Project");

            Console.SetCursorPosition(Console.WindowWidth - 48, Console.WindowHeight - 21);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
Welcome to Falling Rocks");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Helper.FancyText(@"
You need to avoid all
obstacles falling toward you!
Use your right and left arrow keys
to move around, and be quick...
                         Good luck!");

            Console.SetCursorPosition(Console.WindowWidth - 49, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press Space to go back");
        }
    }
}