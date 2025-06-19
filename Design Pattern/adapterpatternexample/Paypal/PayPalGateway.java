package adapterpatternexample.Paypal;

public class PayPalGateway {
    public void sendPayment(double amount) {
        System.out.println("Processing payment of $" + amount + " through PayPal.");
    }
}

