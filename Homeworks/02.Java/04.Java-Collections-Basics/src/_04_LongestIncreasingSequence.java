import java.util.Scanner;

/* 4. Write a program to find all increasing sequences inside an array of integers.
 * The integers are given in a single line, separated by a space.
 * Print the sequences in the order of their appearance in the input array, each at a single line.
 * Separate the sequence elements by a space. Find also the longest increasing sequence
 * and print it at the last line. If several sequences have the same longest length, print the leftmost of them. */

public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		System.out.println(getLongestIncreasingSequence(in.nextLine()));
		in.close();
	}

	public static StringBuilder getLongestIncreasingSequence(String input) {
		String[] elements = input.split(" ");
		StringBuilder result = new StringBuilder();
		
		result.append(elements[0]);
		
		StringBuilder currentSequence = new StringBuilder();
		StringBuilder bestSequence = new StringBuilder();
		
		currentSequence.append(elements[0]);
		boolean isFound = false;
		
		for (int i = 1; i < elements.length; i++) {
			if (Integer.parseInt(elements[i]) > Integer.parseInt(elements[i - 1])) {
				result.append(" " + elements[i]);
				currentSequence.append(" " + elements[i]);
				isFound = true;
			} else {
				result.append("\r" + elements[i]);
				currentSequence.setLength(0);
				currentSequence.append(elements[i]);
			}
			if (bestSequence.length() < currentSequence.length()) {
				bestSequence.setLength(0);
				bestSequence.append(currentSequence);
			}
		}
		
		if(!isFound) {
			bestSequence.setLength(0);
			bestSequence.append(elements[0]);
		}

		return result.append("\rLongest: " + bestSequence);
	}
}
