package FactoryMethodPatternExample;

import FactoryMethodPatternExample.Excel.ExcelDocumentFactory;
import FactoryMethodPatternExample.Pdf.PdfDocumentFactory;
import FactoryMethodPatternExample.Word.WordDocumentFactory;

public class FactoryMethodTest {
    public static void main(String[] args) {
        // Create Word Document
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.createDocument();
        wordDoc.open();
        wordDoc.save();
        wordDoc.close();

        System.out.println("-----------------------------");

        // Create PDF Document
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.createDocument();
        pdfDoc.open();
        pdfDoc.save();
        pdfDoc.close();

        System.out.println("-----------------------------");

        // Create Excel Document
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excelDoc = excelFactory.createDocument();
        excelDoc.open();
        excelDoc.save();
        excelDoc.close();
    }
}
