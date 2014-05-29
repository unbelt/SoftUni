import java.util.Scanner;
import java.text.DecimalFormat;

/* 5. Write a method to convert from degrees to radians.
 *    Write a method to convert from radians to degrees.
 *    You are given a number n and n queries for conversion.
 *    Each conversion query will consist of a number + space + measure.
 *    Measures are "deg" and "rad". Convert all radians to degrees and all degrees to radians.
 *    Print the results as n lines, each holding a number + space + measure. */

public class AngleUnitConverter {

	

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Number of queries: ");
		int queries = in.nextInt();
		String[] result = new String[queries];

		for (int i = 0; i < queries; i++) {
			System.out.print("Enter unit #" + (i + 1) + " ");
			result[i] = unitConverter((in.nextDouble()) + " " + in.next());
		}
		in.close();
		
		for (int i = 0; i < result.length; i++) {
			System.out.println(result[i]);
		}
		
	}

	public static String unitConverter(String unit) {
		final String DEGREE = "deg";
		final String RADIANS = "rad";
		
		DecimalFormat decimal = new DecimalFormat("0.000000 ");
		
		double number = Double.valueOf(unit.split(" ")[0]);
		String masure = unit.split(" ")[1];

		if (masure.equals(DEGREE)) {

			return decimal.format(number * Math.PI / 180) + RADIANS;
		}
		if (masure.equals(RADIANS)) {
			return decimal.format(number * 180 / Math.PI) + DEGREE;
		}

		return "Error";
	}
}
