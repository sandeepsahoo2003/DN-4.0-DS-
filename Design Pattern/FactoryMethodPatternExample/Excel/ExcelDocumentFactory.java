package FactoryMethodPatternExample.Excel;

import FactoryMethodPatternExample.Document;
import FactoryMethodPatternExample.DocumentFactory;

// Factory for Excel Documents
public class ExcelDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new ExcelDocument();
    }
}