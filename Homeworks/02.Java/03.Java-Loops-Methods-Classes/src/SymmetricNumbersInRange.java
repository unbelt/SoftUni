import java.util.Scanner;

// 1. Write a program to generate and print all symmetric numbers in given range [start…end] (0 ≤ start ≤ end ≤ 999).
// 	  A number is symmetric if its digits are symmetric toward its middle.
//    For example, the numbers 101, 33, 989 and 5 are symmetric, but 102, 34 and 997 are not symmetric. 

public class SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Starting number: ");
		int start = in.nextInt();

		System.out.print("Ending number: ");
		int end = in.nextInt();

		in.close();

		for (int i = start; i <= end; i++) {

			// Convert toString and put in char array
			char[] numbers = String.valueOf(i).toCharArray();

			if (numbers[0] == numbers[numbers.length - 1]) {
				System.out.print(i + " ");
			}
		}
	}
}