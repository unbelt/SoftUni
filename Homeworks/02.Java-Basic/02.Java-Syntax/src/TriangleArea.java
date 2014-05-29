import java.util.Scanner;

// 1. Write a program that enters 3 points in the plane (as integer x and y coordinates),
// 	  calculates and prints the area of the triangle composed by these 3 points.
// 	  Round the result to a whole number. In case the three points do not form a triangle, print "0" as result. 

public class TriangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.print("Enter Ax: ");
		int Ax = in.nextInt();
		
		System.out.print("Enter AY: ");
		int Ay = in.nextInt();
		
		System.out.print("Enter Bx: ");
		int Bx = in.nextInt();
		
		System.out.print("Enter By: ");
		int By = in.nextInt();
		
		System.out.print("Enter Cx: ");
		int Cx = in.nextInt();
		
		System.out.print("Enter Cy: ");
		int Cy = in.nextInt();
		
		in.close();
		
		int triangleArea = (Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By)) / 2;

		System.out.println("Triangle area = " + Math.abs(triangleArea));
	}
}