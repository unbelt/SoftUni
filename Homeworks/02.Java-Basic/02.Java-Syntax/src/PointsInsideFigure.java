import java.awt.Rectangle;
import java.awt.geom.Rectangle2D;
import java.util.Scanner;

// 3. Write a program to check whether a point is inside or outside of a given figure.
//	  The point is given as a pair of floating-point numbers, separated by a space.
//    Your program should print "Inside" or "Outside". 

public class PointsInsideFigure {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		Rectangle2D firstRectangle = new Rectangle();
		firstRectangle.setFrame(12.5, 6, 10, 2.5);
		
		Rectangle2D secondRectangle = new Rectangle();
		secondRectangle.setFrame(12.5, 8.5, 5, 5);
		
		Rectangle2D thirdRectangle = new Rectangle();
		thirdRectangle.setFrame(20, 8.5, 2.5, 5);
		
		System.out.print("Enter point x: ");
		double x = in.nextDouble();
		
		System.out.print("Enter point y: ");
		double y = in.nextDouble();
		
		in.close();
		
		if (firstRectangle.contains(x, y) ||
			secondRectangle.contains(x, y) ||
			thirdRectangle.contains(x, y)) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}
}