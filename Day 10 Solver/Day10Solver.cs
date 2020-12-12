using System.Collections.Generic;
using System.Linq;

namespace Day_10_Solver
{
    public static class Day10Solver
    {
        public static int Part1Solution(string[] lines)
        {
            List<int> adapters = new List<int>();

            foreach (var line in lines)
            {
                adapters.Add(int.Parse(line));
            }

            int oneJoltDiffs = 0;
            int threeJoltDiffs = 0;
            int currentAdapter = 0;
            var currentJoltDifference = 0;

            // Order adapters
            adapters = adapters.OrderBy(x => x).ToList();
            // Add my adapter
            adapters.Add(adapters.Max() + 3);

            foreach (var adapter in adapters)
            {
                currentJoltDifference = adapter - currentAdapter;
                if (currentJoltDifference == 1)
                {
                    oneJoltDiffs++;
                }
                if (currentJoltDifference == 3)
                {
                    threeJoltDiffs++;
                }
                currentAdapter = adapter;
            }

            return oneJoltDiffs * threeJoltDiffs;
        }

        public static long Part2Solution(string[] lines)
        {
            List<int> adapters = new List<int>();

            foreach (var line in lines)
            {
                adapters.Add(int.Parse(line));
            }

            // Order adapters
            adapters = adapters.OrderBy(x => x).ToList();
            adapters.Insert(0, 0);
            // Add my adapter
            adapters.Add(adapters.Max() + 3);

            var forks = new long[adapters.Count];
            for (var i = 0; i < forks.Length; i++)
            {
                // Always begins with only 1 way
                if (i == 0)
                {
                    forks[i] = 1;
                }
                else
                {
                    forks[i] = 0;
                    // Sum the other possibilities that come from behind
                    for (var j = i - 1; j >= 0; j--)
                    {
                        if (adapters[i] - adapters[j] <= 3)
                        {
                            forks[i] += forks[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return forks[forks.Length - 1];
        }
    }
}
