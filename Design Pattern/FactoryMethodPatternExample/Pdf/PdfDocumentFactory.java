package FactoryMethodPatternExample.Pdf;

import FactoryMethodPatternExample.Document;
import FactoryMethodPatternExample.DocumentFactory;

// Factory for PDF Documents
public class PdfDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new PdfDocument();
    }
}