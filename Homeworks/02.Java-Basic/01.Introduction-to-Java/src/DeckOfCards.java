import java.io.FileOutputStream;

import javax.swing.JFrame;
import javax.swing.JOptionPane;

import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Image;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

/* 9. Generate a PDF by External Library
 * 		Write a program to generate a PDF document called Deck-of-Cards.pdf
 * 		and print in it a standard deck of 52 cards, following one after another.
 * 		Each card should be a rectangle holding its face and suit. 
 */

public class DeckOfCards {

	// Document path and font
	private static String FILE = "Cards.pdf"; // ouput will be at current dir
	private static Font titleFont = new Font(Font.FontFamily.COURIER, 36, Font.BOLD);

	// Execution
	public static void main(String[] args) {
		Document document = new Document();
		JFrame frame = new JFrame();
		
		try {
			PdfWriter.getInstance(document, new FileOutputStream(FILE));
			document.open();
			addMetaData(document);
			addContent(document);
			document.close();
			JOptionPane.showMessageDialog(frame, "Export successful!");
		} catch (Exception e) {
			e.printStackTrace();
			JOptionPane.showMessageDialog(frame, "Something goes wrong!");
		}
	}

	// Meta data
	private static void addMetaData(Document document) {
		document.addTitle("Deck of Cards");
		document.addSubject("Print deck of cards");
		document.addKeywords("Deck, Cards, PDF");
		document.addAuthor("Flyer");
		document.addCreator("Flyer");
	}
	
	// Main logic
	private static void addContent(Document document) throws DocumentException {

		// Add title
		Paragraph title = new Paragraph("Deck of Cards", titleFont);
		title.setAlignment(Element.ALIGN_CENTER);
		title.setSpacingAfter(50);
		document.add(title);

		PdfPTable table = new PdfPTable(13);
		
		for (int i = 0; i < 52; i++) {
			try {
				table.addCell(Image.getInstance("img/" + (i + 1) + ".jpg"));
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		
		document.add(table);
	}
}