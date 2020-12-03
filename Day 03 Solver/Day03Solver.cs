using System;

namespace Day_03_Solver
{
    public static class Day03Solver
    {
        public static int Part1Solution(string[] lines)
        {
            return TraverseMap(lines, 3, 1);
        }

        public static double Part2Solution(string[] lines)
        {
            // Total result is too big for int or double
            UInt64 result = Convert.ToUInt64(TraverseMap(lines, 1, 1));
            result *= Convert.ToUInt64(TraverseMap(lines, 3, 1));
            result *= Convert.ToUInt64(TraverseMap(lines, 5, 1));
            result *= Convert.ToUInt64(TraverseMap(lines, 7, 1));
            result *= Convert.ToUInt64(TraverseMap(lines, 1, 2));
            return result;
        }

        private static int TraverseMap(string[] lines, int stepsRight, int stepsDown)
        {
            int trees = 0;

            int rowIndex = 0;
            int rowLength = lines[0].Length;
            int currentLocation = 0;
            while (rowIndex < lines.Length)
            {
                if (currentLocation >= rowLength)
                {
                    currentLocation -= rowLength;
                }

                var currentRow = lines[rowIndex];

                if (currentRow[currentLocation] == '#')
                {
                    trees++;
                }

                currentLocation += stepsRight;
                rowIndex += stepsDown;
            }
            return trees;
        }
    }
}
