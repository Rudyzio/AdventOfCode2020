using System;

namespace Day_05_Solver
{
    public static class Day05Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int placeId = 0;
            foreach (var line in lines)
            {
                (var row, var column) = CalculatePosition(line);
                var currentSeatID = row * 8 + column;
                if (currentSeatID > placeId)
                {
                    placeId = (int)currentSeatID;
                }
            }
            return placeId;
        }

        public static int Part2Solution(string[] lines)
        {

            var rows = 128;
            var columns = 8;
            bool[,] seats = new bool[rows, columns];

            foreach (var line in lines)
            {
                (var row, var column) = CalculatePosition(line);
                seats[(int)row, (int)column] = true;
            }

            for (var i = 1; i < rows - 1; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (!seats[i, j])
                    {
                        return i * 8 + j;
                    }
                }
            }

            return 0;
        }

        private static (double, double) CalculatePosition(string line)
        {
            double upperLimitRow = 127;
            double lowerLimitRow = 0;
            double upperLimitColumn = 7;
            double lowerLimitColumn = 0;

            foreach (var position in line)
            {
                switch (position)
                {
                    case 'F':
                        upperLimitRow -= Math.Ceiling((upperLimitRow - lowerLimitRow) / 2);
                        break;
                    case 'B':
                        lowerLimitRow += Math.Ceiling((upperLimitRow - lowerLimitRow) / 2);
                        break;
                    case 'R':
                        lowerLimitColumn += Math.Ceiling((upperLimitColumn - lowerLimitColumn) / 2);
                        break;
                    case 'L':
                        upperLimitColumn -= Math.Ceiling((upperLimitColumn - lowerLimitColumn) / 2);
                        break;
                }
                // System.Console.WriteLine($"{position}-{lowerLimitRow}:{upperLimitRow}");
            }

            return (upperLimitRow, upperLimitColumn);
        }
    }
}
