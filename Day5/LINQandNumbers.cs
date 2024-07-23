using System;
using System.Linq;

namespace LINQandNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[50];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10001); // Generates random numbers between 1 and 10,000
            }

            ListNumbersAscending(numbers);
            ListNumbersUnder100Descending(numbers);
            ListEvenNumbers(numbers);
            FindMinMaxSum(numbers);
        }

        static void ListNumbersAscending(int[] numbers)
        {
            var sortedNumbers = numbers.OrderBy(n => n).ToArray();
            Console.WriteLine("Numbers in ascending order:");
            foreach (var number in sortedNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");
        }

        static void ListNumbersUnder100Descending(int[] numbers)
        {
            var filteredNumbers = numbers.Where(n => n < 100).OrderByDescending(n => n).ToArray();
            Console.WriteLine("Numbers under 100 in descending order:");
            foreach (var number in filteredNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");
        }

        static void ListEvenNumbers(int[] numbers)
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            Console.WriteLine("Even numbers in original order:");
            foreach (var number in evenNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");
        }

        static void FindMinMaxSum(int[] numbers)
        {
            var minNumber = numbers.Min();
            var maxNumber = numbers.Max();
            var sumNumbers = numbers.Sum();

            Console.WriteLine($"Minimum number: {minNumber}");
            Console.WriteLine($"Maximum number: {maxNumber}");
            Console.WriteLine($"Sum of all numbers: {sumNumbers}\n");
        }
    }
}
