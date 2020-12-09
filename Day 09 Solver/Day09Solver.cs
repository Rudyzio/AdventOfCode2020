using System.Collections.Generic;
using System.Linq;

namespace Day_09_Solver
{
    public static class Day09Solver
    {
        public static long Part1Solution(string[] lines, int preamble)
        {
            long[] numbers = new long[lines.Length];

            // Read input
            for (var i = 0; i < lines.Length; i++)
            {
                numbers[i] = long.Parse(lines[i]);
            }

            // Pointer in right place
            int pointer = preamble;

            while (pointer < numbers.Length)
            {
                if (!IsSumOfPreviousPreamble(numbers, pointer, preamble))
                {
                    return numbers[pointer];
                }
                pointer++;
            }

            return 0;
        }

        public static long Part2Solution(string[] lines, int preamble)
        {
            long[] numbers = new long[lines.Length];

            // Read input
            for (var i = 0; i < lines.Length; i++)
            {
                numbers[i] = long.Parse(lines[i]);
            }

            var step1Solution = Part1Solution(lines, preamble);

            // Get rid of bigger ones and order by biggest first
            numbers = numbers.Where(x => x < step1Solution && x != step1Solution).ToArray();

            var solutionValues = new List<long>();

            for (var i = 0; i < numbers.Length; i++)
            {
                long intermediateValue = numbers[i];
                solutionValues = new List<long>() { numbers[i] };
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (intermediateValue > intermediateValue + numbers[j])
                    {
                        break;
                    }

                    if (intermediateValue == step1Solution)
                    {
                        return solutionValues.Min() + solutionValues.Max();
                    }

                    intermediateValue += numbers[j];
                    solutionValues.Add(numbers[j]);
                }
            }

            return 0;
        }

        private static bool IsSumOfPreviousPreamble(long[] numbers, int pointer, int preamble)
        {
            int lowerSection = pointer - preamble;
            int higherSection = pointer;
            // System.Console.WriteLine($"LowerSection {lowerSection}; Higher section {higherSection}; Target number {numbers[pointer]}");

            for (var i = lowerSection; i < higherSection; i++)
            {
                if (numbers[i] > numbers[pointer])
                {
                    continue;
                }
                for (var j = i + 1; j < higherSection; j++)
                {
                    if (numbers[j] > numbers[pointer])
                    {
                        continue;
                    }
                    // System.Console.WriteLine($"{i};{j}");
                    // System.Console.WriteLine($"{numbers[i]} + {numbers[j]} = {numbers[i] + numbers[j]}");
                    if (numbers[i] + numbers[j] == numbers[pointer])
                    {
                        // System.Console.WriteLine();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
