using Day_24_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day24Solver_Tests
    {
        [Theory]
        [InlineData("Day24_Input/test.input", 10)]
        [InlineData("Day24_Input/puzzle.input", 322)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day24Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day24_Input/test.input", 2208)]
        [InlineData("Day24_Input/puzzle.input", 3831)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day24Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
