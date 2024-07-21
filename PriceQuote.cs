using System;

class PriceQuoter
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Price Quoter Menu:");
            Console.WriteLine("1. Enter a new order");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "2")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            if (choice != "1")
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }

            // Display product list
            Console.WriteLine("Available Products:");
            Console.WriteLine("1. BG-127");
            Console.WriteLine("2. WRTR-28");
            Console.WriteLine("3. GUAC-8");
            Console.Write("Choose a product by entering the number: ");
            string productChoice = Console.ReadLine();

            string productCode;
            switch (productChoice)
            {
                case "1":
                    productCode = "BG-127";
                    break;
                case "2":
                    productCode = "WRTR-28";
                    break;
                case "3":
                    productCode = "GUAC-8";
                    break;
                default:
                    Console.WriteLine("Invalid product choice. Please try again.");
                    continue;
            }

            // Prompt the user for the quantity
            Console.WriteLine("Enter the quantity:");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive integer.");
                continue;
            }

            // Determine the price per unit based on the product code and quantity
            decimal pricePerUnit = GetPricePerUnit(productCode, quantity);

            if (pricePerUnit == -1)
            {
                Console.WriteLine("Invalid product code.");
                continue;
            }

            // Calculate the total price
            decimal totalPrice = pricePerUnit * quantity;

            // Check for additional large order discount
            if (quantity >= 250)
            {
                decimal discount = totalPrice * 0.15m;
                decimal discountedPrice = totalPrice - discount;

                Console.WriteLine($"Product Code: {productCode}");
                Console.WriteLine($"Quantity: {quantity}");
                Console.WriteLine($"Per Unit Price: {pricePerUnit:C}");
                Console.WriteLine($"Total Order Price: {totalPrice:C}");
                Console.WriteLine($"Large Order Discount: 15%");
                Console.WriteLine($"Discounted Order Price: {discountedPrice:C}");
            }
            else
            {
                Console.WriteLine($"Product Code: {productCode}");
                Console.WriteLine($"Quantity: {quantity}");
                Console.WriteLine($"Per Unit Price: {pricePerUnit:C}");
                Console.WriteLine($"Total Order Price: {totalPrice:C}");
            }

            Console.WriteLine(); // Add a blank line for readability
        }
    }

    static decimal GetPricePerUnit(string productCode, int quantity)
    {
        switch (productCode)
        {
            case "BG-127":
                if (quantity >= 1 && quantity <= 24) return 18.99m;
                if (quantity >= 25 && quantity <= 50) return 17.00m;
                if (quantity >= 51) return 14.49m;
                break;

            case "WRTR-28":
                if (quantity >= 1 && quantity <= 24) return 125.00m;
                if (quantity >= 25 && quantity <= 50) return 113.75m;
                if (quantity >= 51) return 99.99m;
                break;

            case "GUAC-8":
                if (quantity >= 1 && quantity <= 50) return 8.99m;
                if (quantity >= 51) return 7.49m;
                break;
        }
        return -1; // Invalid product code
    }
}
