import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Scanner;

/*7. Write a program to calculate the difference between two dates in number of days.
 *   The dates are entered at two consecutive lines in format day-month-year.
 *   Days are in range [1…31]. Months are in range [1…12]. Years are in range [1900…2100]. */

public class DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		Scanner in = new Scanner(System.in);
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");

		System.out.print("First date: ");
		long firstDate = dateFormat.parse(in.next()).getTime();

		System.out.print("Second date: ");
		long secondDate = dateFormat.parse(in.next()).getTime();

		in.close();

		// using Math.abs() -> there is no negative date count
		System.out.println(Math.abs((firstDate - secondDate)
				/ (1000 * 60 * 60 * 24)));
	}
}
