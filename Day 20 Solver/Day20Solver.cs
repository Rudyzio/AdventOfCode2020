using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_20_Solver
{
    public static class Day20Solver
    {
        public static long Part1Solution(string[] lines)
        {
            List<Tile> tiles = ParseInput(lines);
            List<Tile> allTileCombinations = GenerateAllCombinations(tiles);

            List<Tile> puzzle = MakePuzzle(tiles, allTileCombinations);

            var corners = puzzle.Where(p => p.ConnectedTiles.Keys.Count == 2).Select(p => p.Number).ToList();

            return corners.Aggregate((long)1, (acc, n) => acc * n);
        }

        public static int Part2Solution(string[] lines)
        {
            List<Tile> tiles = ParseInput(lines);
            List<Tile> allTileCombinations = GenerateAllCombinations(tiles);

            List<Tile> puzzle = MakePuzzle(tiles, allTileCombinations);

            var pictureContent = MakePicture(puzzle);
            var picture = new Tile(0, pictureContent);
            var monsters = GetMonsters(picture);

            var totalHashes = CountHashes(pictureContent, (int)Math.Sqrt(puzzle.Count));

            return totalHashes - monsters;
        }

        private static List<Tile> ParseInput(string[] lines)
        {
            var toReturn = new List<Tile>();

            for (var i = 0; i <= lines.Length; i += 12)
            {
                var tileContent = lines.Skip(i).Take(11).ToList();
                var tile = new Tile(tileContent);
                toReturn.Add(tile);
            }

            return toReturn;
        }

        private static List<Tile> GenerateAllCombinations(List<Tile> tiles)
        {
            var toReturn = new List<Tile>();
            foreach (var tile in tiles)
            {
                toReturn.Add(tile);

                for (var angle = 90; angle < 360; angle += 90)
                {
                    toReturn.Add(tile.Rotate(angle));
                }

                var flipX = tile.FlipX();
                for (var angle = 90; angle < 360; angle += 90)
                {
                    toReturn.Add(flipX.Rotate(angle));
                }

                var flipY = tile.FlipY();
                for (var angle = 90; angle < 360; angle += 90)
                {
                    toReturn.Add(flipY.Rotate(angle));
                }
            }
            return toReturn;
        }

        private static List<Tile> MakePuzzle(List<Tile> tiles, List<Tile> allTileCombinations)
        {
            var possibleEdges = new Position[] { Position.Top, Position.Right, Position.Bottom, Position.Left };
            Dictionary<Position, Position> OppositeEdges = new()
            {
                { Position.Top, Position.Bottom },
                { Position.Bottom, Position.Top },
                { Position.Left, Position.Right },
                { Position.Right, Position.Left }
            };

            var tilesToFit = new Queue<Tile>();
            tilesToFit.Enqueue(tiles.First());

            while (tilesToFit.Count > 0)
            {
                var currentTile = tilesToFit.Dequeue();

                foreach (var piece in allTileCombinations)
                {
                    if (currentTile.Number == piece.Number)
                    {
                        continue;
                    }

                    foreach (var edge in possibleEdges)
                    {
                        if (currentTile.ConnectedTiles.ContainsKey(edge))
                        {
                            continue;
                        }

                        if (piece.ConnectedTiles.ContainsKey(OppositeEdges[edge]))
                        {
                            continue;
                        }

                        if (currentTile.ConnectsOnEdge(edge, piece))
                        {
                            currentTile.ConnectedTiles.Add(edge, piece);
                            piece.ConnectedTiles.Add(OppositeEdges[edge], currentTile);
                            tilesToFit.Enqueue(piece);
                            break;
                        }
                    }
                }
            }

            return allTileCombinations.Where(x => x.ConnectedTiles.Count > 0).ToList();
        }

        private static char[,] MakePicture(List<Tile> puzzle)
        {
            // Since it is a square
            int nRows = (int)Math.Sqrt(puzzle.Count);

            char[,] pictureContent = new char[nRows * 8, nRows * 8];

            // Get top left row
            var currentRow = puzzle.SingleOrDefault(x =>
                                            x.ConnectedTiles.Keys.Count == 2 &&
                                            x.ConnectedTiles.ContainsKey(Position.Right) &&
                                            x.ConnectedTiles.ContainsKey(Position.Bottom)
                                          );

            Tile currentColumn;
            int row = 0;
            int column = 0;
            int currentRowPointer = 0;
            int currentColumnPointer = 0;

            while (currentRow != null)
            {
                row = currentRowPointer;
                column = currentColumnPointer;
                for (var i = 1; i < 9; i++, row++)
                {
                    for (var j = 1; j < 9; j++, column++)
                    {
                        pictureContent[row, column] = currentRow.Content[i, j];
                    }
                    column = currentColumnPointer;
                }

                currentRow.ConnectedTiles.TryGetValue(Position.Right, out currentColumn);
                while (currentColumn != null)
                {
                    currentColumnPointer += 8;
                    column = currentColumnPointer;
                    row = currentRowPointer;
                    for (var i = 1; i < 9; i++, row++)
                    {
                        for (var j = 1; j < 9; j++, column++)
                        {
                            pictureContent[row, column] = currentColumn.Content[i, j];
                        }
                        column = currentColumnPointer;
                    }
                    currentColumn.ConnectedTiles.TryGetValue(Position.Right, out currentColumn);
                }

                currentRowPointer += 8;
                currentColumnPointer = 0;
                currentRow.ConnectedTiles.TryGetValue(Position.Bottom, out currentRow);
            }

            return pictureContent;
        }

        private static int GetMonsters(Tile picture)
        {
            var monsters = CountMonsters(picture.Content);
            if (monsters == 0)
            {
                for (var angle = 90; angle < 360; angle += 90)
                {
                    var tile = picture.Rotate(angle);
                    monsters = CountMonsters(tile.Content);
                    if (monsters > 0)
                    {
                        break;
                    }
                }
            }

            if (monsters == 0)
            {
                var flipX = picture.FlipX();
                monsters = CountMonsters(flipX.Content);

                if (monsters == 0)
                {
                    for (var angle = 90; angle < 360; angle += 90)
                    {
                        var tile = flipX.Rotate(angle);
                        monsters = CountMonsters(tile.Content);
                        if (monsters > 0)
                        {
                            break;
                        }
                    }
                }
            }

            if (monsters == 0)
            {
                var flipY = picture.FlipY();
                monsters = CountMonsters(flipY.Content);

                if (monsters == 0)
                {
                    for (var angle = 90; angle < 360; angle += 90)
                    {
                        var tile = flipY.Rotate(angle);
                        monsters = CountMonsters(tile.Content);
                        if (monsters > 0)
                        {
                            break;
                        }
                    }
                }
            }

            return monsters;
        }

        private static int CountMonsters(char[,] picture)
        {
            (int Y, int X)[] monsterMask = new (int Y, int X)[]
            {
                (0,18),
                (1,0),
                (1,5),
                (1,6),
                (1,11),
                (1,12),
                (1,17),
                (1,18),
                (1,19),
                (2,1),
                (2,4),
                (2,7),
                (2,10),
                (2,13),
                (2,16)
            };

            var monsterWidth = 20;
            var monsterHeight = 3;

            var height = picture.GetLength(0);
            var width = picture.GetLength(1);
            var monsterCount = 0;

            for (var i = 0; i < height - monsterHeight; i++)
            {
                for (var j = 0; j < width - monsterWidth; j++)
                {
                    if (monsterMask.All(p => picture[i + p.Y, j + p.X] == '#'))
                    {
                        monsterCount++;
                    }
                }
            }

            return monsterCount * monsterMask.Count();
        }

        private static int CountHashes(char[,] picture, int nRows)
        {
            var totalHashes = 0;
            for (var i = 0; i < nRows * 8; i++)
            {
                for (var j = 0; j < nRows * 8; j++)
                {
                    if (picture[i, j] == '#')
                    {
                        totalHashes++;
                    }
                }
            }
            return totalHashes;
        }
    }

    public class Tile
    {
        public Tile(List<string> tileContent)
        {
            Content = new char[10, 10];
            ConnectedTiles = new Dictionary<Position, Tile>();

            var tileWithDots = tileContent[0].Split(" ")[1];
            Number = long.Parse(tileWithDots.Remove(tileWithDots.Length - 1));

            for (var i = 1; i < tileContent.Count; i++)
            {
                for (var j = 0; j < tileContent[i].Length; j++)
                {
                    Content[i - 1, j] = tileContent[i][j];
                }
            }

            AddEdges();
        }

        public Tile(long tileNumber, char[,] content)
        {
            Number = tileNumber;
            Content = content;
            ConnectedTiles = new Dictionary<Position, Tile>();
            if (Content.GetLength(0) <= 10)
                AddEdges();
        }

        private void AddEdges()
        {
            Edges = new Dictionary<Position, Edge>();

            Edges.Add(Position.Top, new Edge());
            Edges.Add(Position.Right, new Edge());
            Edges.Add(Position.Bottom, new Edge());
            Edges.Add(Position.Left, new Edge());

            for (var i = 0; i < Content.GetLength(0); i++)
            {
                for (var j = 0; j < Content.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Edges[Position.Top].Content[j] = Content[i, j];
                    }

                    if (i == Content.GetLength(0) - 1)
                    {
                        Edges[Position.Bottom].Content[j] = Content[i, j];
                    }

                    if (j == 0)
                    {
                        Edges[Position.Left].Content[i] = Content[i, j];
                    }

                    if (j == Content.GetLength(1) - 1)
                    {
                        Edges[Position.Right].Content[i] = Content[i, j];
                    }
                }
            }
        }

        public long Number { get; set; }
        public char[,] Content { get; set; }
        public Dictionary<Position, Edge> Edges { get; set; }
        public Dictionary<Position, Tile> ConnectedTiles { get; set; }

        public void Print()
        {
            System.Console.WriteLine($"Tile {Number}:");
            for (var i = 0; i < Content.GetLength(0); i++)
            {
                var row = string.Empty;
                for (var j = 0; j < Content.GetLength(1); j++)
                {
                    // System.Console.WriteLine(i + " " + j);
                    row += Content[i, j];
                }
                System.Console.WriteLine(row);
            }
            System.Console.WriteLine();
        }

        public void PrintEdges()
        {
            System.Console.WriteLine("====== Edges ======");
            System.Console.WriteLine($"Top:    {new string(Edges[Position.Top].Content)}");
            System.Console.WriteLine($"Right:  {new string(Edges[Position.Right].Content)}");
            System.Console.WriteLine($"Bottom: {new string(Edges[Position.Bottom].Content)}");
            System.Console.WriteLine($"Left:   {new string(Edges[Position.Left].Content)}");
            System.Console.WriteLine();
        }

        // https://www.geeksforgeeks.org/inplace-rotate-square-matrix-by-90-degrees/
        public Tile Rotate(int degrees)
        {
            var newContent = Content.Clone() as char[,];
            int times = degrees / 90;
            var N = newContent.GetLength(0);

            for (var i = 0; i < times; i++)
            {
                // Consider all 
                // squares one by one 
                for (int x = 0; x < N / 2; x++)
                {
                    // Consider elements 
                    // in group of 4 in 
                    // current square 
                    for (int y = x; y < N - x - 1; y++)
                    {
                        // store current cell 
                        // in temp variable 
                        char temp = newContent[x, y];

                        // move values from 
                        // right to top 
                        newContent[x, y] = newContent[y, N - 1 - x];

                        // move values from 
                        // bottom to right 
                        newContent[y, N - 1 - x] = newContent[N - 1 - x,
                                                N - 1 - y];

                        // move values from 
                        // left to bottom 
                        newContent[N - 1 - x,
                            N - 1 - y]
                            = newContent[N - 1 - y, x];

                        // assign temp to left 
                        newContent[N - 1 - y, x] = temp;
                    }
                }
            }

            return new Tile(Number, newContent);
        }

        // https://stackoverflow.com/questions/44496196/2d-array-flip-vertically-and-horizontally
        public Tile FlipX()
        {
            var newContent = Content.Clone() as char[,];

            for (int y = 0; y < newContent.GetLength(0); y++)
            {
                for (int x = 0; x < newContent.GetLength(1) / 2; x++)
                {
                    var temp = newContent[y, (newContent.GetLength(1) - 1) - x];
                    newContent[y, (newContent.GetLength(1) - 1) - x] = newContent[y, x];
                    newContent[y, x] = temp;
                }
            }

            return new Tile(Number, newContent);
        }

        public Tile FlipY()
        {
            var newContent = Content.Clone() as char[,];

            for (var y = 0; y < newContent.GetLength(0) / 2; y++)
            {
                for (var x = 0; x < newContent.GetLength(1); x++)
                {
                    var temp = newContent[(newContent.GetLength(0) - 1) - y, x];
                    newContent[(newContent.GetLength(0) - 1) - y, x] = newContent[y, x];
                    newContent[y, x] = temp;
                }
            }

            return new Tile(Number, newContent);
        }

        public bool ConnectsOnEdge(Position position, Tile tile)
        {
            char[] sourceEdge;
            char[] targetEdge = null;

            sourceEdge = Edges[position].Content;

            switch (position)
            {
                case Position.Top:
                    targetEdge = tile.Edges[Position.Bottom].Content;
                    break;
                case Position.Right:
                    targetEdge = tile.Edges[Position.Left].Content;
                    break;
                case Position.Bottom:
                    targetEdge = tile.Edges[Position.Top].Content;
                    break;
                case Position.Left:
                    targetEdge = tile.Edges[Position.Right].Content;
                    break;
            }

            return sourceEdge.SequenceEqual(targetEdge);
        }
    }

    public class Edge
    {
        public Edge()
        {
            Content = new char[10];
        }
        public char[] Content { get; set; }
    }

    public enum Position
    {
        Top,
        Right,
        Bottom,
        Left
    }
}
