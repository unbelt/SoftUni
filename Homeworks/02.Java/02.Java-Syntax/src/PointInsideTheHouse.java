import java.awt.Rectangle;
import java.awt.geom.Path2D;
import java.util.Scanner;

// 9. Write a program to check whether a point is inside or outside a given shape.
//	  The point is given as a pair of floating-point
//    numbers, separated by a space. Your program should print "Inside" or "Outside".

public class PointInsideTheHouse {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		double[] xPoints = { 12.5, 12.5, 17.5, 17.5, 20, 20, 22.5, 22.5, 17.5 };
		double[] yPoints = { 8.5, 13.5, 13.5, 8.5, 8.5, 13.5, 13.5, 8.5, 3.5 };

		Path2D house = new Path2D.Double();
		house.moveTo(xPoints[0], yPoints[0]);

		for (int i = 1; i < xPoints.length; ++i) {
			house.lineTo(xPoints[i], yPoints[i]);
		}

		house.closePath();
		Rectangle houseBounds = new Rectangle();
		houseBounds = house.getBounds();
		
		System.out.print("Enter point x: ");
		double x = in.nextDouble();
		
		System.out.print("Enter point y: ");
		double y = in.nextDouble();
		
		in.close();
		
		if (houseBounds.contains(x, y) && house.contains(x, y)) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}
}