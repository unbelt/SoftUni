namespace FallingRocks
{
    using System;

    public class Dwarf
    {
        // Color
        public Dwarf(char view, int xPos, int yPos, ConsoleColor color)
        {
            this.View = view;
            this.XPos = xPos;
            this.YPos = yPos;
            this.Color = color;
        }

        // Properties
        public int XPos { get; set; }

        public int YPos { get; set; }

        public char View { get; set; }

        public ConsoleColor Color { get; set; }

        public bool IsHittedBy(Rocks rock)
        {
            if (this.XPos == rock.XPos && this.YPos + 1 == rock.YPos)
            {
                return true;
            }

            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.XPos, this.YPos);
            Console.ForegroundColor = this.Color;
            Console.Write(this.View);
        }
    }
}