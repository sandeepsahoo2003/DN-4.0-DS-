package financialforecast;

public class Forecast {

    // OPTIMIZED VERSION
    // public static double predictFutureValueIterative(double currentValue, double growthRate, int years) {
    //     for (int i = 0; i < years; i++) {
    //         currentValue *= (1 + growthRate);
    //     }
    //     return currentValue;
    // }

    // // Or best:
    // public static double predictFutureValueMath(double currentValue, double growthRate, int years) {
    //     return currentValue * Math.pow(1 + growthRate, years);
    // }

    public static double predictFutureValue(double currentValue, double growthRate, int years) {
        if (years == 0) {
            return currentValue; // Base case
        } else {
            return predictFutureValue(currentValue * (1 + growthRate), growthRate, years - 1);
        }
    }

    public static void main(String[] args) {
        double presentValue = 1000.0;
        double annualGrowth = 0.05; // 5%
        int forecastYears = 10;

        double futureValue = predictFutureValue(presentValue, annualGrowth, forecastYears);
        System.out.printf("Future Value after %d years: %.2f\n", forecastYears, futureValue);
    }
}