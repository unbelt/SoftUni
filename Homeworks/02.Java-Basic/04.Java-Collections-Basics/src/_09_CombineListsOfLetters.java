import java.util.ArrayList;
import java.util.Scanner;


/* 9. Write a program that reads two lists of letters l1 and l2 and combines them:
 *    appends all letters c from l2 to the end of l1, but only when c does not appear in l1.
 *    Print the obtained combined list. All lists are given as sequence of letters separated by a single space,
 *    each at a separate line. Use ArrayList<Character> of chars to keep the input and output lists. */

public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		ArrayList<Character> firstList = new ArrayList<Character>();
		ArrayList<Character> secondList = new ArrayList<Character>();
		
		System.out.print("First list: ");
		for (char character : in.nextLine().toCharArray()) {
		    firstList.add(character);
		}
		System.out.print("Second list: ");
		for (char character : in.nextLine().toCharArray()) {
		    secondList.add(character);
		}
		
		in.close();
		
		ArrayList<Character> output = new ArrayList<Character>();
		output.addAll(firstList);
		
		for (int i = 0; i < secondList.size(); i++) {
		    if (!firstList.contains(secondList.get(i))) {
			output.add(' ');
			output.add(secondList.get(i));
		    }
		}
		for (char character : output) {
		    System.out.print(character);
		}
	}
}
