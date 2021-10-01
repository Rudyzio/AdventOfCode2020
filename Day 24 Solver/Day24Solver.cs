using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_24_Solver
{
    public static class Day24Solver
    {
        public static int Part1Solution(string[] lines)
        {
            return ParseTiles(lines).Values.Count(x => x == Color.Black);
        }

        public static int Part2Solution(string[] lines)
        {
            var tiles = ParseTiles(lines);

            int current = 1;
            while (current <= 100)
            {
                foreach (var k in tiles.Keys.Select(k => k).ToArray())
                    tiles.FillAdjacent(k);
                tiles.ApplyRules();
                current++;
            }
            return tiles.Values.Count(x => x == Color.Black);
        }

        private static string[] _dirs = { "e", "se", "sw", "w", "nw", "ne" };

        private static (int x, int y) DirToCoords(string dir)
        {
            return dir switch
            {
                "ne" => (1, 1),
                "e" => (2, 0),
                "se" => (1, -1),
                "sw" => (-1, -1),
                "w" => (-2, 0),
                "nw" => (-1, 1),
                _ => throw new Exception("Oh oh...")
            };
        }

        private static Dictionary<(int x, int y), Color> ParseTiles(string[] lines)
        {
            Dictionary<(int x, int y), Color> tiles = new Dictionary<(int x, int y), Color>();
            const char emptyChar = '\0';

            foreach (var line in lines)
            {
                (int x, int y) position = (0, 0);
                for (var i = 0; i < line.Length; i++)
                {
                    var character = line[i];
                    char nextCharacter = i + 1 < line.Length ? line[i + 1] : emptyChar;
                    var (x, y) = (0, 0);
                    switch (character)
                    {
                        case 's':
                        case 'n':
                            if (nextCharacter.Equals('w') || nextCharacter.Equals('e'))
                            {
                                (x, y) = DirToCoords(character.ToString() + nextCharacter.ToString());
                                i++;
                            }
                            else
                            {
                                (x, y) = DirToCoords(character.ToString());
                            }
                            position.y += y;
                            position.x += x;
                            break;
                        case 'e':
                        case 'w':
                            (x, y) = DirToCoords(character.ToString());
                            position.y += y;
                            position.x += x;
                            break;
                    }
                }
                if (tiles.ContainsKey(position))
                {
                    tiles[position] = tiles[position] == Color.Black ? Color.White : Color.Black;
                }
                else
                {
                    tiles.Add(position, Color.Black);
                }
                tiles.FillAdjacent(position);
            }

            return tiles;
        }

        private static void FillAdjacent(this Dictionary<(int x, int y), Color> tiles, (int x, int y) position)
        {
            foreach (var dir in _dirs)
            {
                var direction = DirToCoords(dir);
                var adjacent = (position.y + direction.y, position.x + direction.x);
                if (!tiles.ContainsKey(adjacent))
                {
                    tiles.Add(adjacent, Color.White);
                }
            }
        }

        private static void ApplyRules(this Dictionary<(int x, int y), Color> tiles)
        {
            var toChange = new List<(int x, int y)>();

            foreach (var pos in tiles.Keys.ToList())
            {
                var adjacents = tiles.GetAdjacents(pos);

                if (
                    (tiles[pos] == Color.Black && (adjacents.Count(x => x.Value == Color.Black) == 0 || adjacents.Count(x => x.Value == Color.Black) > 2))
                    || 
                    (tiles[pos] == Color.White && adjacents.Count(x => x.Value == Color.Black) == 2)
                   )
                {
                    toChange.Add(pos);
                }
            }

            foreach (var toFlip in toChange)
            {
                tiles[toFlip] = tiles[toFlip] == Color.Black ? Color.White : Color.Black;
            }

        }

        private static Dictionary<(int x, int y), Color> GetAdjacents(this Dictionary<(int x, int y), Color> tiles, (int x, int y) position)
        {
            var toReturn = new Dictionary<(int x, int y), Color>();

            foreach (var dir in _dirs)
            {
                var direction = DirToCoords(dir);
                var adjacent = (position.x + direction.x, position.y + direction.y);
                if (tiles.ContainsKey(adjacent))
                {
                    toReturn.Add(adjacent, tiles[adjacent]);
                }
                else
                {
                    toReturn.Add(adjacent, Color.White);
                }
            }

            return toReturn;
        }
    }

    public enum Color
    {
        Black,
        White
    }
}
