using System.Collections.Generic;
using System.Linq;

namespace Day_11_Solver
{
    public static class Day11Solver
    {
        public static int Part1Solution(string[] lines)
        {
            Position[,] positions = new Position[lines.Length, lines[0].Length];
            positions.ReadInput(lines);
            // positions.PrintPositions();

            var peopleMoved = true;
            do
            {
                peopleMoved = ApplyRulesPart1(positions);
                // positions.PrintPositions();
            } while (peopleMoved);

            return positions.CountOccupied();

        }

        public static int Part2Solution(string[] lines)
        {
            Position[,] positions = new Position[lines.Length, lines[0].Length];
            positions.ReadInput(lines);
            // positions.PrintPositions();

            var peopleMoved = true;
            do
            {
                peopleMoved = ApplyRulesPart2(positions);
                // positions.PrintPositions();
            } while (peopleMoved);

            return positions.CountOccupied();
        }

        private static int CountOccupied(this Position[,] positions)
        {
            var toReturn = 0;
            foreach (var pos in positions)
            {
                if (pos.State == PositionState.Occupied)
                {
                    toReturn++;
                }
            }

            return toReturn;
        }

        private static bool ApplyRulesPart1(Position[,] positions)
        {
            bool peopleMoved = false;
            for (var i = 0; i < positions.GetLength(0); i++)
            {
                for (var j = 0; j < positions.GetLength(1); j++)
                {
                    var position = positions[i, j];
                    if (position.State == PositionState.Floor)
                    {
                        continue;
                    }
                    var adjacents = GetAdjacents(positions, i, j);
                    if (position.State == PositionState.Empty && adjacents.Count(x => x.State == PositionState.Occupied) == 0)
                    {
                        peopleMoved = true;
                        position.ChangeState = true;
                        continue;
                    }

                    if (position.State == PositionState.Occupied && adjacents.Count(x => x.State == PositionState.Occupied) >= 4)
                    {
                        peopleMoved = true;
                        position.ChangeState = true;
                        continue;
                    }
                }
            }

            positions.ApplyChanges();

            return peopleMoved;
        }

        private static bool ApplyRulesPart2(Position[,] positions)
        {
            bool peopleMoved = false;
            for (var i = 0; i < positions.GetLength(0); i++)
            {
                for (var j = 0; j < positions.GetLength(1); j++)
                {
                    var position = positions[i, j];
                    if (position.State == PositionState.Floor)
                    {
                        continue;
                    }
                    var adjacents = GetFirstNotFloorAdjacents(positions, i, j);
                    if (position.State == PositionState.Empty && adjacents.Count(x => x.State == PositionState.Occupied) == 0)
                    {
                        peopleMoved = true;
                        position.ChangeState = true;
                        continue;
                    }

                    if (position.State == PositionState.Occupied && adjacents.Count(x => x.State == PositionState.Occupied) >= 5)
                    {
                        peopleMoved = true;
                        position.ChangeState = true;
                        continue;
                    }
                }
            }

            positions.ApplyChanges();

            return peopleMoved;
        }

        private static void ApplyChanges(this Position[,] positions)
        {
            foreach (var pos in positions)
            {
                if (pos.ChangeState)
                {
                    pos.ChangeState = false;
                    if (pos.State == PositionState.Empty)
                    {
                        pos.State = PositionState.Occupied;
                        continue;
                    }
                    if (pos.State == PositionState.Occupied)
                    {
                        pos.State = PositionState.Empty;
                        continue;
                    }
                }
            }
        }

        private static List<Position> GetFirstNotFloorAdjacents(Position[,] positions, int i, int j)
        {
            var toReturn = new List<Position>();
            var iMaxValue = positions.GetLength(0);
            var jMaxValue = positions.GetLength(1);

            // Up
            for (var row = j - 1; row > -1; row--)
            {
                if (positions[i, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added up: {i}:{row}");
                    toReturn.Add(positions[i, row]);
                    break;
                }
            }

            // Right
            for (var column = i + 1; column < iMaxValue; column++)
            {
                if (positions[column, j].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added right: {column}:{j}");
                    toReturn.Add(positions[column, j]);
                    break;
                }
            }

            // Down
            for (var row = j + 1; row < jMaxValue; row++)
            {
                if (positions[i, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added down: {i}:{row}");
                    toReturn.Add(positions[i, row]);
                    break;
                }
            }

            // Left
            for (var column = i - 1; column > -1; column--)
            {
                if (positions[column, j].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added left: {column}:{j}");
                    toReturn.Add(positions[column, j]);
                    break;
                }
            }

            // Left up
            for (int column = i - 1, row = j - 1; column > -1 && row > -1; column--, row--)
            {
                if (positions[column, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added left up: {column}:{row}");
                    toReturn.Add(positions[column, row]);
                    break;
                }
            }

            // Right up
            for (int column = i + 1, row = j - 1; column < iMaxValue && row > -1; column++, row--)
            {
                if (positions[column, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added right up: {column}:{row}");
                    toReturn.Add(positions[column, row]);
                    break;
                }
            }

            // Right down
            for (int column = i + 1, row = j + 1; column < iMaxValue && row < jMaxValue; column++, row++)
            {
                if (positions[column, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added right down: {column}:{row}");
                    toReturn.Add(positions[column, row]);
                    break;
                }
            }

            // Left down
            for (int column = i - 1, row = j + 1; column > -1 && row < jMaxValue; column--, row++)
            {
                if (positions[column, row].State != PositionState.Floor)
                {
                    // System.Console.WriteLine($"Added left down: {column}:{row}");
                    toReturn.Add(positions[column, row]);
                    break;
                }
            }

            return toReturn;
        }

        private static List<Position> GetAdjacents(Position[,] positions, int i, int j)
        {
            var toReturn = new List<Position>();
            var iMaxValue = positions.GetLength(0);
            var jMaxValue = positions.GetLength(1);

            // Up
            if (j - 1 > -1)
            {
                toReturn.Add(positions[i, j - 1]);
            }
            // Right
            if (i + 1 < iMaxValue)
            {
                toReturn.Add(positions[i + 1, j]);
            }
            // Down
            if (j + 1 < jMaxValue)
            {
                toReturn.Add(positions[i, j + 1]);
            }
            // Left
            if (i - 1 > -1)
            {
                toReturn.Add(positions[i - 1, j]);
            }
            // Left Up
            if (i - 1 > -1 && j - 1 > -1)
            {
                toReturn.Add(positions[i - 1, j - 1]);
            }
            // Right Up
            if (i + 1 < iMaxValue && j - 1 > -1)
            {
                toReturn.Add(positions[i + 1, j - 1]);
            }
            // Right Down
            if (i + 1 < iMaxValue && j + 1 < jMaxValue)
            {
                toReturn.Add(positions[i + 1, j + 1]);

            }
            // Left Down
            if (i - 1 > -1 && j + 1 < jMaxValue)
            {
                toReturn.Add(positions[i - 1, j + 1]);

            }
            return toReturn;
        }

        private static void ReadInput(this Position[,] positions, string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    positions[i, j] = new Position(line[j]);
                }
            }
        }

        private static void PrintPositions(this Position[,] positions)
        {
            System.Console.WriteLine();
            for (var i = 0; i < positions.GetLength(0); i++)
            {
                var line = string.Empty;
                for (var j = 0; j < positions.GetLength(1); j++)
                {
                    switch (positions[i, j].State)
                    {
                        case PositionState.Floor:
                            line += '.';
                            break;
                        case PositionState.Empty:
                            line += 'L';
                            break;
                        case PositionState.Occupied:
                            line += '#';
                            break;
                    }
                }
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine();
        }
    }

    public class Position
    {
        public Position(char state)
        {
            ChangeState = false;
            switch (state)
            {
                case '.':
                    State = PositionState.Floor;
                    break;
                case 'L':
                    State = PositionState.Empty;
                    break;
                case '#':
                    State = PositionState.Occupied;
                    break;
            }
        }
        public PositionState State { get; set; }
        public bool ChangeState { get; set; }
    }

    public enum PositionState
    {
        Floor,
        Empty,
        Occupied
    }
}
