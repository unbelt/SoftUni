package java.util;

import java.io.Serializable;
import java.io.ObjectOutputStream;
import java.io.IOException;
import java.lang.reflect.Array;
import java.util.function.BiConsumer;
import java.util.function.BiFunction;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.function.UnaryOperator;
import java.util.stream.IntStream;
import java.util.stream.Stream;
import java.util.stream.StreamSupport;

public class Collections {
	// Suppresses default constructor, ensuring non-instantiability.
	private Collections() {
	}

	// Algorithms
	private static final int BINARYSEARCH_THRESHOLD = 5000;
	private static final int REVERSE_THRESHOLD = 18;
	private static final int SHUFFLE_THRESHOLD = 5;
	private static final int FILL_THRESHOLD = 25;
	private static final int ROTATE_THRESHOLD = 100;
	private static final int COPY_THRESHOLD = 10;
	private static final int REPLACEALL_THRESHOLD = 11;
	private static final int INDEXOFSUBLIST_THRESHOLD = 35;

	@SuppressWarnings("unchecked")
	public static <T extends Comparable<? super T>> void sort(List<T> list) {
		Object[] array = list.toArray();
		Arrays.sort(array);
		ListIterator<T> list = list.listIterator();

		for (int j = 0; j < array.length; j++) {
			list.next();
			list.set((T) array[j]);
		}
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static <T> void sort(List<T> list, Comparator<? super T> c) {
		Object[] array = list.toArray();
		Arrays.sort(array, (Comparator) c);
		ListIterator<T> list = list.listIterator();

		for (int j = 0; j < array.length; j++) {
			list.next();
			list.set((T) array[j]);
		}
	}

	public static <T> int binarySearch(
			List<? extends Comparable<? super T>> list, T key) {

		if (list instanceof RandomAccess
				|| list.size() < BINARYSEARCH_THRESHOLD) {
			return Collections.indexedBinarySearch(list, key);
		}

		return Collections.iteratorBinarySearch(list, key);
	}

	private static <T> int indexedBinarySearch(
			List<? extends Comparable<? super T>> list, T key) {
		int low = 0;
		int high = list.size() - 1;

		while (low <= high) {
			int mid = (low + high) >>> 1;
			Comparable<? super T> midVal = list.get(mid);
			int cmp = midVal.compareTo(key);

			if (cmp < 0) {
				low = mid + 1;
			} else if (cmp > 0) {
				high = mid - 1;
			}

			return mid; // key found
		}

		return -(low + 1); // key not found

	}

	private static <T> int iteratorBinarySearch(
			List<? extends Comparable<? super T>> list, T key) {
		int low = 0;
		int high = list.size() - 1;
		ListIterator<? extends Comparable<? super T>> list = list
				.listIterator();

		while (low <= high) {
			int mid = (low + high) >>> 1;
			Comparable<? super T> midVal = get(list, mid);
			int cmp = midVal.compareTo(key);

			if (cmp < 0) {
				low = mid + 1;
			} else if (cmp > 0) {
				high = mid - 1;
			}

			return mid; // key found
		}

		return -(low + 1); // key not found
	}

	private static <T> T get(ListIterator<? extends T> list, int index) {
		T obj = null;

		int pos = list.nextIndex();
		if (pos <= index) {
			do {
				obj = list.next();
			} while (pos++ < index);
		} else {
			do {
				obj = list.previous();
			} while (--pos > index);
		}

		return obj;
	}
}