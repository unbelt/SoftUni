import java.util.Scanner;

/* 2. Write a program that enters an array of strings and finds in it all sequences of equal elements.
 *    The input strings are given as a single line, separated by a space. */

public class _02_SequencesOfEqualStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter few strings [space separated]: ");
		System.out.println(countEqualStrings(in.nextLine()));
		in.close();
	}
	
	public static StringBuilder countEqualStrings(String input) {
		String[] elements = input.split(" ");
		StringBuilder result = new StringBuilder();
		
		result.append(elements[0]);

		for (int i = 1; i < elements.length; i++) {
			if (elements[i].equals(elements[i - 1])) {
				result.append(" " + elements[i]);
				continue;
			} else {
				result.append("\r" + elements[i]);
			}
		}
		
		return result;
	}
}