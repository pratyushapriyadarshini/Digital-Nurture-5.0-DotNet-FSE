public class Main {

    public static void main(String[] args) {

        Logger logger1 = Logger.getInstance();

        logger1.log("Application Started");

        Logger logger2 = Logger.getInstance();

        logger2.log("User Logged In");

        if (logger1 == logger2) {
            System.out.println("Both Logger objects are the SAME instance.");
        } else {
            System.out.println("Different instances created.");
        }

    }

}