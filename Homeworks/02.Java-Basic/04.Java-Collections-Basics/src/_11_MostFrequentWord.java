import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/* 11. Write a program to find the most frequent word in a text and print it,
 *     as well as how many times it appears in format "word -> count".
 *     Consider any non-letter character as a word separator.
 *     Ignore the character casing. If several words have the same maximal frequency,
 *     print all of them in alphabetical order. */

public class _11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Input: ");
		System.out.print(wordCounter(in.nextLine()));
		in.close();
	}
	
	public static StringBuilder wordCounter(String source) {
		
		String[] input = source.toLowerCase().split("(\\s|\\p{Punct})+");
		Map<String, Integer> wordCount = new TreeMap<String, Integer>();
		int maxCount = 0;
		
		for (String string : input) {
			Integer currentCount = wordCount.get(string);
			
			if (currentCount == null) {
				currentCount = 0;
			}
			if (maxCount < currentCount + 1) {
				maxCount = currentCount + 1;
			}
			
			wordCount.put(string, currentCount + 1);
		}
		
		StringBuilder result = new StringBuilder();
		
		for (Map.Entry<String, Integer> max : wordCount.entrySet()) {
		    if (max.getValue() == maxCount) {
		    	result.append(max.getKey() + " -> " + max.getValue() + " times\r");
		    }
		}
		
		return result;
	}
}
