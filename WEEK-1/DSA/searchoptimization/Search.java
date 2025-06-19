package searchoptimization;

public class Search {

    public static Product linearSearch(Product[] products, int productId) {
        for (Product p : products) {
            if (p.getProductId() == productId) {
                return p; // found
            }
        }
        return null; // not found
    }

    public static Product binarySearch(Product[] products, int productId) {
        int left = 0;
        int right = products.length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (products[mid].getProductId() == productId) {
                return products[mid];
            } else if (products[mid].getProductId() < productId) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return null; // not found
    }
}