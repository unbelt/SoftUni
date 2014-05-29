import java.util.Scanner;

/* 7. Write a program to find how many times given string appears in given text as substring.
 *    The text is given at the first input line. The search string is given at the second input line.
 *    The output is an integer number. Please ignore the character casing. */

public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Input: ");
		String input = in.nextLine().toLowerCase();

		System.out.print("Search for: ");
		String substring = in.next().toLowerCase();

		in.close();

		int lastIndex = 0;
		int substringCount = 0;
		
		while (lastIndex != -1) {
			lastIndex = input.indexOf(substring, lastIndex);
			
			if (lastIndex != -1) {
				substringCount++;
				lastIndex++;
			}
		}
		
		System.out.println(substringCount);

		// Implementation without repetitions
		// String[] substrings = input.split(substring);
		// System.out.println(substrings.length + 1);
	}
}
