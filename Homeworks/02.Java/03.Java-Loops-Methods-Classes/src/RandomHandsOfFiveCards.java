import java.util.Random;
import java.util.Scanner;

// 6. Write a program to generate n random hands of 5 different cards form a standard suit of 52 cards.

public class RandomHandsOfFiveCards {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
				"Q", "K", "A" };
		char[] suits = { '♣', '♦', '♥', '♠' };

		System.out.print("Count of hands: ");
		int handCount = in.nextInt();
		in.close();

		Random random = new Random();
		int f = 0;
		int s = 0;

		for (int i = 0; i < handCount; i++) {
			for (int j = 0; j < 5; j++) {
				f = random.nextInt(12) + 1;
				s = random.nextInt(3) + 1;

				System.out.print(faces[f] + suits[s] + " ");
			}
			System.out.println();
		}
	}
}
