using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQandStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruitsAndVegetables = new List<string>
            {
                "Apple", "Banana", "Strawberry", "Cherry", "Mango", "Blueberry", 
                "Carrot", "Tomato", "Broccoli", "Spinach", "Pineapple", "Peach",
                "Cucumber", "Grape", "Watermelon", "Avocado", "Lettuce", "Pear", 
                "Pumpkin", "Beetroot"
            };

            ListStartWithB(fruitsAndVegetables);
            ListContainBetty(fruitsAndVegetables);
            ListStartWithAtoM(fruitsAndVegetables);
            CountStartWithNtoZ(fruitsAndVegetables);
            FindLongestString(fruitsAndVegetables);
        }

        static void ListStartWithB(List<string> items)
        {
            var result = items.Where(item => item.StartsWith("B", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("Strings that start with 'B' or 'b':");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void ListContainBetty(List<string> items)
        {
            var result = items.Where(item => item.Contains("betty", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("Strings that contain 'betty':");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void ListStartWithAtoM(List<string> items)
        {
            var result = items.Where(item => item[0] >= 'A' && item[0] <= 'M' || item[0] >= 'a' && item[0] <= 'm').ToList();
            Console.WriteLine("Strings that start with letters A-M:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void CountStartWithNtoZ(List<string> items)
        {
            var count = items.Count(item => item[0] >= 'N' && item[0] <= 'Z' || item[0] >= 'n' && item[0] <= 'z');
            Console.WriteLine($"Number of strings that start with letters N-Z: {count}");
            Console.WriteLine();
        }

        static void FindLongestString(List<string> items)
        {
            var longestString = items.OrderByDescending(item => item.Length).FirstOrDefault();
            Console.WriteLine($"The longest string in the list is: {longestString}");
            Console.WriteLine();
        }
    }
}
