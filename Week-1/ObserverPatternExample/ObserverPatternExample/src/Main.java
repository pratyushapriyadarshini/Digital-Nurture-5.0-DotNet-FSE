public class Main {

    public static void main(String[] args) {

        NewsAgency agency = new NewsAgency();

        Observer channel1 = new NewsChannel("Aaj Tak");
        Observer channel2 = new NewsChannel("NDTV");

        agency.registerObserver(channel1);
        agency.registerObserver(channel2);

        agency.setNews("Observer Pattern Implemented Successfully");

    }
}