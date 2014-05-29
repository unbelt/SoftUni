import java.util.Scanner;

// 6. Write a program to calculate the count of bits 1 in the binary representation of given integer number n.

public class CountOfBitsOne {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter a number: ");
		int number = in.nextInt();
		in.close();
		
		System.out.println("Count of bit 1 = " + Integer.bitCount(number));
	}
}