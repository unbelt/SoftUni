using System;

/* Print a Deck of 52 Cards
 *  Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers).
 *  The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A.
 *  Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
 */

class PrintDeckOfCards
{
    static void Main()
    {
        var cardRanks = new char[] { 'J', 'Q', 'K', 'A' };
        var cardColors = new char[] { '♣', '♦', '♥', '♠' };

        for (int i = 2; i < 15; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i < 11)
                {
                    Console.Write("{0}{1} ", i, cardColors[j]);
                }
                else
                {
                    Console.Write("{0}{1} ", cardRanks[i - 11], cardColors[j]);
                }
            }

            Console.WriteLine();
        }
    }
}