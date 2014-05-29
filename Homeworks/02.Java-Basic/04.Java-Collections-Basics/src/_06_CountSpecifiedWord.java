import java.util.Scanner;

/* 6. Write a program to find how many times a word appears in given text.
 *    The text is given at the first input line.
 *    The target word is given at the second input line.
 *    The output is an integer number. Please ignore the character casing.
 *    Consider that any non-letter character is a word separator. */

public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Text to check: ");
		String[] input = in.nextLine().split("(\\s|\\p{Punct})+");
		
		System.out.print("Search for word: ");
		String wanted = in.next().toLowerCase();
		in.close();
		
		int count = 0;
		
		for (int i = 0; i < input.length; i++) {
			if (input[i].toLowerCase().equals(wanted)) {
				count++;
			}
		}
		
		System.out.print(count);
	}
}
