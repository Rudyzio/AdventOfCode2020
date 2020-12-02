using System.Linq;

namespace Day_02_Solver
{
    public static class Day02Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int validPasswords = 0;
            foreach (var line in lines)
            {
                (int min, int max, char letter, string password) = ParseInput(line);
                var timesInPassword = password.Count(x => x == letter);
                if (timesInPassword >= min && timesInPassword <= max)
                    validPasswords++;
            }
            return validPasswords;
        }

        public static int Part2Solution(string[] lines)
        {
            int validPasswords = 0;
            foreach (var line in lines)
            {
                (int firstPosition, int secondPosition, char letter, string password) = ParseInput(line);
                var containsFirstPosition = password[firstPosition - 1] == letter;
                var containsSecondPosition = password[secondPosition - 1] == letter;
                // XOR operation
                if (containsFirstPosition ^ containsSecondPosition)
                    validPasswords++;
            }
            return validPasswords;
        }

        private static (int, int, char, string) ParseInput(string line)
        {
            var splitted = line.Split(" ");
            var times = splitted[0];
            var timesSplitted = splitted[0].Split("-");
            var min = int.Parse(timesSplitted[0]);
            var max = int.Parse(timesSplitted[1]);

            var letter = splitted[1].First();
            var password = splitted[2];
            return (min, max, letter, password);
        }
    }
}
