using Day_09_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day09Solver_Tests
    {
        [Theory]
        [InlineData("Day09_Input/test.input", 127, 5)]
        [InlineData("Day09_Input/puzzle.input", 556543474, 25)]	
        public void TestPart1Solution(string inputFile, int expected, int preamble)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day09Solver.Part1Solution(lines, preamble);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day09_Input/test.input", 62, 5)]
        [InlineData("Day09_Input/puzzle.input", 76096372, 25)]
        public void TestPart2Solution(string inputFile, int expected, int preamble)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day09Solver.Part2Solution(lines, preamble);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
