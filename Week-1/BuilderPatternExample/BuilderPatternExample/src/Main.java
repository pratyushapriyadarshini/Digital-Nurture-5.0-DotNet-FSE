public class Main {

    public static void main(String[] args) {

        Computer computer1 = new Computer.Builder()
                .setCPU("Intel i5")
                .setRAM("8GB")
                .setStorage("512GB SSD")
                .build();

        computer1.display();

        Computer computer2 = new Computer.Builder()
                .setCPU("AMD Ryzen 7")
                .setRAM("16GB")
                .setStorage("1TB SSD")
                .build();

        computer2.display();

    }

}