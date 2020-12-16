using System.Collections.Generic;

namespace Day_15_Solver
{
    public static class Day15Solver
    {
        public static int Part1Solution(string[] lines)
        {
            return DetermineNumber(lines, 2020);
        }

        public static int Part2Solution(string[] lines)
        {
            return DetermineNumber(lines, 30000000);
        }

        private static int DetermineNumber(string[] lines, int target)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            var line = lines[0];
            var splitted = line.Split(",");

            int turn = 1;
            int lastNumber = 0;
            int currentNumber = 0;
            bool lastNumberFirstTime = true;

            foreach (var startingNum in splitted)
            {
                lastNumber = int.Parse(startingNum);
                numbers.Add(lastNumber, turn);
                turn++;
            }

            while (turn <= target)
            {
                if (lastNumberFirstTime)
                {
                    currentNumber = 0;
                    if (numbers.ContainsKey(currentNumber))
                    {
                        lastNumberFirstTime = false;
                    }
                    else
                    {
                        numbers.Add(currentNumber, turn);
                    }
                }
                else
                {
                    currentNumber = turn - 1 - numbers[lastNumber];
                    numbers[lastNumber] = turn - 1;
                    if (!numbers.ContainsKey(currentNumber))
                    {
                        lastNumberFirstTime = true;
                        numbers.Add(currentNumber, turn);
                    }

                }

                turn++;
                lastNumber = currentNumber;
            }

            return lastNumber;
        }

    }
}
