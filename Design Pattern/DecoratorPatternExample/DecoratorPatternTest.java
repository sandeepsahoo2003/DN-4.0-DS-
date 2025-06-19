package DecoratorPatternExample;

public class DecoratorPatternTest {
    public static void main(String[] args) {

        // Base notifier: Email only
        Notifier simpleEmailNotifier = new EmailNotifier();
        simpleEmailNotifier.send("Hello World!");

        System.out.println("------------------------------");

        // Add SMS notifications on top of Email
        Notifier smsEmailNotifier = new SMSNotifierDecorator(new EmailNotifier());
        smsEmailNotifier.send("Order confirmed!");

        System.out.println("------------------------------");

        // Add SMS and Slack notifications on top of Email
        Notifier multiChannelNotifier = new SlackNotifierDecorator(
                new SMSNotifierDecorator(
                        new EmailNotifier()));
        multiChannelNotifier.send("System maintenance at midnight.");
    }
}