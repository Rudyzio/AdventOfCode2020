using System;

namespace Day_01_Solver
{
    public static class Day01Solver
    {
        public static int Part1Solution(string[] lines)
        {
            const int sumResult = 2020;
            int[] entries = Array.ConvertAll(lines, int.Parse);

            for (var i = 0; i < entries.Length; i++)
            {
                var toSearch = sumResult - entries[i];
                // Search only on the ones in front, no need to go from the beginning
                for (var j = i + 1; j < entries.Length; j++)
                {
                    if (entries[j] == toSearch)
                    {
                        return entries[i] * entries[j];
                    }
                }
            }

            return 0;
        }

        public static int Part2Solution(string[] lines)
        {
            const int sumResult = 2020;
            int[] entries = Array.ConvertAll(lines, int.Parse);

            for (var i = 0; i < entries.Length; i++)
            {
                // Search only on the ones in front, no need to go from the beginning
                for (var j = i + 1; j < entries.Length; j++)
                {
                    var intermediate = entries[i] + entries[j];
                    // If the sum of the first two numbers is bigger than 2020 just skip
                    if (intermediate < sumResult)
                    {
                        for (var k = j + 1; k < entries.Length; k++)
                        {
                            if (intermediate + entries[k] == sumResult)
                            {
                                return entries[i] * entries[j] * entries[k];
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}
