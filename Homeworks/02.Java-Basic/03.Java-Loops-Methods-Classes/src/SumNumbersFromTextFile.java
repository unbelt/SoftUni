import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

/* 8. Write a program to read a text file "Input.txt" holding a sequence of integer numbers,
 *    each at a separate line. Print the sum of the numbers at the console.
 *    Ensure you close correctly the file in case of exception or in case of normal execution.
 *    In case of exception (e.g. the file is missing), print "Error" as a result. */

public class SumNumbersFromTextFile {

	public static void main(String[] args) {
		String source = "./input.txt";
		System.out.println(sum(source));
	}

	public static String sum(String source) {
		java.util.List<Integer> integers = new ArrayList<Integer>();

		try (Scanner fileScanner = new Scanner(new File(source))) {
			while (fileScanner.hasNextInt()) {
				integers.add(fileScanner.nextInt());
			}
		} catch (IOException e) {
			return "Error";
		}

		long sum = 0;
		
		for (Integer integer : integers) {
			sum += integer;
		}

		return String.valueOf(sum);
	}
}