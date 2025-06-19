package ProxyPatternExample;

// Real Subject: Loads a big image from a remote server
public class RealImage implements Image {

    private final String filename;

    public RealImage(String filename) throws InterruptedException {
        this.filename = filename;
        loadFromRemoteServer();
    }

    private void loadFromRemoteServer() throws InterruptedException {
        System.out.println("Loading image from remote server: " + filename);
        // Simulate heavy loading with sleep if you want:
         Thread.sleep(5000);
    }

    @Override
    public void display() {
        System.out.println("Displaying image: " + filename);
    }
}