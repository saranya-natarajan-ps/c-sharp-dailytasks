using System;

class FormatTheData
{
    static void Main()
    {
        string name = "Zachary";
        DateTime bday = new DateTime(1990, 5, 20);
        decimal pay = 69759.25M;

        // Basic formatting
        Console.WriteLine("V1- {0} was born on {1:dd-MM-yyyy} and earns {2:C}", name, bday, pay);
        Console.WriteLine($"V2- {name} was born on {bday:dd-MM-yyyy} and earns {pay:C}");

        // Experimenting with different formats
        // Date formats
        Console.WriteLine($"Date Format 1: {bday:MMMM dd, yyyy}"); // Full month name
        Console.WriteLine($"Date Format 2: {bday:MM/dd/yyyy}"); // MM/dd/yyyy format
        Console.WriteLine($"Date Format 3: {bday:yyyy-MM-dd}"); // ISO 8601 format

        // Number formats
        Console.WriteLine($"Number Format 1: {pay:N}"); // Number with thousands separator
        Console.WriteLine($"Number Format 2: {pay:F2}"); // Fixed-point with 2 decimal places
        Console.WriteLine($"Number Format 3: {pay:E}"); // Scientific notation

        // Currency formats
        Console.WriteLine($"Currency Format 1: {pay:C}"); // Default currency format
        Console.WriteLine($"Currency Format 2: {pay:C2}"); // Currency with 2 decimal places
        Console.WriteLine($"Currency Format 3: {pay:C0}"); // Currency with no decimal places

        // Custom numeric format strings
        Console.WriteLine($"Custom Format 1: {pay:0.00}"); // Two decimal places
        Console.WriteLine($"Custom Format 2: {pay:0,0.00}"); // Thousands separator with two decimal places
        Console.WriteLine($"Custom Format 3: {pay:0.##}"); // Two decimal places if needed
    }
}
