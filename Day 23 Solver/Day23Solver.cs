using System.Collections.Generic;
using System.Linq;

namespace Day_23_Solver
{
    public static class Day23Solver
    {
        public static long Part1Solution(string[] lines)
        {
            (var currentCup, var oneCup, var dictMap) = ParseInput(lines);
            Move(currentCup, dictMap, 9, 100);
            return GetAnswer(oneCup);
        }

        public static long Part2Solution(string[] lines)
        {
            (var currentCup, var oneCup, var dictMap) = ParseInput(lines, 1000000 - lines[0].Length);
            Move(currentCup, dictMap, 1000000, 10000000);
            return (long)oneCup.Next.Value * (long)oneCup.Next.Next.Value;
        }

        private static void Move(Cup currentCup, Dictionary<int, Cup> dictMap, int max, int moves)
        {
            int currentMove = 1;
            while (currentMove <= moves)
            {
                // System.Console.WriteLine($"-- move {currentMove} --");
                // System.Console.WriteLine($"Cups:");
                // dictMap.Print(currentCup);

                // Pickups
                var pickupStart = currentCup.Next;
                var pickupEnd = pickupStart.Next.Next;
                // System.Console.WriteLine($"Pick up:");
                var pickups = new List<int>()
                {
                    pickupStart.Value,
                    pickupStart.Next.Value,
                    pickupStart.Next.Next.Value
                };
                // pickups.Print();

                currentCup.Next = pickupEnd.Next;

                // Destination cup
                var cupNextValue = currentCup.Value;
                do
                {
                    cupNextValue--;
                    cupNextValue = cupNextValue == 0 ? max : cupNextValue;
                }
                while (pickups.Contains(cupNextValue));
                var destinationCup = dictMap[cupNextValue];
                // System.Console.WriteLine($"destination: {destinationCup.Value}");

                // Place cups
                var tempNext = destinationCup.Next;
                destinationCup.Next = pickupStart;
                pickupEnd.Next = tempNext;

                currentCup = currentCup.Next;

                // System.Console.WriteLine();
                currentMove++;
            }
            // System.Console.WriteLine($"-- final --");
            // dictMap.Print(currentCup);
        }

        private static long GetAnswer(Cup start)
        {
            var toReturn = string.Empty;
            var current = start.Next;

            while (current != start)
            {
                toReturn += current.Value.ToString();
                current = current.Next;
            }

            return long.Parse(toReturn);
        }

        private static (Cup, Cup, Dictionary<int, Cup>) ParseInput(string[] lines, int extraNumbers = 0)
        {
            var dictMap = new Dictionary<int, Cup>();
            var input = lines[0];

            Cup firstCup = new Cup { Value = int.Parse(input[0].ToString()) };
            dictMap.Add(firstCup.Value, firstCup);
            Cup currentCup = firstCup;
            Cup oneCup = null;

            if (firstCup.Value == 1)
            {
                oneCup = firstCup;
            }

            for (var i = 1; i < input.Length; i++)
            {
                var cup = new Cup { Value = int.Parse(input[i].ToString()) };
                if (cup.Value == 1)
                {
                    oneCup = cup;
                }
                dictMap.Add(cup.Value, cup);
                currentCup.Next = cup;
                currentCup = cup;
            }

            var nextValue = 10;

            for (var i = 0; i < extraNumbers; i++)
            {
                var cup = new Cup { Value = nextValue };
                dictMap.Add(cup.Value, cup);
                currentCup.Next = cup;
                currentCup = cup;
                nextValue++;
            }

            // close circle
            currentCup.Next = firstCup;

            currentCup = firstCup;
            return (currentCup, oneCup, dictMap);
        }

        private static void Print(this List<int> obj, int currentCup = -1)
        {
            var toPrint = string.Empty;
            foreach (var entry in obj)
            {
                if (currentCup == entry)
                {
                    toPrint += $"({entry}) ";
                }
                else
                {
                    toPrint += $"{entry} ";
                }
            }
            System.Console.WriteLine(toPrint);
        }

        private static void Print(this Dictionary<int, Cup> obj, Cup start)
        {
            var toPrint = string.Empty;
            var current = start.Next;

            do
            {
                toPrint += $"{current.Value} ";
                current = current.Next;
            } while (current != start);

            System.Console.WriteLine(toPrint);
        }
    }

    public class Cup
    {
        public int Value { get; set; }
        public Cup Next { get; set; }
    }
}
