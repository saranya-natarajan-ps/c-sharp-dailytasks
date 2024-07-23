using System;

namespace TimeMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter time in hh:mm format: ");
            string inputTime = Console.ReadLine();

            if (!DateTime.TryParseExact(inputTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
            {
                Console.WriteLine("Invalid time format. Please use hh:mm format.");
                return;
            }

            Console.Write("Enter number of minutes to add: ");
            if (!int.TryParse(Console.ReadLine(), out int minutesToAdd) || minutesToAdd < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of minutes.");
                return;
            }

            DateTime newTime = time.AddMinutes(minutesToAdd);

            Console.WriteLine($"New time: {newTime:HH:mm}");
        }
    }
}
