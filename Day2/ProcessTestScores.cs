using System;

namespace ProcessTestScores
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testScores = GetTestScores();

            int highestScore = GetHighestScore(testScores);
            double averageScore = GetAverageScore(testScores);
            int lowestScore = GetLowestScore(testScores);

            Console.WriteLine($"Highest Test Score: {highestScore}");
            Console.WriteLine($"Average Test Score: {averageScore:F2}");
            Console.WriteLine($"Lowest Test Score: {lowestScore}");
        }

        static int[] GetTestScores()
        {
            int[] scores = new int[6];
            for (int i = 0; i < scores.Length; i++)
            {
                Console.Write($"Enter test score {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out scores[i]) || scores[i] < 0 || scores[i] > 100)
                {
                    Console.Write("Invalid input. Please enter a valid test score between 0 and 100: ");
                }
            }
            return scores;
        }

        static int GetHighestScore(int[] scores)
        {
            int highest = scores[0];
            foreach (int score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                }
            }
            return highest;
        }

        static double GetAverageScore(int[] scores)
        {
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            return (double)total / scores.Length;
        }

        static int GetLowestScore(int[] scores)
        {
            int lowest = scores[0];
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            return lowest;
        }
    }
}
