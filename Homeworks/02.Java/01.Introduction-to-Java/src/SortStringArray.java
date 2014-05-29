import java.util.Arrays;
import java.util.Scanner;

/* 8. Sort Array of Strings
 * 		Write a program that enters from the console number n and n strings, then sorts them alphabetically and prints them.
 * 		Note: you might need to learn how to use loops and arrays in Java (search in Internet).
 */

public class SortStringArray {

	public static void main(String[] args) {
		
		Scanner in = new Scanner(System.in);
		System.out.print("Number of strings: ");
		int arrLength = in.nextInt();
		
		String[] stringArray = new String[arrLength];
		
		for (int i = 0; i < arrLength; i++) {
			System.out.print("String #" + (i + 1));
			stringArray[i] 	= in.next();
		}
		
		in.close();
		
		Arrays.sort(stringArray);
		System.out.println(Arrays.toString(stringArray));
	}
}
