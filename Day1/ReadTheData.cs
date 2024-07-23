using System;

class ReadTheData
{
    static void Main()
    {
        // Prompt the user for two integers
        Console.WriteLine("Enter the first integer:");
        int firstInt = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second integer:");
        int secondInt = Convert.ToInt32(Console.ReadLine());

        // Calculate and display the sum, difference, product, and quotient of the two integers
        Console.WriteLine($"Sum of integers: {firstInt + secondInt}");
        Console.WriteLine($"Difference of integers: {firstInt - secondInt}");
        Console.WriteLine($"Product of integers: {firstInt * secondInt}");
        if (secondInt != 0)
        {
            Console.WriteLine($"Quotient of integers: {firstInt / secondInt}");
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }

        // Prompt the user for two doubles
        Console.WriteLine("Enter the first double:");
        double firstDouble = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the second double:");
        double secondDouble = Convert.ToDouble(Console.ReadLine());

        // Calculate and display the sum, difference, product, and quotient of the two doubles
        Console.WriteLine($"Sum of doubles: {firstDouble + secondDouble}");
        Console.WriteLine($"Difference of doubles: {firstDouble - secondDouble}");
        Console.WriteLine($"Product of doubles: {firstDouble * secondDouble}");
        if (secondDouble != 0.0)
        {
            Console.WriteLine($"Quotient of doubles: {firstDouble / secondDouble}");
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }
    }
}
