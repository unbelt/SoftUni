import java.util.Arrays;
import java.util.Scanner;

// 3. Write a program that finds the smallest of three numbers.

public class TheSmallestNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter count of the numbers: ");
		
		int numberCount = in.nextInt();
		double[] numbers = new double[numberCount];
		
		for(int i = 0; i < numberCount; i++){
			System.out.print("Enter number # " + (i + 1));
			numbers[i] = in.nextDouble();
		}
		
		in.close();
		
		Arrays.sort(numbers);
		
		System.out.println("smallest = " + numbers[0]);
		System.out.println("largest = " + numbers[numbers.length-1]);
	}
}