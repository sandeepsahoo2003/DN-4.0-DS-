package BuilderPatternExample;

public class BuilderPatternTest {
    public static void main(String[] args) {

        // Build a high-end gaming computer
        Computer gamingPC = new Computer.Builder()
                .setCPU("Intel i9")
                .setRAM("32GB")
                .setStorage("2TB SSD")
                .setGraphicsCard(true)
                .setBluetooth(true)
                .build();

        System.out.println(gamingPC);

        // Build a basic office computer
        Computer officePC = new Computer.Builder()
                .setCPU("Intel i5")
                .setRAM("8GB")
                .setStorage("512GB SSD")
                .setGraphicsCard(false)
                .setBluetooth(false)
                .build();

        System.out.println(officePC);
    }
}