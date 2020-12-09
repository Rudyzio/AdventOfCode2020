using Day_08_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day08Solver_Tests
    {
        [Theory]
        [InlineData("Day08_Input/test.input", 5)]
        [InlineData("Day08_Input/puzzle.input", 1394)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day08Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day08_Input/test.input", 8)]
        [InlineData("Day08_Input/puzzle.input", 1626)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day08Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
