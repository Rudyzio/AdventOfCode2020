using System.Collections.Generic;
using System.Linq;

namespace Day_06_Solver
{
    public static class Day06Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int yesAnswersCount = 0;
            List<char> yesAnswers = new List<char>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yesAnswersCount += yesAnswers.Count;
                    yesAnswers.Clear();
                    continue;
                }

                foreach (var character in line)
                {
                    if (!yesAnswers.Contains(character))
                    {
                        yesAnswers.Add(character);
                    }
                }
            }
            // Last line not counted if lines end without an empty line
            yesAnswersCount += yesAnswers.Count;

            return yesAnswersCount;
        }

        public static int Part2Solution(string[] lines)
        {
            int yesAnswersCount = 0;
            List<char> yesAnswers = new List<char>();
            List<char> yesTotalAnswers = new List<char>();
            int peopleInGroup = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    foreach (var answer in yesAnswers)
                    {
                        if (yesTotalAnswers.Count(x => x == answer) == peopleInGroup)
                        {
                            yesAnswersCount++;
                        }
                    }
                    yesAnswers.Clear();
                    yesTotalAnswers.Clear();
                    peopleInGroup = 0;
                    continue;
                }

                foreach (var character in line)
                {
                    if (!yesAnswers.Contains(character))
                    {
                        yesAnswers.Add(character);
                    }
                    yesTotalAnswers.Add(character);
                }

                peopleInGroup++;
            }
            // Last line not counted if lines end without an empty line
            foreach (var answer in yesAnswers)
            {
                if (yesTotalAnswers.Count(x => x == answer) == peopleInGroup)
                {
                    yesAnswersCount++;
                }
            }

            return yesAnswersCount;
        }
    }
}
