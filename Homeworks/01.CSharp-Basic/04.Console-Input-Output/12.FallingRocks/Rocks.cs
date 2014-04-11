namespace FallingRocks
{
    using System;
    using System.Linq;

    public class Rocks
    {
        // Fields
        private const int PLAYFIELD = 25;
        private bool isPrinted = false;
        private int xPos;
        private int yPos;
        private Random randomPosition = new Random();

        // Constructor
        public Rocks(char symbol, ConsoleColor color)
        {
            this.Direction = randomPosition.Next(1, PLAYFIELD - 1);
            this.Symbol = symbol;
            this.Color = color;
        }

        // Properties
        public int XPos
        {
            get { return this.xPos; }

            set { this.xPos = value; }
        }

        public int YPos
        {
            get { return this.yPos; }

            set { this.yPos = value; }
        }

        public char Symbol { get; set; }

        public int Direction { get; set; }

        public ConsoleColor Color { get; set; }

        public void Move()
        {
            Random randomPosition = new Random();

            this.XPos = Direction;
            this.YPos += 1;
        }

        public void Clear()
        {
            if (this.isPrinted)
            {
                Console.SetCursorPosition(this.XPos, this.YPos);
                Console.Write(' ');
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(this.XPos, this.YPos);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
            this.isPrinted = true;
        }
    }
}