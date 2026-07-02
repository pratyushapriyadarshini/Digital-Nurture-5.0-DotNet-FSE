public class Main {

    public static void main(String[] args) {

        PaymentContext context =
                new PaymentContext(new CreditCardPayment());

        context.makePayment(5000);

        context.setStrategy(new PayPalPayment());

        context.makePayment(2500);

    }
}