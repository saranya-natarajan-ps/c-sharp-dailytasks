using System;

class MortgageCalculator
{
    static void Main()
    {
        // Prompt the user for the loan amount
        Console.WriteLine("How much are you borrowing?");
        decimal amountBorrowed = Convert.ToDecimal(Console.ReadLine());

        // Prompt the user for the interest rate
        Console.WriteLine("What is your interest rate?");
        double annualInterestRate = Convert.ToDouble(Console.ReadLine());

        // Prompt the user for the loan length in years
        Console.WriteLine("How long is your loan (in years)?");
        int loanLengthInYears = Convert.ToInt32(Console.ReadLine());

        // Calculate the monthly interest rate
        double monthlyInterestRate = annualInterestRate / 1200;

        // Calculate the number of monthly payments
        int numberOfPayments = loanLengthInYears * 12;

        // Calculate the monthly payment using the formula
        double estimatedPayment = CalculateMonthlyPayment(amountBorrowed, monthlyInterestRate, numberOfPayments);

        // Display the estimated monthly payment
        Console.WriteLine($"Your estimated payment is {estimatedPayment:C}");
    }

    static double CalculateMonthlyPayment(decimal amountBorrowed, double monthlyInterestRate, int numberOfPayments)
    {
        double A = (double)amountBorrowed;
        double MIR = monthlyInterestRate;
        int NP = numberOfPayments;

        double Pmt = A * MIR / (1 - Math.Pow(1 + MIR, -NP));
        return Pmt;
    }
}
