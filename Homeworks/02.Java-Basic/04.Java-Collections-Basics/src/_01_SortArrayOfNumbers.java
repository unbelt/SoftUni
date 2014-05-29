import java.util.Arrays;
import java.util.Scanner;

// 1. Write a program to enter a number n and n integer numbers and sort and print them.
//    Keep the numbers in array of integers: int[]. 

public class _01_SortArrayOfNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Enter numbers count: ");
		int numbersCount = in.nextInt();
		
		System.out.print("Enter few numbers [space separated]: ");
		int[] numbers = new int[numbersCount];
		
		for (int i = 0; i < numbersCount; i++) {
			numbers[i] = in.nextInt();
		}
		in.close();
		
		Arrays.sort(numbers);
		System.out.print(Arrays.toString(numbers));
	}
}