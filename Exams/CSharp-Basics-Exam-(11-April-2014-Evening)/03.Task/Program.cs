using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int top = n + 2;
        int bottom = -1;
        int side = n / 2 + 1;

        for (int i = 0; i <= n / 2; i++)
        {
            Console.WriteLine(new string('-', side -= 1) + new string('*', bottom += 2) + new string('-', side));
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("|" + new string('*', n - 2) + "|");
        }
    }
}