using System;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> movies = new List<string>();
            bool addMoreMovies = true;

            while (addMoreMovies)
            {
                Console.Write("Enter a movie name: ");
                string movie = Console.ReadLine();
                movies.Add(movie);

                Console.Write("Do you want to add another movie (yes/no)? ");
                string response = Console.ReadLine().ToLower();
                if (response != "yes" && response != "y")
                {
                    addMoreMovies = false;
                }
            }

            movies.Sort();
            Console.WriteLine("\nMovies sorted alphabetically:");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            bool continueSearching = true;
            while (continueSearching)
            {
                Console.WriteLine("\nChoose search type: ");
                Console.WriteLine("1. Partial Search");
                Console.WriteLine("2. Exact Search");
                Console.Write("Enter your choice (1 or 2): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a word or phrase to search for: ");
                        string partialSearch = Console.ReadLine().ToLower();
                        var partialMatches = movies.Where(m => m.ToLower().Contains(partialSearch)).ToList();

                        if (partialMatches.Any())
                        {
                            Console.WriteLine("Partial Search Results:");
                            foreach (var match in partialMatches)
                            {
                                Console.WriteLine(match);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No matches found.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter the exact movie name to search for: ");
                        string exactSearch = Console.ReadLine().ToLower();
                        bool exactMatch = movies.Any(m => m.ToLower() == exactSearch);

                        if (exactMatch)
                        {
                            Console.WriteLine($"The movie '{exactSearch}' was found.");
                        }
                        else
                        {
                            Console.WriteLine($"The movie '{exactSearch}' was not found.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        continue;
                }

                Console.Write("Do you want to perform another search (yes/no)? ");
                string continueResponse = Console.ReadLine().ToLower();
                if (continueResponse != "yes" && continueResponse != "y")
                {
                    continueSearching = false;
                }
            }
        }
    }
}
