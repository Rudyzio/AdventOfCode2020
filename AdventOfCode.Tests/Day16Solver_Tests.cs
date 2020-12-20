using Day_16_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day16Solver_Tests
    {
        [Theory]
        [InlineData("Day16_Input/test.input", 71)]
        [InlineData("Day16_Input/puzzle.input", 20058)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day16Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day16_Input/test2.input", 132)]
        [InlineData("Day16_Input/puzzle.input", 366871907221)]
        public void TestPart2Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day16Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
