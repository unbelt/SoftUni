import java.util.Calendar;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

/* 5. Print the Current Date and Time
 * 		Create a simple Java program CurrentDateTime.java to print the current date and time.
 */

public class CurrentDateTime {
	
	public static void main(String[] args) {
		
		DateFormat dateFormat = new SimpleDateFormat("hh:mm:ss dd.MM.yyyy");
		Calendar calendar = Calendar.getInstance();
		
		System.out.println(dateFormat.format(calendar.getTime()));
	}
}