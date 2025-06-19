package DecoratorPatternExample;

// Concrete Component: sends Email notifications
public class EmailNotifier implements Notifier {

    @Override
    public void send(String message) {
        System.out.println("Sending EMAIL with message: " + message);
    }
}