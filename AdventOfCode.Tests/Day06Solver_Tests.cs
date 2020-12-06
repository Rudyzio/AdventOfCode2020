using Day_06_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day06Solver_Tests
    {
        [Theory]
        [InlineData("Day06_Input/test.input", 11)]
        [InlineData("Day06_Input/puzzle.input", 6583)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day06Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day06_Input/test.input", 6)]
        [InlineData("Day06_Input/puzzle.input", 3290)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day06Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
