import java.util.Scanner;

/* 6. Sum Two Numbers
 * 		Write a program SumTwoNumbers.java that enters two integers from the console, calculates and prints their sum.
 */

public class SumTwoNumbers {
	
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("First number: ");
		int firstNum = in.nextInt();
		
		System.out.print("Second number: ");
		int secondNum = in.nextInt();
		
		in.close();
		
		System.out.println(firstNum + secondNum);
	}
}