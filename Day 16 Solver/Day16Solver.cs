using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_16_Solver
{
    public static class Day16Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int toReturn = 0;

            (var validations, var myTicket, var otherTickets) = ParseInput(lines);

            foreach (var ticket in otherTickets)
            {
                foreach (var pos in ticket)
                {
                    var validPos = false;
                    foreach (var validation in validations)
                    {
                        if (validation.Value(pos))
                        {
                            validPos = true;
                            break;
                        }
                    }
                    if (!validPos)
                    {
                        toReturn += pos;
                        break;
                    }
                }
            }

            return toReturn;
        }

        public static long Part2Solution(string[] lines)
        {
            (var validations, var myTicket, var otherTickets) = ParseInput(lines);
            
            List<List<int>> otherTicketsCleaned = new List<List<int>>();
            Dictionary<string, List<int>> validColumns = new Dictionary<string, List<int>>();
            Dictionary<string, int> definitiveColumns = new Dictionary<string, int>();
            long toReturn = 1;

            // Discard other tickets
            foreach (var ticket in otherTickets)
            {
                var validTicket = true;
                foreach (var pos in ticket)
                {
                    var validPos = false;
                    foreach (var validation in validations)
                    {
                        if (validation.Value(pos))
                        {
                            validPos = true;
                            break;
                        }
                    }
                    if (!validPos)
                    {
                        validTicket = false;
                        break;
                    }
                }
                if (validTicket)
                {
                    otherTicketsCleaned.Add(ticket);
                }
            }

            // Check validations matched
            foreach (var validation in validations)
            {
                validColumns.Add(validation.Key, new List<int>());
                for (var column = 0; column < validations.Count; column++)
                {
                    var validPos = true;
                    for (int j = 0; j < otherTicketsCleaned.Count; j++)
                    {
                        var ticketColumn = otherTicketsCleaned[j][column];
                        if (!validation.Value(ticketColumn))
                        {
                            validPos = false;
                            break;
                        }
                    }
                    if (validPos)
                    {
                        validColumns[validation.Key].Add(column);
                    }
                }
            }

            // Distribute solutions
            while (validColumns.Count > 0)
            {
                var singleSolutions = validColumns.Where(x => x.Value.Count == 1);
                foreach (var sol in singleSolutions)
                {
                    string name = sol.Key;
                    int column = sol.Value.First();
                    validColumns.Remove(name);
                    foreach (var validColumn in validColumns)
                    {
                        validColumns[validColumn.Key].Remove(column);
                    }
                    definitiveColumns.Add(name, column);
                }
            }

            // Get answer
            foreach (var definitive in definitiveColumns)
            {
                if (definitive.Key.StartsWith("departure"))
                {
                    toReturn *= myTicket[definitive.Value];
                }
            }

            return toReturn;
        }

        private static (Dictionary<string, Func<int, bool>>, List<int>, List<List<int>>) ParseInput(string[] lines)
        {
            Dictionary<string, Func<int, bool>> validations = new Dictionary<string, Func<int, bool>>();
            List<int> myTicket = new List<int>();
            List<List<int>> otherTickets = new List<List<int>>();

            var parseAction = ParseActions.Validations;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (parseAction == ParseActions.Validations)
                    {
                        parseAction = ParseActions.MyTicket;
                        continue;
                    }
                    if (parseAction == ParseActions.MyTicket)
                    {
                        parseAction = ParseActions.OtherTickets;
                        continue;
                    }
                }

                if (line.Equals("your ticket:") || line.Equals("nearby tickets:"))
                {
                    continue;
                }

                switch (parseAction)
                {
                    case ParseActions.Validations:
                        (var name, var validation) = ParseValidation(line);
                        validations.Add(name, validation);
                        break;
                    case ParseActions.MyTicket:
                        myTicket = ParseMyTicket(line);
                        break;
                    case ParseActions.OtherTickets:
                        otherTickets.Add(ParseOtherTicket(line));
                        break;
                }
            }

            return (validations, myTicket, otherTickets);
        }

        private static (string, Func<int, bool>) ParseValidation(string line)
        {
            var validationName = line.Split(":")[0];

            var validationsToParse = line.Split(":")[1];
            var splittedValidations = validationsToParse.Split("or");

            var firstMinValue = int.Parse(splittedValidations[0].Split("-")[0]);
            var firstMaxValue = int.Parse(splittedValidations[0].Split("-")[1]);

            var secondMinValue = int.Parse(splittedValidations[1].Split("-")[0]);
            var secondMaxValue = int.Parse(splittedValidations[1].Split("-")[1]);

            Func<int, bool> toReturn = x => (x >= firstMinValue && x <= firstMaxValue) || (x >= secondMinValue && x <= secondMaxValue);

            return (validationName, toReturn);
        }

        private static List<int> ParseMyTicket(string line)
        {
            return line.Split(",").ToList().ConvertAll(x => int.Parse(x));
        }

        private static List<int> ParseOtherTicket(string line)
        {
            return line.Split(",").ToList().ConvertAll(x => int.Parse(x));
        }

    }

    public enum ParseActions
    {
        Validations,
        MyTicket,
        OtherTickets
    }
}
