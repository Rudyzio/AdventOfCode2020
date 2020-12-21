using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_19_Solver
{
    public static class Day19Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int toReturn = 0;
            (var rules, var messages) = ParseInput(lines);
            foreach (var message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    if (CheckRules(rules["0"], rules, message))
                    {
                        toReturn++;
                    }
                }
            }

            return toReturn;
        }

        public static int Part2Solution(string[] lines)
        {
            int toReturn = 0;
            (var rules, var messages) = ParseInput(lines);
            rules["8"] = new List<List<string>>() { new List<string> { "42" }, new List<string> { "42", "8" } };
            rules["11"] = new List<List<string>>() { new List<string> { "42", "31" }, new List<string> { "42", "11", "31" } };
            // PrintRules(rules);
            foreach (var message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    if (CheckRules(rules["0"], rules, message))
                    {
                        // System.Console.WriteLine($"MATCHED {message}");
                        toReturn++;
                    }
                }
            }

            return toReturn;
        }

        private static bool CheckRules(List<List<string>> currentRules, Dictionary<string, List<List<string>>> rules, string message)
        {
            foreach (var rule in currentRules)
            {
                if (MatchRule(rule.ConvertAll(x => x), rules, message))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool MatchRule(List<string> currentRule, Dictionary<string, List<List<string>>> rules, string message)
        {
            var singleRule = currentRule.First();
            // If rule is letters
            if (Regex.IsMatch(singleRule, @"^[a-zA-Z]+$"))
            {
                if (message.StartsWith(singleRule))
                {
                    message = message.Remove(0, singleRule.Length);
                    currentRule.RemoveAt(0);
                    if (message.Length == 0 && currentRule.Count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (currentRule.Count > 0)
                            return MatchRule(currentRule, rules, message);
                    }

                }
            }
            // Expand
            else
            {
                var expansions = rules[singleRule];
                currentRule.RemoveAt(0);
                foreach (var expansion in expansions)
                {
                    var toPush = new List<string>();
                    toPush.AddRange(expansion);
                    toPush.AddRange(currentRule);
                    if (MatchRule(toPush, rules, message))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static (Dictionary<string, List<List<string>>>, List<string>) ParseInput(string[] lines)
        {
            Dictionary<string, List<List<string>>> rules = new Dictionary<string, List<List<string>>>();
            List<string> messages = new List<string>();
            var parser = ParseSection.Rules;

            // Parse Input
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    parser = ParseSection.Messages;
                }

                if (parser == ParseSection.Rules)
                {
                    var splitted = line.Split(":");
                    var rule = splitted[1];

                    if (rule.Contains("|"))
                    {
                        foreach (var ruleSplitted in rule.Split("|"))
                        {
                            if (!rules.ContainsKey(splitted[0]))
                            {
                                rules.Add(splitted[0], new List<List<string>>());
                            }
                            rules[splitted[0]].Add(ruleSplitted.Split(" ").ToList().Where(x => !string.IsNullOrEmpty(x)).ToList());
                        }
                    }
                    else
                    {
                        rules.Add(splitted[0], new List<List<string>>() { rule.Replace("\"", string.Empty).Split(" ").ToList().Where(x => !string.IsNullOrEmpty(x)).ToList() });
                    }
                }
                else
                {
                    messages.Add(line);
                }

            }

            return (rules, messages);
        }

        private static void Print(Dictionary<string, List<List<string>>> rules, List<string> messages)
        {
            PrintRules(rules);
            PrintMessages(messages);
        }

        private static void PrintRules(Dictionary<string, List<List<string>>> rules)
        {
            foreach (var rule in rules)
            {
                var rightSide = string.Empty;
                foreach (var entry in rule.Value)
                {
                    rightSide += entry.Aggregate((i, j) => i + " " + j) + " | ";
                }
                System.Console.WriteLine($"{rule.Key}: {rightSide.Remove(rightSide.Length - 1)}");
            }
        }

        private static void PrintMessages(List<string> messages)
        {
            foreach (var message in messages)
            {
                System.Console.WriteLine(message);
            }
        }
    }

    public enum ParseSection
    {
        Rules,
        Messages
    }
}
