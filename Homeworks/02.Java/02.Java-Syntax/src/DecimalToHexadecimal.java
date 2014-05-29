import java.util.Scanner;

// 5. Write a program that enters a positive integer number num and converts and prints it in hexadecimal form.
//    You may use some built-in method from the standard Java libraries. 

public class DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter a number: ");
		String input = in.next();
		
		in.close();
		
		int decimal = Integer.parseInt(input);
		String hexadecimal = Integer.toHexString(decimal);
		
		System.out.println("Hex value: " + hexadecimal.toUpperCase());
	}
}