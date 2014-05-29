import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/* 8. Write a program to extract all email addresses from given text.
 *    The text comes at the first input line. Print the emails in the output, each at a separate line.
 *    Emails are considered to be in format <user>@<host> */

public class _08_ExtractEmails {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		System.out.print("Input: ");
		System.out.print(getValidEmails(in.nextLine()));
		in.close();
	}

	public static List<String> getValidEmails(String input) {
		Pattern emailPattern = Pattern.compile(
				"^([a-z0-9])+([_-])?+([a-z0-9])*@([a-z0-9_-])+([a-z0-9\\._-]+)+$",
				Pattern.CASE_INSENSITIVE);

		Matcher emailMatcher = emailPattern.matcher(input);
		List<String> validEmails = new ArrayList<String>();

		while (emailMatcher.find()) {
			validEmails.add(emailMatcher.group());
		}

		return validEmails;
	}
}
