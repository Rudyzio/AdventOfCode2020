using Day_12_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day12Solver_Tests
    {
        [Theory]
        [InlineData("Day12_Input/test.input", 25)]
        [InlineData("Day12_Input/puzzle.input", 882)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day12Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day12_Input/test.input", 286)]
        [InlineData("Day12_Input/puzzle.input", 28885)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day12Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
