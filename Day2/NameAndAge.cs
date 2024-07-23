using System;

namespace NameAndAge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueEntering = true;
            int maxAttempts = 3;
            int attemptCount = 0;

            while (continueEntering && attemptCount < maxAttempts)
            {
                attemptCount++;

                Console.Write("Please enter your name: ");
                string name = Console.ReadLine();

                Console.Write("Please enter how old you will be on 31-December: ");
                int ageOn31December;
                while (!int.TryParse(Console.ReadLine(), out ageOn31December) || ageOn31December < 0)
                {
                    Console.Write("Invalid input. Please enter a valid age: ");
                }

                int birthYear = GetBirthYear(ageOn31December);
                Console.WriteLine($"{name} was born in {birthYear}");

                if (attemptCount < maxAttempts)
                {
                    Console.Write("Do you want to enter another (yes/no)? ");
                    string response = Console.ReadLine().ToLower();
                    if (response != "yes" && response != "y")
                    {
                        continueEntering = false;
                    }
                }
            }
        }

        static int GetBirthYear(int ageOn31December)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - ageOn31December;
        }
    }
}
