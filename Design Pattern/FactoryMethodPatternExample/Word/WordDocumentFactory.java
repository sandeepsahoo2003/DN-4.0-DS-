package FactoryMethodPatternExample.Word;

import FactoryMethodPatternExample.Document;
import FactoryMethodPatternExample.DocumentFactory;

// Factory for Word Documents
public class WordDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new WordDocument();
    }
}
