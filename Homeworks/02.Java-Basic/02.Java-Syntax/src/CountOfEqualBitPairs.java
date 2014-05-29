import java.util.Scanner;

// 6. Write a program to count how many sequences of two equal bits ("00" or "11")
//	  can be found in the binary representation of given integer number n (with overlapping).

public class CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter number: ");
		int number = in.nextInt();
		in.close();
		
		String binary = Integer.toBinaryString(number);
		char[] binaryArray = binary.toCharArray();
		
		int counter = 0;
		
		for(int i = 0; i < binaryArray.length - 1; i++){
			
			System.out.print(binaryArray[i]);
			
			if (binaryArray[i] == '0' && binaryArray[i + 1] == '0' ||
				binaryArray[i] == '1' && binaryArray[i + 1] == '1')
			{
				counter++;
			}
		}
		
		System.out.println("\nCount of pairs = " + counter);
	}
}