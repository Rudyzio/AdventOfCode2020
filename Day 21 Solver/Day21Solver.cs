using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_21_Solver
{
    public static class Day21Solver
    {
        public static int Part1Solution(string[] lines)
        {
            (var suspects, var occurrences) = ParseInput(lines);
            var allSuspects = suspects.SelectMany(x => x.Value).ToList();
            var totalOccurrences = occurrences.Where(x => !allSuspects.Contains(x.Key)).Sum(x => x.Value);

            return totalOccurrences;
        }

        public static string Part2Solution(string[] lines)
        {
            (var suspects, var occurrences) = ParseInput(lines);

            var canonicalOrder = suspects.OrderBy(x => x.Key).Select(x => x.Value.First()).ToList().Aggregate((i, j) => i + "," + j);

            return canonicalOrder;
        }

        private static (Dictionary<string, List<string>>, Dictionary<string, int>) ParseInput(string[] lines)
        {
            var suspects = new Dictionary<string, List<string>>();
            var occurrences = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var suspectString = Regex.Match(line, @"^[^\(]+").Value;
                var allergenesString = Regex.Match(line, @"\(contains(.*?\))").Groups[1].ToString();
                var suspectsList = suspectString.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();

                foreach (var suspect in suspectsList)
                {
                    if (!occurrences.ContainsKey(suspect))
                    {
                        occurrences.Add(suspect, 1);
                    }
                    else
                    {
                        occurrences[suspect]++;
                    }
                }

                foreach (var allergene in allergenesString.Split(","))
                {
                    var cleanAllergene = allergene.Replace(")", "").Trim();
                    if (!suspects.ContainsKey(cleanAllergene))
                    {
                        suspects.Add(cleanAllergene, new List<string>());
                    }

                    if (suspects[cleanAllergene].Count == 0)
                    {
                        suspects[cleanAllergene] = suspectsList;
                    }
                    else
                    {
                        suspects[cleanAllergene] = suspectsList.Intersect(suspects[cleanAllergene]).ToList();
                    }

                    // Clean from other allergenes
                    if (suspects[cleanAllergene].Count == 1)
                    {
                        var criminal = suspects[cleanAllergene].First();

                        foreach (var storedSuspects in suspects)
                        {
                            if (!storedSuspects.Key.Equals(cleanAllergene))
                            {
                                suspects[storedSuspects.Key] = storedSuspects.Value.Where(x => !x.Equals(criminal)).ToList();
                            }
                        }
                    }
                }
            }
        
            return (suspects, occurrences);
        }
    }
}
