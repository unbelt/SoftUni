import java.util.Scanner;

// 5. Write a program to count the number of words in given sentence. Use any non-letter character as word separator.

public class _05_CountAllWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Text to check: ");
		System.out.print(in.nextLine().split("\\w+").length - 1);
		in.close();
	}
}