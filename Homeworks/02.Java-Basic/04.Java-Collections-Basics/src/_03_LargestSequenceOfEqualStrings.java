import java.util.Scanner;

/* 3. Write a program that enters an array of strings and finds in it the largest sequence of equal elements.
 *    If several sequences have the same longest length, print the leftmost of them.
 *    The input strings are given as a single line, separated by a space. */

public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Enter few strings [space separated]: ");
		System.out.print(getEqualElements(in.nextLine()));
		in.close();
	}

	public static StringBuilder getEqualElements(String input) {
		String[] elements = input.split(" ");
		StringBuilder result = new StringBuilder();
		
		if (elements.length == 1) {
			return result.append(elements[0]);
		}

		int wordCount = 1;
		int largestWordCount = 0;
		String bestWord = "";

		for (int i = 1; i < elements.length; i++) {
			if (elements[i].equals(elements[i - 1])) {
				wordCount++;
			} else {
				wordCount = 1;
			}
			if (largestWordCount < wordCount) {
				largestWordCount = wordCount;
				bestWord = elements[i - 1];
			}
		}

		for (int i = 0; i < largestWordCount; i++) {
			result.append(bestWord + " ");
		}

		return result;
	}
}
