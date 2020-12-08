using Day_07_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day07Solver_Tests
    {
        [Theory]
        [InlineData("Day07_Input/test.input", 4)]
        [InlineData("Day07_Input/puzzle.input", 224)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day07Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day07_Input/test.input", 32)]
        [InlineData("Day07_Input/test1.input", 126)]
        [InlineData("Day07_Input/puzzle.input", 1488)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day07Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
