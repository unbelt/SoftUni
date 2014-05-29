import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

/* 10. At the first line at the console you are given a piece of text.
 *     Extract all words from it and print them in alphabetical order.
 *     Consider each non-letter character as word separator.
 *     Take the repeating words only once. Ignore the character casing.
 *     Print the result words in a single line, separated by spaces.*/

public class _10_ExtractAllUniqueWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Input: ");
		String[] input = in.nextLine().split("(\\s|\\p{Punct})+");
		in.close();
		
		Set<String> uniqueWords = new HashSet<String>();
		
		for (String string : input) {
			uniqueWords.add(string.toLowerCase());
		}
		
		System.out.print(uniqueWords);
	}
}