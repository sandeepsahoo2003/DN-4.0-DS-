package SingletonPatternExample;

public class Logger {

    private Logger() {
        System.out.println("Logger initialized!");
    }

    // Inner static helper class
    private static class LoggerHelper {
        private static final Logger INSTANCE = new Logger();
    }

    public static Logger getInstance() {
        return LoggerHelper.INSTANCE;
    }

    public void log(String message) {
        System.out.println("LOG: " + message);
    }
}
