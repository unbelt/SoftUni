using System;

class DrawFigure
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int top = n + 2;
        int bottom = -1;
        int side = n / 2 + 1;

        for (int i = 0; i < n; i++)
        {
            if (i < (n / 2))
            {
                Console.WriteLine(new string('.', i) + new string('*', top -= 2) + new string('.', i));
            }
            else
            {
                Console.WriteLine(new string('.', side -= 1) + new string('*', bottom += 2) + new string('.', side));
            }
        }
    }
}