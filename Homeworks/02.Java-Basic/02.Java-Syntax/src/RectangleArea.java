import java.util.Scanner;

// 1. Write a program that enters the sides of a rectangle (two integers a and b) and calculates and prints the rectangle's area.

public class RectangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter side A: ");
		float sideA = in.nextFloat();
		System.out.print("Enter side B: ");
		float sideB = in.nextFloat();
		
		in.close();
		
		System.out.println("Area: " + sideA * sideB);
	}
}