package ProxyPatternExample;

// Proxy: Adds lazy initialization and caching
public class ProxyImage implements Image {

    private final String filename;
    private RealImage realImage;

    public ProxyImage(String filename) {
        this.filename = filename;
    }

    @Override
    public void display() throws InterruptedException {
        if (realImage == null) {
            // Lazy load only when needed
            realImage = new RealImage(filename);
        }
        realImage.display();
    }
}