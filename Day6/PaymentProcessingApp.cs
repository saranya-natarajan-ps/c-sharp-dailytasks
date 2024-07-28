using System;

namespace PaymentProcessingApp
{
    // Define a delegate type that matches the signature of the payment processing methods
    delegate bool PaymentHandler(string accountNumber, double amount);

    // Step 1: Define the various payment processing methods
    class PaymentMethods
    {
        private static Random random = new Random();

        public bool ProcessMastercardPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Mastercard payment for account {accountNumber} with amount {amount}");
            return random.Next(0, 10) >= 1; // 10% chance of failure
        }

        public bool ProcessVisaPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Visa payment for account {accountNumber} with amount {amount}");
            return random.Next(0, 10) >= 1; // 10% chance of failure
        }

        public bool ProcessDiscoverPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Discover payment for account {accountNumber} with amount {amount}");
            return random.Next(0, 10) >= 1; // 10% chance of failure
        }
    }

    // Step 3: Create the PaymentProcessor class
    class PaymentProcessor
    {
        public bool ProcessPayment(PaymentHandler paymentHandler, string accountNumber, double amount)
        {
            return paymentHandler(accountNumber, amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentMethods paymentMethods = new PaymentMethods();
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            // Mastercard payment
            PaymentHandler mastercardHandler = new PaymentHandler(paymentMethods.ProcessMastercardPayment);
            bool isMastercardOk = paymentProcessor.ProcessPayment(mastercardHandler, "1234-1111-2222-1234", 100.00);
            if (!isMastercardOk)
                Console.WriteLine("[ALERT] Mastercard payment processing failed");

            // Visa payment
            PaymentHandler visaHandler = new PaymentHandler(paymentMethods.ProcessVisaPayment);
            bool isVisaOk = paymentProcessor.ProcessPayment(visaHandler, "1234-2222-3333-2345", 200.00);
            if (!isVisaOk)
                Console.WriteLine("[ALERT] Visa payment processing failed");

            // Discover payment
            PaymentHandler discoverHandler = new PaymentHandler(paymentMethods.ProcessDiscoverPayment);
            bool isDiscoverOk = paymentProcessor.ProcessPayment(discoverHandler, "1234-3333-4444-3456", 300.00);
            if (!isDiscoverOk)
                Console.WriteLine("[ALERT] Discover payment processing failed");
        }
    }
}
