package searchoptimization;

import java.util.Arrays;

public class SearchTest {
    public static void main(String[] args) {

        Product[] products = {
            new Product(5, "Shoes", "Footwear"),
            new Product(2, "Shirt", "Apparel"),
            new Product(8, "Laptop", "Electronics"),
            new Product(1, "Watch", "Accessories")
        };

        // Linear search works on unsorted array
        Product result1 = Search.linearSearch(products, 8);
        System.out.println("Linear Search found: " + result1);

        // Binary search: must sort first
        Arrays.sort(products, (a, b) -> a.getProductId() - b.getProductId());

        Product result2 = Search.binarySearch(products, 8);
        System.out.println("Binary Search found: " + result2);
    }
}
