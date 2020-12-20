using System.Collections.Generic;
using System.Linq;

namespace Day_17_Solver
{
    public static class Day17Solver
    {
        public static int Part1Solution(string[] lines)
        {
            var cubes = ParseInput(lines);
            var neighboursOffsets = GenerateNeighboursOffsets();

            int cycle = 1;

            while (cycle <= 6)
            {
                cubes.GenerateOuterLayer(neighboursOffsets, false);

                cubes = RunCycle(cubes, neighboursOffsets, false);

                cycle++;
            }

            return cubes.Count(x => x.Value == '#');
        }

        public static int Part2Solution(string[] lines)
        {
            var cubes = ParseInput(lines);
            var neighboursOffsets = GenerateNeighboursOffsets();

            int cycle = 1;

            while (cycle <= 6)
            {
                cubes.GenerateOuterLayer(neighboursOffsets, true);

                cubes = RunCycle(cubes, neighboursOffsets, true);

                cycle++;
            }

            return cubes.Count(x => x.Value == '#');
        }

        private static Dictionary<(int x, int y, int z, int w), char> ParseInput(string[] lines)
        {
            var toReturn = new Dictionary<(int x, int y, int z, int w), char>();
            for (var x = 0; x < lines.Length; x++)
            {
                for (var y = 0; y < lines[x].Length; y++)
                {
                    toReturn.Add((x, y, 0, 0), lines[x][y]);
                }
            }
            return toReturn;
        }

        private static void PrintPositions(this Dictionary<(int x, int y, int z, int w), char> cubes)
        {
            var minW = cubes.Min(x => x.Key.w);
            var maxW = cubes.Max(x => x.Key.w);

            var minZ = cubes.Min(x => x.Key.z);
            var maxZ = cubes.Max(x => x.Key.z);

            var minY = cubes.Min(x => x.Key.y);
            var maxY = cubes.Max(x => x.Key.y);

            var minX = cubes.Min(x => x.Key.x);
            var maxX = cubes.Max(x => x.Key.x);

            System.Console.WriteLine();
            for (var w = minW; w <= maxW; w++)
            {
                for (var z = minZ; z <= maxZ; z++)
                {
                    System.Console.WriteLine($"z={z} w={w}");
                    for (var y = minY; y <= maxY; y++)
                    {
                        var row = string.Empty;
                        for (var x = minX; x <= maxX; x++)
                        {
                            row += cubes.Single(pos => pos.Key.x == y && pos.Key.y == x && pos.Key.z == z && pos.Key.w == w).Value;
                        }
                        System.Console.WriteLine(row);
                    }
                    System.Console.WriteLine();
                }
            }
        }

        private static Dictionary<(int x, int y, int z, int w), char> RunCycle(Dictionary<(int x, int y, int z, int w), char> cubes, List<(int x, int y, int z, int w)> neighboursOffsets, bool partTwo)
        {
            var nextIteration = new Dictionary<(int x, int y, int z, int w), char>();

            foreach (var entry in cubes)
            {
                var neighbours = partTwo ?
                                    neighboursOffsets
                                        .Select(pos => (entry.Key.x + pos.x, entry.Key.y + pos.y, entry.Key.z + pos.z, entry.Key.w + pos.w))
                                        .Count(x => cubes.ContainsKey(x) && cubes[x] == '#')
                                        :
                                    neighboursOffsets
                                        .Select(pos => (entry.Key.x + pos.x, entry.Key.y + pos.y, entry.Key.z + pos.z, entry.Key.w + pos.w))
                                        .Count(x => cubes.ContainsKey(x) && cubes[x] == '#');


                if (entry.Value == '#')
                {
                    if (neighbours == 2 || neighbours == 3)
                    {
                        nextIteration.Add(entry.Key, '#');
                    }
                    else
                    {
                        nextIteration.Add(entry.Key, '.');
                    }
                }
                else
                {
                    if (neighbours == 3)
                    {
                        nextIteration.Add(entry.Key, '#');
                    }
                    else
                    {
                        nextIteration.Add(entry.Key, '.');
                    }
                }
            }

            return nextIteration;
        }

        private static void GenerateOuterLayer(this Dictionary<(int x, int y, int z, int w), char> cubes, List<(int x, int y, int z, int w)> neighboursOffsets, bool partTwo)
        {
            foreach (var entry in cubes.Keys.ToList())
            {
                var neighbours = partTwo
                    ? neighboursOffsets.Select(pos => (entry.x + pos.x, entry.y + pos.y, entry.z + pos.z, entry.w + pos.w))
                    : neighboursOffsets.Select(pos => (entry.x + pos.x, entry.y + pos.y, entry.z + pos.z, 0));

                foreach (var neighbour in neighbours)
                {
                    if (!cubes.TryGetValue(neighbour, out var value))
                    {
                        cubes[neighbour] = '.';
                    }
                }
            }
        }

        private static List<(int x, int y, int z, int w)> GenerateNeighboursOffsets()
        {
            var toReturn = new List<(int x, int y, int z, int w)>();
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    for (int z = -1; z < 2; z++)
                    {
                        for (int w = -1; w < 2; w++)
                        {
                            if (x != 0 || y != 0 || z != 0 || w != 0)
                            {
                                toReturn.Add((x, y, z, w));
                            }
                        }
                    }
                }

            }
            return toReturn;
        }
    }
}
