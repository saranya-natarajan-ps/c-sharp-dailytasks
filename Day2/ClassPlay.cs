using System;

namespace ClassPlay
{
    class SportsPlayer
    {
        // Properties
        public string PlayerName { get; set; }
        public string Sport { get; set; }
        public int YearsExperience { get; set; }
        public string Team { get; set; }
        public int Age { get; set; }

        // Constructor
        public SportsPlayer(string playerName, string sport, int yearsExperience, string team, int age)
        {
            PlayerName = playerName;
            Sport = sport;
            YearsExperience = yearsExperience;
            Team = team;
            Age = age;
        }

        // Methods
        public void PrintPlayerInfo()
        {
            Console.WriteLine($"Player Name: {PlayerName}");
            Console.WriteLine($"Sport: {Sport}");
            Console.WriteLine($"Years Experience: {YearsExperience}");
            Console.WriteLine($"Team: {Team}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine();
        }

        public void DisplayPlayerGreeting()
        {
            Console.WriteLine($"Hello, my name is {PlayerName} and I play {Sport} for {Team}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of SportsPlayer
            SportsPlayer player1 = new SportsPlayer("Michael Jordan", "Basketball", 15, "Chicago Bulls", 57);
            SportsPlayer player2 = new SportsPlayer("Serena Williams", "Tennis", 20, "USA", 39);
            SportsPlayer player3 = new SportsPlayer("Lionel Messi", "Soccer", 18, "Inter Miami CF", 36);

            // Using methods on each instance
            player1.PrintPlayerInfo();
            player1.DisplayPlayerGreeting();

            player2.PrintPlayerInfo();
            player2.DisplayPlayerGreeting();

            player3.PrintPlayerInfo();
            player3.DisplayPlayerGreeting();
        }
    }
}
