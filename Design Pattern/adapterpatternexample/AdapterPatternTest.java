package adapterpatternexample;

import adapterpatternexample.Paypal.PayPalAdapter;
import adapterpatternexample.Paypal.PayPalGateway;
import adapterpatternexample.Square.SquareAdapter;
import adapterpatternexample.Square.SquareGateway;
import adapterpatternexample.Stripe.StripeAdapter;
import adapterpatternexample.Stripe.StripeGateway;

public class AdapterPatternTest {
    public static void main(String[] args) {
        // PayPal Payment
        PaymentProcessor paypalProcessor = new PayPalAdapter(new PayPalGateway());
        paypalProcessor.processPayment(100.50);

        // Stripe Payment
        PaymentProcessor stripeProcessor = new StripeAdapter(new StripeGateway());
        stripeProcessor.processPayment(250.75);

        // Square Payment
        PaymentProcessor squareProcessor = new SquareAdapter(new SquareGateway());
        squareProcessor.processPayment(500.00);
    }
}