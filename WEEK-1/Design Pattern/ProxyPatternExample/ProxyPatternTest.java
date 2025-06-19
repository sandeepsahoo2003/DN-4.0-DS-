package ProxyPatternExample;

public class ProxyPatternTest {
    public static void main(String[] args) throws InterruptedException {

        Image image1 = new ProxyImage("Photo1.jpg");
        Image image2 = new ProxyImage("Photo2.jpg");

        // Image will be loaded only on first display()
        System.out.println("First call - image1:");
        image1.display(); // loads + displays

        System.out.println("\nSecond call - image1:");
        image1.display(); // uses cached realImage

        System.out.println("\nFirst call - image2:");
        image2.display(); // loads + displays

        System.out.println("\nSecond call - image2:");
        image2.display(); // uses cached realImage
    }
}