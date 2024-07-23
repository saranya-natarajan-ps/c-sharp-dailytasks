using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQandObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Alice", Gender = "Female", Age = 30, Hometown = "New York" },
                new Person { Name = "Bob", Gender = "Male", Age = 22, Hometown = "Los Angeles" },
                new Person { Name = "Charlie", Gender = "Male", Age = 24, Hometown = "Chicago" },
                new Person { Name = "David", Gender = "Male", Age = 26, Hometown = "Houston" },
                new Person { Name = "Eva", Gender = "Female", Age = 21, Hometown = "Phoenix" },
                new Person { Name = "Frank", Gender = "Male", Age = 29, Hometown = "Philadelphia" },
                new Person { Name = "Grace", Gender = "Female", Age = 28, Hometown = "San Antonio" },
                new Person { Name = "Hannah", Gender = "Female", Age = 22, Hometown = "San Diego" },
                new Person { Name = "Ivan", Gender = "Male", Age = 23, Hometown = "Dallas" },
                new Person { Name = "Jack", Gender = "Male", Age = 30, Hometown = "San Jose" },
                new Person { Name = "Kathy", Gender = "Female", Age = 25, Hometown = "Austin" },
                new Person { Name = "Leo", Gender = "Male", Age = 21, Hometown = "Jacksonville" },
                new Person { Name = "Mia", Gender = "Female", Age = 27, Hometown = "Fort Worth" },
                new Person { Name = "Nina", Gender = "Female", Age = 24, Hometown = "Columbus" },
                new Person { Name = "Oscar", Gender = "Male", Age = 28, Hometown = "Charlotte" },
                new Person { Name = "Paul", Gender = "Male", Age = 22, Hometown = "San Francisco" },
                new Person { Name = "Quincy", Gender = "Male", Age = 25, Hometown = "Indianapolis" },
                new Person { Name = "Rachel", Gender = "Female", Age = 26, Hometown = "Seattle" },
                new Person { Name = "Sophia", Gender = "Female", Age = 23, Hometown = "Denver" },
                new Person { Name = "Tom", Gender = "Male", Age = 29, Hometown = "Boston" },
            };

            ListMalesUnder25(people);
            ListDistinctHometowns(people);
            ListPeopleSortedByHometownAndName(people);
            AverageAgeByGender(people);
            ListHometownsAndCount(people);
        }

        static void ListMalesUnder25(List<Person> people)
        {
            var result = people.Where(p => p.Gender == "Male" && p.Age < 25).ToList();
            Console.WriteLine("Males under 25:");
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} ({person.Age} years old) from {person.Hometown}");
            }
            Console.WriteLine();
        }

        static void ListDistinctHometowns(List<Person> people)
        {
            var result = people.Select(p => p.Hometown).Distinct().OrderBy(h => h).ToList();
            Console.WriteLine("Distinct hometowns in ascending order:");
            foreach (var hometown in result)
            {
                Console.WriteLine(hometown);
            }
            Console.WriteLine();
        }

        static void ListPeopleSortedByHometownAndName(List<Person> people)
        {
            var result = people.OrderBy(p => p.Hometown).ThenBy(p => p.Name).ToList();
            Console.WriteLine("People sorted by hometown, and within hometown by name:");
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} from {person.Hometown}");
            }
            Console.WriteLine();
        }

        static void AverageAgeByGender(List<Person> people)
        {
            var averageAgeWomen = people.Where(p => p.Gender == "Female").Average(p => p.Age);
            var averageAgeMen = people.Where(p => p.Gender == "Male").Average(p => p.Age);

            Console.WriteLine($"Average age of women: {averageAgeWomen:F2}");
            Console.WriteLine($"Average age of men: {averageAgeMen:F2}");
            Console.WriteLine();
        }

        static void ListHometownsAndCount(List<Person> people)
        {
            var result = people.GroupBy(p => p.Hometown)
                               .Select(g => new { Hometown = g.Key, Count = g.Count() })
                               .OrderBy(h => h.Hometown)
                               .ToList();

            Console.WriteLine("Hometowns and the number of people from each hometown:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Hometown}: {item.Count} people");
            }
            Console.WriteLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
