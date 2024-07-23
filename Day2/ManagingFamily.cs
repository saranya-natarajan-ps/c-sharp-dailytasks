using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagingFamily
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {Gender}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            bool addMorePeople = true;

            while (addMorePeople)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter age: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.Write("Invalid input. Please enter a valid age: ");
                }

                Console.Write("Enter gender: ");
                string gender = Console.ReadLine();

                Person person = new Person(name, age, gender);
                people.Add(person);

                Console.Write("Do you want to add another person (yes/no)? ");
                string response = Console.ReadLine().ToLower();
                if (response != "yes" && response != "y")
                {
                    addMorePeople = false;
                }
            }

            bool continueMenu = true;
            while (continueMenu)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Display all people");
                Console.WriteLine("2. Display all people of a selected gender");
                Console.WriteLine("3. Display all people between a specified age range");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllPeople(people);
                        break;

                    case "2":
                        DisplayPeopleByGender(people);
                        break;

                    case "3":
                        DisplayPeopleByAgeRange(people);
                        break;

                    case "4":
                        continueMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        static void DisplayAllPeople(List<Person> people)
        {
            Console.WriteLine("\nAll People:");
            foreach (var person in people)
            {
                person.Display();
            }
        }

        static void DisplayPeopleByGender(List<Person> people)
        {
            Console.Write("Enter gender to filter by: ");
            string gender = Console.ReadLine().ToLower();

            var filteredPeople = people.Where(p => p.Gender.ToLower() == gender).ToList();

            if (filteredPeople.Any())
            {
                Console.WriteLine($"\nPeople of gender '{gender}':");
                foreach (var person in filteredPeople)
                {
                    person.Display();
                }
            }
            else
            {
                Console.WriteLine($"No people found with gender '{gender}'.");
            }
        }

        static void DisplayPeopleByAgeRange(List<Person> people)
        {
            Console.Write("Enter the minimum age: ");
            int minAge;
            while (!int.TryParse(Console.ReadLine(), out minAge) || minAge < 0)
            {
                Console.Write("Invalid input. Please enter a valid minimum age: ");
            }

            Console.Write("Enter the maximum age: ");
            int maxAge;
            while (!int.TryParse(Console.ReadLine(), out maxAge) || maxAge < 0)
            {
                Console.Write("Invalid input. Please enter a valid maximum age: ");
            }

            var filteredPeople = people.Where(p => p.Age >= minAge && p.Age <= maxAge).ToList();

            if (filteredPeople.Any())
            {
                Console.WriteLine($"\nPeople between ages {minAge} and {maxAge}:");
                foreach (var person in filteredPeople)
                {
                    person.Display();
                }
            }
            else
            {
                Console.WriteLine($"No people found between ages {minAge} and {maxAge}.");
            }
        }
    }
}
