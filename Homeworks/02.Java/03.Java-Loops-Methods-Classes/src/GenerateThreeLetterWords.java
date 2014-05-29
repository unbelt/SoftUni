import java.util.Arrays;
import java.util.Scanner;

/* 2. Write a program to generate and print all 3-letter words consisting of given set of characters.
 *    For example if we have the characters 'a' and 'b', all possible words will be
 *    "aaa", "aab", "aba", "abb", "baa", "bab", "bba" and "bbb".
 *    The input characters are given as string at the first line of the input.
 *    Input characters are unique (there are no repeating characters). */

public class GenerateThreeLetterWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Enter up to 3 letters: ");
		String word = in.next();
		in.close();

		permutation(word);
	}

	private static void permutation(String str) {
		char[] chars = str.toCharArray();
		Arrays.sort(chars);

		for (int first = 0; first < chars.length; first++) {
			for (int second = 0; second < chars.length; second++) {
				for (int third = 0; third < chars.length; third++) {
					System.out.println(chars[first] + "" + chars[second] + ""
							+ chars[third]);
				}
			}
		}
	}
}